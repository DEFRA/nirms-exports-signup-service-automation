using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class PointOfDestinationEstablishmentPage : IPointOfDestinationEstablishmentPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-fieldset__heading')]"));
        private IWebElement PageHeading1 => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-l')]"));
        private IWebElement PointOfDestination => _driver.WaitForElementClickable(By.XPath("//a[normalize-space()='Points of destination (optional)']"));
        private IWebElement EstablishmentPostcode => _driver.WaitForElement(By.XPath("//input[@id='search-points-of-departure']"));
        private IWebElement FindEstablishment => _driver.WaitForElement(By.XPath("//button[contains(text(),'Find establishment')]"));
        private IWebElement SelectAddres => _driver.WaitForElement(By.Id("points-of-departure-address-select"));
        private IWebElement SelectAddresButton => _driver.WaitForElement(By.XPath("//button[contains(text(),'Select address')]"));
        private IWebElement CannotFindEstablishment => _driver.WaitForElement(By.XPath("//span[contains(text(),'Cannot find establishment')]"));
        private IWebElement AddEstablishmentManually => _driver.WaitForElement(By.XPath("//a[contains(text(),'Add the establishment address manually')]"));
        private IWebElement EstablishmentName => _driver.WaitForElement(By.Id("establishment-name"));
        private IWebElement EstablishmentAddr1 => _driver.WaitForElement(By.Id("address-line-1"));
        private IWebElement EstablishmentAddr2 => _driver.WaitForElement(By.Id("address-line-2"));
        private IWebElement EstablishmentCity => _driver.WaitForElement(By.Id("address-city"));
        private IWebElement EstablishmentCountry => _driver.WaitForElement(By.Id("address-country"));
        private IWebElement Postcode => _driver.WaitForElement(By.Id("address-postcode"));
        private IWebElement SaveAndContinue => _driver.WaitForElementClickable(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PointOfDestinationEstablishmentPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool ClickOnPointsOfDestinationLink()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", PointOfDestination);
            return PageHeading.Text.Contains("Add a point of destination (optional)");
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
            return PageHeading.Text.Contains("Add a point of departure");
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

        #endregion Page Methods
    }
}