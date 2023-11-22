using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    internal interface IFooterPage
    {
        public bool VerifyPrivacyFooterLink(string privacyLink1, string privacyLink2);
        public void ClickOnPrivacyFooterLink();
        public bool VerifyCookiesFooterLink(string cookiesLink1, string cookiesLink2);
        public void ClickOnCookiesFooterLink();
        public bool VerifyAccessibilityFooterLink(string accessibilityLink1, string accessibilityLink2);
        public void ClickOnAccessibilityFooterLink();
        public void ClickOnContactFooterLink();
        public bool VerifyContactFooterLink(string contactLink1, string contactLink2);
        public void ClickOnTCsFooterLink();
        public bool VerifyTCsFooterLink(string TCsLink1, string TCsLink2);
        public bool VerifyFooterText();
        public bool VerifyLogoInThePageFooter();

        public bool VerifyLinksOnFooterPage(string privacyLink1, string privacyLink2);

    }
}
