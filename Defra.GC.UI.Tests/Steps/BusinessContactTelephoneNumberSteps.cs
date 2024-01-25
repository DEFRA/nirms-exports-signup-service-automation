using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class BusinessContactTelephoneNumberSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IBusinessContactTelephoneNumberPage? contactTelephoneNumberPage => _objectContainer.IsRegistered<IBusinessContactTelephoneNumberPage>() ? _objectContainer.Resolve<IBusinessContactTelephoneNumberPage>() : null;
        public BusinessContactTelephoneNumberSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }

        [When(@"enter telephone number '([^']*)'")]
        [Then(@"enter telephone number '([^']*)'")]
        public void ThenEnterTelephoneNumber(string telephoneNumber)
        {
            contactTelephoneNumberPage.EnterTelephoneNumber(telephoneNumber);
        }

        [When(@"click on save and continue on Contact Number page")]
        [Then(@"click on save and continue on Contact Number page")]
        public void ThenClickOnSaveAndContinue()
        {
            contactTelephoneNumberPage.ClickOnSaveAndContinue();
        }

        [Then(@"verify error message '([^']*)' on contact telephone number page")]
        public void ThenVerifyErrorMessageOnContactTelephoneNumberPage(string errorMessage)
        {
            Assert.True(contactTelephoneNumberPage.VerifyErrorMessageOnContactTelephoneNumberPage(errorMessage), "contact telephone number error message not matching");
        }

        [Then(@"click on contact telephone number link")]
        public void ThenClickOnContactTelephoneNumberLink()
        {
            contactTelephoneNumberPage.ClickOnContactTelephoneNumberLink();
        }
    }
}
