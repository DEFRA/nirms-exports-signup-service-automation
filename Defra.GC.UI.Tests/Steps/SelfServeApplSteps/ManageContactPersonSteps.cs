using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps.SelfServeApplSteps
{
    [Binding]
    public class ManageContactPersonSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IManageContactPersonPage? manageContactPersonPage => _objectContainer.IsRegistered<IManageContactPersonPage>() ? _objectContainer.Resolve<IManageContactPersonPage>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        public ManageContactPersonSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"enter contact person Name '([^']*)'")]
        public void WhenEnterContactPersonName(string name)
        {
            manageContactPersonPage.enterContactPersonName(name);
        }

        [When(@"enter contact person Position '([^']*)'")]
        public void WhenEnterContactPersonPosition(string position)
        {
            manageContactPersonPage.enterContactPersonposition(position);
        }

        [When(@"enter contact person Email address '([^']*)'")]
        public void WhenEnterContactPersonEmailAddress(string emailAddress)
        {
            manageContactPersonPage.enterContactPersonEmailAddress(emailAddress);
        }

        [When(@"enter contact person Telephone number '([^']*)'")]
        public void WhenEnterContactPersonTelephoneNumber(string TelephoneNumber)
        {
            manageContactPersonPage.enterContactPersonTelephoneNumber(TelephoneNumber);
        }

        [When(@"click on save contact person details")]
        public void WhenClickOnSaveContactPersonDetails()
        {
            manageContactPersonPage.clickOnSaveContactPersonDetails();
        }

        [Then(@"verify contact person details as '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenVerifyContactPersonDetailsAs(string name, string position, string emailAddress, string TelephoneNumber)
        {
            Assert.True(manageContactPersonPage.verifyContactPersonDetails(name,position,emailAddress,TelephoneNumber), "Contact person details not matching");
        }

    }
}
