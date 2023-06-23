using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class BusinessContactPositionSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IBusinessContactPositionPage? contactPositionPage => _objectContainer.IsRegistered<IBusinessContactPositionPage>() ? _objectContainer.Resolve<IBusinessContactPositionPage>() : null;
        public BusinessContactPositionSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }

        [Then(@"navigate to business contact position page")]
        public void ThenNavigateToBusinessContactNamePage()
        {
            contactPositionPage.NavigateToBusinessContactPositionPage();
        }

        [When(@"enter business contact position '([^']*)'")]
        [Then(@"enter business contact position '([^']*)'")]
        public void ThenEnterBusinessContactPosition(string ContactPosition)
        {
            contactPositionPage.EnterBusinessContactPosition(ContactPosition);
        }

        [When(@"click on save and continue on contact position page")]
        [Then(@"click on save and continue on contact position page")]
        public void ThenClickOnSaveAndContinue()
        {
            contactPositionPage.ClickOnSaveAndContinue();
        }


        [Then(@"verify error message '([^']*)' on business contact position page")]
        public void ThenVerifyErrorMessageOnBusinessContactPositionPage(string errorMessage)
        {
            Assert.True(contactPositionPage.VerifyErrorMessageOnBusinessContactPositionPage(errorMessage), "contact position error message not matching");

        }

        [Then(@"click on business contact position link")]
        public void ThenClickOnBusinessContactPositionLink()
        {
            contactPositionPage.ClickOnBusinessContactPositionLink();
        }
    }
}
