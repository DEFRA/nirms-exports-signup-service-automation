using BoDi;
using Defra.GC.UI.Tests.HelperMethods;
using Defra.GC.UI.Tests.Pages;
using Defra.UI.Framework.Driver;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechTalk.SpecFlow;

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
        public IWebElement AddressLine1 => _driver.WaitForElement(By.XPath("//input[@id='address-line-1']"));

        public IWebElement City => _driver.WaitForElement(By.XPath("//input[@id='address-city']"));
        public IWebElement Realpost => _driver.WaitForElement(By.XPath("//input[@id='address-postcode']"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Save and continue']"));
        private By save = By.XPath("//button[normalize-space()='Save and continue']");
        private IWebElement InvalidError => _driver.WaitForElement(By.XPath("//p[@id='Name_Error' and  not(self::span)]"));
        private IWebElement BackLink => _driver.WaitForElement(By.XPath("//a[normalize-space()='Back']"));
        private IWebElement SaveLater => _driver.WaitForElement(By.XPath("(//a[normalize-space()='Save and continue later'])[1]"));
        private IWebElement Eligiblity => _driver.WaitForElement(By.XPath("//a[normalize-space()='Check eligibility']"));

        private IWebElement CountryName => _driver.WaitForElement(By.XPath("//label[normalize-space()='England']"));
        private IWebElement CountryError => _driver.WaitForElement(By.XPath("//p[@id='Country_Error']"));
        private IWebElement Address => _driver.WaitForElement(By.XPath(" //a[normalize-space()='Registered address']"));
        private IWebElement AddressError => _driver.WaitForElement(By.XPath("//p[@id='LineOne_Error']"));

        private IWebElement AddressOne => _driver.WaitForElement(By.XPath("//input[@id='address-line-1']"));
        private IWebElement AddressTown => _driver.WaitForElement(By.XPath("//input[@id='address-city']"));
        private IWebElement AddressPostcode => _driver.WaitForElement(By.XPath("//input[@id='address-postcode']"));

        private IWebElement ErrorValidationAddress => _driver.WaitForElement(By.XPath("//li//a"));

        private By Errors = By.XPath("//li//a");

        //

        public void ClickOnRegisteredAddres()
        {
            _driver.Navigate().GoToUrl("https://tstgcwebaw1001.azurewebsites.net/registration-tasklist");
            Address.Click();
        }

        public void ClickOnSaveAndContinuebuttonWithoutAddress()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,1000)", "");

            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SaveAndContinue)).Click();
        }

        public void ClickOnEligiblity()
        {
            _driver.Navigate().GoToUrl("https://tstgcwebaw1001.azurewebsites.net/registration-tasklist");
            Eligiblity.Click();
        }

        public void SelectCountry()
        {
            CountryName.Click();
            SaveAndContinue.Click();
        }

        public void EntertheAddress()
        {
            AddressOne.SendKeys("1");
            AddressTown.SendKeys("London");
            AddressPostcode.SendKeys("WV1 3EB");

            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            Thread.Sleep(1000);
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SaveAndContinue)).Click();
        }

        public string SelectWithoutCountryAndVerifyMessage()
        {
            SaveAndContinue.Click();
            return CountryError.Text;
        }

        public void ClickonBusiness()
        {
            _driver.Navigate().GoToUrl("https://tstgcwebaw1001.azurewebsites.net/registration-tasklist");
            Businessname.Click();
        }

        public void EnterBusinessName()
        {
            BusinessnameText.SendKeys("Defra");
            SaveAndContinue.Click();
        }

        public void EnterInvalidBusinessName()
        {
            BusinessnameText.SendKeys("£££*****");
            SaveAndContinue.Click();
        }

        public void EnterInvalidAddress()
        {
            AddressLine1.SendKeys("£££*****");
            City.SendKeys("****");
            Realpost.SendKeys("****");

            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            Thread.Sleep(1000);
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SaveAndContinue)).Click();
        }

        public string ValidateInvalidErrorMessage()
        {
            return InvalidError.Text;
        }

        public void WithoutBusinessName()
        {
            SaveAndContinue.Click();
        }

        public string WithoutBusinessNameValidation()
        {
            return InvalidError.Text;
        }

        public void ClickonBusinessBacklink()
        {
            BackLink.Click();
        }

        public void ClickonSaveContinuelaterlink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            Thread.Sleep(10000);
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SaveLater)).Click();
        }

        public string VerifyUserinTaskListPage()
        {
            Console.WriteLine("-------->", _driver.Url);
            return _driver.Url;
        }

        public List<string> ErrorValidation()
        {
            IList<IWebElement> errors = _driver.FindElements(Errors);
            List<string> errorList = new List<string>();

            foreach (IWebElement error in errors)
            {
                errorList.Add(error.Text);
            }
            return errorList;
        }
    }
}