using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;


namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class BusinessNameStep
    {
        private readonly object _lock = new object();
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public BusinessNameStep(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IBusinessNamePage? BusinessNamePagetest => _objectContainer.IsRegistered<IBusinessNamePage>() ? _objectContainer.Resolve<IBusinessNamePage>() : null;

        [Then(@"user verifies the ""([^""]*)"" error message")]
        public void ThenUserVerifiesTheErrorMessage(string p0)
        {
            string error = BusinessNamePagetest.SelectWithoutCountryAndVerifyMessage();
            StringAssert.Contains(p0, error);
        }

        [Then(@"user verifies the ""([^""]*)"" error message when user clicks on save button without Business name")]
        public void ThenUserVerifiesTheErrorMessageWhenUserClicksOnSaveButtonWithoutBusinessName(string p0)
        {
            string error = BusinessNamePagetest.WithoutBusinessNameValidation();
            StringAssert.Contains(p0, error);
        }

        [Then(@"user verifies the ""([^""]*)"" error message for Business name")]
        public void ThenUserVerifiesTheErrorMessageForBusinessName(string p0)
        {
            string error = BusinessNamePagetest.ValidateInvalidErrorMessage();
            StringAssert.Contains(p0, error);
        }

        [Then(@"verify error message '([^']*)' on  Business name page")]
        public void ThenVerifyErrorMessageOnBusinessNamePage(string errorMessage)
        {
            Assert.True(BusinessNamePagetest.VerifyErrorMessageOnBusinessNamePage(errorMessage), "Business name error message not matching");
        }

        [When(@"user is in Business name page")]
        public void WhenUserIsInBusinessNamePage()
        {
            BusinessNamePagetest.ClickonBusinessName();
        }

        [When(@"user clicks back button")]
        public void WhenUserClicksBackButton()
        {
            BusinessNamePagetest.ClickonBusinessBacklink();
        }

        [When(@"user clicks on Save and continue later link")]
        public void WhenUserClicksOnSaveAndContinueLaterLink()
        {
            BusinessNamePagetest.ClickonSaveContinuelaterlink();
            BusinessNamePagetest.VerifyUserinTaskListPage();
        }

        [Then(@"user  navigates back to task list page")]
        public void ThenUserNavigatesBackToTaskListPage()
        {
            BusinessNamePagetest.VerifyUserinTaskListPage();
        }

        [When(@"user enters Business name  '([^']*)'")]
        public void WhenUserEntersBusinessName(string dEFRA)
        {
            BusinessNamePagetest.EnterBusinessName(dEFRA);
        }

        [Then(@"click on save and continue on Business Name page")]
        public void ThenClickOnSaveAndContinueOnBusinessNamePage()
        {
            BusinessNamePagetest.ClickOnSaveAndContinue();
        }

        [Then(@"user verify the business name status '([^']*)'")]
        public void ThenUserVerifyTheBusinessStatus(string status)
        {
            Assert.True(BusinessNamePagetest.VerifyBusinessNameStatus(status), "Status is Invalid");
        }

        [When(@"complete Business name task with '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenCompleteBusinessNameTaskWith(string businessName, string businessAddr, string businessTown, string addrPostcode)
        {
            BusinessNamePagetest.CompleteBusinessNameTask(businessName, businessAddr, businessTown, addrPostcode);
        }

    }
}