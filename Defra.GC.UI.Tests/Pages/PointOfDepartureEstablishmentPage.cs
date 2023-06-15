using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class PointOfDepartureEstablishmentPage : IPointOfDepartureEstablishmentPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-fieldset__heading')]"));
        private IWebElement PageHeading1 => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-l')]"));
        private IWebElement PointOfDeparture => _driver.WaitForElementClickable(By.XPath("//a[contains(text(),'Points of departure')]"));
        private IWebElement EstablishmentPostcode => _driver.WaitForElement(By.XPath("//input[@id='Postcode']"));
        private IWebElement FindEstablishment => _driver.WaitForElement(By.XPath("//button[contains(text(),'Find establishment')]"));
        private IWebElement SelectAddres => _driver.WaitForElement(By.Id("points-of-departure-address-select"));
        private IWebElement SelectAddresButton => _driver.WaitForElement(By.XPath("//button[contains(text(),'Select address')]"));
        private IWebElement CannotFindEstablishment => _driver.WaitForElement(By.XPath("//span[contains(text(),'Cannot find establishment')]"));
        private IWebElement AddEstablishmentManually => _driver.WaitForElement(By.XPath("//a[contains(text(),'Add the establishment address manually')]"));
        private IWebElement EstablishmentName => _driver.WaitForElement(By.Id("EstablishmentName"));
        private IWebElement EstablishmentAddr1 => _driver.WaitForElement(By.Id("LineOne"));
        private IWebElement EstablishmentAddr2 => _driver.WaitForElement(By.Id("LineTwo"));
        private IWebElement EstablishmentCity => _driver.WaitForElement(By.Id("CityName"));
        private IWebElement EstablishmentCountry => _driver.WaitForElement(By.Id("Country"));
        private IWebElement Postcode => _driver.WaitForElement(By.Id("PostCode"));
        private IWebElement SaveAndContinue => _driver.WaitForElementClickable(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement EstablishmentEmailAddress => _driver.WaitForElement(By.Id("establishment-email"));
        private IWebElement Continue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        private By NumberOfEstablishments => By.XPath("//div[@class='govuk-summary-card']");
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));
        private IWebElement ChangedEstablishmentName => _driver.WaitForElement(By.XPath("//h2[contains(@class,'govuk-summary-card__title')]"));
        private IWebElement ChangedEstablishmentAddr => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Address')]/..//dd[@class='govuk-summary-list__value']"));
        private IWebElement ChangeEstablishmentEmail => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Email address')]/..//a"));
        private IWebElement ChangePostcode => _driver.WaitForElement(By.XPath("//a[contains(text(),'Change')]"));
        private IWebElement EmailAdressPage => _driver.WaitForElement(By.XPath("//label[contains(text(),'Establishment email address (optional)')]"));
        private IWebElement ChangedEmailAdress => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Email address')]/..//dd"));
        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public PointOfDepartureEstablishmentPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool ClickOnPointsOfDepartureLink()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", PointOfDeparture);
            return PageHeading.Text.Contains("Add a point of departure");
        }

        public void EnterEstablishmentPostcode(string postcode)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].setAttribute('value', '" + postcode + "')", EstablishmentPostcode);
            FindEstablishment.Click();
        }

        public bool VerifyAddAPointOfDeparturePage()
        {
            return PageHeading1.Text.Contains("Add a point of departure");
        }

        public void ClickOnCannotFindEstablishmentLink()
        {
            CannotFindEstablishment.Click();
        }

        public bool ClickOnAddTheEstablishmentAddressManuallyLink()
        {
            AddEstablishmentManually.Click();
            return PageHeading.Text.Contains("Establishments");
        }

        public void AddGBPointOfDepartureEstablishmentAddress(string testName, string testAddress, string testCity, string testCountry, string testCode)
        {
            EstablishmentName.SendKeys(testName);
            EstablishmentAddr1.SendKeys(testAddress);
            EstablishmentAddr2.SendKeys(testAddress);
            EstablishmentCity.SendKeys(testCity);
            EstablishmentCountry.SendKeys(testCountry);
            Postcode.SendKeys(testCode);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }

        public bool VerifyErrorMessageOnAddAPointOfDeparture(string errorMessage)
        {
            return ErrorMessage.Text.Contains(errorMessage);
        }

        public void AddEstablishmentEmailAddress(string emailAddress)
        {
            EstablishmentEmailAddress.SendKeys(emailAddress);
            Continue.Click();
        }

        public void ClickOnAddAnotherEstablishmentAddress()
        {
            _driver.ClickRadioButton("Yes, add another point");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }

        public void ClickOnIHaveFinishedAddingPointsOfDeparture()
        {
            _driver.ClickRadioButton("No, I have finished adding points");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }

        public bool VerifyMoreThan1EstablishmentAddressesAdded()
        {
            int count = _driver.FindElements(NumberOfEstablishments).Count();
            if (count > 1)
                return true;
            else
                return false;
        }

        public void RemoveEstablishmentAddress(string establishmentAddress)
        {
            string RemoveEstablishment = "//h2[contains(text(),'" + establishmentAddress + "')]/..//a";
            _driver.WaitForElement(By.XPath(RemoveEstablishment)).Click();
        }

        public int VerifyEstablishmentAddressCount()
        {
            return _driver.FindElements(NumberOfEstablishments).Count();
        }

        public bool VerifySearchForEstablishmentAddressPageLoaded()
        {
            return FindEstablishment.Displayed;
        }


        public void ClickOnChangeEstablishmentAddress(string establishmentName)
        {
            string RemoveEstablishment = "//h2[contains(text(),'" + establishmentName + "')]/../following-sibling::div//a";
            _driver.WaitForElement(By.XPath(RemoveEstablishment)).Click();
        }

        public bool VerifyAddEstablishmentAddressManuallyPageLoaded()
        {
            return EstablishmentName.Displayed;
        }

        public bool VerifyChangedEstablishmentAddressFields(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode)
        {
            if (ChangedEstablishmentName.Text.Contains(establishmentName) && ChangedEstablishmentAddr.Text.Contains(establishmentAddress) && ChangedEstablishmentAddr.Text.Contains(establishmentCity) && ChangedEstablishmentAddr.Text.Contains(establishmentCode))
                return true;
            else
                return false;
        }

        public void ClickOnChangeEstablishmentPostcode()
        {
            ChangePostcode.Click();
        }

        public bool VerifyEstablishmentPostcodeChanged(string establishmentCode)
        {
            string GetChangedPostcode = "//span[contains(text(),'" + establishmentCode + "')]";
            return _driver.WaitForElement(By.XPath(GetChangedPostcode)).Displayed;
        }

        public void ClickOnChangeEstablishmentEmailAddress()
        {
            ChangeEstablishmentEmail.Click();
        }

        public bool VerifyAddEstablishmentEmailAddressPageLoaded()
        {
            return EmailAdressPage.Displayed;
        }

        public bool VerifyChangedEstablishmentEmailAddress(string establishmentEmail)
        {
            return ChangedEmailAdress.Text.Contains(establishmentEmail);
        }


        #endregion

    }
}
