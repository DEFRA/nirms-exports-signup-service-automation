
namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessNamePage
    {
        public void ClickOnSaveAndContinue();

        public void EnterBusinessName(string businessname);

        public string SelectWithoutCountryAndVerifyMessage();

        public bool VerifyErrorMessageOnBusinessNamePage(string errorMessage);

        public void ClickonBusinessName();

        public string ValidateInvalidErrorMessage();

        public string WithoutBusinessNameValidation();

        public void ClickonBusinessBacklink();

        public void ClickonSaveContinuelaterlink();

        public string VerifyUserinTaskListPage();

        public bool VerifyBusinessNameStatus(string status);

        public void CompleteBusinessNameTask(string businessName, string businessAddr, string businessTown, string addrPostcode);

        public void CompleteBusinessNameTaskWithSave(string businessName, string businessAddr, string businessTown, string addrPostcode);

        public void EditBusinessNameTask(string businessName);

        public bool VerifyBusinessName(string businessName);
    }
}