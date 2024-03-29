﻿using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessContactEmailAddressPage : IBusinessContactEmailAddressPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement EmailAddresslink => _driver.WaitForElementClickable(By.XPath("//a[contains(text(),'Email address')]"));
        private IWebElement EmailAddress => _driver.WaitForElement(By.Id("Email"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));
        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public BusinessContactEmailAddressPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void ClickOnSaveAndContinue()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndContinue);
            //SaveAndContinue.Click();
        }

        public void ClickOnContactEmailAddressLink()
        {
            _driver.ElementImplicitWait();
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", EmailAddresslink);
        }

        public void EnterEmailAddress(string emailAddress)
        {
            EmailAddress.Clear();
            EmailAddress.SendKeys(emailAddress);
            //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            //jsExecutor.ExecuteScript("arguments[0].setAttribute('value', '" + emailAddress + "')", EmailAddress);
        }

        public bool VerifyErrorMessageOnContactEmailAddressPage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }
        #endregion

    }
}
