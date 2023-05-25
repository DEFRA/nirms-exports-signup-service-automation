using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
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
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        public BusinessContactTelephoneNumberSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }

        [Then(@"navigate to contact telephone number page")]
        public void ThenNavigateToContactTelephoneNumberPage()
        {
            contactTelephoneNumberPage.NavigateToContactTelephoneNumberPage();
        }

        [Then(@"enter telephone number '([^']*)'")]
        public void ThenEnterTelephoneNumber(string telephoneNumber)
        {
            contactTelephoneNumberPage.EnterTelephoneNumber(telephoneNumber);
        }

        [Then(@"click on save and continue")]
        public void ThenClickOnSaveAndContinue()
        {
            contactTelephoneNumberPage.ClickOnSaveAndContinue();
        }

        [Then(@"verify next page '([^']*)' is loaded")]
        public void ThenVerifyNextPageIsLoaded(string pageName)
        {
            contactTelephoneNumberPage.VerifyNextPageIsLoaded(pageName);
        }

        [Then(@"verify error message on contact telephone number page")]
        public void ThenVerifyErrorMessageOnContactTelephoneNumberPage()
        {
            contactTelephoneNumberPage.VerifyErrorMessageOnContactTelephoneNumberPage();
        }

        [Then(@"verify signUp task list page is loaded")]
        public void ThenVerifySignUpTaskListPageIsLoaded()
        {
            contactTelephoneNumberPage.VerifySignUpTaskListPageIsLoaded();
        }

        [Then(@"click on back link")]
        public void ThenClickOnBackLink()
        {
            contactTelephoneNumberPage.ClickOnBackLink();
        }


        [Then(@"navigate to task list page")]
        public void ThenNavigateToTaskListPage()
        {
            contactTelephoneNumberPage.NavigateToTaskListPage();
        }

        [Then(@"click on contact telephone number link")]
        public void ThenClickOnContactTelephoneNumberLink()
        {
            contactTelephoneNumberPage.ClickOnContactTelephoneNumberLink();
        }

        [Then(@"click save and continue later")]
        public void ThenClickSaveAndContinueLater()
        {
            contactTelephoneNumberPage.ClickSaveAndContinueLater();
        }
    }
}
