
namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    internal interface IAuthorisedSignatoryEmailAddressPage
    {
        public void ClickOnAuthEmailAddres();
        public void EnterAuthEmailAddress(string emailAddress);
        public void ClickOnSaveAndContinue();
        public bool ValidateInvalidErrorMessage(string errorMessage);
        public void ClickonBusinessBacklink();


    }
}
