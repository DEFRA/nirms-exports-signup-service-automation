using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps.SelfServeApplSteps
{

    [Binding]
    public class SelfServeDashboadSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private ISelfServeDashboardPage? selfServeDashboardPage => _objectContainer.IsRegistered<ISelfServeDashboardPage>() ? _objectContainer.Resolve<ISelfServeDashboardPage>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        public SelfServeDashboadSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"select business '([^']*)' on self serve dashboard")]
        public void WhenSelectBusinessToSignUponSelfServe(string businessSelection)
        {
            selfServeDashboardPage.SelectBusinessOnSelfServe(businessSelection);
        }

        [Then(@"verify Business RMS number '([^']*)' on self serve dashboard page")]
        public void ThenVerifyBusinessRMSNumberOnSelfServeDashboardPage(string BusinessRMSNumber)
        {
            Assert.True(selfServeDashboardPage.VerifyBusinessRMSNumber(BusinessRMSNumber), "Business RMS Number is not matching");
        }

    }
}
