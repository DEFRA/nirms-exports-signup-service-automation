using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Defra.UI.Framework.Driver;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessContactNamePage : IBusinessContactNamePage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement Backlink => _driver.FindElement(By.XPath("//a[contains(text(),'Back')]"));
        private IWebElement Fullnamelink => _driver.FindElement(By.XPath("//a[contains(text(),'Full name')]"));
        private IWebElement Fullname => _driver.FindElement(By.Id("business-name"));
        private IWebElement SaveAndContinue => _driver.FindElement(By.Id("button-rbCountrySubmit"));
        private IWebElement SaveAndContinueLater => _driver.FindElement(By.Id("button-rbCountrySave"));

        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public BusinessContactNamePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void NavigateToBusinessContactNamePage()
        { 
        
        }

        public void EnterBusinessContactName(string ContactName)
        { 
        
        }

        public void VerifyErrorMessageOnBusinessContactNamePage()
        {

        }

        public void ClickOnBusinessContactNameLink()
        { 
        
        }
        #endregion

    }
}
