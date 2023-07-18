using System.Diagnostics.Metrics;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessEligibilityPage
    {
        public bool ClickOnCheckEligibilityTask();

        public void SelectCountryToCompleteEligibility(string country, string FBONumber, string businessname);

        public void SelectCountryToCompleteEligibilitywithoutRegulations(string businessSelection, string country, string FBONumber);

        public void InvaildFBOdata(string country, string FBONumber, string BusinessSelection);

        public bool VerifyEligibilityTaskStatus(string status);

        public void SelectFBONumberToCompleteEligibility(string FBONumber);

        public void AssuranceCompleteWithNoSelection(string country, string FBONumber);

        public void NavigateToRegulations(string businessSelection, string country, string FBONumber);

        public void NoFBONumberToCompleteEligibility(string FBONumber);

        public bool VerifyNoSignUpTaskListPageIsLoaded();

        public bool VerifyErrorMessageOnSPSAssurancePage(string errorMessage);

        public bool VerifyErrorMessageOnRegulationsPage(string errorMessage);

        public void AssurancePagWithCountry(string businessSelection, string country);

        public string VerifyCountryPageloaded();

        public string VerifySPOPageloaded();

        public void EditCountryToCompleteEligibility(string country);

        public void EditFBONumberToCompleteEligibility(string FBONumber);
    }
}