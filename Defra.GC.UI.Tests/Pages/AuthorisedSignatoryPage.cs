using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class AuthorisedSignatoryPage : IAuthorisedSignatoryPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public AuthorisedSignatoryPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Objects

        public IWebElement AuthorisedSignatoryLink => _driver.WaitForElement(By.XPath("//a[normalize-space()='Authorised Signatory']"));
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

        #endregion Page Methods

    }
}