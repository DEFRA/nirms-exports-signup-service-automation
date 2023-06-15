using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class AssurancPage : IAssurancPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects

        private IWebElement Backlink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Back')]"));
        private IWebElement SaveAndContinueLater => _driver.WaitForElement(By.XPath("//a[contains(text(),'Save and continue later')]"));
        private IWebElement NoSignUPTaskPage => _driver.WaitForElement(By.XPath("//h1[normalize-space()='You cannot sign up your business']"));
        private IWebElement CheckEligibility => _driver.WaitForElement(By.XPath("//a[contains(text(),'Check eligibility')]"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-fieldset__heading')]"));
        private IWebElement SelectCountry => _driver.WaitForElement(By.Id("radio-rbCountryEng"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(@id,'button-rbCountrySubmit')]"));
        private IWebElement EligibilityStatus => _driver.WaitForElement(By.Id("business-country"));
        private IWebElement FBORadioYes => _driver.WaitForElement(By.Id("radio-has-fbo"));
        private IWebElement FBONumberEle => _driver.WaitForElement(By.Id("FboNumber"));
        private IWebElement FBOContinue => _driver.WaitForElement(By.Id("button-rbFboSubmit"));

        private IWebElement CountryPage => _driver.WaitForElement(By.XPath("//h1[normalize-space()='Which country is your business based in?']"));

        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//a[contains(text(),'Enter FBO number using only letters, numbers and h')]"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public AssurancPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool ClickOnCheckEligibilityTask()
        {
            CheckEligibility.Click();
            return PageHeading.Text.Contains("Which country is your business based in");
        }

        public void AssuranceCompleteWithNoSelection(string country, string FBONumber)
        {
            _driver.ClickRadioButton(country);
            SaveAndContinue.Click();
            NoFBONumberToCompleteEligibility(FBONumber);
        }

        public void NoFBONumberToCompleteEligibility(string FBONumber)
        {
            _driver.ClickRadioButton("No");
            FBONumberEle.SendKeys(FBONumber);
            FBOContinue.Click();
        }

        public void AssurancePagWithCountry(string country)
        {
            _driver.ClickRadioButton(country);
            SaveAndContinue.Click();
            Backlink.Click();
        }

        public bool VerifyEligibilityTaskStatus(string status)
        {
            return EligibilityStatus.Text.Contains(status);
        }

        public bool VerifyNoSignUpTaskListPageIsLoaded()
        {
            return NoSignUPTaskPage.Text.Contains("cannot sign");
        }

        public bool VerifyErrorMessageOnSPSAssurancePage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        public bool VerifyCountryPageloaded()
        {
            return CountryPage.Displayed;
        }

        #endregion Page Methods
    }
}