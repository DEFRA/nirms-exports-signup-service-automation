namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IFBOorPHRNumberPage
    {
       
        public bool ClickOnFBOorPHRNumberTask();
        public void InvaildFBOdata(string FBONumber);
        public void InvaildPHRdata(string PHRNumber);
        public void CompleteFBOorPHRNumberTaskWithFBONumber(string FBONumber);
        public void CompleteFBOorPHRNumberTaskWithPHRNumber(string PHRNumber);
        public void ContinueFBOorPHRNumberTaskWithoutFBOorPHRNumber();
        public void EditFBONumberToCompleteFBOorPHRNumberTask(string FBONumber);
        public void EditPHRNumberToCompleteEligibility(string PHRNumber);
        public bool VerifyFBOorPHRNumberTaskStatus(string status);
        public bool VerifyHintTextMessage(string hintText);
        public bool VerifyDynamicNameOnSPSAssurancePage(string Name, string country);
        public bool VerifySaveAndReturnToDashboardButtonOnFBOPHRPage();
    }
}
