using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using Defra.UI.Framework.Driver;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class ApplicationPage : IApplicationPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading'] | //h1[contains(text(),'You have successfully submitted a request to sign ')]"));
        private IWebElement Backlink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Back')]"));
        private IWebElement Aphalink => _driver.WaitForElement(By.XPath("//a[normalize-space()='NIRetailMovementEnquiries@apha.gov.uk']"));
        private IWebElement feedbacklink => _driver.WaitForElement(By.XPath("//a[normalize-space()='feedback']"));
        private IWebElement BackToDashboardlink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Back to dashboard')] | //button[contains(text(),'Back to Dashboard')] | //button[contains(text(),'Back to dashboard')]"));
        private IWebElement SaveAndReturnToDashboard => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save and return to dashboard')]"));
        private IWebElement ReturnToDashboard => _driver.WaitForElement(By.XPath("//button[contains(text(),'Return to dashboard')]"));
        private IWebElement SignUPTaskPage => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl']"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement Continue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Continue']"));
        private IWebElement Feedbacktext => _driver.WaitForElement(By.XPath("//div[@class='QuestionText BorderColor']"));
        private IWebElement GenericGOVPage => _driver.WaitForElement(By.XPath("//span[contains(@class,'govuk-header__logotype-text')] | (//span[contains(@class,'govuk-!-margin-bottom-2 govuk-!-display-block')])[1]"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]"));
        private IWebElement HintText => _driver.WaitForElement(By.XPath("//p[contains(@id,'name-hint')]"));
        private IWebElement GOVLink => _driver.WaitForElement(By.XPath("//*[name()='svg' and @class='govuk-header__logotype']"));
        private IWebElement PageText => _driver.WaitForElement(By.XPath("//p[contains(text(),'These are the establishments')]"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public ApplicationPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool VerifyNextPageIsLoaded(string pageName)
        {
            string text = PageHeading.Text;
            return PageHeading.Text.Contains(pageName);
        }

        public bool VerifyAPHAEmail(string link)
        {
            return Aphalink.Text.Contains(link);
        }

        public void ClickOnBackLink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,-1000)", "");
            Thread.Sleep(1000);
            Backlink.Click();
        }

        public void ClickOnFeedBackLink()
        {
            feedbacklink.Click();
        }

        public void ClickonBackToDashboardlink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,-4000)", "");
            Thread.Sleep(3000);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", BackToDashboardlink);
        }

        public void NavigateToTaskListPage()
        {
            string url = UrlBuilder.Default().Add("registration-tasklist").Build();
            _driver.Navigate().GoToUrl(url);
        }

        public bool VerifySignUpTaskListPageIsLoaded()
        {
            return SignUPTaskPage.Text.Contains("Sign up for the Northern Ireland Retail Movement Scheme");
        }

        public bool VerifyFeedbackPageLoaded()
        {
            return Feedbacktext.Text.Contains("What part of the service are you using today?");
        }

        public bool VerifyGenericGOVPageLoaded()
        {
            return GenericGOVPage.Text.Contains("GOV.UK");
        }

        public void ClickSaveAndReturnToDashboard()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndReturnToDashboard);
        }

        public void ClickReturnToDashboard()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", ReturnToDashboard);
        }

        public void ClickOnSaveAndContinue()
        {
            Thread.Sleep(1000);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }

        public void ClickOnContinue()
        {
            Thread.Sleep(1000);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", Continue);
        }

        public void ClickOnBackToDashboardLink()
        {
            BackToDashboardlink.Click();
        }

        public void CloseCurrentTab()
        {
            _driver.Close();
        }

        public void SwitchToNextTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.LastOrDefault());
            Thread.Sleep(1000);
        }

        public void SwitchToPreviousOpenTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
        }

        public bool VerifyDynamicNameInTitleOfPage(string Name, string title)
        {
            if (PageHeading.Text.Contains(Name) && PageHeading.Text.Contains(title))
                return true;
            else
                return false;
        }

        public bool VerifyDynamicNameErrorMessage(string Name, string errorMessage)
        {
            if (ErrorMessage.Text.Contains(Name) && ErrorMessage.Text.Contains(errorMessage))
                return true;
            else
                return false;
        }

        public bool VerifyDynamicHintTextMessage(string BusinessName)
        {
            if (HintText.Text.Contains(BusinessName))

                return true;
            else
                return false;
        }
        public void ClickGOVHeaderLink()
        {
            GOVLink.Click();
        }

        public bool VerifyTextOnEstablishmentPage(string message)
        {
            if (PageText.Text.Contains(message))

                return true;
            else
                return false;
        }

        #endregion Page Methods
    }
}