using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

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
        private IWebElement EligibilityStatus => _driver.WaitForElement(By.Id("eligibility"));
        private IWebElement FBONumberEle => _driver.WaitForElement(By.Id("FboNumber"));
        private IWebElement FBOContinue => _driver.WaitForElement(By.Id("button-rbFboSubmit"));
        private IWebElement NoSignUPTaskPage => _driver.WaitForElement(By.ClassName("govuk-heading-l"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//a[@href='#FboNumber']"));
        private IWebElement RegulationsErrorMessage => _driver.WaitForElement(By.XPath("//p[@id='RegulationConfirmed_Error']"));
        private IWebElement RegulationCheckbox => _driver.WaitForElementClickable(By.XPath("//label[contains(text(),'I confirm that I have understood the guidance and ')]"));
        private IWebElement Continue => _driver.WaitForElement(By.Id("button-elig_regulations_Submit data-module="));

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

        public void SelectCountryToCompleteEligibility(string country, string FBONumber, string businesselection)
        {
            _driver.FindElement(By.XPath("//input[@value='" + businesselection + "']")).Click();
            //_driver.ElementImplicitWait();
            //_driver.ClickRadioButton(businesselection);
            ClickSaveAndContinue();
            _driver.ElementImplicitWait();
            _driver.ClickRadioButton(country);
            ClickSaveAndContinue();
            SelectFBONumberToCompleteEligibility(FBONumber);
            ConfirmReMosRegulationToCompleteEligibility();
        }

        public void ClickSaveAndContinue()
        {
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }

        public void SelectCountryToCompleteEligibilitywithoutRegulations(string businessSelection, string country, string FBONumber)
        {
            _driver.FindElement(By.XPath("//input[@value='" + businessSelection + "']")).Click();
            ClickSaveAndContinue();
            _driver.ClickRadioButton(country);
            SaveAndContinue.Click();
            SelectFBONumberToCompleteEligibility(FBONumber);
            _driver.ElementImplicitWait();
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", Continue);
        }

        public void InvaildFBOdata(string country, string FBONumber,string businessSelection)
        {
            _driver.FindElement(By.XPath("//input[@value='" + businessSelection + "']")).Click();
            ClickSaveAndContinue();
            _driver.ClickRadioButton(country);
            ClickSaveAndContinue();
            SelectFBONumberToCompleteEligibility(FBONumber);
        }

        public void NavigateToRegulations(string businessSelection, string country, string FBONumber)
        {
            _driver.FindElement(By.XPath("//input[@value='" + businessSelection + "']")).Click();
            ClickSaveAndContinue();
            _driver.ClickRadioButton(country);
            ClickSaveAndContinue();
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
            string text = EligibilityStatus.Text;
            return EligibilityStatus.Text.Contains(status);
        }

        public void AssuranceCompleteWithNoSelection(string country, string FBONumber)
        {
            _driver.ClickRadioButton(country);
            ClickSaveAndContinue();
            NoFBONumberToCompleteEligibility(FBONumber);
        }

        public void NoFBONumberToCompleteEligibility(string FBONumber)
        {
            _driver.ClickRadioButton("No");
            FBOContinue.Click();
        }

        public void AssurancePagWithCountry(string businessSelection, string country)
        {
            _driver.FindElement(By.XPath("//input[@value='" + businessSelection + "']")).Click();
            ClickSaveAndContinue(); 
            _driver.ClickRadioButton(country);
            ClickSaveAndContinue();
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
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,2501)", "");
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

        public void EditCountryToCompleteEligibility(string country)
        {
            _driver.ClickRadioButton(country);
            ClickSaveAndContinue();
            FBOContinue.Click();
            ConfirmReMosRegulationToCompleteEligibility();
        }

        public void EditFBONumberToCompleteEligibility(string FBONumber)
        {
            SelectFBONumberToCompleteEligibility(FBONumber);
            ConfirmReMosRegulationToCompleteEligibility();
        }

        #endregion Page Methods
    }
}