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
        private IWebElement BusinessName => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-summary-list__row')]//dt"));
        private IWebElement Status => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-tag govuk-tag')]"));
        private IWebElement RefreshLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Refresh list')]"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public SelfServeDashboardPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void SelectBusinessOnSelfServe(string businessSelection)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            Thread.Sleep(1000);

            string ManageLink = "//span[contains(text(),'" + businessSelection + "')]/..";
            IWebElement ManageLinkEle = _driver.WaitForElement(By.XPath(ManageLink));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", ManageLinkEle);
        }

        public bool VerifyBusinessRMSNumber(string businessRMSNumber) 
        {
            return BusinessRMSNumberEle.Text.Contains(businessRMSNumber);
        }

        public void ClickOnAuthorisedRepresentativeChangeLink()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", ChangeAuthRepresentative);
        }

        public void ClickOnCancelLink()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", CalcelEle);
        }

        public void ClickOnContactPersonChangeLink()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", ChangeContactPerson);
        }

        public bool VerifyContactPersonDateFormatOnSelfServeDashboard(string text)
        {
            DateTime now = DateTime.Now;
            string todaysDate = now.ToString("dd MMM yyy");
            text = text + " " + todaysDate;
            return ContactPersonDate.Text.Contains(text);
        }

        public bool VerifyAuthRepresentativeDateFormatOnSelfServeDashboard(string text)
        {
            DateTime now = DateTime.Now;
            string todaysDate = now.ToString("dd MMM yyy");
            text = text + " " + todaysDate;
            return AuthRepresentativeDate.Text.Contains(text);

        }
        public bool VerifyStatusOnSelfServe(string status, string businessSelection, string selfServeLink)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,400)", "");
            Thread.Sleep(1000);
            string SelfServeStatus = "//dt[contains(text(),'" + businessSelection + "')]/..//div";
            IWebElement SelfServeStatusEle = _driver.WaitForElement(By.XPath(SelfServeStatus));
            string SelfServeLink = "//span[contains(text(),'" + businessSelection + "')]/..";
            IWebElement LinkEle = _driver.WaitForElement(By.XPath(SelfServeLink));
            _driver.ElementImplicitWait();
            return SelfServeStatusEle.Text.Contains(status) && LinkEle.Text.Contains(selfServeLink);
        }


        public void NavigateToSelfServeDashboardURL()
        {
            _driver.Navigate().GoToUrl("https://tst-sign-up.trade.azure.defra.cloud/");
            Thread.Sleep(1000);
        }
        public void ClickOnRefreshLink()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", RefreshLink);
        }
        #endregion Page Methods

    }

}
