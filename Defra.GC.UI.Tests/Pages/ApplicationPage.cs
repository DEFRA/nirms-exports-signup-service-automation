﻿using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class ApplicationPage : IApplicationPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl']"));
        private IWebElement Backlink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Back')]"));
        private IWebElement SaveAndContinueLater => _driver.WaitForElement(By.XPath("//a[contains(text(),'Save and continue later')]"));
        private IWebElement SignUPTaskPage => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl']"));

        #endregion
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public ApplicationPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool VerifyNextPageIsLoaded(string pageName)
        {
            return PageHeading.Text.Contains(pageName);
        }

        public void ClickOnBackLink()
        {
            Backlink.Click();
        }

        public void NavigateToTaskListPage()
        {
            string url = UrlBuilder.Default().Add("registration-tasklist").Build();
            _driver.Navigate().GoToUrl(url);
        }

        public bool VerifySignUpTaskListPageIsLoaded()
        {
            return SignUPTaskPage.Text.Contains("Sign up for the Northern Ireland Retail Movement Scheme");
        }

        public void ClickSaveAndContinueLater()
        {
            SaveAndContinueLater.Click();
        }
        #endregion

    }
}