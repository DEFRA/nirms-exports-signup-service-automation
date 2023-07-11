namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface ITermsAndConditionsPage
    {
        public bool VerifyTandCsErrorsMessage(string errorMessage);

        public bool VerifyTandCDate();

        public void CheckBoxSelected();

        public void ClickOnSubmitSignUp();
    }
}