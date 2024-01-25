using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class AuthorisedSignatoryNameSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IAuthorisedSignatoryNamePage? authorisedSignatoryNamePage => _objectContainer.IsRegistered<IAuthorisedSignatoryNamePage>() ? _objectContainer.Resolve<IAuthorisedSignatoryNamePage>() : null;
        public AuthorisedSignatoryNameSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }

        [When(@"user is on Authorised Signatory Enter name page")]
        public void ClickonEnterAuthorisedSignatoryName()
        {
            authorisedSignatoryNamePage.ClickonFullName();
        }

        [When(@"user enters manually '([^']*)' in the full name feild")]
        [Then(@"user enters manually '([^']*)' in the full name feild")]
        public void EnterFullName(string dEFRA)
        {
            authorisedSignatoryNamePage.EnterFullName(dEFRA);
        }

        [Then(@"click on save and continue on Authorised signatory Enter Name page")]
        public void ThenClickOnSaveAndContinueOnBusinessNamePage()
        {
            authorisedSignatoryNamePage.ClickOnSaveAndContinue();
        }

        [Then(@"user verifies the '([^""]*)' error message for Authorised Signatory name")]
        public void ThenUserVerifiesTheErrorMessageForAuthSignatoryName(string errorMessage)
        {
            Assert.True(authorisedSignatoryNamePage.VerifyErrorMessageOnAuthorisedSignatoryNamePage(errorMessage), "authorised signatory name error message not matching");
        }
    }
}



