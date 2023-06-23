using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using System.Diagnostics.Metrics;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessEligibilityPage : IBusinessEligibilityPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement CheckEligibility => _driver.WaitForElement(By.XPath("//a[contains(text(),'Check eligibility')]"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-fieldset__heading')]"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(@id,'button-rbCountrySubmit')]"));

        private IWebElement EligibilityStatus => _driver.WaitForElement(By.Id("business-country"));
        private IWebElement FBONumberEle => _driver.WaitForElement(By.Id("FboNumber"));
        private IWebElement FBOContinue => _driver.WaitForElement(By.Id("button-rbFboSubmit"));
        private IWebElement NoSignUPTaskPage => _driver.WaitForElement(By.ClassName("govuk-heading-l"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//a[@href='#FboNumber']"));
        private IWebElement RegulationsErrorMessage => _driver.WaitForElement(By.XPath("//p[@id='RegulationConfirmed_Error']"));
        private IWebElement RegulationCheckbox => _driver.WaitForElementClickable(By.XPath("//label[contains(text(),'I confirm that I have understood the guidance and ')]"));
        private IWebElement Continue => _driver.WaitForElement(By.ClassName("govuk-button"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public BusinessEligibilityPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool ClickOnCheckEligibilityTask()
        {
            CheckEligibility.Click();
            return PageHeading.Text.Contains("Which country is your business based in");
        }

        public void SelectCountryToCompleteEligibility(string country, string FBONumber)
        {
            _driver.ClickRadioButton(country);
            SaveAndContinue.Click();
            SelectFBONumberToCompleteEligibility(FBONumber);
            ConfirmReMosRegulationToCompleteEligibility();
        }

        public void SelectCountryToCompleteEligibilitywithoutRegulations(string country, string FBONumber)
        {
            _driver.ClickRadioButton(country);
            SaveAndContinue.Click();
            SelectFBONumberToCompleteEligibility(FBONumber);
            Continue.Click();
        }

        public void NavigateToRegulations(string country, string FBONumber)
        {
            _driver.ClickRadioButton(country);
            SaveAndContinue.Click();
            SelectFBONumberToCompleteEligibility(FBONumber);
        }

        public void InvaildFBOdata(string country, string FBONumber)
        {
            _driver.ClickRadioButton(country);
            SaveAndContinue.Click();
            SelectFBONumberToCompleteEligibility(FBONumber);
        }

        public void SelectFBONumberToCompleteEligibility(string FBONumber)
        {
            _driver.ClickRadioButton("Yes");
            FBONumberEle.SendKeys(FBONumber);
            FBOContinue.Click();
        }

        public void ConfirmReMosRegulationToCompleteEligibility()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,2500)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", RegulationCheckbox);
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", Continue);
        }

        public bool VerifyEligibilityTaskStatus(string status)
        {
            return EligibilityStatus.Text.Contains(status);
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
            FBOContinue.Click();
        }

        public void AssurancePagWithCountry(string country)
        {
            _driver.ClickRadioButton(country);
            SaveAndContinue.Click();
        }

        public bool VerifyNoSignUpTaskListPageIsLoaded()
        {
            return NoSignUPTaskPage.Text.Contains("cannot sign");
        }

        public bool VerifyErrorMessageOnSPSAssurancePage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        public bool VerifyErrorMessageOnRegulationsPage(string errorMessage)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,2500)", "");
            return RegulationsErrorMessage.Text.Contains(errorMessage);
        }

        public string VerifyCountryPageloaded()
        {
            return PageHeading.Text;
        }

        public string VerifySPOPageloaded()
        {
            return PageHeading.Text;
        }

        #endregion Page Methods
    }
}