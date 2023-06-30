namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IAuthorisedSignatoryPage
    {
        public bool ClickOnAuthorisedSignatoryLink();

        public void CompleteContactPersonAuthorisedSignatoryWithYes();

        public void SelectAuthorisedSignatory(string authorisation);

        public bool VerifyErrorMessageOnAuthorisedPage(string erromessage);
    }
}