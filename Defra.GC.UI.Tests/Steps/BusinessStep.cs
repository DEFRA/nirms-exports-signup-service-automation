using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using static System.Net.Mime.MediaTypeNames;
using Defra.UI.Framework.Driver;
using System;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class BusinessStep
    {
        private readonly object _lock = new object();
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public BusinessStep(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private ISignInPage? Signin => _objectContainer.IsRegistered<ISignInPage>() ? _objectContainer.Resolve<ISignInPage>() : null;

        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private IBusinessPage? BusinessPagetest => _objectContainer.IsRegistered<IBusinessPage>() ? _objectContainer.Resolve<IBusinessPage>() : null;

        [When(@"user navigates to registered address page")]
        public void WhenUserNavigatesToRegisteredAddressPage()
        {
            BusinessPagetest.ClickOnRegisteredAddres();
        }

        [When(@"user clicks  save continue button without entering value")]
        public void WhenUserClicksSaveContinueButtonWithoutEnteringValue()
        {
            BusinessPagetest.ClickOnSaveAndContinuebuttonWithoutAddress();
        }

        [Then(@"user verifies address error message")]
        public void ThenUserVerifiesAddressErrorMessage(Table table)
        {
            List<string> errorlist = BusinessPagetest.ErrorValidation();
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
            List<string> errorlist = BusinessPagetest.ErrorValidation();
            int i = 0;
            foreach (TableRow row in table.Rows)
            {
                string value = row["Value"];
                Assert.AreEqual(value, errorlist[i++]);
            }
        }

        [When(@"user is in country details page")]
        public void WhenUserIsInCountryDetailsPage()
        {
            BusinessPagetest.ClickOnEligiblity();
        }

        [When(@"user clicks on Check eligibility link")]
        public void WhenUserClicksOnCheckEligibilityLink()
        {
            BusinessPagetest.ClickOnEligiblity();
        }

        [When(@"user selects country name and click on save continue")]
        public void WhenUserEntersCountryNameAndClickOnSaveContinue()
        {
            BusinessPagetest.SelectCountry();
        }

        [When(@"user enters address and click on save continue")]
        public void WhenUserEntersAddressAndClickOnSaveContinue()
        {
            BusinessPagetest.EntertheAddress();
            BusinessPagetest.VerifyUserinTaskListPage();
        }

        [When(@"user enters invalid adderror message for Business nameress and click on save continue")]
        public void WhenUserEntersInvalidAddressAndClickOnSaveContinue()
        {
            BusinessPagetest.EnterInvalidAddress();
        }

        [Then(@"user verifies the ""([^""]*)"" error message")]
        public void ThenUserVerifiesTheErrorMessage(string p0)
        {
            string error = BusinessPagetest.SelectWithoutCountryAndVerifyMessage();
            StringAssert.Contains(p0, error);
        }

        [Then(@"user verifies the ""([^""]*)"" error message when user clicks on save button without Business name")]
        public void ThenUserVerifiesTheErrorMessageWhenUserClicksOnSaveButtonWithoutBusinessName(string p0)
        {
            string error = BusinessPagetest.WithoutBusinessNameValidation();
            StringAssert.Contains(p0, error);
        }

        [Then(@"user verifies the ""([^""]*)"" error message for Business name")]
        public void ThenUserVerifiesTheErrorMessageForBusinessName(string p0)
        {
            string error = BusinessPagetest.ValidateInvalidErrorMessage();
            StringAssert.Contains(p0, error);
        }

        [Then(@"verify error message '([^']*)' on  Business name page")]
        public void ThenVerifyErrorMessageOnBusinessNamePage(string errorMessage)
        {
            Assert.True(BusinessPagetest.VerifyErrorMessageOnBusinessNamePage(errorMessage), "Business name error message not matching");
        }

        //[Then(@"user verifies the ""([^""]*)"" address error message")]
        //public void ThenUserVerifiesTheAddressErrorMessage(string p0)
        //{
        //    string error = BusinessPagetest.ClickOnSaveAndContinuebuttonWithoutAddress();
        //    StringAssert.Contains(p0, error);
        //}

        [When(@"user is in Business details page")]
        public void WhenUserIsInBusinessDetailsPage()
        {
            BusinessPagetest.ClickonBusiness();
        }

        [When(@"user enters Business name and click on save continue")]
        public void WhenUserEntersBusinessNameAndClickOnSaveContinue()
        {
            BusinessPagetest.EnterBusinessName();
        }

        [Then(@"user verifys sucessfully addded business name")]
        public void ThenUserVerifysSucessfullyAdddedBusinessName()
        {
        }

        [When(@"user enters invalid Business name")]
        public void WhenUserEntersInvalidBusinessName()
        {
            BusinessPagetest.EnterInvalidBusinessName();
        }

        [Then(@"user verifies the invalid error message")]
        public void ThenUserVerifiesTheInvalidErrorMessage()
        {
        }

        [When(@"user clicks back button")]
        public void WhenUserClicksBackButton()
        {
            BusinessPagetest.ClickonBusinessBacklink();
        }

        [When(@"user clicks on Save and continue later link")]
        public void WhenUserClicksOnSaveAndContinueLaterLink()
        {
            BusinessPagetest.ClickonSaveContinuelaterlink();
            BusinessPagetest.VerifyUserinTaskListPage();
        }

        [Then(@"user  navigates back to task list page")]
        public void ThenUserNavigatesBackToTaskListPage()
        {
            BusinessPagetest.VerifyUserinTaskListPage();
        }
    }
}