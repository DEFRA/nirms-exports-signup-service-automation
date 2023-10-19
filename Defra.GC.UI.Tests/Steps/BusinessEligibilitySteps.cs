using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Diagnostics.Metrics;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class BusinessEligibilitySteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IBusinessEligibilityPage? eligibilityPage => _objectContainer.IsRegistered<IBusinessEligibilityPage>() ? _objectContainer.Resolve<IBusinessEligibilityPage>() : null;

        public BusinessEligibilitySteps(ScenarioContext context, IObjectContainer container)
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
        public void WhenCompleteEligibilityTaskWith(string country, string FBONumber)
        {
            eligibilityPage.CompleteEligibility(country, FBONumber);
        }

        [When(@"complete eligibility task with '([^']*)', '([^']*)' without Regulations")]
        public void WhenCompleteEligibilityTaskWithWithoutRegulations(string country, string FBONumber)
        {
            eligibilityPage.SelectCountryToCompleteEligibilitywithoutRegulations(country, FBONumber);
        }

        [When(@"complete eligibility task with '([^']*)', '([^']*)' and navigate to Regulations page")]
        public void WhenCompleteEligibilityTaskWithAndNavigateToRegulationsPage(string country, string FBONumber)
        {
            eligibilityPage.NavigateToRegulations(country, FBONumber);
        }

        [When(@"complete eligibility task with invalid data '([^']*)', '([^']*)'")]
        public void WhenCompleteEligibilityTaskWithInvalidData(string country, string FBONumber)
        {
            eligibilityPage.InvaildFBOdata(country, FBONumber);
        }

        [Then(@"verify eligibility task status as '([^']*)'")]
        public void ThenVerifyEligibilityTaskStatus(String status)
        {
            Assert.True(eligibilityPage.VerifyEligibilityTaskStatus(status), "Eligibility not completed");
        }

        [When(@"complete eligibility task with '([^']*)' and without FBONumber")]
        public void WhenCompleteEligibilityTaskWithoutFBO(string country)
        {
            eligibilityPage.AssuranceCompleteWithNoFBO(country);
        }

        [Then(@"verify no signp page appears")]
        [When(@"verify no signp page appears")]
        public void WhenVerifyNoSignpPageAppears()
        {
            eligibilityPage.VerifyNoSignUpTaskListPageIsLoaded();

            Assert.True(eligibilityPage.VerifyNoSignUpTaskListPageIsLoaded(), "Signup task  pageloaded");
        }

        [Then("verify error message '([^']*)' on  SPS_Assurance page")]
        [When(@"verify error message '([^']*)' on  SPS_Assurance page")]
        public void WhenVerifyErrorMessageOnSPS_AssurancePage(string errorMessage)
        {
            Assert.True(eligibilityPage.VerifyErrorMessageOnSPSAssurancePage(errorMessage), "FBO invalid error not matching");
        }

        [Then(@"verify error message '([^']*)' on  Regulations page")]
        public void ThenVerifyErrorMessageOnRegulationsPage(string errorMessage)
        {
            Assert.True(eligibilityPage.VerifyErrorMessageOnRegulationsPage(errorMessage), "Regulations invalid error not matching");
        }

        [When(@"complete eligibility task with '([^']*)'")]
        public void WhenCompleteEligibilityTaskWith(string country)
        {
            eligibilityPage.AssurancePagWithCountry(country);
        }

        [When(@"select business to sign up '([^']*)'")]
        public void WhenSelectBusinessToSignUpACMELtd(string businessSelection)
        {
            eligibilityPage.SelectBusinessToSignUp(businessSelection);
        }

        [When(@"verify eligibility task with fields '([^']*)', '([^']*)'")]
        public void WhenVerifyEligibilityTaskFields(string country, string FBONumber)
        {
            eligibilityPage.VerifyEligibilityTaskFields(country, FBONumber);
        }

        [Then(@"user  navigates to the Country selection page")]
        public void ThenUserNavigatesToTheCountrySelectionPage()
        {
            Assert.AreEqual(eligibilityPage.VerifyCountryPageloaded(), "Which country is your business based in?");
        }

        [Then(@"user navigates to the SPO_Assurance page")]
        public void ThenUserNavigatesToTheSPO_AssurancePage()
        {
            Assert.AreEqual(eligibilityPage.VerifySPOPageloaded(), "Does your business have a Food Business Operator (FBO) or Plant Health Registration (PHR) number?");
        }
    }
}