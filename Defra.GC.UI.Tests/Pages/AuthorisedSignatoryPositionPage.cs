using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class AuthorisedSignatoryPositionPage : IAuthorisedSignatoryPositionPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(@class,'govuk-button')]"));
        private IWebElement AuthPosition => _driver.WaitForElement(By.XPath("//input[contains(@id,'Position')]"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));

        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public AuthorisedSignatoryPositionPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void EnterAuthSignatoryPosition(string AuthSignPosition)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].setAttribute('value', '" + AuthSignPosition + "')", AuthPosition);
        }

        public void ClickOnSaveAndContinue()
        {
            SaveAndContinue.Click();
        }

        public bool VerifyErrorMessageOnAuthSignatoryPositionPage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        #endregion
    }
}
