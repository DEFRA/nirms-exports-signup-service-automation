using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessContactTelephoneNumberPage : IBusinessContactTelephoneNumberPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement TelephoneNumberlink => _driver.WaitForElementClickable(By.XPath("//a[contains(text(),'Telephone number')]"));
        //private IWebElement Telephone => _driver.WaitForElement(By.Id("business-phone"));
        private IWebElement Telephone => _driver.WaitForElement(By.XPath("//input[contains(@id,'PhoneNumber')]"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.Id("Phone_Error"));
        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public BusinessContactTelephoneNumberPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void ClickOnSaveAndContinue()
        {
            SaveAndContinue.Click();
        }


        public void ClickOnContactTelephoneNumberLink()
        {
            _driver.ElementImplicitWait();
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", TelephoneNumberlink);
        }

        public void EnterTelephoneNumber(string telephoneNumber)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].setAttribute('value', '" + telephoneNumber + "')", Telephone);
        }

        public bool VerifyErrorMessageOnContactTelephoneNumberPage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        #endregion

    }
}
