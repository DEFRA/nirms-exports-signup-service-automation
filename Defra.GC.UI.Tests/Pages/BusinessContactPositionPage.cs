using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
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
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects

        private IWebElement Positionlink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Position')]"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.Id("button-rbPositionSubmit"));
        private IWebElement BusinessContactPosition => _driver.WaitForElement(By.Id("contact-position"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));

        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public BusinessContactPositionPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods
        public void NavigateToBusinessContactPositionPage()
        {
            string url = UrlBuilder.Default().Add("registered-business-contact-position").Build();
            _driver.Navigate().GoToUrl(url);
        }

        public void EnterBusinessContactPosition(string ContactPosition)
        {
            BusinessContactPosition.SendKeys(ContactPosition);
        }

        public void ClickOnSaveAndContinue()
        {
            SaveAndContinue.Click();
        }

        public bool VerifyErrorMessageOnBusinessContactPositionPage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        public void ClickOnBusinessContactPositionLink()
        {
            Positionlink.Click();
        }
        #endregion

    }
}
