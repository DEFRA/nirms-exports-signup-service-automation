using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessContactEmailAddressPage : IBusinessContactEmailAddressPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement Backlink => _driver.FindElement(By.XPath("//a[contains(text(),'Back')]"));
        private IWebElement EmailAddresslink => _driver.FindElement(By.XPath("//a[contains(text(),'Email address')]"));
        private IWebElement EmailAddress => _driver.FindElement(By.Id("email"));
        private IWebElement SaveAndContinue => _driver.FindElement(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement SaveAndContinueLater => _driver.FindElement(By.XPath("//a[contains(text(),'Save and continue later')]"));
        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public BusinessContactEmailAddressPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods


        public void ClickOnSaveAndContinue()
        { 
        
        }

        public void ClickOnBackLink()
        { 
        
        }

        public void ClickOnContactEmailAddressLink()
        { 
        
        }

        public void ClickSaveAndContinueLater()
        { 
        
        }

        public void EnterEmailAddress(string emailAddress)
        { 
        
        }

        public void NavigateToContactEmailAddressPage()
        { 
        
        }

        public void NavigateToTaskListPage()
        { 
        
        }

        public void VerifyErrorMessageOnContactEmailAddressPage()
        {
        
        }

        public void VerifyNextPageIsLoaded(string pageName)
        { 
        
        }

        public void VerifySignUpTaskListPageIsLoaded() 
        { 
        
        }
        #endregion

    }
}
