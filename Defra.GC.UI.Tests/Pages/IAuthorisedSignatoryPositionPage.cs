
namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IAuthorisedSignatoryPositionPage
    {
        public void EnterAuthSignatoryPosition(string AuthSignatoryPosition);

        public void ClickOnSaveAndContinue();

        public bool VerifyErrorMessageOnAuthSignatoryPositionPage(string errorMessage);

    }
}
