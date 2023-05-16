using BoDi;
using Defra.GC.UI.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Defra.GC.UI.Tests.Pages;
using Defra.GC.UI.Tests.Data.Users;

namespace Defra.GC.UI.Tests.Steps
{
    [Binding]
    public class BusinessStep
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private ISignInPage? Signin => _objectContainer.IsRegistered<ISignInPage>() ? _objectContainer.Resolve<ISignInPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        public BusinessStep(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"user is in Business details page")]
        public void WhenUserIsInBusinessDetailsPage()
        {
        }

        [When(@"user enters Business name and click on save continue")]
        public void WhenUserEntersBusinessNameAndClickOnSaveContinue()
        {
        }

        [Then(@"user verifys sucessfully addded business name")]
        public void ThenUserVerifysSucessfullyAdddedBusinessName()
        {
        }
    }
}