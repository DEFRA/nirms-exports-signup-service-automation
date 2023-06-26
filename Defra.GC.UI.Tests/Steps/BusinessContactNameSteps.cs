using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class BusinessContactNameSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IBusinessContactNamePage? contactNamePage => _objectContainer.IsRegistered<IBusinessContactNamePage>() ? _objectContainer.Resolve<IBusinessContactNamePage>() : null;
        public BusinessContactNameSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }

        [When(@"complete Business contact details task with '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenCompleteBusinessContactDetailsTaskWith(string contactName, string contactPosition, string contactEmail, string contactTelephone)
        {
            contactNamePage.CompleteBusinessContactDetailsTask(contactName, contactPosition, contactEmail, contactTelephone);
        }

        [When(@"enter business contact person '([^']*)'")]
        [Then(@"enter business contact person '([^']*)'")]
        public void ThenEnterBusinessContactName(string ContactName)
        {
            contactNamePage.EnterBusinessContactName(ContactName);
        }

        [When(@"click on save and continue on business contact name page")]
        [Then(@"click on save and continue on business contact name page")]
        public void ThenClickOnSaveAndContinue()
        {
            contactNamePage.ClickOnSaveAndContinue();
        }

        [Then(@"verify error message '([^']*)' on business contact name page")]
        public void ThenVerifyErrorMessageOnBusinessContactNamePage(string errorMessage)
        {
            Assert.True(contactNamePage.VerifyErrorMessageOnBusinessContactNamePage(errorMessage), "Full Name error message not matching");

        }

        [When(@"click on business contact details link")]
        [Then(@"click on business contact details link")]
        public void ThenClickOnBusinessContactDetailsLink()
        {
            contactNamePage.ClickOnBusinessContactDetailsLink();
        }

        [Then(@"user verify the business contact details status '([^']*)'")]
        public void ThenUserVerifyTheBusinessContactDetailsStatus(string status)
        {
             Assert.True(contactNamePage.VerifyTheBusinessContactDetailsStatus(status), "Status is Invalid");
        }

    }
}
