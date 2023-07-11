
namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface ITaskListPage
    {
        public bool ClickOnCheckAnswersAndSubmitSignUp();
        public bool VerifyCheckAnswersAndSubmitSignUpLinkStatus();
        public bool VerifyCheckAnswersAndSubmitSignUpStatus(string status);
    }
}
