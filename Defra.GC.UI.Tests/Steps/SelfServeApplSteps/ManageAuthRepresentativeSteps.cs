using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps.SelfServeApplSteps
{

    [Binding]
    public class ManageAuthRepresentativeSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IManageAuthRepresentativePage? manageAuthRepresentativePage => _objectContainer.IsRegistered<IManageAuthRepresentativePage>() ? _objectContainer.Resolve<IManageAuthRepresentativePage>() : null;

        public ManageAuthRepresentativeSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"enter Authorised Representative Name '([^']*)'")]
        public void WhenEnterAuthorisedRepresentativeName(string name)
        {
            manageAuthRepresentativePage.EnterAuthorisedRepresentativeName(name);
        }

        [When(@"enter Authorised Representative Position '([^']*)'")]
        public void WhenEnterAuthorisedRepresentativePosition(string position)
        {
            manageAuthRepresentativePage.EnterAuthorisedRepresentativePosition(position);
        }

        [When(@"enter Authorised Representative Email address '([^']*)'")]
        public void WhenEnterAuthorisedRepresentativeEmailAddress(string emailAddress)
        {
            manageAuthRepresentativePage.EnterAuthorisedRepresentativeEmailAddress(emailAddress);
        }

        [When(@"click on save Authorised Representative details")]
        public void WhenClickOnSaveAuthorisedRepresentativeDetails()
        {
            manageAuthRepresentativePage.SaveAuthorisedRepresentativeDetails();
        }

        [Then(@"verify Authorised Representative details as '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenVerifyAuthorisedRepresentativeDetailsAs(string p0, string p1, string p2)
        {
            Assert.True(manageAuthRepresentativePage.VerifyAuthorisedRepresentativeDetailsAs(p0, p1, p2), "Auth Representative details not matching");
        }

        [When(@"verify error messages '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        [Then(@"verify error messages '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenVerifyErrorMessages(string p0, string p1, string p2, string p3)
        {
            Assert.True(manageAuthRepresentativePage.VerifyErrorMessages(p0, p1, p2, p3), "Error Messages not matching");
        }


    }
}
