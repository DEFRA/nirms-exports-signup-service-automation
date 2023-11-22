using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;



namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
    {
        public class FooterPage : IFooterPage
        {
            private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
            private IObjectContainer _objectContainer;
            private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

            #region Page Objects

            private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading'] | //h1[contains(text(),'You have successfully submitted a request to sign ')]"));
            private IWebElement PrivacyLink => _driver.WaitForElement(By.XPath("(//a[contains(@class,'govuk-footer__link')])[1]"));
            private IWebElement CookiesLink => _driver.WaitForElement(By.XPath("(//a[contains(@class,'govuk-footer__link')])[2]"));
            private IWebElement AccessibilityLink => _driver.WaitForElement(By.XPath("(//a[contains(@class,'govuk-footer__link')])[3]"));
            private IWebElement ContactLink => _driver.WaitForElement(By.XPath("(//a[contains(@class,'govuk-footer__link')])[4]"));
            private IWebElement TermsAndConditionsLink => _driver.WaitForElement(By.XPath("(//a[contains(@class,'govuk-footer__link')])[5]"));
            private IWebElement FooterText => _driver.WaitForElement(By.XPath("//span[contains(@class,'govuk-footer__licence-description')]"));
            //private IWebElement FooterLogo => _driver.WaitForElement(By.XPath("(//div[contains(@class,'govuk-footer__meta-item')]/a)"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
            private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        public FooterPage(IObjectContainer container)
            {
                _objectContainer = container;
            }

            #region Page Methods

           

            public void ClickOnPrivacyFooterLink()
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                jsExecutor.ExecuteScript("arguments[0].click();", PrivacyLink);
            }

            public bool VerifyLinksOnFooterPage(string Link1, string Link2)
            {
            return (_driver.FindElement(By.LinkText(Link1)).Displayed && _driver.FindElement(By.LinkText(Link2)).Displayed) ;
            }

            public bool VerifyPrivacyFooterLink(string privacyLink1, string privacyLink2)
            {
                if (PageHeading.Text.Contains("Northern Ireland Retail Movement Scheme privacy notice"))
                {
                 VerifyLinksOnFooterPage(privacyLink1, privacyLink2);
                }
                return true;
            }

            public void ClickOnCookiesFooterLink()
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,4000)", "");
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                jsExecutor.ExecuteScript("arguments[0].click();", CookiesLink);
            }

            public bool VerifyCookiesFooterLink(string cookiesLink1, string cookiesLink2)
            {
                if (PageHeading.Text.Contains("Cookies"))
                {
                VerifyLinksOnFooterPage(cookiesLink1, cookiesLink2);
                }
                return true;
            }

        public void ClickOnAccessibilityFooterLink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,4000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", AccessibilityLink);
        }

        public bool VerifyAccessibilityFooterLink(string accessibilityLink1, string accessibilityLink2)
        {
            if (PageHeading.Text.Contains("Accessibility statement for Move goods under the NI Retail Movement Scheme"))
            {
                VerifyLinksOnFooterPage(accessibilityLink1, accessibilityLink2);
            }
            return true;
        }

        public void ClickOnContactFooterLink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,4000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", ContactLink);
        }

        public bool VerifyContactFooterLink(string contactLink1 , string contactLink2)
        {
            if (PageHeading.Text.Contains("Contact"))
            {
                VerifyLinksOnFooterPage(contactLink1, contactLink2);
            }
            return true;
        }
        public void ClickOnTCsFooterLink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,4000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", TermsAndConditionsLink);
        }

        public bool VerifyTCsFooterLink(string TCsLink1, string TCsLink2)
        {
            if (PageHeading.Text.Contains("Northern Ireland Retail Movement Scheme Terms & Conditions"))
            {
                VerifyLinksOnFooterPage(TCsLink1, TCsLink2);
            }
            return true;
        }

        public bool VerifyFooterText()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,4000)", "");
            if (FooterText.Text.Contains("All content is available under the"))
            {
                if (_driver.FindElement(By.LinkText("Open Government Licence v3.0")).Displayed);
            }
            return true;
        }
        public bool VerifyLogoInThePageFooter()
        {
            return (_driver.FindElement(By.LinkText("© Crown copyright")).Displayed);
        }

        #endregion Page Methods
    }
    }
