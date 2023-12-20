namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    internal interface IManageContactPersonPage
    {
        public void clickOnSaveContactPersonDetails();
        public void enterContactPersonEmailAddress(string emailAddress);
        public void enterContactPersonName(string name);
        public void enterContactPersonposition(string position);
        public void enterContactPersonTelephoneNumber(string telephoneNumber);
        public void verifyContactPersonDetails(string name, string position, string emailAddress, string telephoneNumber);
    }
}
