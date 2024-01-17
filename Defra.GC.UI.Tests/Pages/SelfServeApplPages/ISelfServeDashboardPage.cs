namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    internal interface ISelfServeDashboardPage
    {
        void ClickOnAuthorisedRepresentativeChangeLink();
        void ClickOnCancelLink();
        void ClickOnContactPersonChangeLink();
        public void SelectBusinessOnSelfServe(string businessSelection);
        public bool VerifyBusinessRMSNumber(string businessRMSNumber);
        public bool VerifyContactPersonDateFormatOnSelfServeDashboard(string text);
        public bool VerifyAuthRepresentativeDateFormatOnSelfServeDashboard(string text);
        public bool VerifyStatusOnSelfServe(string businessSelection, string Status);
        public void NavigateToSelfServeURL();
    }
}
