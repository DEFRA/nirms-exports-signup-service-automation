using System.Diagnostics.Metrics;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessEligibilityPage
    {
        public bool ClickOnPurposeOfBusinessTask();
        public void CompleteEligibility(string country);
        public void ContinueEligibilityTaskWithWithoutRegulations();
        public bool VerifyEligibilityTaskStatus(string status);
        public void NavigateToRegulationsAndConfirmRegulation();
        public bool VerifyNoSignUpTaskListPageIsLoaded();
        public bool VerifyErrorMessageOnSPSAssurancePage(string errorMessage);
        public bool VerifyErrorMessageOnRegulationsPage(string errorMessage);
        public bool VerifyEligibilityTaskFields(string country, string FBONumber);
        public string VerifyCountryPageloaded();
        public string VerifySPOPageloaded();
        public void SelectBusinessToSignUp(string businessSelection);
        public void ConfirmReMosRegulationToCompleteEligibility();
        public void ClickOnManageAccessLinkOnAnotherbusinessPage();
        public bool VerifyDynamicNameOnSPSAssurancePage(string Name, string country);
    }
}