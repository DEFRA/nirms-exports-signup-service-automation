using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.UI.Framework.Driver;
using OpenQA.Selenium;


namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    public class SelfServeDashboardPage : ISelfServeDashboardPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading'] | //h1[contains(text(),'You have successfully submitted a request to sign ')]"));
        private IWebElement BusinessRMSNumberEle => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Business RMS number')]/following-sibling::dd"));


        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public SelfServeDashboardPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void SelectBusinessOnSelfServe(string businessSelection)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,6000)", "");
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//span[contains(text(),'" + businessSelection + "')]/..")).Click();
        }

        public bool VerifyBusinessRMSNumber(string businessRMSNumber) 
        {
            return BusinessRMSNumberEle.Text.Contains(businessRMSNumber);
        }

        #endregion Page Methods


    }

}
