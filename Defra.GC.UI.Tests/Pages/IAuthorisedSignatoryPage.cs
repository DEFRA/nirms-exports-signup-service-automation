namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IAuthorisedSignatoryPage
    {
        public bool ClickOnAuthorisedSignatoryLink();

        public void CompleteContactPersonAuthorisedSignatoryWithYes();

        public void EditAuthorisedSignatoryToNo(string authorisation);

        public void SelectAuthorisedSignatory(string authorisation);

        public bool VerifyErrorMessageOnAuthorisedPage(string erromessage);

        public bool VerifyTheAuthorisedSignatoryStatus(string status);
    }
}