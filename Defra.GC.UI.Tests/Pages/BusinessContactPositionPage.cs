using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessContactPositionPage : IBusinessContactPositionPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement Positionlink => _driver.WaitForElementClickable(By.XPath("//a[contains(text(),'Position')]"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.Id("button-rbPositionSubmit"));
        private IWebElement BusinessContactPosition => _driver.WaitForElement(By.Id("contact-position"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));

        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public BusinessContactPositionPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void EnterBusinessContactPosition(string ContactPosition)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].setAttribute('value', '" + ContactPosition + "')", BusinessContactPosition);
        }

        public void ClickOnSaveAndContinue()
        {
            SaveAndContinue.Click();
        }

        public bool VerifyErrorMessageOnBusinessContactPositionPage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        public void ClickOnBusinessContactPositionLink()
        {
            _driver.ElementImplicitWait();
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", Positionlink);
        }
        #endregion

    }
}
