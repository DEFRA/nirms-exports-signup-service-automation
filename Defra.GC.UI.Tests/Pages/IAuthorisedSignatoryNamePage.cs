
namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
  
        public interface IAuthorisedSignatoryNamePage
        {
        public void ClickonFullName();
        public void EnterFullName(string fullname);
        public void ClickOnSaveAndContinue();
        public bool VerifyErrorMessageOnAuthorisedSignatoryNamePage(string errorMessage);
        public void ClickOnAuthorisedSignatoryBacklink();
        public void EditAuthorisedSignatoryName(string name);
    }
}
