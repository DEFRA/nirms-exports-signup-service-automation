using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading'] | //h1[contains(text(),'You have successfully submitted a request to sign ')]"));

        private IWebElement CheckBox => _driver.WaitForElement(By.XPath("//input[@id='TandCs']"));

        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));

        private IWebElement Cdate => _driver.WaitForElement(By.XPath("//p[contains(text(),'Date of declaration')]"));
        private IWebElement SubmitSignUpButton => _driver.WaitForElement(By.XPath("//button[@id='button-assuranceSubmit']"));
        private IWebElement TCsTextMessage => _driver.WaitForElement(By.XPath("//label[contains(@class,'govuk-label govuk-checkboxes__label govuk-!-font-weight-bold')]"));
        #endregion Page Objects

        #region Page Methods

        public bool VerifyTandCsErrorsMessage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        public bool VerifyTandCsText(string Name, string TCsText)
        {
            if(TCsTextMessage.Text.Contains(Name) && TCsTextMessage.Text.Contains(TCsText))
                return true;
            else
                return false;
        }

        public bool VerifyTandCDate()
        {
            string sDate = DateTime.Now.ToString("d MMMM yyyy");
            return Cdate.Text.Contains(sDate);
        }

        public void CheckBoxSelected()
        {
            PageHeading.Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,3000)", "");
            Thread.Sleep(1000);
            //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            //jsExecutor.ExecuteScript("arguments[0].click();", CheckBox);
            IWebElement checkBox = _driver.WaitForElementExists(By.XPath("//div[contains(@class,'govuk-checkboxes__item')]/input"));
            Actions actions = new Actions(_driver);
            actions.MoveToElement(checkBox).Click().Build().Perform();
        }

        public void ClickOnSubmitSignUp()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SubmitSignUpButton);
        }

        #endregion Page Methods
    }
}