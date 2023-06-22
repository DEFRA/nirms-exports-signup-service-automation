using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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

        [When(@"click on points of destination  link")]
        public void WhenClickOnPointsOfDestinationLink()
        {
            Assert.True(pointOfDestinationEstablishmentPage.ClickOnPointsOfDestinationLink(), "Point Of Destination Page not loaded");
            Thread.Sleep(5000);
        }

        [Then(@"verify Add a point of departure Page loaded")]
        public void ThenVerifyAddAPointOfDeparturePageLoaded()
        {
            Assert.True(pointOfDestinationEstablishmentPage.VerifyAddAPointOfDeparturePage(), "Select Point Of Departure Page not loaded");
        }
    }
}