namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessContactTelephoneNumberPage
    {
        public void ClickOnContactTelephoneNumberLink();
        public void ClickOnSaveAndContinue();
        public void EnterTelephoneNumber(string telephoneNumber);
        public bool VerifyErrorMessageOnContactTelephoneNumberPage(string errorMessage);
    }
}
