namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface ISignInPage
    {
        public bool IsPageLoaded();
        public bool IsSignedIn(string userName, string password);
        public void ClickSignedOut();
        public bool IsSignedOut();
        public void EnterPAssword();
    }
}
