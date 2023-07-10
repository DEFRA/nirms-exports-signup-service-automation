using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class TermsAndConditionsPage : ITermsAndConditionsPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public TermsAndConditionsPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Objects

        private IWebElement ConfirmSanitaryAndPhytosanitaryBox => _driver.WaitForElementExists(By.Id("AssuranceCommitment"));
        private IWebElement AddPointOfDepartureLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Add another place of dispatch')]"));
        private IWebElement AddPointOfDestinationLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Add another place of destination')]"));
        private By NumberOfEstablishments => By.XPath("//div[@class='govuk-summary-card']");

        private IWebElement Chequebox => _driver.WaitForElement(By.XPath("//input[@id='TandCs']/.."));

        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));

        private IWebElement Cdate => _driver.WaitForElement(By.XPath("//p[contains(text(),'Date of declaration')]"));

        #endregion Page Objects

        #region Page Methods

        public void ConfirmSanitaryAndPhytosanitary()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", ConfirmSanitaryAndPhytosanitaryBox);
            //IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            //jsExecutor1.ExecuteScript("arguments[0].click();", Continue);
        }

        public bool VerifyTandCsErrorsMessage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        public string VerifyTandCDay()
        {
            return Cdate.Text;
        }

        public void ChequeBoxSelected()
        {
            Chequebox.Click();
        }

        #endregion Page Methods
    }
}