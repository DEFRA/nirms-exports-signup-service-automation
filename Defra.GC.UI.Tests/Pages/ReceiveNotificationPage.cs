using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class ReceiveNotificationPage : IReceiveNotificationPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public ReceiveNotificationPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Objects

        private IWebElement PageHeadingNotification => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-panel__title')]"));

        private IWebElement PageHeadingOutcomeNotification => _driver.WaitForElement(By.XPath("(//div[@class='govuk-grid-column-two-thirds']/p)[2]"));
        private IWebElement GBConfirmationNotification => _driver.WaitForElement(By.XPath("(//div[@class='govuk-grid-column-two-thirds']/p)[4]"));

        private IWebElement NIConfirmationNotification => _driver.WaitForElement(By.XPath("(//div[@class='govuk-grid-column-two-thirds']/p)[3]"));
        private IWebElement ReturnToBusinesses => _driver.WaitForElement(By.XPath("//a[contains(text(),'Return to your businesses')]"));
        #endregion Page Objects

        #region Page Methods

        public bool VerifyNotificationMessage(string NotifyMessage)
        {
            return PageHeadingNotification.Text.Contains(NotifyMessage);
        }

        public bool VerifyGbConfirmationMessage(string ConfirmationMessage)
        {
            return GBConfirmationNotification.Text.Contains(ConfirmationMessage);
        }

        public bool VerifyNiConfirmationMessage(string ConfirmationMessage)
        {
            return NIConfirmationNotification.Text.Contains(ConfirmationMessage);
        }

        public bool VerifyNotificationOutcomeMessage(string NotifyoutcomeMessage)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,4000)", "");
            return PageHeadingOutcomeNotification.Text.Contains(NotifyoutcomeMessage);
        }

        public void ClickOnReturnToBusinesses()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", ReturnToBusinesses);
        }


        #endregion Page Methods
    }
}