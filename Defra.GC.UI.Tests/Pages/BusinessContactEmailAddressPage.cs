using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessContactEmailAddressPage : IBusinessContactEmailAddressPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects

        private IWebElement EmailAddresslink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Email address')]"));
        private IWebElement EmailAddress => _driver.WaitForElement(By.Id("email"));
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
            SaveAndContinue.Click();
        }

        public void ClickOnContactEmailAddressLink()
        {
            EmailAddresslink.Click();
        }

        public void EnterEmailAddress(string emailAddress)
        {
            EmailAddress.SendKeys(emailAddress);
        }

        public void NavigateToContactEmailAddressPage()
        {
            string url = UrlBuilder.Default().Add("registered-business-contact-name").Build();
            _driver.Navigate().GoToUrl(url);
        }

        public bool VerifyErrorMessageOnContactEmailAddressPage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }
        #endregion

    }
}
