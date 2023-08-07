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
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(@id,'button-rbCountrySubmit')]"));
        private IWebElement EligibilityStatus => _driver.WaitForElement(By.Id("eligibility"));
        private IWebElement FBONumberEle => _driver.WaitForElement(By.Id("FboNumber"));
        private IWebElement FBOContinue => _driver.WaitForElement(By.Id("button-rbFboSubmit"));
        private IWebElement NoSignUPTaskPage => _driver.WaitForElement(By.ClassName("govuk-heading-l"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//a[@href='#FboNumber']"));
        private IWebElement RegulationsErrorMessage => _driver.WaitForElement(By.XPath("//p[@id='RegulationConfirmed_Error']"));
        private IWebElement RegulationCheckbox => _driver.WaitForElementClickable(By.XPath("//label[contains(text(),'I confirm that I have understood the guidance and ')]"));
        private IWebElement Continue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        private By ErrorSummaryBy => By.XPath("//h2[contains(@class,'govuk-error-summary__title')]");
        private By RegulationCheckedboxBy => By.XPath("//input[@checked='checked']");
        private IWebElement FBONumberValue => _driver.WaitForElement(By.Id("FboNumber"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public BusinessEligibilityPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool ClickOnCheckEligibilityTask()
        {
            if(PageHeading.Text.Contains("Sign up"))
            CheckEligibility.Click();
            return PageHeading.Text.Contains("What will your business do");
        }

        public void CompleteEligibility(string country, string FBONumber)
        {
            if (!PageHeading.Text.Contains("Sign up"))
            {
                if (PageHeading.Text.Contains("What will your business do"))
                {
                    if (_driver.FindElements(ErrorSummaryBy).Count > 0)
                    {
                        ClickContinue();
                    }
                    else
                    {
                        if (country.Contains("England") || country.Contains("Scotland") || country.Contains("Wales"))
                        {
                            _driver.ClickRadioButton("Send consignments from Great Britain");
                            _driver.ClickRadioButton(country);
                        }
                        else
                        if (country.Contains("Northern Ireland"))
                        {
                            _driver.ClickRadioButton("Receive consignments from Great Britain");
                        }
                        ClickContinue();
                    }
                }
                if (PageHeading.Text.Contains("Food Business Operator (FBO)"))
                {
                    _driver.ElementImplicitWait();
                    _driver.ClickRadioButton("Yes");
                    if (!FBONumberValue.GetAttribute("value").Contains(FBONumber))
                    {
                        FBONumberEle.SendKeys(FBONumber);
                    }
                    ClickContinue();
                }
                if (PageHeading.Text.Contains("Requirements of the Northern Ireland Retail Movement Scheme"))
                {
                    ConfirmReMosRegulationToCompleteEligibility();
                }
            }
        }

        public void ClickSaveAndContinue()
        {
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }

        public void ClickContinue()
        {
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", Continue);
        }

        public void SelectCountryToCompleteEligibilitywithoutRegulations(string country, string FBONumber)
        {
            if (_driver.WaitForElement(ErrorSummaryBy).Text.Contains("You cannot change this answer"))
                ClickContinue();
            //SelectFBONumberToCompleteEligibility(FBONumber);
            ClickContinue();
            _driver.ElementImplicitWait();
            DoNotConfirmReMosRegulationToCompleteEligibility();
        }

        public void SelectBusinessToSignUp(string businessSelection)
        {
            _driver.FindElement(By.XPath("//label[contains(text(),'" +businessSelection + "')]/../input")).Click();
            ClickSaveAndContinue();
        }

        public void InvaildFBOdata(string country, string FBONumber)
        {
            if (_driver.WaitForElement(ErrorSummaryBy).Text.Contains("You cannot change this answer"))
                ClickContinue();
            SelectFBONumberToCompleteEligibility(FBONumber);
        }

        public void NavigateToRegulations(string country, string FBONumber)
        {
            if (_driver.WaitForElement(ErrorSummaryBy).Text.Contains("You cannot change this answer"))
                ClickContinue();
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
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            if (_driver.FindElements(RegulationCheckedboxBy).Count() > 0)
            {
                string checkedValue = jsExecutor1.ExecuteScript("return document.getElementById('Confirmed').checked").ToString();
                if (checkedValue.Contains("True"))
                    ClickContinue();
            }
            else
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                jsExecutor.ExecuteScript("arguments[0].click();", RegulationCheckbox);
                ClickContinue();
            }
        }

        public void DoNotConfirmReMosRegulationToCompleteEligibility()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,2500)", "");
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            if (_driver.FindElements(RegulationCheckedboxBy).Count() > 0)
            {
                string checkedValue = jsExecutor1.ExecuteScript("return document.getElementById('Confirmed').checked").ToString();
                if (checkedValue.Contains("True"))
                {
                    IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                    jsExecutor.ExecuteScript("arguments[0].click();", RegulationCheckbox);
                }
                ClickContinue();
            }
        }

        public bool VerifyEligibilityTaskStatus(string status)
        {
            string text = EligibilityStatus.Text;
            return EligibilityStatus.Text.Contains(status);
        }

        public void AssuranceCompleteWithNoFBO()
        {
            ClickContinue();
            NoFBONumberToCompleteEligibility();
        }

        public void NoFBONumberToCompleteEligibility()
        {
            _driver.ClickRadioButton("No");
            FBOContinue.Click();
        }

        public void AssurancePagWithCountry(string country)
        {
            if (_driver.WaitForElement(ErrorSummaryBy).Text.Contains("You cannot change this answer"))
                ClickContinue();
        }

        public bool VerifyEligibilityTaskFields(string country, string FBONumber)
        {
            bool status = true;
            if (!_driver.WaitForElement(ErrorSummaryBy).Text.Contains("You cannot change this answer"))
                status = false;
            ClickContinue();
            if (!FBONumberValue.GetAttribute("value").Contains(FBONumber))
                status = false;
            ClickContinue();
            ClickContinue();
            return status;
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

        public void EditFBONumberToCompleteEligibility(string FBONumber)
        {
            SelectFBONumberToCompleteEligibility(FBONumber);
            ConfirmReMosRegulationToCompleteEligibility();
        }

        #endregion Page Methods
    }
}