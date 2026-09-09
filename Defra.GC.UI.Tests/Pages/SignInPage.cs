using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class SignInPage : ISignInPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement StartNew => _driver.WaitForElement(By.Id("button-rbIndexSave"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement UserId => _driver.FindElement(By.Id("user_id"));
        private IWebElement Password => _driver.FindElement(By.Id("password"));
        private IWebElement SignIn => _driver.WaitForElement(By.Id("continue"));
        private IWebElement SignOut => _driver.WaitForElement(By.XPath("//a[text()='Sign out']"));
        private IWebElement Accept_Cookies => _driver.WaitForElement(By.XPath("//button[text()='Accept analytics cookies']"));
        private IWebElement Hide_Cookies => _driver.WaitForElement(By.XPath("//a[text()='Hide cookie message']"));
        private By SignInConfirmBy => By.Id("Link-SignOut");
        private IWebElement SignOutConfirmMessage => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-l')]"));
        private IWebElement EnvPassword => _driver.WaitForElement(By.Id("password"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public SignInPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public bool IsPageLoaded()
        {
            return PageHeading.Text.Contains("Sign in using Government Gateway");
        }

        public bool IsSignedIn(string userName, string password)
        {
            UserId.SendKeys(userName);
            Password.SendKeys(password);
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SignIn)).Click();
            Thread.Sleep(1000);
            //_driver.Navigate().GoToUrl("https://tst-sign-up.trade.azure.defra.cloud/registered-business-picker");
            //Thread.Sleep(1000);
            int count = _driver.WaitForElements(SignInConfirmBy).Count(d => d.Text.Trim().Equals("Sign out"));
            return count > 0;
        }

        public bool IsSignedInSelfServe(string userName, string password)
        {
            UserId.SendKeys(userName);
            Password.SendKeys(password);
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SignIn)).Click();
            int count = _driver.WaitForElements(SignInConfirmBy).Count(d => d.Text.Trim().Equals("Sign out"));
            return count > 0;
        }

        public void ClickSignedOut()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,4000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SignOut);
        }

        public bool IsSignedOut()
        {
            ClickSignedOut();
            //return SignOutConfirmMessage.Text.Contains("General certificate for moving goods under the NI");
            return true;
        }

        public void EnterPAssword()
        {
            try
            {
                Accept_Cookies.Click();
                Hide_Cookies.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (PageHeading.Text.Contains("This is for testing use only"))
            {
                EnvPassword.SendKeys(ConfigSetup.BaseConfiguration.TestConfiguration.EnvPassword);
                applicationPage.ClickOnContinue();
            }

            SelectGovernmentGatewaySignInOption();
        }

        private void SelectGovernmentGatewaySignInOption()
        {
            try
            {
                // The service now shows a "How do you want to sign in?" page before the
                // Government Gateway sign-in page. Wait for either that interstitial (which
                // exposes the Government Gateway radio, id="scp") or the Government Gateway
                // sign-in heading to appear.
                _driver.WaitForElementCondition(d =>
                    d.FindElements(By.Id("scp")).Count > 0 ||
                    d.FindElements(By.XPath("//h1[contains(text(),'Sign in using Government Gateway')]")).Count > 0);

                if (_driver.FindElements(By.Id("scp")).Count > 0)
                {
                    // Click the visible label (a trusted click) so Azure B2C registers the
                    // radio selection. The input itself is a hidden govuk radio and a JS
                    // click is untrusted, so B2C only accepts a real click via the label.
                    _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(By.XPath("//label[@for='scp']"))).Click();

                    // Wait until the radio is actually checked before submitting.
                    _driver.WaitForElementCondition(d =>
                        (bool)((IJavaScriptExecutor)d).ExecuteScript("var e=document.getElementById('scp');return e && e.checked;"));

                    // Click the VISIBLE Continue button (id="continueReplacement"). The
                    // id="continue" element is a hidden, zero-size native B2C button that is
                    // never "clickable", so waiting on it just times out.
                    _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(By.Id("continueReplacement"))).Click();

                    // Block until the Government Gateway sign-in page has actually loaded.
                    _driver.WaitForElementCondition(d =>
                        d.FindElements(By.XPath("//h1[contains(text(),'Sign in using Government Gateway')]")).Count > 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}