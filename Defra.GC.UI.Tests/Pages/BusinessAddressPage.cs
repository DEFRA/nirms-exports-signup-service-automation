using BoDi;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;

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

        #region Page Objects

        public IWebElement Businessname => _driver.WaitForElement(By.XPath("//a[normalize-space()='Business name']"));
        public IWebElement BusinessnameText => _driver.WaitForElement(By.XPath("//input[@id='business-name']"));
        public IWebElement AddressLine1 => _driver.WaitForElement(By.XPath("//input[@id='address-line-1']"));
        public IWebElement City => _driver.WaitForElement(By.XPath("//input[@id='address-city']"));
        public IWebElement Realpost => _driver.WaitForElement(By.XPath("//input[@id='address-postcode']"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Save and continue']"));
        private By save = By.XPath("//button[normalize-space()='Save and continue']");
        private IWebElement InvalidError => _driver.WaitForElement(By.XPath("//p[@id='Name_Error' and  not(self::span)]"));
        private IWebElement Address => _driver.WaitForElement(By.XPath(" //a[normalize-space()='Registered address']"));
        private IWebElement AddressOne => _driver.WaitForElement(By.XPath("//input[@id='LineOne']"));
        private IWebElement AddressTown => _driver.WaitForElement(By.XPath("//input[@id='CityName']"));
        private IWebElement AddressPostcode => _driver.WaitForElement(By.XPath("//input[@id='PostCode']"));
        private IWebElement AddressStatus => _driver.WaitForElement(By.XPath("//strong[@id='business-address']"));
        private IWebElement ErrorValidationAddress => _driver.WaitForElement(By.XPath("//li//a"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private By Errors = By.XPath("//ul[@class='govuk-list govuk-error-summary__list']//li//a");
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        #endregion Page Objects

        #region Page Methods

        public void ClickOnRegisteredAddres()
        {
            Address.Click();
        }

        public void EnterBusinessAddress(string add1, string town, string postcode)
        {
            AddressOne.Clear();
            AddressTown.Clear();
            AddressPostcode.Clear();
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

        public string ValidateInvalidErrorMessage()
        {
            return InvalidError.Text;
        }

        public string VerifyUserinTaskListPage()
        {
            return _driver.Url;
        }

        public bool VerifyAddressStatus(string status)
        {
            return AddressStatus.Text.Contains(status);
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

        public void EditBusinessAddress(string add1, string town, string postcode)
        {
            AddressOne.Clear();
            AddressTown.Clear(); ;
            AddressPostcode.Clear();
            AddressOne.SendKeys(add1);
            AddressTown.SendKeys(town);
            AddressPostcode.SendKeys(postcode);
            applicationPage.ClickSaveAndReturnToDashboard();
        }
        #endregion Page Methods
    }
}