namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessContactPositionPage
    {
        public void EnterBusinessContactPosition(string ContactPosition);
        public bool VerifyErrorMessageOnBusinessContactPositionPage(string errorMessage);
        public void ClickOnBusinessContactPositionLink();
        public void ClickOnSaveAndContinue();
    }
}
