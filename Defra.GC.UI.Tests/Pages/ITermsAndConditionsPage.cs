namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface ITermsAndConditionsPage
    {
        public void ConfirmSanitaryAndPhytosanitary();

        public bool VerifyTandCsErrorsMessage(string errorMessage);

        public string VerifyTandCDay();

        public void ChequeBoxSelected();
    }
}