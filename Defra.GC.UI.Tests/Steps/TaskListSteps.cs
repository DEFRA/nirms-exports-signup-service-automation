using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]

    public class TaskListSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private ITaskListPage? taskListPage => _objectContainer.IsRegistered<ITaskListPage>() ? _objectContainer.Resolve<ITaskListPage>() : null;


        public TaskListSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }

        [When(@"click on Check answers and submit sign up")]
        [Then(@"click on Check answers and submit sign up")]
        public void ThenClickOnCheckAnswersAndSubmitSignUp()
        {
            Assert.True(taskListPage.ClickOnCheckAnswersAndSubmitSignUp(), "Check Answers And Submit SignUp page not loaded");
        }

        [Then(@"verify Check answers and submit sign up status '([^']*)'")]
        public void ThenVerifyCheckAnswersAndSubmitSignUpStatus(string status)
        {
            Assert.True(taskListPage.VerifyCheckAnswersAndSubmitSignUpStatus(status), "Check Answers And Submit SignUp status not matching");
        }

        [Then(@"verify Check answers and submit sign up link is enabled")]
        public void ThenVerifyCheckAnswersAndSubmitSignUpLink()
        {
            Assert.True(taskListPage.VerifyCheckAnswersAndSubmitSignUpLinkStatus(), "Check Answers And Submit SignUp link is not enabled");
        }

        [When(@"click on eligibility task")]
        public void WhenClickOnEligibilityTask()
        {
            Assert.True(taskListPage.ClickOnEligibilityTask(), "Eligibility Task Page not loaded");
        }

    }
}
