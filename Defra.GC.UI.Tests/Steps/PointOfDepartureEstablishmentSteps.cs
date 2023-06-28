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

        [When(@"complete Points of departure with '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenCompletePointsOfDeparture(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode)
        {
            pointOfDepartureEstablishmentPage.CompletePointsOfDeparture(establishmentName, establishmentAddress, establishmentCity, establishmentCountry, establishmentCode);
        }

        [Then(@"user verify the Points of departure status '([^']*)'")]
        public void ThenUserVerifyThePointsOfDepartureStatus(string status)
        {
            Assert.True(pointOfDepartureEstablishmentPage.VerifyThePointsOfDepartureStatus(status), "Point Of Departure Status not matching");
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
        public void ThenAddEstablishmentAddressManuallyWithFields(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode)
        {
            pointOfDepartureEstablishmentPage.AddGBPointOfDepartureEstablishmentAddress(establishmentName, establishmentAddress, establishmentCity, establishmentCountry, establishmentCode);
        }


        [Then(@"verify error message '([^']*)' on establishment page")]
        public void ThenVerifyErrorMessageOnAddAPointOfDeparturePage(string errorMessage)
        {
            Assert.True(pointOfDepartureEstablishmentPage.VerifyErrorMessageOnAddAPointOfDeparture(errorMessage), "Invalid error on Establishment address page");
        }

        [When(@"add establishment email address '([^']*)'")]
        [Then(@"add establishment email address '([^']*)'")]
        public void WhenAddEstablishmentEmailAddress(string emailAddress)
        {
            pointOfDepartureEstablishmentPage.AddEstablishmentEmailAddress(emailAddress);
        }

        [When(@"click on add another establishment address")]
        public void WhenClickOnAddAnotherEstablishmentAddress()
        {
            pointOfDepartureEstablishmentPage.ClickOnAddAnotherEstablishmentAddress();
        }

        [Then(@"verify more than 1 establishment addresses added")]
        public void WhenVerifyMoreThan1EstablishmentAddressesAdded()
        {
            Assert.True(pointOfDepartureEstablishmentPage.VerifyMoreThan1EstablishmentAddressesAdded(), "Another Establishment address not added successfully");
        }

        [When(@"click on I have finished adding points of departure")]
        public void WhenClickOnIHaveFinishedAddingPointsOfDeparture()
        {
            pointOfDepartureEstablishmentPage.ClickOnIHaveFinishedAddingPointsOfDeparture();
        }

        [When(@"remove establishment address '([^']*)'")]
        public void WhenRemoveEstablishmentAddress(string establishmentAddress)
        {
            pointOfDepartureEstablishmentPage.RemoveEstablishmentAddress(establishmentAddress);
        }

        [Then(@"verify establishment address count '([^']*)'")]
        public void ThenVerifyEstablishmentAddressCount(string count)
        {
            int ExpectedCount = Int32.Parse(count);
            Assert.AreEqual(pointOfDepartureEstablishmentPage.VerifyEstablishmentAddressCount(), ExpectedCount);
        }

        [Then(@"verify search for establishment address page loaded")]
        public void ThenVerifySearchForEstablishmentAddressPageLoaded()
        {
            Assert.True(pointOfDepartureEstablishmentPage.VerifySearchForEstablishmentAddressPageLoaded(), "Find Establishment address page not loaded successfully");
        }

        [When(@"click on change establishment address '([^']*)'")]
        public void WhenClickOnChangeEstablishmentAddress(string EstablishmentName)
        {
            pointOfDepartureEstablishmentPage.ClickOnChangeEstablishmentAddress(EstablishmentName);
        }

        [When(@"verify add establishment address manually page loaded")]
        public void WhenVerifyAddEstablishmentAddressManuallyPageLoaded()
        {
            Assert.True(pointOfDepartureEstablishmentPage.VerifyAddEstablishmentAddressManuallyPageLoaded(), "Add Establishment address manually page not loaded successfully");
        }

        [When(@"verify changed establishment address fields '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenVerifyChangedEstablishmentAddressFields(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode)
        {
            Assert.True(pointOfDepartureEstablishmentPage.VerifyChangedEstablishmentAddressFields(establishmentName, establishmentAddress, establishmentCity,establishmentCountry, establishmentCode), "Establishment address not changed successfully");
        }

        [When(@"click on change link next to Establishment postcode")]
        public void WhenClickOnChangeLinkNextToEstablishmentPostcode()
        {
            pointOfDepartureEstablishmentPage.ClickOnChangeEstablishmentPostcode();
        }

        [Then(@"verify establishment postcode changed to '([^']*)'")]
        public void ThenVerifyEstablishmentPostcodeChanged(string establishmentCode)
        {
            Assert.True(pointOfDepartureEstablishmentPage.VerifyEstablishmentPostcodeChanged(establishmentCode), "Establishment postcode not changed successfully");
        }

        [When(@"click on change establishment email address")]
        public void WhenClickOnChangeEstablishmentEmailAddress()
        {
            pointOfDepartureEstablishmentPage.ClickOnChangeEstablishmentEmailAddress();
        }

        [When(@"verify add establishment email address page loaded")]
        public void WhenVerifyAddEstablishmentEmailAddressPageLoaded()
        {
            Assert.True(pointOfDepartureEstablishmentPage.VerifyAddEstablishmentEmailAddressPageLoaded(), "Add Establishment email address page not loaded successfully");
        }

        [Then(@"verify changed establishment email address '([^']*)'")]
        public void ThenVerifyChangedEstablishmentEmailAddress(string establishmentEmail)
        {
            Assert.True(pointOfDepartureEstablishmentPage.VerifyChangedEstablishmentEmailAddress(establishmentEmail), "Establishment email address not changed successfully");
        }

        [Then(@"verify points of destination link not visible on tasklist page")]
        public void ThenVerifyPointsOfDestinationLinkNotVisibleOnTasklistPage()
        {
            Assert.True(pointOfDepartureEstablishmentPage.VerifyPointsOfDestinationLinkOnTasklistPage(), "Points Of Destination Link Visible On Tasklist Page");
        }

    }
}
