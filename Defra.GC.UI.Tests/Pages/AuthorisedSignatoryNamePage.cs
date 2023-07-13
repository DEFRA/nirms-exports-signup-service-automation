using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class AuthorisedSignatoryNamePage : IAuthorisedSignatoryNamePage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public AuthorisedSignatoryNamePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Objects
        public IWebElement AuthorisedSignatoryLink => _driver.WaitForElement(By.XPath("//a[normalize-space()='Authorised Signatory']"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(@class,'govuk-button')]"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));
        public IWebElement Fullname => _driver.WaitForElement(By.XPath("//input[@id='Name']"));
        private IWebElement BackLink => _driver.WaitForElement(By.XPath("//a[normalize-space()='Back']"));
        #endregion Page Objects


        #region Page Methods
        public void ClickonFullName()
        {
            Fullname.Click();
        }

        public void EnterFullName(string FullName)
        {
            Fullname.Clear();
            Fullname.SendKeys(FullName);
        }

        public void ClickOnSaveAndContinue()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            _driver.ElementImplicitWait();
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }

        public bool VerifyErrorMessageOnAuthorisedSignatoryNamePage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        public void ClickOnAuthorisedSignatoryBacklink()
        {
            BackLink.Click();
        }

        public void EditAuthorisedSignatoryName(string FullName)
        {
            EnterFullName(FullName);
            ClickOnSaveAndContinue();
            ClickOnSaveAndContinue();
            ClickOnSaveAndContinue();
        }
        #endregion Page Methods
    }
}
