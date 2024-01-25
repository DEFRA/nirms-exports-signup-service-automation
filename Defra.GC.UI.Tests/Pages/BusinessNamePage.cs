using BoDi;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class BusinessNamePage : IBusinessNamePage
    {
        public IObjectContainer _objectContainer;

        public BusinessNamePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Objects

        public IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement BusinessDeatailSelectBusiness => _driver.WaitForElement(By.XPath("//a[normalize-space()='Selected business']"));
        public IWebElement StartupNewSignupRequest => _driver.WaitForElement(By.XPath("//a[normalize-space()='start a new sign up request']"));
        public IWebElement Businessname => _driver.WaitForElement(By.XPath("//a[normalize-space()='Business details']"));
        public IWebElement BusinessnameText => _driver.WaitForElement(By.XPath("//input[@id='Name']"));
        public IWebElement AddressLine1 => _driver.WaitForElement(By.XPath("//input[@id='address-line-1']"));
        public IWebElement City => _driver.WaitForElement(By.XPath("//input[@id='address-city']"));
        public IWebElement Realpost => _driver.WaitForElement(By.XPath("//input[@id='address-postcode']"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Save and continue']"));
        private By save = By.XPath("//button[normalize-space()='Save and continue']");
        private IWebElement InvalidError => _driver.WaitForElement(By.XPath("//p[@id='Name_Error' and  not(self::span)]"));
        private IWebElement BackLink => _driver.WaitForElement(By.XPath("//a[normalize-space()='Back']"));
        private IWebElement SaveLater => _driver.WaitForElement(By.XPath("(//a[normalize-space()='Save and continue later'])[1]"));
        private IWebElement BusinessStatus => _driver.WaitForElement(By.XPath("//strong[@id='business-details']"));
        private IWebElement SelectedBusinessName => _driver.WaitForElement(By.XPath("//strong[@id='selected-business']"));
        private IWebElement CountryName => _driver.WaitForElement(By.XPath("//label[normalize-space()='England']"));
        private IWebElement CountryError => _driver.WaitForElement(By.XPath("//p[@id='Country_Error']"));
        private IWebElement Address => _driver.WaitForElement(By.XPath(" //a[normalize-space()='Registered address']"));
        private IWebElement AddressOne => _driver.WaitForElement(By.XPath("//input[@id='address-line-1']"));
        private IWebElement AddressTown => _driver.WaitForElement(By.XPath("//input[@id='address-city']"));
        private IWebElement AddressPostcode => _driver.WaitForElement(By.XPath("//input[@id='address-postcode']"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));
        private IBusinessAddressPage? businessAddressPage => _objectContainer.IsRegistered<IBusinessAddressPage>() ? _objectContainer.Resolve<IBusinessAddressPage>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        private By Errors = By.XPath("//li//a");

        #endregion Page Objects

        #region Page Methods

        public void ClickOnSelectedBusinessNameTask()
        {
            BusinessDeatailSelectBusiness.Click();
        }

        public void ClickOnSignUpNewRequest()
        {
            StartupNewSignupRequest.Click();
        }

        public string SelectWithoutCountryAndVerifyMessage()
        {
            SaveAndContinue.Click();
            return CountryError.Text;
        }

        public bool VerifyErrorMessageOnBusinessNamePage(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        public void ClickonBusinessName()
        {
            Businessname.Click();
        }

        public void EnterBusinessName(string businessname)
        {
            BusinessnameText.Clear();
            BusinessnameText.SendKeys(businessname);
        }

        public void ClickOnSaveAndContinue()
        {
            SaveAndContinue.Click();
        }

        public string ValidateInvalidErrorMessage()
        {
            return InvalidError.Text;
        }

        public string WithoutBusinessNameValidation()
        {
            SaveAndContinue.Click();
            return InvalidError.Text;
        }

        public void ClickonBusinessBacklink()
        {
            BackLink.Click();
        }

        public void ClickonSaveContinuelaterlink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            _driver.ElementImplicitWait();
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SaveLater)).Click();
        }

        public string VerifyUserinTaskListPage()
        {
            return _driver.Url;
        }

        public bool VerifyBusinessNameStatus(string status)
        {
            return BusinessStatus.Text.Contains(status);
        }

        public void CompleteBusinessNameTask(string businessName, string businessAddr, string businessTown, string addrPostcode)
        {
            ClickonBusinessName();
            EnterBusinessName(businessName);
            ClickOnSaveAndContinue();
            businessAddressPage.EnterBusinessAddress(businessAddr, businessTown, addrPostcode);
            applicationPage.ClickSaveAndReturnToDashboard();
        }

        public void CompleteBusinessNameTaskWithSave(string businessName, string businessAddr, string businessTown, string addrPostcode)
        {
            ClickonBusinessName();
            EnterBusinessName(businessName);
            ClickOnSaveAndContinue();
            businessAddressPage.EnterBusinessAddress(businessAddr, businessTown, addrPostcode);
            applicationPage.ClickOnSaveAndContinue();
        }

        public void EditBusinessNameTask(string businessName)
        {
            EnterBusinessName(businessName);
            //ClickOnSaveAndContinue();
            //businessAddressPage.ClickOnSaveAndContinue();
            applicationPage.ClickSaveAndReturnToDashboard();
        }

        public bool VerifyBusinessName(string businessName)
        {
            return SelectedBusinessName.Text.Contains(businessName, StringComparison.CurrentCultureIgnoreCase);
           // return SelectedBusinessName.Text.Contains(businessName.ToUpper());
        }

        #endregion Page Methods
    }
}