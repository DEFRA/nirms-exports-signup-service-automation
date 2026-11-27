using Defra.GC.UI.Tests.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Capabilities
{
    public class BrowserStackCapability : IDriverOptions
    {


        private readonly BaseConfiguration _configuration;
        private readonly Dictionary<string, object> _browserstackOptions = new();

        private readonly string _target;
        private readonly string _deviceName;
        private readonly string _bs_os_version;

        public BrowserStackCapability(BaseConfiguration baseConfiguration, ScenarioContext context)
        {
            _configuration = baseConfiguration;
            _target = _configuration.UiFrameworkConfiguration.Target;
            _deviceName = _configuration.TestConfiguration.DeviceName;
            _bs_os_version = _configuration.TestConfiguration.BSOSVersion;
        }


        public DriverOptions GetDriverOptions(Dictionary<string, string> capDictionary = null)
        {
            _browserstackOptions.Clear();

            GetBrowserStackConfig();
            GetProjectDriverOptions();
            GetTestNameDriverOptions();

            _browserstackOptions.Add("os", _deviceName);
            _browserstackOptions.Add("osVersion", _bs_os_version);

            DriverOptions driverOptions;
            if (_target.Contains("Chrome"))
                driverOptions = new ChromeOptions();
            else if (_target.Contains("Edge"))
                driverOptions = new EdgeOptions();
            else if (_target.Contains("Safari"))
                driverOptions = new SafariOptions();
            else if (_target.Contains("Firefox"))
                driverOptions = new FirefoxOptions();
            else
                throw new ArgumentException($"Unsupported BrowserStack browser target: {_target}");

            driverOptions.BrowserVersion = "latest";
            driverOptions.AcceptInsecureCertificates = true;
            driverOptions.AddAdditionalOption("bstack:options", _browserstackOptions);

            return driverOptions;

        }



        private void GetBrowserStackConfig()
        {
            if (!_browserstackOptions.ContainsKey("debug"))
            {
                _browserstackOptions.Add("debug", true);
                _browserstackOptions.Add("userName", _configuration.BrowserStackConfiguration.CloudDeviceUserName);
                _browserstackOptions.Add("accessKey", _configuration.BrowserStackConfiguration.CloudDeviceUserKey);
                _browserstackOptions.Add("idleTimeout", 300);
            }
        }

        private void GetProjectDriverOptions()
        {
            if (!_browserstackOptions.ContainsKey("projectName"))
            {
                _browserstackOptions.Add("projectName", _configuration.TestConfiguration.Project);
                _browserstackOptions.Add("buildName", _configuration.TestConfiguration.Build);
            }
        }

        protected virtual void GetTestNameDriverOptions()
        {
            if (!_browserstackOptions.ContainsKey("sessionName"))
                _browserstackOptions.Add("sessionName", TestContext.CurrentContext.Test.ClassName);
        }

    }
}
