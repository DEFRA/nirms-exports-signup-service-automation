using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]

    public class CheckYourAnswersSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private ICheckYourAnswersPage? checkYourAnswersPage => _objectContainer.IsRegistered<ICheckYourAnswersPage>() ? _objectContainer.Resolve<ICheckYourAnswersPage>() : null;

        public CheckYourAnswersSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }


        [When(@"confirm Sanitary and phytosanitary SPS assurance commitment")]
        [Then(@"confirm Sanitary and phytosanitary SPS assurance commitment")]
        public void ThenConfirmSanitaryAndPhytosanitarySPSAssuranceCommitment()
        {
            checkYourAnswersPage.ConfirmSanitaryAndPhytosanitary();
        }

        [When(@"edit value of '([^']*)' to '([^']*)' on Check answers page")]
        public void WhenEditValueOfToOnCheckAnswersPage(string FieldName, string FieldValue)
        {
            checkYourAnswersPage.EditValueOnCheckAnswersPage(FieldName, FieldValue);
        }

        [Then(@"verify edited value of '([^']*)' to '([^']*)' on Check answers page")]
        public void ThenVerifyEditedValueOfToOnCheckAnswersPage(string FieldName, string FieldValue)
        {
            Assert.True(checkYourAnswersPage.VerifyEditedValueOnCheckAnswersPage(FieldName, FieldValue), "Value not updated on Check Answers Page");
        }

        [When(@"click on Add another point of departure link")]
        public void WhenClickOnAddAnotherPointOfDepartureLink()
        {
            checkYourAnswersPage.ClickOnAddAnotherPointOfDepartureLink();
        }


        [When(@"click on Add another point of destination link")]
        public void WhenClickOnAddAnotherPointOfDestinationLink()
        {
            checkYourAnswersPage.ClickOnAddAnotherPointOfDestinationLink();
        }

        [Then(@"verify more than 1 establishment addresses added on Check your answers page")]
        public void ThenVerifyMoreThan1EstablishmentAddressesAddedOnCheckYourAnswersPage()
        {
            Assert.True(checkYourAnswersPage.VerifyMoreThan1EstablishmentAddressesAdded(), "Another Establishment address not added successfully");
        }

        [Then(@"verify total '([^']*)' establishment addresses added")]
        public void ThenVerifyTotalEstablishmentAddressesAdded(string TotalNum)
        {
            Assert.True(checkYourAnswersPage.VerifyTotalEstablishmentAddressesAdded(TotalNum), "Total Establishment address count not matching");
        }

        [When(@"click on remove link on estblishment '([^']*)' on check answers page")]
        public void WhenClickOnRemoveLinkOnEstblishmentOnCheckAnswersPage(string EstablishmentName)
        {
            checkYourAnswersPage.ClickOnRemoveLinkOnEstblishmentOnCheckAnswersPage(EstablishmentName);
        }


    }
}
