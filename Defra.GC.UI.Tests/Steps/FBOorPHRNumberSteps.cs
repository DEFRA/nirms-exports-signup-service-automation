using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]

    public class FBOorPHRNumberSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IFBOorPHRNumberPage? fboPhrPage => _objectContainer.IsRegistered<IFBOorPHRNumberPage>() ? _objectContainer.Resolve<IFBOorPHRNumberPage>() : null;
        public FBOorPHRNumberSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }

        [When(@"click on FBOorPHRNumber task")]
        public void WhenClickOnFBOorPHRNumberTask()
        {
            fboPhrPage.ClickOnFBOorPHRNumberTask();
        }

        [When(@"enter invalid FBO '([^']*)'")]
        public void WhenEnterInvalidFBO(string FBONumber)
        {
            fboPhrPage.InvaildFBOdata(FBONumber);
        }

        [When(@"enter invalid PHR '([^']*)'")]
        public void WhenEnterInvalidPHR(string PHRNumber)
        {
            fboPhrPage.InvaildPHRdata(PHRNumber);
        }


        [When(@"complete FBO or PHR number task without FBO or PHR Number")]
        public void WhencompleteFBOorPHRnumbertaskwithoutFBOorPHRNumber()
        {
            fboPhrPage.ContinueFBOorPHRNumberTaskWithoutFBOorPHRNumber();
        }

        [When(@"enter PHR number '([^']*)' for FBO or PHR number task")]
        public void WhenCompleteFBOOrPHRNumberTaskWithPHR(string PHRNumber)
        {
            fboPhrPage.CompleteFBOorPHRNumberTaskWithPHRNumber(PHRNumber);
        }

        [When(@"enter FBO number '([^']*)' for FBO or PHR number task")]
        public void WhenCompleteFBOOrPHRNumberTaskWithFBO(string FBONumber)
        {
            fboPhrPage.CompleteFBOorPHRNumberTaskWithFBONumber(FBONumber);
        }

        [Then(@"verify hint text '([^']*)' on FBO PHR page")]
        public void ThenVerifyOnCompletedSignUpPage(string hintText)
        {
            Assert.True(fboPhrPage.VerifyHintTextMessage(hintText), "Mismatching the hint text on FBO PHR page");
        }

        [Then(@"verify FBOorPHRNumber task status as '([^']*)'")]
        public void ThenVerifyFBOorPHRNumberTaskStatus(String status)
        {
            Assert.True(fboPhrPage.VerifyFBOorPHRNumberTaskStatus(status), "FBOorPHRNumber not completed");
        }

        [Then(@"verify dynamic name '([^']*)' on eligibility task on SPS Assurance page with '([^']*)'")]
        public void ThenVerifyDynamicNameOnEligibilityTaskOnSPSAssurancePageWith(string Name, string country)
        {
            Assert.True(fboPhrPage.VerifyDynamicNameOnSPSAssurancePage(Name, country), "Dynamic business not matching on SPS Assurance Page");
        }
    }
}
