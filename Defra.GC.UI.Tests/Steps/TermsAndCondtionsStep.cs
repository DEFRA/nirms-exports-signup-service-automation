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

        //[Then(@"verify total '([^']*)' establishment addresses added")]
        //public void ThenVerifyTotalEstablishmentAddressesAdded(string TotalNum)
        //{
        //    Assert.True(checkYourAnswersPage.VerifyTotalEstablishmentAddressesAdded(TotalNum), "Total Establishment address count not matching");
        //}

        //[When(@"click on remove link on estblishment '([^']*)' on check answers page")]
        //public void WhenClickOnRemoveLinkOnEstblishmentOnCheckAnswersPage(string EstablishmentName)
        //{
        //    checkYourAnswersPage.ClickOnRemoveLinkOnEstblishmentOnCheckAnswersPage(EstablishmentName);
        //}

        [Then(@"verify error message '([^']*)' on ReMoS Terms & Conditions Declaration  page")]
        public void ThenVerifyErrorMessageOnReMoSTermsConditionsDeclarationPage(string errorMessage)
        {
            Assert.True(TandCsPage.VerifyTandCsErrorsMessage(errorMessage), "T and C's error not matching matching");
        }

        [Then(@"verify the current date is shows on ReMoS Terms & Conditions Declaration  page")]
        public void ThenVerifyTheCurrentDateIsShowsOnReMoSTermsConditionsDeclarationPage()
        {
            Thread.Sleep(10000);
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            String dy = datevalue.Day.ToString();
            String yy = datevalue.Year.ToString();

            DateTime dt = DateTime.Now;

            Assert.True(TandCsPage.VerifyTandCDay().Contains(dy), "T and C's error not matching matching");

            Assert.True(TandCsPage.VerifyTandCDay().Contains(dt.ToString("MMMM")), "T and C's error not matching matching");

            Assert.True(TandCsPage.VerifyTandCDay().Contains(yy), "T and C's error not matching matching");
        }
    }
}