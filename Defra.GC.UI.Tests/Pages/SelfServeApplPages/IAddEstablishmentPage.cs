namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    public interface IAddEstablishmentPage
    {
        public void ClickOnLink(string linkText);
        public bool VerifyLinksOnEstablishmentPage(string link1, string link2, string link3);
    }
}
