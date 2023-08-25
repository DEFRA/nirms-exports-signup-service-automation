using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using Defra.UI.Framework.Driver;
using OpenQA.Selenium;


namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class ManageAccountPage : IManageAccountPage
    {
        private IObjectContainer _objectContainer;

        #region Page Objects
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
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
            ManageAccountlink.Click();

            var browserTabs = _driver.WindowHandles;
            _driver.SwitchTo().Window(browserTabs[1]);
            return PageHeading.Text.Contains("Your Defra account");
        }

        public bool VerifyAddNewAccountLink()
        {
            AddNewAccountLink.Click();
            return PageHeading.Text.Contains("Which type of account do you want to add?");
        }

        #endregion Page Methods

    }
}
