
namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IEligibilityPage
    {
        public bool ClickOnCheckEligibilityTask();

        public void SelectCountryToCompleteEligibility(string country, string FBONumber);

        public bool VerifyEligibilityTaskStatus(string status);

        public void SelectFBONumberToCompleteEligibility(string FBONumber);
    }
}
