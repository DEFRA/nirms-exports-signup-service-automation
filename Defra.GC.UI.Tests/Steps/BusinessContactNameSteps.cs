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

        [Then(@"enter business contact name '([^']*)'")]
        public void ThenEnterBusinessContactName(string ContactName)
        {
            contactNamePage.EnterBusinessContactName(ContactName);
        }

        [Then(@"click on save and continue on contact full name page")]
        public void ThenClickOnSaveAndContinue()
        {
            contactNamePage.ClickOnSaveAndContinue();
        }

        [Then(@"verify error message '([^']*)' on business contact name page")]
        public void ThenVerifyErrorMessageOnBusinessContactNamePage(string errorMessage)
        {
            Assert.True(contactNamePage.VerifyErrorMessageOnBusinessContactNamePage(errorMessage), "Full Name error message not matching");

        }

        [Then(@"click on business contact name link")]
        public void ThenClickOnBusinessContactNameLink()
        {
            contactNamePage.ClickOnBusinessContactNameLink();
        }
    }
}
