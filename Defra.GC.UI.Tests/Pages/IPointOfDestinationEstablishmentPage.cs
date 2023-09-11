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

        public void CompletePointsOfDestination(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode);

        public void CompletePointsOfDestinationWithSave(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode);

        public bool VerifyThePointsOfDestinationStatus(string status);

        public bool VerifyErrorMessageOnAddAPointOfDestinationForNoResults(string status);

        public bool VerifyDuplicateEstablishmentErrorMessage(string errorMessage);
    }
}