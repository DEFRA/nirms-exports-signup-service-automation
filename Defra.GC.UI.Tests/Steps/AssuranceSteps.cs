using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class AssuranceSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IAssurancPage? AssurancPage => _objectContainer.IsRegistered<IAssurancPage>() ? _objectContainer.Resolve<IAssurancPage>() : null;

        public AssuranceSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"complete eligibility task without '([^']*)', '([^']*)'")]
        public void WhenCompleteEligibilityTaskWithout(string country, string FBONumber)
        {
            AssurancPage.AssuranceCompleteWithNoSelection(country, FBONumber);
        }

        [Then(@"verify no signp page appears")]
        [When(@"verify no signp page appears")]
        public void WhenVerifyNoSignpPageAppears()
        {
            AssurancPage.VerifyNoSignUpTaskListPageIsLoaded();

            Assert.True(AssurancPage.VerifyNoSignUpTaskListPageIsLoaded(), "Signup task  pageloaded");
        }

        [Then("verify error message '([^']*)' on  SPS_Assurance page")]
        [When(@"verify error message '([^']*)' on  SPS_Assurance page")]
        public void WhenVerifyErrorMessageOnSPS_AssurancePage(string errorMessage)
        {
            Assert.True(AssurancPage.VerifyErrorMessageOnSPSAssurancePage(errorMessage), "FBO invalid error not matching");
        }

        [When(@"complete eligibility task with '([^']*)'")]
        public void WhenCompleteEligibilityTaskWith(string country)
        {
            AssurancPage.AssurancePagWithCountry(country);
        }

        [Then(@"user  navigates to the Country selection page")]
        public void ThenUserNavigatesToTheCountrySelectionPage()
        {
            Assert.True(AssurancPage.VerifyCountryPageloaded(), "Country page is not loaded");
        }
    }
}