namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IPointOfDepartureEstablishmentPage
    {
        public bool ClickOnPointsOfDepartureLink();

        public void EnterEstablishmentPostcode(string postcode);

        public bool VerifyAddAPointOfDeparturePage();

        public void ClickOnCannotFindEstablishmentLink();

        public void ClickOndifferentPostCodeLink();

        public void ClickOnAdressManuallyLink();

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

        public void ClickOnChangeEstablishmentAddress(string establishmentName);

        public bool VerifyAddEstablishmentAddressManuallyPageLoaded();

        public bool VerifyChangedEstablishmentAddressFields(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode);

        public void ClickOnChangeEstablishmentPostcode();

        public bool VerifyEstablishmentPostcodeChanged(string establishmentCode);

        public void ClickOnChangeEstablishmentEmailAddress();

        public bool VerifyAddEstablishmentEmailAddressPageLoaded();

        public bool VerifyChangedEstablishmentEmailAddress(string establishmentEmail);

        public bool VerifyPointsOfDestinationLinkOnTasklistPage();

        public void CompletePointsOfDeparture(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode);

        public bool VerifyThePointsOfDepartureStatus(string status);

        public bool VerifyInvalidEstablishmentEmailAddress(string invalidEmail);

        public void ClickOnSelectAddressButton();
    }
}