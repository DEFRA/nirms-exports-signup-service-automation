namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessContactTelephoneNumberPage
    {
        public void ClickOnBackLink();
        public void ClickOnContactTelephoneNumberLink();
        public void ClickOnSaveAndContinue();
        public void ClickSaveAndContinueLater();
        public void EnterTelephoneNumber(string telephoneNumber);
        public void NavigateToContactTelephoneNumberPage();
        public void NavigateToTaskListPage();
        public void VerifyErrorMessageOnContactTelephoneNumberPage();
        public void VerifyNextPageIsLoaded(string pageName);
        public void VerifySignUpTaskListPageIsLoaded();
    }
}
