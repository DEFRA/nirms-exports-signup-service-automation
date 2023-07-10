using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class AuthorisedSignatorySteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IAuthorisedSignatoryPage? authorisedSignatoryPage => _objectContainer.IsRegistered<IAuthorisedSignatoryPage>() ? _objectContainer.Resolve<IAuthorisedSignatoryPage>() : null;

        public AuthorisedSignatorySteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"click on Authorised Signatory link")]
        public void WhenClickOnAuthorisedSignatoryLink()
        {
            Assert.True(authorisedSignatoryPage.ClickOnAuthorisedSignatoryLink(), "Authorised Signatory page not loaded");
        }

        [When(@"select '([^']*)' to the contact person is the Authorised Signatory")]
        public void WhenSelectToTheContactPersonIsTheAuthorisedSignatory(string Authorisation)
        {
            authorisedSignatoryPage.SelectAuthorisedSignatory(Authorisation);
        }

        [When(@"complete contact person Authorised Signatory with Yes Authorisation")]
        public void WhenCompleteContactPersonAuthorisedSignatoryWithYes()
        {
            authorisedSignatoryPage.CompleteContactPersonAuthorisedSignatoryWithYes();
        }

        [Then(@"verify error message '([^']*)' on Authorised Signatory page")]
        public void ThenVerifyErrorMessageOnAuthorisedSignatoryPage(string errorMessage)
        {
            Assert.True(authorisedSignatoryPage.VerifyErrorMessageOnAuthorisedPage(errorMessage), "Invalid error on Authorised  page");
        }

        [Then(@"user verify the Authorised Signatory status '([^']*)'")]
        public void ThenUserVerifyTheAuthorisedSignatoryStatus(string status)
        {
            Assert.True(authorisedSignatoryPage.VerifyTheAuthorisedSignatoryStatus(status), "Authorised Signatory Status not matching");
        }
    }
}