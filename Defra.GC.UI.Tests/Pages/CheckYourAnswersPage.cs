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
        private IAuthorisedSignatoryNamePage? authorisedSignatoryNamePage => _objectContainer.IsRegistered<IAuthorisedSignatoryNamePage>() ? _objectContainer.Resolve<IAuthorisedSignatoryNamePage>() : null;
        private IAuthorisedSignatoryPositionPage? authorisedSignatoryPositionPage => _objectContainer.IsRegistered<IAuthorisedSignatoryPositionPage>() ? _objectContainer.Resolve<IAuthorisedSignatoryPositionPage>() : null;
        private IAuthorisedSignatoryEmailAddressPage? authorisedSignatoryEmailPage => _objectContainer.IsRegistered<IAuthorisedSignatoryEmailAddressPage>() ? _objectContainer.Resolve<IAuthorisedSignatoryEmailAddressPage>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        #region Page Objects
        private IWebElement ConfirmSanitaryAndPhytosanitaryBox => _driver.WaitForElementExists(By.Id("AssuranceCommitment"));
        private IWebElement AddPointOfDepartureLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Add another place of dispatch')]"));
        private IWebElement AddPointOfDestinationLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Add another place of destination')]"));
        private By NumberOfEstablishments => By.XPath("//div[@class='govuk-summary-card']");
        private IWebElement Businessname => _driver.WaitForElement(By.Id("business-details-name"));
        private IWebElement AnotherBusinessname => _driver.WaitForElement(By.XPath("//a[normalize-space()='Sign up another business']"));
        private IWebElement NoFBOPHRNumberValue => _driver.WaitForElement(By.Id("business-details-fbo"));
        #endregion Page Objects

        #region Page Methods

        public void ConfirmSanitaryAndPhytosanitary()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", ConfirmSanitaryAndPhytosanitaryBox);
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
                BusinessAddressPagetest.EditBusinessAddress(fieldValue, fieldValue, "SE9 0AW");
            }
            else if (fieldName.Contains("FBO number"))
            {
                eligibilityPage.EditFBONumberToCompleteFBOorPHRNumberTask(fieldValue);
            }
            else if (fieldName.Contains("PHR number"))
            {   
                eligibilityPage.EditPHRNumberToCompleteEligibility(fieldValue);
            }
            else if (fieldName.Contains("Contact name"))
            {
                contactNamePage.EditBusinessContactName(fieldValue);
            }
            else if (fieldName.Contains("Contact position"))
            {
                contactNamePage.EditBusinessContactPosition(fieldValue);
            }
            else if (fieldName.Contains("Contact email address"))
            {
                contactNamePage.EditBusinessContactEmailAddress(fieldValue);
            }
            else if (fieldName.Contains("Contact telephone number"))
            {
                contactNamePage.EditBusinessContactTelephoneNumber(fieldValue);
            }
            else if (fieldName.Contains("Address"))
            {
                pointOfDepartureEstablishmentPage.AddGBPointOfDepartureEstablishmentAddress(fieldValue, fieldValue, fieldValue, fieldValue, "SE9 0AA");
                pointOfDepartureEstablishmentPage.AddEstablishmentEmailAddress("test@test.com");
                pointOfDepartureEstablishmentPage.ClickOnIHaveFinishedAddingPointsOfDeparture();
                applicationPage.ClickSaveAndReturnToDashboard();

            }
            else if (fieldName.Contains("Email address"))
            {
                pointOfDepartureEstablishmentPage.AddEstablishmentEmailAddress(fieldValue);
                pointOfDepartureEstablishmentPage.ClickOnIHaveFinishedAddingPointsOfDeparture();
                applicationPage.ClickSaveAndReturnToDashboard();
            }
            else if (fieldName.Contains("Contact person is the authorised representative"))
            {
                if (fieldValue.Contains("Yes"))
                {
                    authorisedSignatoryPage.SelectAuthorisedSignatory("Yes");
                }
                else
                {
                    authorisedSignatoryPage.EditAuthorisedSignatoryToNo("No");
                }
            }
            else if (fieldName.Contains("Authorised Signatory name"))
            {
                authorisedSignatoryNamePage.EditAuthorisedSignatoryName(fieldValue);
            }
            else if (fieldName.Contains("Authorised Signatory position"))
            {
                authorisedSignatoryPositionPage.EditAuthorisedSignatoryPosition(fieldValue);
            }
            else if (fieldName.Contains("Authorised Signatory email address"))
            {
                authorisedSignatoryEmailPage.EditAuthorisedSignatoryEmailAddress(fieldValue);
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

        public string VerifyBusinessNameAdded()
        {
            return Businessname.Text.Trim();
        }

        public void VerifySelectedBusinessNamePage()
        {
            AnotherBusinessname.Click();
        }


        public bool VerifyNoFBONoPHROption(string FBOOptionMsg)
        {
            return NoFBOPHRNumberValue.Text.Contains(FBOOptionMsg);
        }

    #endregion Page Methods

}
}
