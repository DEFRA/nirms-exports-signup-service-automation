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

        private By CheckBox = By.CssSelector("#TandCs");

        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));

        private IWebElement Cdate => _driver.WaitForElement(By.XPath("//p[contains(text(),'Date of declaration')]"));
        private IWebElement SubmitSignUpButton => _driver.WaitForElement(By.XPath("//button[@id='button-assuranceSubmit']"));

        #endregion Page Objects

        #region Page Methods

        public bool VerifyTandCsErrorsMessage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        public bool VerifyTandCDate()
        {
            string sDate = DateTime.Now.ToString("dd MMMM yyyy");
            return Cdate.Text.Contains(sDate);
        }

        public void CheckBoxSelected()
        {
            _driver.FindElement(CheckBox).Click();
        }

        public void ClickOnSubmitSignUp()
        {
            SubmitSignUpButton.Click();
        }

        #endregion Page Methods
    }
}