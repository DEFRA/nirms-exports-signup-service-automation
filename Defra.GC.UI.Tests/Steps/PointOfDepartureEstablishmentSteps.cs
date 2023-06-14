using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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

        [When(@"click on points of departure link")]
        [Then(@"click on points of departure link")]
        public void ThenClickOnPointsOfDepartureLink()
        {
            Assert.True(pointOfDepartureEstablishmentPage.ClickOnPointsOfDepartureLink(), "Point Of Departure Page not loaded");
        }

        [When(@"enter Establishment postcode '([^']*)'")]
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

        [When(@"click on cannot find establishment link")]
        [Then(@"click on cannot find establishment link")]
        public void ThenClickOnCannotFindEstablishmentLink()
        {
            pointOfDepartureEstablishmentPage.ClickOnCannotFindEstablishmentLink();
        }

        [When(@"click on the add establishment address manually link")]
        [Then(@"click on the add establishment address manually link")]
        public void ThenClickOnAddTheEstablishmentAddressManuallyLink()
        {
            Assert.True(pointOfDepartureEstablishmentPage.ClickOnAddTheEstablishmentAddressManuallyLink(), "Add establishment address page not loaded");
        }

        [When(@"add establishment address manually with fields '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        [Then(@"add establishment address manually with fields '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenAddEstablishmentAddressManuallyWithFields(string testName, string testAddress, string testCity, string testCountry, string testCode)
        {
            pointOfDepartureEstablishmentPage.AddGBPointOfDepartureEstablishmentAddress(testName, testAddress, testCity, testCountry, testCode);
        }


        [Then(@"verify error message '([^']*)' on establishment page")]
        public void ThenVerifyErrorMessageOnAddAPointOfDeparturePage(string errorMessage)
        {
            Assert.True(pointOfDepartureEstablishmentPage.VerifyErrorMessageOnAddAPointOfDeparture(errorMessage), "Invalid error on Establishment address page");
        }

    }
}
