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
        private IWebElement ConfirmationNotification => _driver.WaitForElement(By.XPath("(//div[@class='govuk-grid-column-two-thirds']/p)[4]"));

        #endregion Page Objects

        #region Page Methods

        public bool VerifyNotificationMessage(string NotifyMessage)
        {
            return PageHeadingNotification.Text.Contains(NotifyMessage);
        }

        public bool VerifyGbNiConfirmationMessage(string ConfirmationMessage)
        {
            return ConfirmationNotification.Text.Contains(ConfirmationMessage);
        }

        public bool VerifyNotificationOutcomeMessage(string NotifyoutcomeMessage)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,4000)", "");
            return PageHeadingOutcomeNotification.Text.Contains(NotifyoutcomeMessage);
        }

        #endregion Page Methods
    }
}