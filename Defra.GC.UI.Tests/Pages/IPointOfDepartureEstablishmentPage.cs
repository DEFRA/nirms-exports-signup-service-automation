namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IPointOfDepartureEstablishmentPage
    {
        public bool ClickOnPointsOfDepartureLink();

        public void EnterEstablishmentPostcode(string postcode);

        public bool VerifyAddAPointOfDeparturePage();

        public void ClickOnCannotFindEstablishmentLink();

        public bool ClickOnAddTheEstablishmentAddressManuallyLink();

        public void AddGBPointOfDepartureEstablishmentAddress(string testName, string testAddress, string testCity, string testCountry, string testCode);

        public bool VerifyErrorMessageOnAddAPointOfDeparture(string errorMessage);

        public void AddEstablishmentEmailAddress(string emailAddress);

        public void ClickOnAddAnotherEstablishmentAddress();

        public void ClickOnIHaveFinishedAddingPointsOfDeparture();

        public bool VerifyMoreThan1EstablishmentAddressesAdded();

        public void RemoveEstablishmentAddress(string establishmentAddress);

        public int VerifyEstablishmentAddressCount();

        public bool VerifySearchForEstablishmentAddressPageLoaded();
    }
}
