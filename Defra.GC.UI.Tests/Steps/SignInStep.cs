using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.GC.UI.Tests.Configuration;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class SigninSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private ISignInPage? Signin => _objectContainer.IsRegistered<ISignInPage>() ? _objectContainer.Resolve<ISignInPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        public SigninSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Given(@"that I navigate to the NI GC application")]
        [When(@"that I navigate to the NI GC application")]
        public void GivenThatINavigateToTheGCApplication()
        {
            string url = UrlBuilder.Default().Build();
            _driver.Navigate().GoToUrl(url);
            Signin.EnterPAssword();
            Assert.True(Signin.IsPageLoaded(), "We are not in the home Page");
        }

        [Given(@"sign in with valid credentials with logininfo '([^']*)'")]
        [When(@"sign in with valid credentials with logininfo '([^']*)'")]
        [Then(@"sign in with valid credentials with logininfo '([^']*)'")]
        public void ThenSignInWithValidCredentialsWithLogininfo(string userType)
        {
            var user = UserObject.GetUser(userType);
            _objectContainer.RegisterInstanceAs(user);
            Assert.True(Signin.IsSignedIn(user.UserName, user.password), "Not able to sign in");
        }

        [Then(@"click on signout button and verify the signout message")]
        public void ThenClickOnSignoutButtonAndVerifyTheSignoutMessage()
        {
            Assert.True(Signin.IsSignedOut(), "Not able to sign in");
        }


        [Given(@"sign in to self serve with valid credentials with logininfo '([^']*)'")]
        [When(@"sign in to self serve with valid credentials with logininfo '([^']*)'")]
        [Then(@"sign in to self serve with valid credentials with logininfo '([^']*)'")]
        public void ThenSignInSelfServeWithValidCredentialsWithLogininfo(string userType)
        {
            var user = UserObject.GetUser(userType);
            _objectContainer.RegisterInstanceAs(user);
            Assert.True(Signin.IsSignedInSelfServe(user.UserName, user.password), "Not able to sign in");
        }
    }
}