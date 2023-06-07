namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IContactEmailAddressPage
    {
        public void ClickOnBackLink();
        public void ClickOnContactEmailAddressLink();
        public void ClickOnSaveAndContinue();
        public void ClickSaveAndContinueLater();
        public void EnterEmailAddress(string emailAddress);
        public void NavigateToContactEmailAddressPage();
        public void NavigateToTaskListPage();
        public void VerifyErrorMessageOnContactEmailAddressPage();
        public void VerifyNextPageIsLoaded(string pageName);
        public void VerifySignUpTaskListPageIsLoaded();
    }
}
