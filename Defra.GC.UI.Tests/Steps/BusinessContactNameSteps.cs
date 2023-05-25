using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
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
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        public BusinessContactNameSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }

        [Then(@"navigate to business contact name page")]
        public void ThenNavigateToBusinessContactNamePage()
        {
            contactNamePage.NavigateToBusinessContactNamePage();
        }

        [Then(@"enter business contact name '([^']*)'")]
        public void ThenEnterBusinessContactName(string ContactName)
        {
            contactNamePage.EnterBusinessContactName(ContactName);
        }

        [Then(@"verify error message on business contact name page")]
        public void ThenVerifyErrorMessageOnBusinessContactNamePage()
        {
            contactNamePage.VerifyErrorMessageOnBusinessContactNamePage();
        }

        [Then(@"click on business contact name link")]
        public void ThenClickOnBusinessContactNameLink()
        {
            contactNamePage.ClickOnBusinessContactNameLink();
        }
    }
}
