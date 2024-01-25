using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps.SelfServeApplSteps
{
    [Binding]

    public class AddEstablishmentSteps
    {

        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IAddEstablishmentPage? addEstablishmentPage => _objectContainer.IsRegistered<IAddEstablishmentPage>() ? _objectContainer.Resolve<IAddEstablishmentPage>() : null;

        public AddEstablishmentSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"click on link '([^']*)'")]
        public void WhenClickOnLink(string linkText)
        {
            addEstablishmentPage.ClickOnLink(linkText);

        }

        [Then(@"verify links on establishment page '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenVerifyLinksOnEstablishmentPage(string link1, string link2, string link3)
        {
            Assert.True(addEstablishmentPage.VerifyLinksOnEstablishmentPage(link1,link2,link3),"Links are establishment page not matched");
        }

    }
}
