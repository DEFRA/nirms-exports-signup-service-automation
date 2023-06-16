using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessEligibilityPage : IBusinessEligibilityPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects

        private IWebElement Backlink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Back')]"));
        private IWebElement SaveAndContinueLater => _driver.WaitForElement(By.XPath("//a[contains(text(),'Save and continue later')]"));
        private IWebElement SignUPTaskPage => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl']"));
        private IWebElement CheckEligibility => _driver.WaitForElement(By.XPath("//a[contains(text(),'Check eligibility')]"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-fieldset__heading')]"));
        private IWebElement SelectCountry => _driver.WaitForElement(By.Id("radio-rbCountryEng"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(@id,'button-rbCountrySubmit')]"));
        private IWebElement EligibilityStatus => _driver.WaitForElement(By.Id("business-country"));
        private IWebElement FBORadioYes => _driver.WaitForElement(By.Id("radio-has-fbo"));
        private IWebElement FBONumberEle => _driver.WaitForElement(By.Id("FboNumber"));
        private IWebElement FBOContinue => _driver.WaitForElement(By.Id("button-rbFboSubmit"));
        private IWebElement NoSignUPTaskPage => _driver.WaitForElement(By.ClassName("govuk-heading-l"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//a[@href='#FboNumber']"));

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
        }

        public void SelectFBONumberToCompleteEligibility(string FBONumber)
        {
            _driver.ClickRadioButton("Yes");
            FBONumberEle.SendKeys(FBONumber);
            FBOContinue.Click();
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

        public string VerifyCountryPageloaded()
        {
            return PageHeading.Text;
        }

        #endregion Page Methods
    }
}