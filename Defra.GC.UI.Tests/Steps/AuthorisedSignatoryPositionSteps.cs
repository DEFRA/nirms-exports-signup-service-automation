using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class AuthorisedSignatoryPositionSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IAuthorisedSignatoryPositionPage? authcontactPositionPage => _objectContainer.IsRegistered<IAuthorisedSignatoryPositionPage>() ? _objectContainer.Resolve<IAuthorisedSignatoryPositionPage>() : null;
        public AuthorisedSignatoryPositionSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }

        [When(@"user enters '([^']*)' position on Authorised signatory position page")]
        [Then(@"user enters '([^']*)' position on Authorised signatory position page")]
        public void ThenEnterAuthorisedSignatoryPosition(string AuthPosition)
        {
            authcontactPositionPage.EnterAuthSignatoryPosition(AuthPosition);
        }

        [When(@"click on save and continue on Authorised signatory position page")]
        [Then(@"click on save and continue on Authorised signatory position page")]
        public void ThenClickOnSaveAndContinue()
        {
            authcontactPositionPage.ClickOnSaveAndContinue();
        }


        [Then(@"verify error message '([^']*)' on Authorised signatory position page")]
        public void ThenVerifyErrorMessageOnBusinessContactPositionPage(string errorMessage)
        {
            Assert.True(authcontactPositionPage.VerifyErrorMessageOnAuthSignatoryPositionPage(errorMessage), "authorised signatory position error message not matching");

        }


    }
}
