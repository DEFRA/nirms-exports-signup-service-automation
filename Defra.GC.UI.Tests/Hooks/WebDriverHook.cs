using BoDi;
using Defra.UI.Framework.Object;
//using Defra.GC.UI.Test.Data.Application;
using Defra.Trade.ReMos.AssuranceService.Tests.Capabilities;
using Defra.GC.UI.Tests.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Reflection;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace Defra.GC.UI.Tests.Hooks
{
    [Binding]
    public class WebDriverHook
    {
        public IWebDriver? Driver { get; set; }
        private static string SeleniumGrid => ConfigSetup.BaseConfiguration.UiFrameworkConfiguration.SeleniumGrid;

        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public WebDriverHook(ScenarioContext context, ObjectContainer container,
            ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _scenarioContext = context;
            _objectContainer = container;
            _specFlowOutputHelper = specFlowOutputHelper;
        }


        [BeforeScenario(Order = (int)HookRunOrder.WebDriver)]
        public void BeforeTestScenario()
        {

            Logger.Debug("Starting set Capability");

            Driver = CreateDriver(GetDriverOptions(), SeleniumGrid);

            _objectContainer.RegisterInstanceAs(Driver);
        }

        internal static IWebDriver CreateDriver(DriverOptions driverOptions, string seleniumGrid)
        {
            if (string.IsNullOrEmpty(seleniumGrid))
            {
                var site = new Site();
                site.With(driverOptions);
                return site.WebDriver.Driver;
            }

            // The framework discards the remote session error; retain Selenium's diagnostics.
            return new RemoteWebDriver(new Uri(seleniumGrid), driverOptions.ToCapabilities(),
                TimeSpan.FromSeconds(90));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var error = _scenarioContext.TestError;
            if (error != null)
            {
                Logger.LogMessage("An error ocurred:" + error.Message);
                Logger.Debug("It was of type:" + error.GetType().Name);
            }

            try
            {
                if (Driver == null)
                {
                    Logger.Debug("Skipping browser cleanup: WebDriver was not initialized.");
                }
                else if (error != null)
                {
                    AttachScreenShotToXmlReport();
                }
            }
            finally
            {
                try
                {
                    Driver?.Quit();
                }
                finally
                {
                    Driver = null;
                    if (ConfigSetup.BaseConfiguration == null)
                    {
                        Logger.Debug("Skipping backend cleanup: configuration was not initialized.");
                    }
                    else if (!ConfigSetup.BaseConfiguration.TestConfiguration.Environment.Contains("pre"))
                    {
                        DeleteApplicationViaBackend();
                    }
                }
            }
        }

        private void AttachScreenShotToXmlReport()
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            filePath = Path.Combine(filePath, "TestResults");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
                Logger.Debug($"{filePath} directory created....");
            }

            var fileTitle = _scenarioContext.ScenarioInfo.Title;
            var fileName = Path.Combine(filePath, $"{fileTitle}_TestFailures_{DateTime.Now:yyyyMMdd_hhss}" + ".png");

            if (Driver is not ITakesScreenshot screenshotDriver)
                throw new InvalidOperationException("The initialized WebDriver does not support screenshots.");

            screenshotDriver.GetScreenshot().SaveAsFile(fileName);

            _specFlowOutputHelper.AddAttachment(fileName);
            Logger.Debug($"SCREENSHOT {fileName} ");
        }

        private DriverOptions GetDriverOptions()
        {
            return _objectContainer.Resolve<IDriverOptions>().GetDriverOptions();
        }

        private void DeleteApplicationViaBackend()
        {
            if (_scenarioContext.Count > 0 &&
                _scenarioContext.ContainsKey("AppDispId"))
            {
                /*var applicationres = (ApplicationResponse)_scenarioContext["AppDispId"];
                if (applicationres != null &&
                    !string.IsNullOrEmpty(applicationres.ApplicationId))
                {
                    _objectContainer.Resolve<ApplicationData>().DeleteApplication(applicationres.ApplicationId);
                }*/

            }


        }

    }

}
