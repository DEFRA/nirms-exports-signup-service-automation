using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class AuthorisedSignatoryEmailAddressSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IAuthorisedSignatoryEmailAddressPage? authSignatoryEmailAddressPage => _objectContainer.IsRegistered<IAuthorisedSignatoryEmailAddressPage>() ? _objectContainer.Resolve<IAuthorisedSignatoryEmailAddressPage>() : null;
        public AuthorisedSignatoryEmailAddressSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }
        [When(@"user is on Authorised Signatory Email address page")]
        public void ClickonEnterAuthorisedSignatoryName()
        {
            authSignatoryEmailAddressPage.ClickOnAuthEmailAddres();
        }

        [When(@"user enters manually '([^']*)' in email address page")]
        [Then(@"user enters manually '([^']*)' in email address page")]
        public void ThenEnterEmailAddress(string emailAddress)
        {
            authSignatoryEmailAddressPage.EnterAuthEmailAddress(emailAddress);
        }

        [When(@"click on save and continue on Authorised Signatory Email address page")]
        [Then(@"click on save and continue on Authorised Signatory Email address page")]
        public void ThenClickOnSaveAndContinue()
        {
            authSignatoryEmailAddressPage.ClickOnSaveAndContinue();
        }


        [Then(@"verify error message '([^']*)' on authorised signatory email address page")]
        public void ThenVerifyErrorMessageOnAuthSignatoryEmailAddressPage(string errorMessage)
        {
            Assert.True(authSignatoryEmailAddressPage.ValidateInvalidErrorMessage(errorMessage), "auth signatory email address error message not matching");
        }

      

    }
}
