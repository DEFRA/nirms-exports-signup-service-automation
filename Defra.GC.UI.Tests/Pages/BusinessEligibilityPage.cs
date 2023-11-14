using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.UI.Framework.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics.Metrics;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessEligibilityPage : IBusinessEligibilityPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement CheckEligibility => _driver.WaitForElement(By.XPath("//a[contains(text(),'Check eligibility')]"));
        private IWebElement ManageAccessLink => _driver.WaitForElement(By.XPath("((//div[contains(@class,'govuk-grid-column-two-thirds')])//a)[1]"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(@id,'button-rbCountrySubmit')]"));
        private IWebElement EligibilityStatus => _driver.WaitForElement(By.Id("eligibility"));
        private IWebElement FBONumberEle => _driver.WaitForElement(By.Id("FboNumber"));
        private IWebElement PHRNumberEle => _driver.WaitForElement(By.Id("PhrNumber"));
        private IWebElement FBOContinue => _driver.WaitForElement(By.Id("button-rbFboSubmit"));
        private IWebElement NoSignUPTaskPage => _driver.WaitForElement(By.ClassName("govuk-heading-l"));
        //private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//a[@href='#FboNumber']"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]"));
        private IWebElement RegulationsErrorMessage => _driver.WaitForElement(By.XPath("//p[@id='RegulationConfirmed_Error']"));
        private IWebElement RegulationCheckbox => _driver.WaitForElementClickable(By.XPath("//label[contains(text(),'I confirm that I have understood the guidance and ')]"));
        private IWebElement Continue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        private By ErrorSummaryBy => By.XPath("//h2[contains(@class,'govuk-error-summary__title')]");
        private By RegulationCheckedboxBy => By.XPath("//input[@checked='checked']");
        private IWebElement FBONumberValue => _driver.WaitForElement(By.Id("FboNumber"));
        private IWebElement PHRNumberValue => _driver.WaitForElement(By.Id("PhrNumber"));
        private IWebElement HintText => _driver.WaitForElement(By.XPath("(//p[contains(@class,'govuk-hint')])[1]"));
       
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
             return PageHeading.Text.Contains("do under the Northern Ireland Retail Movement Scheme?");
            
        }

        public void CompleteEligibility(string country, string FBONumber)
        {
            if (!PageHeading.Text.Contains("Sign up"))
            {
                SelectBusinessCountry(country);

                if (PageHeading.Text.Contains("Food Business Operator (FBO)"))
                {
                    _driver.ElementImplicitWait();
                    _driver.ClickRadioButton("has an FBO");
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

        public void CompleteEligibilityWithCountryAndPHR(string country, string PHRNumber)
        {
            if (!PageHeading.Text.Contains("Sign up"))
            {
                SelectBusinessCountry(country);

                if (PageHeading.Text.Contains("Food Business Operator (FBO)"))
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,3000)", "");
                    Thread.Sleep(1000);
                    _driver.ClickRadioButton("has a PHR");
                    if (!PHRNumberValue.GetAttribute("value").Contains(PHRNumber))
                    {
                        PHRNumberEle.SendKeys(PHRNumber);
                    }
                    ClickContinue();
                }
                if (PageHeading.Text.Contains("Requirements of the Northern Ireland Retail Movement Scheme"))
                {
                    ConfirmReMosRegulationToCompleteEligibility();
                }
            }
        }

        public bool VerifyHintTextMessage(string hintText)
        {
            return HintText.Text.Contains(hintText);
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
            SelectBusinessCountry(country);
            SelectFBONumberToCompleteEligibility(FBONumber);
            _driver.ElementImplicitWait();
            DoNotConfirmReMosRegulationToCompleteEligibility();
        }

        public void SelectBusinessToSignUp(string businessSelection)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,6000)", "");
             Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(text(),'" +businessSelection + "')]/../input")).Click();
            ClickSaveAndContinue();
        }

        public void InvaildFBOdata(string country, string FBONumber)
        {
            SelectBusinessCountry(country);
            SelectFBONumberToCompleteEligibility(FBONumber);
        }

        public void InvaildPHRdata(string country, string PHRNumber)
        {
            SelectBusinessCountry(country);
            SelectPHRNumberToCompleteEligibility(PHRNumber);
        }
        public void SelectPHRNumberToCompleteEligibility(string PHRNumber)
        {
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,6000)", "");
            Thread.Sleep(2000);
            _driver.ClickRadioButton("has a PHR");
            PHRNumberEle.Clear();
            PHRNumberEle.SendKeys(PHRNumber);
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,4000)", "");
            Thread.Sleep(1000);
            FBOContinue.Click();
        }

        public void NavigateToRegulations(string country, string FBONumber)
        {
            SelectBusinessCountry(country);
            SelectFBONumberToCompleteEligibility(FBONumber);
        }

        public void SelectFBONumberToCompleteEligibility(string FBONumber)
        {
            _driver.ClickRadioButton("has an FBO");
            FBONumberEle.Clear();
            FBONumberEle.SendKeys(FBONumber);
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,4000)", "");
            Thread.Sleep(1000);
            FBOContinue.Click();
        }

        public void ConfirmReMosRegulationToCompleteEligibility()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,3500)", "");
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
            ClickContinue();
        }

        public bool VerifyEligibilityTaskStatus(string status)
        {
            string text = EligibilityStatus.Text;
            return EligibilityStatus.Text.Contains(status);
        }

        public void AssuranceCompleteWithNoFBO(string country)
        {
            SelectBusinessCountry(country);
            NoFBONumberToCompleteEligibility();
        }

        public void NoFBONumberToCompleteEligibility()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,3000)", "");
            Thread.Sleep(1000);
            _driver.ClickRadioButton("does not have either of these numbers");
            FBOContinue.Click();
        }

        public void AssurancePagWithCountry(string country)
        {
            SelectBusinessCountry(country);
        }

        public void SelectBusinessCountry(string country)
        {
            // if (PageHeading.Text.Contains("What will your business do"))
            if (PageHeading.Text.Contains("do under the Northern Ireland Retail Movement Scheme?"))
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
                        _driver.ElementImplicitWait();
                        ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
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

        public void EditPHRNumberToCompleteEligibility(string PHRNumber)
        {
            SelectPHRNumberToCompleteEligibility(PHRNumber);
            ConfirmReMosRegulationToCompleteEligibility();
        }

        public void ClickOnManageAccessLinkOnAnotherbusinessPage()
        {
            if (PageHeading.Text.Contains("You do not have access to any other businesses"))
            ManageAccessLink.Click();
            //return PageHeading.Text.Contains("What will your business do");
        }
        #endregion Page Methods
    }
}