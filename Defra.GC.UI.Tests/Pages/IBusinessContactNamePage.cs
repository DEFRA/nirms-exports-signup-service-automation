namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessContactNamePage
    {
        public void NavigateToBusinessContactNamePage();
        public void EnterBusinessContactName(string ContactName);
        public void VerifyErrorMessageOnBusinessContactNamePage();
        public void ClickOnBusinessContactNameLink();
    }
}
