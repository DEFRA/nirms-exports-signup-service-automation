using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion Page Objects


        #region Page Methods
        public bool ClickOnCheckAnswersAndSubmitSignUp()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", CheckAnswersSubmitSignUpLink);
            return PageHeading.Text.Contains("Check your answers");
        }
        #endregion Page Methods
    }
}
