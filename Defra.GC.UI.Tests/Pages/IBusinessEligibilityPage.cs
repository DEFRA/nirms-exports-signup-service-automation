using System.Diagnostics.Metrics;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessEligibilityPage
    {
        public bool ClickOnCheckEligibilityTask();

        public void CompleteEligibility(string country, string FBONumber);

        public void SelectCountryToCompleteEligibilitywithoutRegulations(string country, string FBONumber);

        public void InvaildFBOdata(string country, string FBONumber);

        public bool VerifyEligibilityTaskStatus(string status);

        public void SelectFBONumberToCompleteEligibility(string FBONumber);

        public void AssuranceCompleteWithNoFBO();

        public void NavigateToRegulations(string country, string FBONumber);

        public void NoFBONumberToCompleteEligibility();

        public bool VerifyNoSignUpTaskListPageIsLoaded();

        public bool VerifyErrorMessageOnSPSAssurancePage(string errorMessage);

        public bool VerifyErrorMessageOnRegulationsPage(string errorMessage);

        public void AssurancePagWithCountry(string country);

        public bool VerifyEligibilityTaskFields(string country, string FBONumber);

        public string VerifyCountryPageloaded();

        public string VerifySPOPageloaded();

        public void EditFBONumberToCompleteEligibility(string FBONumber);

        public void SelectBusinessToSignUp(string businessSelection);
    }
}