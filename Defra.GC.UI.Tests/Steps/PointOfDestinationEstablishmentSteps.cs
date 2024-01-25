using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class PointOfDestinationEstablishmentSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPointOfDestinationEstablishmentPage? pointOfDestinationEstablishmentPage => _objectContainer.IsRegistered<IPointOfDestinationEstablishmentPage>() ? _objectContainer.Resolve<IPointOfDestinationEstablishmentPage>() : null;

        public PointOfDestinationEstablishmentSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"complete Points of destination with '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenCompletePointsOfDestination(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode)
        {
            pointOfDestinationEstablishmentPage.CompletePointsOfDestination(establishmentName, establishmentAddress, establishmentCity, establishmentCountry, establishmentCode);
        }

        [When(@"complete Points of destination with '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)' with save and continue")]
        public void ThenCompletePointsOfDestinationWithSave(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode)
        {
            pointOfDestinationEstablishmentPage.CompletePointsOfDestinationWithSave(establishmentName, establishmentAddress, establishmentCity, establishmentCountry, establishmentCode);
        }

        [Then(@"user verify the Points of destination status '([^']*)'")]
        public void ThenUserVerifyThePointsOfDestinationStatus(string status)
        {
            Assert.True(pointOfDestinationEstablishmentPage.VerifyThePointsOfDestinationStatus(status), "Point Of Destination Status not matching");
        }

        [Then(@"verify error message '([^']*)' on Add a place of destination page")]
        public void ThenVerifyErrorMessageOnAddAPlaceOfDestinationPage(string errorMessage)
        {
            Assert.True(pointOfDestinationEstablishmentPage.VerifyErrorMessageOnAddAPointOfDestinationForNoResults(errorMessage), "Invalid error on Establishment address page");
        }

        [When(@"click on points of destination link")]
        public void WhenClickOnPointsOfDestinationLink()
        {
            Assert.True(pointOfDestinationEstablishmentPage.ClickOnPointsOfDestinationLink(), "Point Of Destination Page not loaded");
        }

        [Then(@"verify Add a point of departure Page loaded")]
        public void ThenVerifyAddAPointOfDeparturePageLoaded()
        {
            Assert.True(pointOfDestinationEstablishmentPage.VerifyAddAPointOfDeparturePage(), "Select Point Of Departure Page not loaded");
        }

        [Then(@"verify duplicate establishment error message '([^']*)'")]
        public void ThenVerifyDuplicateEstablishmentErrorMessage(string errorMessage)
        {
            Assert.True(pointOfDestinationEstablishmentPage.VerifyDuplicateEstablishmentErrorMessage(errorMessage), "Duplicate error message not matching");
        }
    }
}