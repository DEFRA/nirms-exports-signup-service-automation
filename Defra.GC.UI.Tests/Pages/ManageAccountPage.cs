using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using Defra.UI.Framework.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class ManageAccountPage : IManageAccountPage
    {
        private IObjectContainer _objectContainer;

        #region Page Objects
        private static readonly By PageHeadingBy = By.CssSelector("h1");
        private IWebElement ManageAccountlink => _driver.WaitForElement(By.XPath("//a[@id='Link-ManageAccount']"));
        private IWebElement AddNewAccountLink => _driver.WaitForElement(By.XPath("//a[@id='link-add-account']"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public ManageAccountPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool VerifyManageAccountLink()
        {
            return VerifyLinkDestination(ManageAccountlink, "Your Defra account");
        }

        public bool VerifyAddNewAccountLink()
        {
            return VerifyLinkDestination(AddNewAccountLink, "Are you registering a business or organisation?");
        }

        private bool VerifyLinkDestination(IWebElement link, string expectedHeading)
        {
            var configuration = ConfigSetup.BaseConfiguration
                ?? throw new InvalidOperationException("Test configuration has not been initialized.");
            var handlesBeforeClick = _driver.WindowHandles.ToHashSet();
            link.Click();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(
                configuration.TestConfiguration.GlobalWaitsInSeconds));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            var actualHeadings = string.Empty;

            try
            {
                return wait.Until(driver =>
                {
                    // Check throughout the wait because a new tab can appear after Click returns.
                    var newHandle = driver.WindowHandles.FirstOrDefault(handle => !handlesBeforeClick.Contains(handle));
                    if (newHandle != null && driver.CurrentWindowHandle != newHandle)
                        driver.SwitchTo().Window(newHandle);

                    var headings = driver.FindElements(PageHeadingBy)
                        .Where(heading => heading.Displayed)
                        .Select(heading => heading.Text)
                        .ToArray();
                    actualHeadings = string.Join(" | ", headings);
                    return headings.Any(heading => heading.Contains(expectedHeading, StringComparison.CurrentCultureIgnoreCase));
                });
            }
            catch (WebDriverTimeoutException ex)
            {
                var pageUrl = new Uri(_driver.Url).GetLeftPart(UriPartial.Path);
                throw new WebDriverTimeoutException(
                    $"Account link did not reach heading '{expectedHeading}'. " +
                    $"Actual headings: '{actualHeadings}'. Page: '{pageUrl}'.", ex);
            }
        }

        #endregion Page Methods

    }
}
