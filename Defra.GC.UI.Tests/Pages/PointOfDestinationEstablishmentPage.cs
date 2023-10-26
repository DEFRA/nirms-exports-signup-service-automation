using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class PointOfDestinationEstablishmentPage : IPointOfDestinationEstablishmentPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IPointOfDepartureEstablishmentPage? pointOfDepartureEstablishmentPage => _objectContainer.IsRegistered<IPointOfDepartureEstablishmentPage>() ? _objectContainer.Resolve<IPointOfDepartureEstablishmentPage>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement PageHeading1 => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-l')]"));
        private IWebElement PointOfDestination => _driver.WaitForElementClickable(By.XPath("//a[contains(text(),'Places of destination')]"));
        private IWebElement PointOfDestinationStatus => _driver.WaitForElement(By.Id("establistment-destination"));
        private IWebElement EstablishmentPostcode => _driver.WaitForElement(By.XPath("//input[@id='Postcode']"));
        private IWebElement FindEstablishment => _driver.WaitForElement(By.XPath("//button[contains(text(),'Find establishment')]"));
        private IWebElement SelectAddres => _driver.WaitForElement(By.Id("points-of-departure-address-select"));
        private IWebElement SelectAddresButton => _driver.WaitForElement(By.XPath("//button[contains(text(),'Select address')]"));
        private IWebElement CannotFindEstablishment => _driver.WaitForElement(By.XPath("//span[contains(text(),'Cannot find establishment')]"));
        private IWebElement AddEstablishmentManually => _driver.WaitForElement(By.XPath("//a[contains(text(),'enter the full establishment address')]"));
        private IWebElement EstablishmentName => _driver.WaitForElement(By.Id("EstablishmentName"));
        private IWebElement EstablishmentAddr1 => _driver.WaitForElement(By.Id("LineOne"));
        private IWebElement EstablishmentAddr2 => _driver.WaitForElement(By.Id("LineTwo"));
        private IWebElement EstablishmentCity => _driver.WaitForElement(By.Id("CityName"));
        private IWebElement EstablishmentCountry => _driver.WaitForElement(By.Id("County"));
        private IWebElement Postcode => _driver.WaitForElement(By.Id("PostCode"));
        private IWebElement SaveAndContinue => _driver.WaitForElementClickable(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a"));
        private By ZeroResult => By.XPath("//p[@class='govuk-!-margin-top-8']");
        private IWebElement DuplicateEstErrorMessage => _driver.WaitForElement(By.Id("EstablishmentName_Error"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PointOfDestinationEstablishmentPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void CompletePointsOfDestination(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode)
        {
            if (!PageHeading.Text.Contains("Add a place of destination"))
            {
                ClickOnPointsOfDestinationLink();
            }
            EnterEstablishmentPostcode(establishmentCode);
            // ClickOnCannotFindEstablishmentLink();
            ClickOnAddTheEstablishmentAddressManuallyLink();
            //AddGBPointOfDepartureEstablishmentAddress(establishmentName, establishmentAddress, establishmentCity, establishmentCountry, establishmentCode);
            pointOfDepartureEstablishmentPage.AddGBPointOfDepartureEstablishmentAddress(establishmentName, establishmentAddress, establishmentCity, establishmentCountry, establishmentCode);
            pointOfDepartureEstablishmentPage.AddEstablishmentEmailAddress("test@test.com");
            pointOfDepartureEstablishmentPage.ClickOnIHaveFinishedAddingPointsOfDeparture();
            applicationPage.ClickSaveAndReturnToDashboard();
        }

        public void CompletePointsOfDestinationWithSave(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode)
        {
            EnterEstablishmentPostcode(establishmentCode);
            ClickOnCannotFindEstablishmentLink();
            ClickOnAddTheEstablishmentAddressManuallyLink();
            pointOfDepartureEstablishmentPage.AddGBPointOfDepartureEstablishmentAddress(establishmentName, establishmentAddress, establishmentCity, establishmentCountry, establishmentCode);
            pointOfDepartureEstablishmentPage.AddEstablishmentEmailAddress("test@test.com");
            pointOfDepartureEstablishmentPage.ClickOnIHaveFinishedAddingPointsOfDeparture();
            applicationPage.ClickOnSaveAndContinue();
        }

        public bool VerifyThePointsOfDestinationStatus(string status)
        {
            return PointOfDestinationStatus.Text.Contains(status);
        }

        public bool VerifyErrorMessageOnAddAPointOfDestinationForNoResults(string errorMessage)
        {
            return _driver.FindElement(ZeroResult).Text.Contains(errorMessage);
        }

        public bool ClickOnPointsOfDestinationLink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", PointOfDestination);
            return PageHeading.Text.Contains("of destination");
        }

        public void EnterEstablishmentPostcode(string postcode)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].setAttribute('value', '" + postcode + "')", EstablishmentPostcode);

            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");

            jsExecutor.ExecuteScript("arguments[0].click();", FindEstablishment);
            // FindEstablishment.Click();
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
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", AddEstablishmentManually);
            return PageHeading.Text.Contains("Add a place of destination");
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

        public bool VerifyDuplicateEstablishmentErrorMessage(string errorMessage)
        {
            return DuplicateEstErrorMessage.Text.Contains(errorMessage);
        }

        #endregion Page Methods
    }
}