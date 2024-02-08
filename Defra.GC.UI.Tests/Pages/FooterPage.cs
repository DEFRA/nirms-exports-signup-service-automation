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

       
        public bool VerifyPageTitle(string PageTitle)
        {
            return PageHeading.Text.Contains(PageTitle);
        }

        public bool VerifyLinkText(string LinkText)
        {
            bool status = false;
            IList<IWebElement> LinkTextEle = _driver.FindElements(By.XPath("//a"));
            foreach (IWebElement ele in LinkTextEle)
            {
                if (ele.Text.Contains(LinkText))
                {
                    status = true;
                    break;
                }
            }
            return status;
        }


        public void ClickOnCookiesFooterLink()
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,4000)", "");
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                jsExecutor.ExecuteScript("arguments[0].click();", CookiesLink);
            }


        public void ClickOnAccessibilityFooterLink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,4000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", AccessibilityLink);
        }


        public void ClickOnContactFooterLink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,4000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", ContactLink);
        }

        public void ClickOnTCsFooterLink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,4000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", TermsAndConditionsLink);
        }

        public bool VerifyFooterText(string FooterHintText)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,4000)", "");
            return FooterText.Text.Contains(FooterHintText);
        }

        #endregion Page Methods
    }
    }
