using System.Diagnostics.Metrics;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessEligibilityPage
    {
        public bool ClickOnPurposeOfBusinessTask();

        public bool ClickOnFBOorPHRNumberTask();

        public void CompleteEligibility(string country);

        public void ContinueEligibilityTaskWithWithoutRegulations();

        public void InvaildFBOdata(string FBONumber);

        public void InvaildPHRdata(string PHRNumber);

        public bool VerifyEligibilityTaskStatus(string status);

        public void CompleteFBOorPHRNumberTaskWithFBONumber(string FBONumber);

        public void CompleteFBOorPHRNumberTaskWithPHRNumber(string PHRNumber);

        public void NavigateToRegulationsAndConfirmRegulation();

        public void ContinueFBOorPHRNumberTaskWithoutFBOorPHRNumber();

        public bool VerifyNoSignUpTaskListPageIsLoaded();

        public bool VerifyErrorMessageOnSPSAssurancePage(string errorMessage);

        public bool VerifyErrorMessageOnRegulationsPage(string errorMessage);

        public bool VerifyEligibilityTaskFields(string country, string FBONumber);

        public string VerifyCountryPageloaded();

        public string VerifySPOPageloaded();

        public void EditFBONumberToCompleteFBOorPHRNumberTask(string FBONumber);

        public void SelectBusinessToSignUp(string businessSelection);

        public bool VerifyHintTextMessage(string hintText);

        public void EditPHRNumberToCompleteEligibility(string PHRNumber);

        public void ConfirmReMosRegulationToCompleteEligibility();

        public void ClickOnManageAccessLinkOnAnotherbusinessPage();

        public bool VerifyDynamicNameOnSPSAssurancePage(string Name, string country);
    }
}