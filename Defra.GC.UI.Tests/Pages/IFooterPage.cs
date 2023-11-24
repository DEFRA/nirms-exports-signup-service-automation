using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    internal interface IFooterPage
    {
        public bool VerifyLinkText(string LinkText);
        public void ClickOnPrivacyFooterLink();
        public void ClickOnCookiesFooterLink();
        public void ClickOnAccessibilityFooterLink();
        public void ClickOnContactFooterLink();
        public void ClickOnTCsFooterLink();
        public bool VerifyFooterText(string FooterHintText);
        public bool VerifyPageTitle(string PageTitle);

    }
}
