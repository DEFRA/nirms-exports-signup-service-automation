using BoDi;
using Defra.GC.UI.Tests.HelperMethods;
using Defra.GC.UI.Tests.Pages;
using Defra.UI.Framework.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessPage : IBusinessPage
    {
        public IObjectContainer _objectContainer;

        public BusinessPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public IWebElement Businessname => _driver.WaitForElement(By.XPath("//a[normalize-space()='Business name']"));
        public IWebElement BusinessnameText => _driver.WaitForElement(By.XPath("//input[@id='business-name']"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(.,'Save and continue')]"));

        public void ClickonBusiness()
        {
            Businessname.Click();
        }

        public void EnterBusinessName()
        {
            BusinessnameText.SendKeys("Defra");
            SaveAndContinue.Click();
            Thread.Sleep(21000);
        }

        public void EnterInvalidBusinessName()
        {
            BusinessnameText.SendKeys("£££*****");
            SaveAndContinue.Click();
            Thread.Sleep(21000);
        }
    }
}