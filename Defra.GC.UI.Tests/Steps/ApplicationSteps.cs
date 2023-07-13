using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class ApplicationSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        public ApplicationSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"click on save and continue")]
        [Then(@"click on save and continue")]
        public void ThenClickOnSaveAndContinue()
        {
            applicationPage.ClickOnSaveAndContinue();
        }

        [When(@"click on continue button")]
        [Then(@"click on continue button")]
        public void ThenClickOnContinueButton()
        {
            applicationPage.ClickOnContinue();
        }

        [Then(@"verify next page '([^']*)' is loaded")]
        public void ThenVerifyNextPageIsLoaded(string pageName)
        {
            Assert.True(applicationPage.VerifyNextPageIsLoaded(pageName), "Expected page not loaded");
        }

        [When(@"click on back link")]
        [Then(@"click on back link")]
        public void ThenClickOnBackLink()
        {
            applicationPage.ClickOnBackLink();
        }

        [Then(@"navigate to task list page")]
        public void ThenNavigateToTaskListPage()
        {
            applicationPage.NavigateToTaskListPage();
        }

        [Then(@"verify signUp task list page is loaded")]
        public void ThenVerifySignUpTaskListPageIsLoaded()
        {
            Assert.True(applicationPage.VerifySignUpTaskListPageIsLoaded(), "Signup task list page not loaded");
        }

        [When(@"click Save and return to dashboard")]
        [Then(@"click Save and return to dashboard")]
        public void ThenClickSaveAndreturnToDashboard()
        {
            applicationPage.ClickSaveAndReturnToDashboard();
        }
    }
}