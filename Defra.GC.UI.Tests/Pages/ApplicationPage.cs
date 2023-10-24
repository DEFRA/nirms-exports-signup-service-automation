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

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading'] | //h1[contains(text(),'You have successfully submitted a request to sign ')]"));
        private IWebElement Backlink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Back')]"));
        private IWebElement feedbacklink => _driver.WaitForElement(By.XPath("//a[normalize-space()='feedback']"));
        private IWebElement BackToDashboardlink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Back to dashboard')]"));
        private IWebElement SaveAndReturnToDashboard => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save and return to dashboard')]"));
        private IWebElement SignUPTaskPage => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl']"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement Continue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Continue']"));
        private IWebElement Feedbacktext => _driver.WaitForElement(By.XPath("//div[@class='QuestionText BorderColor']"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public ApplicationPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool VerifyNextPageIsLoaded(string pageName)
        {
            string text = PageHeading.Text;
            return PageHeading.Text.Contains(pageName);
        }

        public void ClickOnBackLink()
        {
            Backlink.Click();
        }

        public void ClickOnFeedBackLink()
        {
            feedbacklink.Click();
        }

        public void ClickonBackToDashboardlink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,-4000)", "");
            Thread.Sleep(1000);
            BackToDashboardlink.Click();
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

        public bool VerifyFeedbackPageLoaded()
        {
            return Feedbacktext.Text.Contains("Overall");
        }

        public void ClickSaveAndReturnToDashboard()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndReturnToDashboard);
        }

        public void ClickOnSaveAndContinue()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }

        public void ClickOnContinue()
        {
            Console.WriteLine("Switched to tab");
            Thread.Sleep(1000);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", Continue);
        }

        public void ClickOnBackToDashboardLink()
        {
            BackToDashboardlink.Click();
        }

        public void SwitchToNextTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.LastOrDefault());
            Thread.Sleep(1000);
        }

        public void SwitchToPreviousOpenTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
        }

        #endregion Page Methods
    }
}