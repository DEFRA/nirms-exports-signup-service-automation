using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class EligibilityPage : IEligibilityPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects
        private IWebElement CheckEligibility => _driver.WaitForElement(By.XPath("//a[contains(text(),'Check eligibility')]"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-fieldset__heading')]"));
        private IWebElement SelectCountry => _driver.WaitForElement(By.Id("radio-rbCountryEng"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(@id,'button-rbCountrySubmit')]"));
        private IWebElement EligibilityStatus => _driver.WaitForElement(By.Id("business-country"));
        private IWebElement FBONumberEle => _driver.WaitForElement(By.Id("FboNumber"));
        private IWebElement FBOContinue => _driver.WaitForElement(By.Id("button-rbFboSubmit"));

        #endregion
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public EligibilityPage(IObjectContainer container)
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
        #endregion

    }
}
