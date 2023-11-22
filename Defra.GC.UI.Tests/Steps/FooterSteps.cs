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

      
        [Then(@"verify privacy link '([^']*)' '([^']*)' in the page footer")]
        public void ThenVerifyPrivacyLinkInFooterPage(string privacyLink1, string privacyLink2)
        {
            footerPage.ClickOnPrivacyFooterLink();
            Assert.True(footerPage.VerifyPrivacyFooterLink(privacyLink1, privacyLink2), "Privacy Link in Page footer not loaded");
        }


        [Then(@"verify cookies '([^']*)' '([^']*)' link in the page footer")]
        public void ThenVerifyCookiesLinkInFooterPage(string cookiesLink1, string cookiesLink2)
        {
            footerPage.ClickOnCookiesFooterLink();
            Assert.True(footerPage.VerifyCookiesFooterLink(cookiesLink1, cookiesLink2), "Cookies Link in Page footer not loaded");
        }


        [Then(@"verify accessibility '([^']*)' '([^']*)' link in the footer page")]
        public void ThenVerifyAccessibilityLinkInFooterPage(string accessibilityLink1, string accessibilityLink2)
        {
            footerPage.ClickOnAccessibilityFooterLink();
            Assert.True(footerPage.VerifyAccessibilityFooterLink(accessibilityLink1, accessibilityLink2), "Accessibility Link in Page footer not loaded");
        }


        [Then(@"verify contact link '([^']*)' '([^']*)' in the footer page")]
        public void ThenVerifyContactLinkInFooterPage(string contactLink1, string contactLink2)
        {
            footerPage.ClickOnContactFooterLink();
            Assert.True(footerPage.VerifyContactFooterLink(contactLink1, contactLink2), "Contact Link in Page footer not loaded");
        }


        [Then(@"verify TCs link '([^']*)' '([^']*)' in the footer page")]
        public void ThenVerifyTCsLinkInFooterPage(string TCsLink1, string TCsLink2)
        {
            footerPage.ClickOnTCsFooterLink();
            Assert.True(footerPage.VerifyTCsFooterLink(TCsLink1, TCsLink2), "TCs Link in Page footer not loaded");
        }

        [Then(@"verify text and link in the footer page")]
        public void ThenVerifyTextLinkInFooterPage()
        {
            Assert.True(footerPage.VerifyFooterText(), "Text and  Link in Page footer not matching");
        }
        [Then(@"verify the logo in the page footer")]
        public void ThenVerifyLogoInFooterPage()
        {
            Assert.True(footerPage.VerifyLogoInThePageFooter(), "Logo in Page footer not matching");
        }

    }
}