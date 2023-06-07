using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessContactTelephoneNumberPage : IBusinessContactTelephoneNumberPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects

        private IWebElement TelephoneNumberlink => _driver.WaitForElementClickable(By.XPath("//a[contains(text(),'Telephone number')]"));
        private IWebElement Telephone => _driver.WaitForElement(By.Id("phone"));
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
            Telephone.SendKeys(telephoneNumber);
        }

        public void NavigateToContactTelephoneNumberPage()
        {
            string url = UrlBuilder.Default().Add("registered-business-contact-phone").Build();
            _driver.Navigate().GoToUrl(url);
        }

        public bool VerifyErrorMessageOnContactTelephoneNumberPage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        #endregion

    }
}
