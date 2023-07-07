namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessContactNamePage
    {
        public void EnterBusinessContactName(string ContactName);

        public bool VerifyErrorMessageOnBusinessContactNamePage(string errorMessage);

        public void ClickOnBusinessContactDetailsLink();

        public void ClickOnSaveAndContinue();

        public void CompleteBusinessContactDetailsTask(string contactName, string contactPosition, string contactEmail, string contactTelephone);

        public bool VerifyTheBusinessContactDetailsStatus(string status);

        public void EditBusinessContactName(string contactName);

        public void EditBusinessContactPosition(string contactPosition);

        public void EditBusinessContactEmailAddress(string contactEmail);

        public void EditBusinessContactTelephoneNumber(string contactTelephone);
    }
}