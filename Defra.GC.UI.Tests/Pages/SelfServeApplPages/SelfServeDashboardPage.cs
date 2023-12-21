using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
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
        private IWebElement ChangeContactPerson => _driver.WaitForElement(By.XPath("//span[contains(text(),'contact person')]/.."));
        private IWebElement ChangeAuthRepresentative => _driver.WaitForElement(By.XPath("//span[contains(text(),'authorised representative')]/.."));
        private IWebElement CalcelEle => _driver.WaitForElement(By.XPath("//a[contains(text(),'Cancel')]"));
        private IWebElement ContactPersonDate => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Contact person')]/..//div"));
        private IWebElement AuthRepresentativeDate => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Authorised representative')]/..//div"));


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

        public void ClickOnAuthorisedRepresentativeChangeLink()
        {
            ChangeAuthRepresentative.Click();
        }

        public void ClickOnCancelLink()
        {
            CalcelEle.Click();
        }

        public void ClickOnContactPersonChangeLink()
        {
            ChangeContactPerson.Click();
        }

        public bool VerifyContactPersonDateFormatOnSelfServeDashboard(string text)
        {
            DateTime now = DateTime.Now;
            string todaysDate = now.ToString("dd MMMM yyyy");
            text = text + todaysDate;
            return ContactPersonDate.Text.Contains(text);
        }

        public bool VerifyAuthRepresentativeDateFormatOnSelfServeDashboard(string text)
        {
            DateTime now = DateTime.Now;
            string todaysDate = now.ToString("dd MMMM yyyy");
            text = text + todaysDate;
            return AuthRepresentativeDate.Text.Contains(text);

        }

        #endregion Page Methods

    }

}
