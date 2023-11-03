namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IReceiveNotificationPage
    {
        public bool VerifyNotificationMessage(string NotifyMessage);

        public bool VerifyNotificationOutcomeMessage(string NotifyoutcomeMessage);

        public bool VerifyGbNiConfirmationMessage(string ConfirmationMessage);
    }
}