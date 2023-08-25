using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]

    public class ManageAccountSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IManageAccountPage? manageAccountPage => _objectContainer.IsRegistered<IManageAccountPage>() ? _objectContainer.Resolve<IManageAccountPage>() : null;

        public ManageAccountSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }


        [Then(@"verify Manage Account Link")]
        public void ThenVerifyManageAccountLink()
        {
            Assert.True(manageAccountPage.VerifyManageAccountLink(), "Manage Account Link has not loaded correct page");
        }

        [Then(@"verify Add New Account Link")]
        public void ThenVerifyAddNewAccountLink()
        {
            Assert.True(manageAccountPage.VerifyAddNewAccountLink(), "Add New Account Link has not loaded correct page");
        }
    }
}
