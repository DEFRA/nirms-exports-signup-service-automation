using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class CheckYourAnswersPage : ICheckYourAnswersPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public CheckYourAnswersPage(IObjectContainer container)
        {
            _objectContainer = container;
        }
        private IBusinessNamePage? BusinessNamePagetest => _objectContainer.IsRegistered<IBusinessNamePage>() ? _objectContainer.Resolve<IBusinessNamePage>() : null;
        private IBusinessAddressPage? BusinessAddressPagetest => _objectContainer.IsRegistered<IBusinessAddressPage>() ? _objectContainer.Resolve<IBusinessAddressPage>() : null;
        private IBusinessEligibilityPage? eligibilityPage => _objectContainer.IsRegistered<IBusinessEligibilityPage>() ? _objectContainer.Resolve<IBusinessEligibilityPage>() : null;
        private IBusinessContactNamePage? contactNamePage => _objectContainer.IsRegistered<IBusinessContactNamePage>() ? _objectContainer.Resolve<IBusinessContactNamePage>() : null;
        private ITaskListPage? taskListPage => _objectContainer.IsRegistered<ITaskListPage>() ? _objectContainer.Resolve<ITaskListPage>() : null;
        private IAuthorisedSignatoryPage? authorisedSignatoryPage => _objectContainer.IsRegistered<IAuthorisedSignatoryPage>() ? _objectContainer.Resolve<IAuthorisedSignatoryPage>() : null;
        private IPointOfDepartureEstablishmentPage? pointOfDepartureEstablishmentPage => _objectContainer.IsRegistered<IPointOfDepartureEstablishmentPage>() ? _objectContainer.Resolve<IPointOfDepartureEstablishmentPage>() : null;

        #region Page Objects
        private IWebElement ConfirmSanitaryAndPhytosanitaryBox => _driver.WaitForElementExists(By.Id("AssuranceCommitment"));
        private IWebElement AddPointOfDepartureLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Add another place of dispatch')]"));
        private IWebElement AddPointOfDestinationLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Add another place of destination')]"));
        private By NumberOfEstablishments => By.XPath("//div[@class='govuk-summary-card']");

        #endregion Page Objects

        #region Page Methods

        public void ConfirmSanitaryAndPhytosanitary()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", ConfirmSanitaryAndPhytosanitaryBox);
            //IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            //jsExecutor1.ExecuteScript("arguments[0].click();", Continue);
        }

        public void EditValueOnCheckAnswersPage(string fieldName, string fieldValue)
        {
            string EditField = "//dt[contains(text(),'" + fieldName + "')]/..//a";
            IWebElement EditFieldEle = _driver.WaitForElement(By.XPath(EditField));

            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", EditFieldEle);
            //_driver.WaitForElement(By.XPath(EditField)).Click();

            if (fieldName.Contains("Business name"))
            {
                BusinessNamePagetest.EditBusinessNameTask(fieldValue);
            }
            else if (fieldName.Contains("Business address"))
            {
                BusinessAddressPagetest.EditBusinessAddress(fieldValue, fieldValue, fieldValue);
            }
            else if (fieldName.Contains("Country"))
            {
                eligibilityPage.EditCountryToCompleteEligibility(fieldValue);
            }
            else if (fieldName.Contains("FBO number"))
            {
                eligibilityPage.EditFBONumberToCompleteEligibility(fieldValue);
            }
            else if (fieldName.Contains("Contact name"))
            {
                contactNamePage.EditBusinessContactName(fieldValue);
                authorisedSignatoryPage.CompleteContactPersonAuthorisedSignatoryWithYes();
            }
            else if (fieldName.Contains("Contact position"))
            {
                contactNamePage.EditBusinessContactPosition(fieldValue);
                authorisedSignatoryPage.CompleteContactPersonAuthorisedSignatoryWithYes();
            }
            else if (fieldName.Contains("Contact email address"))
            {
                contactNamePage.EditBusinessContactEmailAddress(fieldValue);
                authorisedSignatoryPage.CompleteContactPersonAuthorisedSignatoryWithYes();
            }
            else if (fieldName.Contains("Contact telephone number"))
            {
                contactNamePage.EditBusinessContactTelephoneNumber(fieldValue);
                authorisedSignatoryPage.CompleteContactPersonAuthorisedSignatoryWithYes();
            }
            else if (fieldName.Contains("Address"))
            {
                pointOfDepartureEstablishmentPage.AddGBPointOfDepartureEstablishmentAddress(fieldValue, fieldValue, fieldValue, fieldValue, fieldValue);
                pointOfDepartureEstablishmentPage.AddEstablishmentEmailAddress("test@test.com");
                pointOfDepartureEstablishmentPage.ClickOnIHaveFinishedAddingPointsOfDeparture();
            }
            else if (fieldName.Contains("Email address"))
            {
                pointOfDepartureEstablishmentPage.AddEstablishmentEmailAddress(fieldValue);
                pointOfDepartureEstablishmentPage.ClickOnIHaveFinishedAddingPointsOfDeparture();
            }
            else if (fieldName.Contains("Contact person is the Authorised Signatory"))
            {
                if (fieldValue.Contains("Yes"))
                {
                    authorisedSignatoryPage.SelectAuthorisedSignatory("Yes");
                }
                else 
                {
                    authorisedSignatoryPage.SelectAuthorisedSignatory("No");
                }
            }

            taskListPage.ClickOnCheckAnswersAndSubmitSignUp();
        }

        public bool VerifyEditedValueOnCheckAnswersPage(string fieldName, string fieldValue)
        {
            string ChangedField = "//dt[contains(text(),'" + fieldName + "')]/..//dd";
            string text = _driver.WaitForElement(By.XPath(ChangedField)).Text;
            return _driver.WaitForElement(By.XPath(ChangedField)).Text.Contains(fieldValue);
        }

        public void ClickOnAddAnotherPointOfDepartureLink()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", AddPointOfDepartureLink);
        }

        public void ClickOnAddAnotherPointOfDestinationLink()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", AddPointOfDestinationLink);
        }

        public bool VerifyMoreThan1EstablishmentAddressesAdded()
        {
            int count = _driver.FindElements(NumberOfEstablishments).Count();
            if (count > 1)
                return true;
            else
                return false;
        }


        public bool VerifyTotalEstablishmentAddressesAdded(string TotalNum)
        {
            int totalEstablishments = Convert.ToInt32(TotalNum);
            int count = _driver.FindElements(NumberOfEstablishments).Count();
            if (count == totalEstablishments)
                return true;
            else
                return false;
        }

        public void ClickOnRemoveLinkOnEstblishmentOnCheckAnswersPage(string EstablishemntName)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0,1400)", "");
            _driver.ElementImplicitWait();
            string RemoveEstablishment = "//h2[contains(text(),'" + EstablishemntName + "')]/..//a";
            IWebElement RemoveEstEle = _driver.WaitForElement(By.XPath(RemoveEstablishment));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", RemoveEstEle);
        }

        #endregion Page Methods

    }
}
