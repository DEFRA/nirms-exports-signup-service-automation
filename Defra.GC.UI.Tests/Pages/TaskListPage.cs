using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class TaskListPage : ITaskListPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public TaskListPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Objects

        public IWebElement CheckAnswersSubmitSignUpLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Check answers and submit sign up')]"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement CheckAnswersStatus => _driver.WaitForElement(By.Id("complete_submit"));
        private IWebElement EligibilityTask => _driver.WaitForElement(By.XPath("//a[contains(text(),'Check eligibility')]"));

        #endregion Page Objects

        #region Page Methods

        public bool ClickOnCheckAnswersAndSubmitSignUp()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", CheckAnswersSubmitSignUpLink);
            return PageHeading.Text.Contains("Check your answers");
        }

        public bool VerifyCheckAnswersAndSubmitSignUpStatus(string status)
        {
            return CheckAnswersStatus.Text.Contains(status);
        }

        public bool VerifyCheckAnswersAndSubmitSignUpLinkStatus()
        {
            return CheckAnswersSubmitSignUpLink.Enabled;
        }

        public bool ClickOnEligibilityTask()
        {
            if (PageHeading.Text.Contains("Sign up"))
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                jsExecutor.ExecuteScript("arguments[0].click();", EligibilityTask);
            }

            return true;
        }

        public void RightClickOnCheckAnswersAndSubmitSignUp()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", CheckAnswersSubmitSignUpLink);
            Thread.Sleep(1000);
            Actions action = new Actions(_driver);
            action.KeyDown(Keys.Control).MoveToElement(CheckAnswersSubmitSignUpLink).Click().Perform();
        }

        #endregion Page Methods
    }
}