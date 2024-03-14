namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    public interface IAddEstablishmentPage
    {
        public void ClickOnLink(string linkText);
        public void ClickOnButton(string buttonText);
        public bool VerifyLinksOnEstablishmentPage(string link1, string link2, string link3);
        public bool VerifyEstablishmentDetailsTable(string establishmentName, string Eststatus, string addrPostcode);
        public void AddEstablishmentAsDraft(string establishmentName, string addressLine, string estCity, string estCountry, string addrPostcode);
        public bool VerifyEstablishmentDetails(string establishmentName, string eststatus, string addrPostcode, string emailAddress);
        public void ClickOnEstablishment(string establishmentName);
        public void ClickOnRemoveEstButton();
        public bool VerifyRemovedEstText(string removedEstMessage);
    }
}
