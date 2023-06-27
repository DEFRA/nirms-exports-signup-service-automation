using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class BusinessContactEmailAddressSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IBusinessContactEmailAddressPage? contactEmailAddressPage => _objectContainer.IsRegistered<IBusinessContactEmailAddressPage>() ? _objectContainer.Resolve<IBusinessContactEmailAddressPage>() : null;
        public BusinessContactEmailAddressSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }

        [When(@"enter email address '([^']*)'")]
        [Then(@"enter email address '([^']*)'")]
        public void ThenEnterEmailAddress(string emailAddress)
        {
            contactEmailAddressPage.EnterEmailAddress(emailAddress);
        }

        [When(@"click on save and continue on contact email address page")]
        [Then(@"click on save and continue on contact email address page")]
        public void ThenClickOnSaveAndContinue()
        {
            contactEmailAddressPage.ClickOnSaveAndContinue();
        }


        [Then(@"verify error message '([^']*)' on contact email address page")]
        public void ThenVerifyErrorMessageOnContactEmailAddressPage(string errorMessage)
        {
            Assert.True(contactEmailAddressPage.VerifyErrorMessageOnContactEmailAddressPage(errorMessage), "contact email address error message not matching");
        }

        [Then(@"click on contact email address link")]
        public void ThenClickOnContactEmailAddressLink()
        {
            contactEmailAddressPage.ClickOnContactEmailAddressLink();
        }
    }
}
