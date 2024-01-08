namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IApplicationPage
    {
        public bool VerifyNextPageIsLoaded(string pageName);

        public bool VerifyAPHAEmail(string link);

        public void NavigateToTaskListPage();

        public void ClickOnBackLink();

        public void ClickOnFeedBackLink();

        public bool VerifySignUpTaskListPageIsLoaded();

        public bool VerifyFeedbackPageLoaded();

        public void ClickSaveAndReturnToDashboard();

        public void ClickOnSaveAndContinue();

        public void ClickOnContinue();

        public void ClickonBackToDashboardlink();

        public void SwitchToNextTab();

        public void SwitchToPreviousOpenTab();

        public bool VerifyGenericGOVPageLoaded();

        public bool VerifyDynamicNameInTitleOfPage(string Name, string title);

        public bool VerifyDynamicNameErrorMessage(string Name, string errorMessage);

        public bool VerifyDynamicHintTextMessage(string BusinessName);

        public void CloseCurrentTab();

        public void ClickReturnToDashboard();
    }
}