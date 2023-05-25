using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessContactTelephoneNumberPage : IBusinessContactTelephoneNumberPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement Backlink => _driver.FindElement(By.XPath("//a[contains(text(),'Back')]"));
        private IWebElement TelephoneNumberlink => _driver.FindElement(By.XPath("//a[contains(text(),'Telephone number')]"));
        private IWebElement Telephone => _driver.FindElement(By.Id("phone"));
        private IWebElement SaveAndContinue => _driver.FindElement(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement SaveAndContinueLater => _driver.FindElement(By.XPath("//a[contains(text(),'Save and continue later')]"));
        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public BusinessContactTelephoneNumberPage(IObjectContainer container)
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

        public void ClickOnContactTelephoneNumberLink()
        { 
        
        }

        public void ClickSaveAndContinueLater()
        { 
        
        }

        public void EnterTelephoneNumber(string telephoneNumber)
        { 
        
        }

        public void NavigateToContactTelephoneNumberPage()
        { 
        
        }

        public void NavigateToTaskListPage()
        { 
        
        }

        public void VerifyErrorMessageOnContactTelephoneNumberPage()
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
