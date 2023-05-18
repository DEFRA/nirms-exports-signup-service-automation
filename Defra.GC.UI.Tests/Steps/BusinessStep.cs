using BoDi;
using Defra.GC.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Defra.GC.UI.Tests.Pages;
using Defra.GC.UI.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace Defra.GC.UI.Tests.Steps
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
    }
}