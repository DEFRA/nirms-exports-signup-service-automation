using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;


namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    public class ManageContactPersonPage : IManageContactPersonPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading'] | //h1[contains(text(),'You have successfully submitted a request to sign ')]"));


        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public ManageContactPersonPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void clickOnSaveContactPersonDetails()
        { }
        public void enterContactPersonEmailAddress(string emailAddress)
        { }
        public void enterContactPersonName(string name)
        { }

        public void enterContactPersonposition(string position)
        { }

        public void enterContactPersonTelephoneNumber(string telephoneNumber)
        { }

        public void verifyContactPersonDetails(string name, string position, string emailAddress, string telephoneNumber)
        { }

        #endregion Page Methods

    }

}
