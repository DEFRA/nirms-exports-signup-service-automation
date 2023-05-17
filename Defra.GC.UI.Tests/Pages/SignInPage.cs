using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.GC.UI.Tests.HelperMethods;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace Defra.GC.UI.Tests.Pages
{
    public class SignInPage : ISignInPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        #region Page Objects
        private By UserIdBy => By.Id("");
        private By ContinueSelectorBy => By.XPath("//button[contains(text(),'Continue')]");
        private By SignInConfirmBy => By.CssSelector("");
        private By SignOutConfirmMessageBy => By.CssSelector("");
        private By MenuButtonBy => By.CssSelector("");
        private IWebElement UserId => _driver.FindElement(UserIdBy);
        private IWebElement Password => _driver.FindElement(By.Id("password"));
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
            Password.SendKeys(password);
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(ContinueSelectorBy)).Click();

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

