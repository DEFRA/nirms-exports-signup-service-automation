using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Defra.UI.Framework.Driver;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessContactNamePage : IBusinessContactNamePage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IBusinessContactEmailAddressPage? ContactEmailAddressPage => _objectContainer.IsRegistered<IBusinessContactEmailAddressPage>() ? _objectContainer.Resolve<IBusinessContactEmailAddressPage>() : null;
        private IBusinessContactPositionPage? ContactPositionPage => _objectContainer.IsRegistered<IBusinessContactPositionPage>() ? _objectContainer.Resolve<IBusinessContactPositionPage>() : null;
        private IBusinessContactTelephoneNumberPage? ContactTelephoneNumberPage => _objectContainer.IsRegistered<IBusinessContactTelephoneNumberPage>() ? _objectContainer.Resolve<IBusinessContactTelephoneNumberPage>() : null;

        #region Page Objects

        private IWebElement BusinessFullName => _driver.WaitForElement(By.XPath("//input[@id='business-name']"));
        private IWebElement Fullnamelink => _driver.WaitForElementClickable(By.XPath("//a[contains(text(),'Full name')]"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.Id("button-rbCountrySubmit"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));
        private IWebElement BusinessContactDetailStatus => _driver.WaitForElement(By.XPath("//strong[@id='replace']"));

        #endregion

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
            ContactTelephoneNumberPage.ClickOnSaveAndContinue();
        }

        public bool VerifyTheBusinessContactDetailsStatus(string status)
        {
            return BusinessContactDetailStatus.Text.Contains(status);
        }

        public void EnterBusinessContactName(string ContactName)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].setAttribute('value', '" + ContactName + "')", BusinessFullName);
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
            jsExecutor.ExecuteScript("arguments[0].click();", Fullnamelink);
        }
        #endregion

    }
}
