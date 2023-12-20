namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    internal interface IManageAuthRepresentativePage
    {
        public void EnterAuthorisedRepresentativeEmailAddress(string emailAddress);
        public void EnterAuthorisedRepresentativeName(string name);
        public void EnterAuthorisedRepresentativePosition(string position);
        public void SaveAuthorisedRepresentativeDetails();
        public void VerifyAuthorisedRepresentativeDetailsAs(string p0, string p1, string p2);
        public void VerifyErrorMessages(string p0, string p1, string p2, string p3);
    }
}
