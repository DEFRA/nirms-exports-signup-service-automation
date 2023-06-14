using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
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
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        public BusinessContactEmailAddressSteps(ScenarioContext context, IObjectContainer container)
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
