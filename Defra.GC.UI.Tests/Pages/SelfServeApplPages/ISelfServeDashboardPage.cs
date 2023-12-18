namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    internal interface ISelfServeDashboardPage
    {
        public void SelectBusinessOnSelfServe(string businessSelection);

        public bool VerifyBusinessRMSNumber(string businessRMSNumber);
    }
}
