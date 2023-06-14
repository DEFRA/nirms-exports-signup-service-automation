namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IPointOfDestinationEstablishmentPage
    {
        public bool ClickOnPointsOfDestinationLink();

        public void EnterEstablishmentPostcode(string postcode);

        public bool VerifyAddAPointOfDeparturePage();

        public void ClickOnCannotFindEstablishmentLink();

        public bool ClickOnAddTheEstablishmentAddressManuallyLink();

        public void AddGBPointOfDepartureEstablishmentAddress(string testName, string testAddress, string testCity, string testCountry, string testCode);

        public bool VerifyErrorMessageOnAddAPointOfDeparture(string errorMessage);
    }
}