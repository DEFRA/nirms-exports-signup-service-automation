using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class BusinessContactPositionSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IBusinessContactPositionPage? contactPositionPage => _objectContainer.IsRegistered<IBusinessContactPositionPage>() ? _objectContainer.Resolve<IBusinessContactPositionPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        public BusinessContactPositionSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }

        [Then(@"navigate to business contact position page")]
        public void ThenNavigateToBusinessContactNamePage()
        {
            contactPositionPage.NavigateToBusinessContactPositionPage();
        }

        [Then(@"enter business contact position '([^']*)'")]
        public void ThenEnterBusinessContactPosition(string ContactPosition)
        {
            contactPositionPage.EnterBusinessContactPosition(ContactPosition);
        }

        [Then(@"verify error message on business contact position page")]
        public void ThenVerifyErrorMessageOnBusinessContactPositionPage()
        {
            contactPositionPage.VerifyErrorMessageOnBusinessContactPositionPage();
        }

        [Then(@"click on business contact position link")]
        public void ThenClickOnBusinessContactPositionLink()
        {
            contactPositionPage.ClickOnBusinessContactPositionLink();
        }
    }
}
