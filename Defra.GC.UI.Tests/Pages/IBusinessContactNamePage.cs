namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessContactNamePage
    {
        public void EnterBusinessContactName(string ContactName);
        public bool VerifyErrorMessageOnBusinessContactNamePage(string errorMessage);
        public void ClickOnBusinessContactNameLink();
        public void ClickOnSaveAndContinue();
    }
}
