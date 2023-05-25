using BoDi;
using Defra.GC.UI.Tests.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessContactPositionPage : IBusinessContactPositionPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement Positionlink => _driver.FindElement(By.XPath("//a[contains(text(),'Position')]"));
        private IWebElement Position=> _driver.FindElement(By.Id("contact-position"));
        private IWebElement SaveAndContinue => _driver.FindElement(By.Id("button-rbPositionSubmit"));
        private IWebElement SaveAndContinueLater => _driver.FindElement(By.Id("button-rbPositionSave"));

        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public BusinessContactPositionPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods
        public void NavigateToBusinessContactPositionPage()
        { 
        
        }

        public void EnterBusinessContactPosition(string ContactPosition)
        { 
        
        }

        public void VerifyErrorMessageOnBusinessContactPositionPage()
        {

        }

        public void ClickOnBusinessContactPositionLink()
        { 
        
        }
        #endregion

    }
}
