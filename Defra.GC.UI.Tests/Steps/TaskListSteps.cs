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

        [Then(@"click on Check answers and submit sign up")]
        public void ThenClickOnCheckAnswersAndSubmitSignUp()
        {
            Assert.True(taskListPage.ClickOnCheckAnswersAndSubmitSignUp(), "Check Answers And Submit SignUp page not loaded");
        }

    }
}
