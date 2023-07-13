using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessContactNamePage : IBusinessContactNamePage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IBusinessContactEmailAddressPage? ContactEmailAddressPage => _objectContainer.IsRegistered<IBusinessContactEmailAddressPage>() ? _objectContainer.Resolve<IBusinessContactEmailAddressPage>() : null;
        private IBusinessContactPositionPage? ContactPositionPage => _objectContainer.IsRegistered<IBusinessContactPositionPage>() ? _objectContainer.Resolve<IBusinessContactPositionPage>() : null;
        private IBusinessContactTelephoneNumberPage? ContactTelephoneNumberPage => _objectContainer.IsRegistered<IBusinessContactTelephoneNumberPage>() ? _objectContainer.Resolve<IBusinessContactTelephoneNumberPage>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        #region Page Objects

        private IWebElement BusinessFullName => _driver.WaitForElement(By.XPath("//input[@id='Name']"));
        private IWebElement ContactPersonLink => _driver.WaitForElementClickable(By.XPath("//a[contains(text(),'Contact person')]"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));
        private IWebElement BusinessContactDetailStatus => _driver.WaitForElement(By.XPath("//strong[@id='contact-details']"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public BusinessContactNamePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void CompleteBusinessContactDetailsTask(string contactName, string contactPosition, string contactEmail, string contactTelephone)
        {
            ClickOnBusinessContactDetailsLink();
            EnterBusinessContactName(contactName);
            ClickOnSaveAndContinue();
            ContactPositionPage.EnterBusinessContactPosition(contactPosition);
            ContactPositionPage.ClickOnSaveAndContinue();
            ContactEmailAddressPage.EnterEmailAddress(contactEmail);
            ContactEmailAddressPage.ClickOnSaveAndContinue();
            ContactTelephoneNumberPage.EnterTelephoneNumber(contactTelephone);
            applicationPage.ClickSaveAndReturnToDashboard();
        }

        public bool VerifyTheBusinessContactDetailsStatus(string status)
        {
            return BusinessContactDetailStatus.Text.Contains(status);
        }

        public void EnterBusinessContactName(string ContactName)
        {
            BusinessFullName.Clear();
            BusinessFullName.SendKeys(ContactName);
        }

        public bool VerifyErrorMessageOnBusinessContactNamePage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        public void ClickOnSaveAndContinue()
        {
            SaveAndContinue.Click();
        }

        public void ClickOnBusinessContactDetailsLink()
        {
            _driver.ElementImplicitWait();
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", ContactPersonLink);
        }

        public void EditBusinessContactName(string contactName)
        {
            EnterBusinessContactName(contactName);
            applicationPage.ClickSaveAndReturnToDashboard();
            //ClickOnSaveAndContinue();
            //ContactPositionPage.ClickOnSaveAndContinue();
            //ContactEmailAddressPage.ClickOnSaveAndContinue();
            //ContactTelephoneNumberPage.ClickOnSaveAndContinue();
        }

        public void EditBusinessContactPosition(string contactPosition)
        {
            ContactPositionPage.EnterBusinessContactPosition(contactPosition);
            ContactPositionPage.ClickOnSaveAndContinue();
            applicationPage.ClickSaveAndReturnToDashboard();
            //ContactEmailAddressPage.ClickOnSaveAndContinue();
            //ContactTelephoneNumberPage.ClickOnSaveAndContinue();
        }

        public void EditBusinessContactEmailAddress(string contactEmail)
        {
            ContactEmailAddressPage.EnterEmailAddress(contactEmail);
            applicationPage.ClickSaveAndReturnToDashboard();
            //ContactEmailAddressPage.ClickOnSaveAndContinue();
            //ContactTelephoneNumberPage.ClickOnSaveAndContinue();
        }

        public void EditBusinessContactTelephoneNumber(string contactTelephone)
        {
            ContactTelephoneNumberPage.EnterTelephoneNumber(contactTelephone);
            applicationPage.ClickSaveAndReturnToDashboard();
            //ContactTelephoneNumberPage.ClickOnSaveAndContinue();
        }

        #endregion Page Methods
    }
}