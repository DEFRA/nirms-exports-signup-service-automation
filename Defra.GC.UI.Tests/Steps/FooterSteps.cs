using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class FooterSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IFooterPage? footerPage => _objectContainer.IsRegistered<IFooterPage>() ? _objectContainer.Resolve<IFooterPage>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        public FooterSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }
    

        [Then(@"verify text '([^']*)' on the page footer")]
        public void ThenVerifyTextLinkInFooterPage(string FooterHintText)
        {
            Assert.True(footerPage.VerifyFooterText(FooterHintText), "Text on Page footer not matching");
        }

        [When(@"click privacy link on footer page")]
        [Then(@"click privacy link on footer page")]
        public void ClickPrivacyLinkFooterPage()
        {
            footerPage.ClickOnPrivacyFooterLink();
        }

        [When(@"click cookies link on footer page")]
        [Then(@"click cookies link on footer page")]
        public void ClickCookiesLinkFooterPage()
        {
            footerPage.ClickOnCookiesFooterLink();
        }

        [When(@"click accessibility link on footer page")]
        [Then(@"click accessibility link on footer page")]
        public void ClickAccessibilityLinkFooterPage()
        {
            footerPage.ClickOnAccessibilityFooterLink();
        }

        [When(@"click contact link on footer page")]
        [Then(@"click contact link on footer page")]
        public void ClickContactLinkFooterPage()
        {
            footerPage.ClickOnContactFooterLink();
        }

        [When(@"click TCs link on footer page")]
        [Then(@"click TCs link on footer page")]
        public void ClickTCsLinkFooterPage()
        {
            footerPage.ClickOnTCsFooterLink();
        }

        [Then(@"verify the page title in Footer page '([^']*)'")]
        public void ThenVerifyPageTitleInFooterPage(string pageTitle)
        {
            Assert.True(footerPage.VerifyPageTitle(pageTitle), "Page title not matching");
        }

        [Then(@"verify the link in Footer page details '([^']*)'")]
        public void VerifyLinkOnTheFooterPage(string Link)
        {
            Assert.True(footerPage.VerifyLinkText(Link), "Link not matching on Footer Page details");
        }
    }
}