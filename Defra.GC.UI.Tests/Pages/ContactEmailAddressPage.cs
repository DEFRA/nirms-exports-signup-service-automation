using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class ContactEmailAddressPage : IContactEmailAddressPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects
        private By UserIdBy => By.Id("");
        private By ContinueSelectorBy => By.XPath("//button[contains(text(),'Continue')]");
        private By SignInConfirmBy => By.CssSelector("");
        private By SignOutConfirmMessageBy => By.CssSelector("");
        private By MenuButtonBy => By.CssSelector("");

        #endregion

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
