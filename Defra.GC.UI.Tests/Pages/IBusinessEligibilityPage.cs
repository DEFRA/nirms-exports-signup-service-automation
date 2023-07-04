using System.Diagnostics.Metrics;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessEligibilityPage
    {
        public bool ClickOnCheckEligibilityTask();

        public void SelectCountryToCompleteEligibility(string country, string FBONumber);

        public void SelectCountryToCompleteEligibilitywithoutRegulations(string country, string FBONumber);

        public void InvaildFBOdata(string country, string FBONumber);

        public bool VerifyEligibilityTaskStatus(string status);

        public void SelectFBONumberToCompleteEligibility(string FBONumber);

        public void AssuranceCompleteWithNoSelection(string country, string FBONumber);

        public void NavigateToRegulations(string country, string FBONumber);

        public void NoFBONumberToCompleteEligibility(string FBONumber);

        public bool VerifyNoSignUpTaskListPageIsLoaded();

        public bool VerifyErrorMessageOnSPSAssurancePage(string errorMessage);

        public bool VerifyErrorMessageOnRegulationsPage(string errorMessage);

        public void AssurancePagWithCountry(string country);

        public string VerifyCountryPageloaded();

        public string VerifySPOPageloaded();

        public void EditCountryToCompleteEligibility(string country);

        public void EditFBONumberToCompleteEligibility(string FBONumber);

    }
}