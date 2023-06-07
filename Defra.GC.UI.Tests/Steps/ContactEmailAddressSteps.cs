using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class ContactEmailAddressSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private IContactEmailAddressPage? contactEmailAddressPage => _objectContainer.IsRegistered<IContactEmailAddressPage>() ? _objectContainer.Resolve<IContactEmailAddressPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        public ContactEmailAddressSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }

        [Then(@"navigate to contact email address page")]
        public void ThenNavigateToContactEmailAddressPage()
        {
            contactEmailAddressPage.NavigateToContactEmailAddressPage();
        }

        [Then(@"enter email address '([^']*)'")]
        public void ThenEnterEmailAddress(string emailAddress)
        {
            contactEmailAddressPage.EnterEmailAddress(emailAddress);
        }

        [Then(@"click on save and continue")]
        public void ThenClickOnSaveAndContinue()
        {
            contactEmailAddressPage.ClickOnSaveAndContinue();
        }

        [Then(@"verify next page '([^']*)' is loaded")]
        public void ThenVerifyNextPageIsLoaded(string pageName)
        {
            contactEmailAddressPage.VerifyNextPageIsLoaded(pageName);
        }

        [Then(@"verify error message on contact email address page")]
        public void ThenVerifyErrorMessageOnContactEmailAddressPage()
        {
            contactEmailAddressPage.VerifyErrorMessageOnContactEmailAddressPage();
        }

        [Then(@"verify signUp task list page is loaded")]
        public void ThenVerifySignUpTaskListPageIsLoaded()
        {
            contactEmailAddressPage.VerifySignUpTaskListPageIsLoaded();
        }

        [Then(@"click on back link")]
        public void ThenClickOnBackLink()
        {
            contactEmailAddressPage.ClickOnBackLink();
        }


        [Then(@"navigate to task list page")]
        public void ThenNavigateToTaskListPage()
        {
            contactEmailAddressPage.NavigateToTaskListPage();
        }

        [Then(@"click on contact email address link")]
        public void ThenClickOnContactEmailAddressLink()
        {
            contactEmailAddressPage.ClickOnContactEmailAddressLink();
        }

        [Then(@"click save and continue later")]
        public void ThenClickSaveAndContinueLater()
        {
            contactEmailAddressPage.ClickSaveAndContinueLater();
        }
    }
}
