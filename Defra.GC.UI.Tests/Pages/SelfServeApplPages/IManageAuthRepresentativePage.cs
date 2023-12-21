namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    internal interface IManageAuthRepresentativePage
    {
        public void EnterAuthorisedRepresentativeEmailAddress(string emailAddress);
        public void EnterAuthorisedRepresentativeName(string name);
        public void EnterAuthorisedRepresentativePosition(string position);
        public void SaveAuthorisedRepresentativeDetails();
        public bool VerifyAuthorisedRepresentativeDetailsAs(string name, string position, string emailAddress);
        public bool VerifyErrorMessages(string message1, string message2, string message3, string p3message4);
    }
}
