using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using System.Net.Mail;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class AuthorisedSignatoryPage : IAuthorisedSignatoryPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IAuthorisedSignatoryEmailAddressPage? authSignatoryEmailAddressPage => _objectContainer.IsRegistered<IAuthorisedSignatoryEmailAddressPage>() ? _objectContainer.Resolve<IAuthorisedSignatoryEmailAddressPage>() : null;
        private IAuthorisedSignatoryNamePage? authSignatoryNamePage => _objectContainer.IsRegistered<IAuthorisedSignatoryNamePage>() ? _objectContainer.Resolve<IAuthorisedSignatoryNamePage>() : null;
        private IAuthorisedSignatoryPositionPage? authSignatoryPositionPage => _objectContainer.IsRegistered<IAuthorisedSignatoryPositionPage>() ? _objectContainer.Resolve<IAuthorisedSignatoryPositionPage>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        public AuthorisedSignatoryPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Objects

        public IWebElement AuthorisedSignatoryLink => _driver.WaitForElement(By.XPath("//a[normalize-space()='Authorised signatory']"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-fieldset__heading')]"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(@id,'button-rbNatureSubmit')]"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));

        #endregion Page Objects

        #region Page Methods

        public bool ClickOnAuthorisedSignatoryLink()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", AuthorisedSignatoryLink);
            return PageHeading.Text.Contains("Authorised Signatory");
        }

        public void SelectAuthorisedSignatory(string authorisation)
        {
            _driver.ClickRadioButton(authorisation);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }

        public void CompleteContactPersonAuthorisedSignatoryWithYes()
        {
            ClickOnAuthorisedSignatoryLink();
            SelectAuthorisedSignatory("Yes");
        }

        public bool VerifyErrorMessageOnAuthorisedPage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        public void EditAuthorisedSignatoryToNo(string authorisation)
        {
            _driver.ClickRadioButton(authorisation);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndContinue);

            authSignatoryNamePage.EnterFullName("AuthSign Full Name");
            applicationPage.ClickOnSaveAndContinue();
            authSignatoryPositionPage.EnterAuthSignatoryPosition("AuthSignPosition");
            applicationPage.ClickOnSaveAndContinue();
            authSignatoryEmailAddressPage.EnterAuthEmailAddress("AuthSignEmail@test.com");
            applicationPage.ClickOnSaveAndContinue();
        }

        #endregion Page Methods
    }
}