namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessEligibilityPage
    {
        public bool ClickOnCheckEligibilityTask();

        public void SelectCountryToCompleteEligibility(string country, string FBONumber);

        public bool VerifyEligibilityTaskStatus(string status);

        public void SelectFBONumberToCompleteEligibility(string FBONumber);

        public void AssuranceCompleteWithNoSelection(string country, string FBONumber);

        public void NoFBONumberToCompleteEligibility(string FBONumber);

        public bool VerifyNoSignUpTaskListPageIsLoaded();

        public bool VerifyErrorMessageOnSPSAssurancePage(string errorMessage);

        public void AssurancePagWithCountry(string country);

        public string VerifyCountryPageloaded();
    }
}