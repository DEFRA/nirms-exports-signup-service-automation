namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IReceiveNotificationPage
    {
        public bool VerifyNotificationMessage(string NotifyMessage);

        public bool VerifyNotificationOutcomeMessage(string NotifyoutcomeMessage);

        public bool VerifyGbConfirmationMessage(string ConfirmationMessage);
        public bool VerifyNiConfirmationMessage(string ConfirmationMessage);
        public void ClickOnReturnToBusinesses();

    }
}