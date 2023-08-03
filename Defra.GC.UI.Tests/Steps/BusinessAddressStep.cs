using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class BusinessAddressStep
    {
        private readonly object _lock = new object();
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public BusinessAddressStep(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private ISignInPage? Signin => _objectContainer.IsRegistered<ISignInPage>() ? _objectContainer.Resolve<ISignInPage>() : null;

        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private IBusinessAddressPage? BusinessAddressPagetest => _objectContainer.IsRegistered<IBusinessAddressPage>() ? _objectContainer.Resolve<IBusinessAddressPage>() : null;

        [When(@"user navigates to registered address page")]
        public void WhenUserNavigatesToRegisteredAddressPage()
        {
            BusinessAddressPagetest.ClickOnRegisteredAddres();
        }

        [Then(@"user verifies address error message")]
        public void ThenUserVerifiesAddressErrorMessage(Table table)
        {
            List<string> errorlist = BusinessAddressPagetest.ErrorValidation();
            int i = 0;
            foreach (TableRow row in table.Rows)
            {
                string value = row["Value"];
                Assert.AreEqual(value, errorlist[i++]);
            }
        }

        [Then(@"user verifies invalid error message")]
        public void ThenUserVerifiesInvalidErrorMessage(Table table)
        {
            List<string> errorlist = BusinessAddressPagetest.ErrorValidation();
            int i = 0;
            foreach (TableRow row in table.Rows)
            {
                string value = row["Value"];
                Assert.AreEqual(value, errorlist[i++]);
            }
        }

        [When(@"user enters manually all address fields  '([^']*)', '([^']*)',  '([^']*)'")]
        public void WhenUserEntersManuallyAllAddressFields(string p0, string testCity, string testCode)
        {
            BusinessAddressPagetest.EnterBusinessAddress(p0, testCity, testCode);
        }

        [Then(@"user verifies invalid error message for address data")]
        public void ThenUserVerifiesInvalidErrorMessageForAddressData(Table table)
        {
            List<string> errorlist = BusinessAddressPagetest.ErrorValidation();
            int i = 0;

            foreach (TableRow row in table.Rows)
            {
                string value = row["Value"];
                Assert.AreEqual(value, errorlist[i++]);
            }
        }


        [Then(@"user  navigates back to task list page from Address page")]
        public void ThenUserNavigatesBackToTaskListPageFromAddressPage()
        {
            BusinessAddressPagetest.VerifyUserinTaskListPage();
        }

        [Then(@"click on save and continue on Address page")]
        public void ThenClickOnSaveAndContinueOnAddressPage()
        {
            BusinessAddressPagetest.ClickOnSaveAndContinue();
        }

        [When(@"user verify the address status '([^']*)'")]
        [Then(@"user verify the address status '([^']*)'")]
        public void ThenUserVerifyTheAddressStatus(string status)
        {
            Assert.True(BusinessAddressPagetest.VerifyAddressStatus(status), "Status is Invalid");
        }
    }
}