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
    }
}
