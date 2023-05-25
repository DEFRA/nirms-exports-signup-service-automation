namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessContactPositionPage
    {
        public void NavigateToBusinessContactPositionPage();
        public void EnterBusinessContactPosition(string ContactPosition);
        public void VerifyErrorMessageOnBusinessContactPositionPage();
        public void ClickOnBusinessContactPositionLink();
    }
}
