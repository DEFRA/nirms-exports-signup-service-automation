﻿namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IAssurancPage
    {
        public bool ClickOnCheckEligibilityTask();

        public bool VerifyEligibilityTaskStatus(string status);

        public void AssuranceCompleteWithNoSelection(string country, string FBONumber);

        public void NoFBONumberToCompleteEligibility(string FBONumber);

        public bool VerifyNoSignUpTaskListPageIsLoaded();

        public bool VerifyErrorMessageOnSPSAssurancePage(string errorMessage);

        public void AssurancePagWithCountry(string country);

        public bool VerifyCountryPageloaded();
    }
}