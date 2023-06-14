using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Globalization;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class EligibilitySteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IEligibilityPage? eligibilityPage => _objectContainer.IsRegistered<IEligibilityPage>() ? _objectContainer.Resolve<IEligibilityPage>() : null;


        public EligibilitySteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"click on check eligibilty task")]
        public void WhenClickOnCheckEligibiltyTask()
        {
            Assert.True(eligibilityPage.ClickOnCheckEligibilityTask(), "Select Coutry page not loaded");
        }


        [When(@"complete eligibility task with '([^']*)', '([^']*)'")]
        public void WhenCompleteEligibilityTask(string country, string FBONumber)
        {
            eligibilityPage.SelectCountryToCompleteEligibility(country, FBONumber);
        }

        [Then(@"verify eligibility task status as '([^']*)'")]
        public void ThenVerifyEligibilityTaskStatus(String status)
        {
            Assert.True(eligibilityPage.VerifyEligibilityTaskStatus(status), "Eligibility not completed");
        }
    }
}
