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
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects
        
        private IWebElement BusinessFullName => _driver.WaitForElement(By.XPath("//input[@id='business-name']"));
        private IWebElement Fullnamelink => _driver.WaitForElementClickable(By.XPath("//a[contains(text(),'Full name')]"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.Id("button-rbCountrySubmit"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));


        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public BusinessContactNamePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void NavigateToBusinessContactNamePage()
        {
            string url = UrlBuilder.Default().Add("registered-business-contact-name").Build();
            _driver.Navigate().GoToUrl(url);
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

        public void ClickOnBusinessContactNameLink()
        {
            _driver.ElementImplicitWait();
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", Fullnamelink);
        }
        #endregion

    }
}
