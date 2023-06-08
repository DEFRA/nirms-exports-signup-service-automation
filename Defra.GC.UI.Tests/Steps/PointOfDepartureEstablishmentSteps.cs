using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class PointOfDepartureEstablishmentSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPointOfDepartureEstablishmentPage? pointOfDepartureEstablishmentPage => _objectContainer.IsRegistered<IPointOfDepartureEstablishmentPage>() ? _objectContainer.Resolve<IPointOfDepartureEstablishmentPage>() : null;


        public PointOfDepartureEstablishmentSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;

        }

        [Then(@"click on points of departure link")]
        public void ThenClickOnPointsOfDepartureLink()
        {
            Assert.True(pointOfDepartureEstablishmentPage.ClickOnPointsOfDepartureLink(), "Point Of Departure Page not loaded");
        }

        [Then(@"enter Establishment postcode '([^']*)'")]
        public void ThenEnterEstablishmentPostcode(string postcode)
        {
            pointOfDepartureEstablishmentPage.EnterEstablishmentPostcode(postcode);
        }

        [Then(@"verify Add a point of departure Page loaded")]
        public void ThenVerifyAddAPointOfDeparturePageLoaded()
        {
            Assert.True(pointOfDepartureEstablishmentPage.VerifyAddAPointOfDeparturePage(), "Select Point Of Departure Page not loaded");
        }

        [Then(@"click on cannot find establishment link")]
        public void ThenClickOnCannotFindEstablishmentLink()
        {
            pointOfDepartureEstablishmentPage.ClickOnCannotFindEstablishmentLink();
        }

        [Then(@"click on the add establishment address manually link")]
        public void ThenClickOnAddTheEstablishmentAddressManuallyLink()
        {
            Assert.True(pointOfDepartureEstablishmentPage.ClickOnAddTheEstablishmentAddressManuallyLink(), "Add establishment address page not loaded");
        }

        [Then(@"Add GB point of Departure establishment address manually with fields '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenAddGBPointOfDepartureEstablishmentAddressManuallyWithFields(string testName, string testAddress, string testCity, string testCountry, string testCode)
        {
            pointOfDepartureEstablishmentPage.AddGBPointOfDepartureEstablishmentAddress(testName, testAddress, testCity, testCountry, testCode);
        }

        [Then(@"verify error message '([^']*)' on Add a point of departure page")]
        public void ThenVerifyErrorMessageOnAddAPointOfDeparturePage(string errorMessage)
        {
            Assert.True(pointOfDepartureEstablishmentPage.VerifyErrorMessageOnAddAPointOfDeparture(errorMessage), "Invalid error on Establishment address page");
        }

    }
}
