﻿using BoDi;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;

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
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

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
            EmailAddress.Clear();
            EmailAddress.SendKeys(emailAddress);
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

        public void EditAuthorisedSignatoryEmailAddress(string EmailAddress)
        {
            EnterAuthEmailAddress(EmailAddress);
            applicationPage.ClickSaveAndReturnToDashboard();
        }
        #endregion Page Methods
    }
}