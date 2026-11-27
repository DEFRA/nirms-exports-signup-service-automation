using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Tests
{
    [TestFixture]
    [NonParallelizable]
    public class ManageAccountPageTests
    {
        private ChromeDriver _driver = null!;
        private ObjectContainer _container = null!;
        private ManageAccountPage _page = null!;

        [OneTimeSetUp]
        public void LoadConfiguration()
        {
            if (ConfigSetup.BaseConfiguration == null)
                ConfigSetup.SetupProjectConfig();
        }

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--disable-popup-blocking");
            _driver = new ChromeDriver(options);
            _container = new ObjectContainer();
            _container.RegisterInstanceAs<IWebDriver>(_driver);
            _page = new ManageAccountPage(_container);
            _driver.Navigate().GoToUrl("about:blank");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _container.Dispose();
        }

        [TestCase(false)]
        [TestCase(true)]
        public void AddAccountWaitsForDelayedNavigation(bool newTab)
        {
            _driver.ExecuteScript(@"
                var openInNewTab = arguments[0];
                document.body.innerHTML = '<h1>Your Defra account</h1><a id=""link-add-account"" href=""#"">Add account</a>';
                document.getElementById('link-add-account').onclick = function(event) {
                    event.preventDefault();
                    setTimeout(function() {
                        var destination = openInNewTab ? window.open('about:blank') : window;
                        destination.document.body.innerHTML = '<h1 class=""govuk-heading-xl extra-class"">Are you registering a business or organisation?</h1>';
                    }, 1000);
                };", newTab);

            Assert.That(_page.VerifyAddNewAccountLink(), Is.True);
            Assert.That(_driver.WindowHandles.Count, Is.EqualTo(newTab ? 2 : 1));
        }

        [Test]
        public void ManageAccountSelectsNewTabInsteadOfAnExistingUnrelatedTab()
        {
            _driver.ExecuteScript("window.open('about:blank');");
            _driver.ExecuteScript(@"
                document.body.innerHTML = '<a id=""Link-ManageAccount"" href=""#"">Manage account</a>';
                document.getElementById('Link-ManageAccount').onclick = function(event) {
                    event.preventDefault();
                    setTimeout(function() {
                        var destination = window.open('about:blank');
                        destination.document.body.innerHTML = '<h1>Your Defra account</h1>';
                    }, 1000);
                };");

            var handlesBeforeClick = _driver.WindowHandles.ToHashSet();
            Assert.That(_page.VerifyManageAccountLink(), Is.True);
            Assert.That(handlesBeforeClick, Does.Not.Contain(_driver.CurrentWindowHandle));
        }

        [Test]
        public void WrongDestinationReportsActualHeading()
        {
            _driver.ExecuteScript(@"
                document.body.innerHTML = '<h1>Unexpected destination</h1><a id=""link-add-account"" href=""#"">Add account</a>';");

            var exception = Assert.Throws<WebDriverTimeoutException>(() => _page.VerifyAddNewAccountLink());

            Assert.That(exception!.Message, Does.Contain("Unexpected destination"));
            Assert.That(exception.Message, Does.Contain("Are you registering a business or organisation?"));
            Assert.That(exception.Message, Does.Contain("about:blank"));
        }
    }
}
