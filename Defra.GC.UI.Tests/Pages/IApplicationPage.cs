namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IApplicationPage
    {
        public bool VerifyNextPageIsLoaded(string pageName);
        public void NavigateToTaskListPage();
        public void ClickOnBackLink();
        public bool VerifySignUpTaskListPageIsLoaded();
        public void ClickSaveAndContinueLater();
    }
}
