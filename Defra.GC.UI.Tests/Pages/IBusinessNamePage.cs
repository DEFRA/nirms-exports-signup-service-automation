
namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessNamePage
    {
        public void ClickOnRegisteredAddres();

        public void ClickOnSaveAndContinue();

        public void EnterBusinessName(string businessname);

        public void EnterInvalidAddress();

        public void SelectCountry();

        public void EntertheAddress();

        public string SelectWithoutCountryAndVerifyMessage();

        public bool VerifyErrorMessageOnBusinessNamePage(string errorMessage);

        public void ClickonBusinessName();

        public void EnterInvalidBusinessName();

        public string ValidateInvalidErrorMessage();

        public string WithoutBusinessNameValidation();

        public void WithoutBusinessName();

        public void ClickonBusinessBacklink();

        public void ClickonSaveContinuelaterlink();

        public string VerifyUserinTaskListPage();

        public List<string> ErrorValidation();

        public bool VerifyBusinessNameStatus(string status);

        public void CompleteBusinessNameTask(string businessName, string businessAddr, string businessTown, string addrPostcode);
    }
}