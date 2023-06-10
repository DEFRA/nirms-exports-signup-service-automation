using BoDi;
using Defra.UI.Framework.Driver;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using Microsoft.VisualBasic;
using System.Windows;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessAddressPage : IBusinessAddressPage
    {
        public IObjectContainer _objectContainer;

        public BusinessAddressPage(IObjectContainer container)
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
        private IWebElement AddressStatus => _driver.WaitForElement(By.XPath("//strong[@id='business-address']"));

        private IWebElement ErrorValidationAddress => _driver.WaitForElement(By.XPath("//li//a"));

        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        private By Errors = By.XPath("//li//a");

        public void ClickOnRegisteredAddres()
        {
            string url = UrlBuilder.Default().Add("registration-tasklist").Build();
            _driver.Navigate().GoToUrl(url);
            Address.Click();
        }

        public void EntertheAddressmanually(string add1, string town, string postcode)
        {
            AddressOne.SendKeys(add1);
            AddressTown.SendKeys(town);
            AddressPostcode.SendKeys(postcode);
        }

        public void ClickOnSaveAndContinue()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            _driver.ElementImplicitWait();
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }

        public void ClickOnEligiblity()
        {
            string url = UrlBuilder.Default().Add("registration-tasklist").Build();
            _driver.Navigate().GoToUrl(url);
            Eligiblity.Click();
        }

        public string ValidateInvalidErrorMessage()
        {
            return InvalidError.Text;
        }

        public void ClickonBusinessBacklink()
        {
            BackLink.Click();
        }

        public string VerifyUserinTaskListPage()
        {
            return _driver.Url;
        }

        public string VerifyAddressStatus()
        {
            return AddressStatus.Text;
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