using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class TermsAndCondtionsStep
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private ITermsAndConditionsPage? TandCsPage => _objectContainer.IsRegistered<ITermsAndConditionsPage>() ? _objectContainer.Resolve<ITermsAndConditionsPage>() : null;

        public TermsAndCondtionsStep(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"verify error message '([^']*)' on ReMoS Terms & Conditions Declaration  page")]
        public void ThenVerifyErrorMessageOnReMoSTermsConditionsDeclarationPage(string errorMessage)
        {
            Assert.True(TandCsPage.VerifyTandCsErrorsMessage(errorMessage), "T and C's error not matching matching");
        }

        [When(@"click on the confirm check box on Terms and conditions page")]
        [Then(@"click on the confirm check box on Terms and conditions page")]
        public void ThenClickOnTheConfirmCheckBoxOnTermsAndConditionsPage()
        {
            TandCsPage.CheckBoxSelected();
        }

        [When(@"click on submit sign up")]
        [Then(@"click on submit sign up")]
        public void ThenClickOnSubmitSignUp()
        {
            TandCsPage.ClickOnSubmitSignUp();
        }

        [Then(@"verify the current date is shows on ReMoS Terms & Conditions Declaration  page")]
        public void ThenVerifyTheCurrentDateIsShowsOnReMoSTermsConditionsDeclarationPage()
        {
            Assert.True(TandCsPage.VerifyTandCDate(), "T and C's date not matching ");
        }
        [Then(@"verify the text '([^']*)' on Terms and conditions page")]
        public void ThenVerifyMessageOnReMoSTermsConditionsDeclarationPage(string TCsText)
        {
            Assert.True(TandCsPage.VerifyTandCsText(TCsText), "T and C's text not matching");
        }
    }
}