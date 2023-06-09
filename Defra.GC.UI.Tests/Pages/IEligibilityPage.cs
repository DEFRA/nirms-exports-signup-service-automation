
namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IEligibilityPage
    {
        public bool ClickOnCheckEligibilityTask();

        public void SelectCountryToCompleteEligibility(string country);

        public bool VerifyEligibilityTaskStatus(string status);

    }
}
