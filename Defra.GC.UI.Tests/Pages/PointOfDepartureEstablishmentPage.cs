using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class PointOfDepartureEstablishmentPage : IPointOfDepartureEstablishmentPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement PageHeading1 => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-l')]"));
        private IWebElement PointOfDeparture => _driver.WaitForElementClickable(By.XPath("//a[contains(text(),'Places of dispatch')]"));
        private By PointOfDestinationLink => By.XPath("//a[normalize-space()='Places of destination']");
        private IWebElement PointOfDepartureStatus => _driver.WaitForElement(By.Id("establistment-dispatch"));
        private IWebElement EstablishmentPostcode => _driver.WaitForElement(By.XPath("//input[@id='Postcode']"));
        private IWebElement FindEstablishment => _driver.WaitForElement(By.XPath("//button[contains(text(),'Find establishment')]"));
        private IWebElement SelectAddres => _driver.WaitForElement(By.Id("points-of-departure-address-select"));
        private IWebElement SelectAddresButton => _driver.WaitForElement(By.XPath("//button[contains(text(),'Select address')]"));
        private By CannotFindEstablishment => By.XPath("//span[contains(text(),'Cannot find establishment')]");
        private IWebElement AddEstablishmentManually => _driver.WaitForElement(By.XPath("//a[contains(text(),'enter the full establishment address')]"));
        private IWebElement EstablishmentName => _driver.WaitForElement(By.Id("EstablishmentName"));
        private IWebElement EstablishmentAddr1 => _driver.WaitForElement(By.Id("LineOne"));
        private IWebElement EstablishmentAddr2 => _driver.WaitForElement(By.Id("LineTwo"));
        private IWebElement EstablishmentCity => _driver.WaitForElement(By.Id("CityName"));
        private IWebElement EstablishmentCountry => _driver.WaitForElement(By.Id("County"));
        private IWebElement Postcode => _driver.WaitForElement(By.Id("PostCode"));
        private IWebElement SaveAndContinue => _driver.WaitForElementClickable(By.XPath("//button[contains(text(),'Save and continue')]"));
        private IWebElement EstablishmentEmailAddress => _driver.WaitForElement(By.Id("establishment-email"));
        private IWebElement Continue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        private By NumberOfEstablishments => By.XPath("//div[@class='govuk-summary-card']");
        private By ErrorMessage => By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a");
        private IWebElement ChangedEstablishmentName => _driver.WaitForElement(By.XPath("//h2[contains(@class,'govuk-summary-card__title')]"));
        private IWebElement ChangedEstablishmentAddr => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Address')]/..//dd[@class='govuk-summary-list__value']"));
        private IWebElement ChangeEstablishmentEmail => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Email address')]/..//a"));
        private IWebElement ChangePostcode => _driver.WaitForElement(By.XPath("//a[contains(text(),'Change')]"));
        private IWebElement EmailAdressPage => _driver.WaitForElement(By.XPath("//label[contains(text(),'Establishment email address (optional)')]"));
        private IWebElement ChangedEmailAdress => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Email address')]/..//dd"));
        private IWebElement InvalidEmailAdressPage => _driver.WaitForElement(By.XPath("//p[@id='Email_Error']"));
        private By AddAnotherPlaceOfDispatchMessage => By.XPath("//h3[contains(text(),'Have you added all your business’ places of')]");
        private IWebElement DifferentPostcode => _driver.WaitForElement(By.XPath("//a[normalize-space()='entered the postcode correctly']"));
        private IWebElement AddressMnualLink => _driver.WaitForElement(By.XPath("//a[normalize-space()='enter an address manually.']"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PointOfDepartureEstablishmentPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void CompletePointsOfDeparture(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode)
        {
            if (!PageHeading.Text.Contains("Add a place of dispatch"))
            {
                ClickOnPointsOfDepartureLink();
            }
            EnterEstablishmentPostcode(establishmentCode);
            ClickOnCannotFindEstablishmentLink();
            ClickOnAddTheEstablishmentAddressManuallyLink();
            AddGBPointOfDepartureEstablishmentAddress(establishmentName, establishmentAddress, establishmentCity, establishmentCountry, establishmentCode);
            AddEstablishmentEmailAddress("test@test.com");
            ClickOnIHaveFinishedAddingPointsOfDeparture();
            applicationPage.ClickSaveAndReturnToDashboard();
        }

        public void CompletePointsOfDepartureWithSave(string establishmentName, string establishmentAddress, string establishmentCity, string establishmentCountry, string establishmentCode)
        {
            EnterEstablishmentPostcode(establishmentCode);
            ClickOnCannotFindEstablishmentLink();
            ClickOnAddTheEstablishmentAddressManuallyLink();
            AddGBPointOfDepartureEstablishmentAddress(establishmentName, establishmentAddress, establishmentCity, establishmentCountry, establishmentCode);
            AddEstablishmentEmailAddress("test@test.com");
            ClickOnIHaveFinishedAddingPointsOfDeparture();
            applicationPage.ClickOnSaveAndContinue();
        }

        public bool VerifyThePointsOfDepartureStatus(string status)
        {
            return PointOfDepartureStatus.Text.Contains(status);
        }

        public bool ClickOnPointsOfDepartureLink()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", PointOfDeparture);
            return PageHeading.Text.Contains("of dispatch");
        }

        public void EnterEstablishmentPostcode(string postcode)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].setAttribute('value', '" + postcode + "')", EstablishmentPostcode);
            FindEstablishment.Click();
        }

        public bool VerifyAddAPointOfDeparturePage()
        {
            return PageHeading1.Text.Contains("Add a place of dispatch");
        }

        public void ClickOnCannotFindEstablishmentLink()
        {
            if (_driver.FindElements(CannotFindEstablishment).Count > 0)
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                jsExecutor.ExecuteScript("arguments[0].click();", _driver.FindElement(CannotFindEstablishment));
            }
        }

        public void ClickOndifferentPostCodeLink()
        {
            DifferentPostcode.Click();
        }

        public void ClickOnSelectAddressButton()
        {
            SelectAddresButton.Click();
        }

        public void ClickOnAdressManuallyLink()
        {
            AddressMnualLink.Click();
        }

        public bool ClickOnAddTheEstablishmentAddressManuallyLink()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", AddEstablishmentManually);
            return PageHeading.Text.Contains("Establishments");
        }

        public void AddGBPointOfDepartureEstablishmentAddress(string testName, string testAddress, string testCity, string testCountry, string testCode)
        {
            if (_driver.FindElements(AddAnotherPlaceOfDispatchMessage).Count > 0)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,4000)", "");
                Thread.Sleep(1000);
                _driver.ClickRadioButton("No, I need to add another place of");
                IJavaScriptExecutor jsExecute = (IJavaScriptExecutor)_driver;
                jsExecute.ExecuteScript("arguments[0].click();", SaveAndContinue);
            }
            EstablishmentName.Clear();
            EstablishmentAddr1.Clear();
            EstablishmentAddr2.Clear();
            EstablishmentCity.Clear();
            EstablishmentCountry.Clear();
            Postcode.Clear();
            EstablishmentName.SendKeys(testName);
            EstablishmentAddr1.SendKeys(testAddress);
            EstablishmentAddr2.SendKeys(testAddress);
            EstablishmentCity.SendKeys(testCity);
            EstablishmentCountry.SendKeys(testCountry);
            Postcode.SendKeys(testCode);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndContinue);

            //if (_driver.FindElements(ErrorMessage).Count > 0)
            //{
            //    if (_driver.FindElement(ErrorMessage).Text.Contains("This address has already been added as a place of"))
            //    {
            //        EstablishmentAddr1.SendKeys("123");
            //        IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            //        jsExecutor1.ExecuteScript("arguments[0].click();", SaveAndContinue);
            //    }
            //}
        }

        public bool VerifyErrorMessageOnAddAPointOfDeparture(string errorMessage)
        {
            return _driver.FindElement(ErrorMessage).Text.Contains(errorMessage);
        }

        public void AddEstablishmentEmailAddress(string emailAddress)
        {
            EstablishmentEmailAddress.Clear();
            EstablishmentEmailAddress.SendKeys(emailAddress);
            // Continue.Click();
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", Continue);
        }

        public void ClickOnAddAnotherEstablishmentAddress()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,4000)", "");
            Thread.Sleep(1000);
            _driver.ClickRadioButton("No, I need to add another place of");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SaveAndContinue);
        }

        public void ClickOnIHaveFinishedAddingPointsOfDeparture()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,400)", "");
            Thread.Sleep(1000);
            _driver.ClickRadioButton("Yes");
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
            //((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,2000)", "");
            //Thread.Sleep(1000);
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
            string RemoveEstablishment = "//h2[contains(text(),'" + establishmentName + "')]/../following-sibling::div//dt[contains(text(),'Address')]/..//a";
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

        public bool VerifyPointsOfDestinationLinkOnTasklistPage()
        {
            if (_driver.FindElements(PointOfDestinationLink).Count > 0)
                return false;
            else
                return true;
        }

        public bool VerifyInvalidEstablishmentEmailAddress(string invalidEmail)
        {
            return InvalidEmailAdressPage.Text.Contains(invalidEmail);
        }

        #endregion Page Methods
    }
}