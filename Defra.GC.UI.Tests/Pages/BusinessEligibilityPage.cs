using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.UI.Framework.Driver;
using NUnit.Framework.Internal;
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

        private IWebElement PurposeOfBusiness => _driver.WaitForElement(By.XPath("//a[contains(text(),'Purpose of business')]"));
        private IWebElement FBOorPHRNumber => _driver.WaitForElement(By.XPath("//a[contains(text(),'FBO or PHR number')]"));
        private IWebElement ManageAccessLink => _driver.WaitForElement(By.XPath("((//div[contains(@class,'govuk-grid-column-two-thirds')])//a)[1]"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement SignNewSignUpRequest => _driver.WaitForElement(By.XPath("(//div[contains(@class,'govuk-grid-column-two-thirds')]//a)[1]"));
        private IWebElement PurposeOfBusinessText => _driver.WaitForElement(By.XPath("(//div[@class='govuk-grid-column-two-thirds']/p)[1]"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(@id,'button-rbCountrySubmit')]"));
        private IWebElement EligibilityStatus => _driver.WaitForElement(By.Id("purposeofbusiness"));
        private IWebElement NoSignUPTaskPage => _driver.WaitForElement(By.ClassName("govuk-heading-l"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]"));
        private IWebElement RegulationsErrorMessage => _driver.WaitForElement(By.XPath("//p[@id='RegulationConfirmed_Error']"));
        private IWebElement RegulationCheckbox => _driver.WaitForElementClickable(By.XPath("//label[contains(text(),'I confirm that I have read and understood ')]"));
        private IWebElement Continue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        private By ErrorSummaryBy => By.XPath("//h2[contains(@class,'govuk-error-summary__title')]");
        private By RegulationCheckedboxBy => By.XPath("//input[@checked='checked']");
        private IWebElement FBONumberValue => _driver.WaitForElement(By.Id("FboNumber"));
        private IWebElement SelectBusinessDP => _driver.WaitForElement(By.Id("SelectedBusiness"));

        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public BusinessEligibilityPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool ClickOnPurposeOfBusinessTask()
        {
            if (PageHeading.Text.Contains("Sign up"))
            {
                PurposeOfBusiness.Click();
            }
            return PageHeading.Text.Contains("Business purpose");
        }

        public void CompleteEligibility(string country)
        {
            if (!PageHeading.Text.Contains("Sign up"))
            {
                if (PageHeading.Text.Contains("Requirements of the Northern Ireland Retail Movement Scheme"))
                {
                    ConfirmReMosRegulationToCompleteEligibility();
                }

                SelectBusinessCountry(country);
            }
        }


        public void ClickSaveAndContinue()
        {
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }
        public void ClickOnStartNewSignUpRequestOnPurposeOfBusiness()
        {
                SignNewSignUpRequest.Click();
        }

        public void ClickContinue()
        {
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", Continue);
        }

        public void ContinueEligibilityTaskWithWithoutRegulations()
        {
            DoNotConfirmReMosRegulationToCompleteEligibility();
        }

        public void SelectBusinessToSignUp(string businessSelection)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,6000)", "");
             Thread.Sleep(1000);

            if (_driver.FindElements(By.XPath("//input[@name='SelectedBusiness']")).Count > 0)
            {
                _driver.FindElement(By.XPath("//label[contains(text(),'" + businessSelection + "')]/../input")).Click();
            }
            else if (_driver.FindElements(By.XPath("//select[@name='SelectedBusiness']")).Count > 0)
            {
                _driver.SelectFromDropdown(SelectBusinessDP, businessSelection);
            }

            ClickSaveAndContinue();
        }

        public void NavigateToRegulationsAndConfirmRegulation()
        {
            if (PageHeading.Text.Contains("Requirements of the Northern Ireland Retail Movement Scheme"))
            {
                ConfirmReMosRegulationToCompleteEligibility();
            }
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

        public void SelectBusinessCountry(string country)
        {
            if (PageHeading.Text.Contains("Requirements of the Northern Ireland Retail Movement Scheme"))
            {
                ConfirmReMosRegulationToCompleteEligibility();
            }

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

        public void ClickOnManageAccessLinkOnAnotherbusinessPage()
        {
            if (PageHeading.Text.Contains("You do not have access to any other businesses"))
            ManageAccessLink.Click();
        }

        public bool VerifyTextOnPurposeOfBusinessPage(string Message)
        {
            return PurposeOfBusinessText.Text.Contains(Message);
        }
        #endregion Page Methods
    }
}