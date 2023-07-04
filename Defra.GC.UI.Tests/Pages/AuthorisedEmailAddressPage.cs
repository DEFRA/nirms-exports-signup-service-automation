using BoDi;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using System.Net.Mail;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class AuthorisedSignatoryEmailAddressPage : IAuthorisedSignatoryEmailAddressPage
    {
        public IObjectContainer _objectContainer;

        public AuthorisedSignatoryEmailAddressPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #region Page Objects

        private IWebElement EmailAddress => _driver.WaitForElement(By.XPath("//input[@id='Email']"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));
        private IWebElement BackLink => _driver.WaitForElement(By.XPath("//a[normalize-space()='Back']"));

        #endregion Page Objects

        #region Page Methods

        public void ClickOnAuthEmailAddres()
        {
            EmailAddress.Click();
        }

        public void EnterAuthEmailAddress(string emailAddress)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].setAttribute('value', '" + emailAddress + "')", EmailAddress);

        }

        public void ClickOnSaveAndContinue()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            _driver.ElementImplicitWait();
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }

        public bool ValidateInvalidErrorMessage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        public void ClickonBusinessBacklink()
        {
            BackLink.Click();
        }

        #endregion Page Methods
    }
}