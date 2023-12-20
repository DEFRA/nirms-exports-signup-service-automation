using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using Defra.UI.Framework.Driver;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    public class ManageAuthRepresentativePage : IManageAuthRepresentativePage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading'] | //h1[contains(text(),'You have successfully submitted a request to sign ')]"));


        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public ManageAuthRepresentativePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void EnterAuthorisedRepresentativeEmailAddress(string emailAddress)
        { }

        public void EnterAuthorisedRepresentativeName(string name)
        { }

        public void EnterAuthorisedRepresentativePosition(string position)
        { }

        public void SaveAuthorisedRepresentativeDetails()
        { }

        public void VerifyAuthorisedRepresentativeDetailsAs(string p0, string p1, string p2)
        { }

        public void VerifyErrorMessages(string p0, string p1, string p2, string p3)
        { }


        #endregion Page Methods

    }

}
