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

        private IWebElement PageHeadingOutcomeNotification => _driver.WaitForElement(By.XPath("//div[@class='govuk-grid-column-two-thirds']"));

        #endregion Page Objects

        #region Page Methods

        public bool VerifyNotificationMessage(string NotifyMessage)
        {
            return PageHeadingNotification.Text.Contains(NotifyMessage);
        }

        public bool VerifyNotificationOutcomeMessage(string NotifyoutcomeMessage)
        {
            return PageHeadingNotification.Text.Contains(NotifyoutcomeMessage);
        }

        #endregion Page Methods
    }
}