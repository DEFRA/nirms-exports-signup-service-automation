namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    public interface IAddEstablishmentPage
    {
        public void ClickOnLink(string linkText);
        public void ClickOnButton(string buttonText);
        public bool VerifyLinksOnEstablishmentPage(string link1, string link2, string link3);
    }
}
