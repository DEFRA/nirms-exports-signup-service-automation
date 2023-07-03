
namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface ICheckYourAnswersPage
    {
        public void ClickOnAddAnotherPointOfDepartureLink();
        public void ClickOnAddAnotherPointOfDestinationLink();
        public void ConfirmSanitaryAndPhytosanitary();
        public void EditValueOnCheckAnswersPage(string fieldName, string fieldValue);
        public bool VerifyEditedValueOnCheckAnswersPage(string fieldName, string fieldValue);
        public bool VerifyMoreThan1EstablishmentAddressesAdded();
    }
}
