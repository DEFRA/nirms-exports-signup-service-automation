using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class SignInPage : ISignInPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        #region Page Objects
        private IWebElement StartNew => _driver.WaitForElement(By.Id("button-rbIndexSave"));

        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public SignInPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public bool IsPageLoaded()
        {
            return true;
        }

        public bool IsSignedIn(string userName, string password)
        {
            StartNew.Click();
            return true;
        }

        public void ClickSignedOut()
        {

        }

        public bool IsSignedOut()
        {
            return true;
        }
    }
}

