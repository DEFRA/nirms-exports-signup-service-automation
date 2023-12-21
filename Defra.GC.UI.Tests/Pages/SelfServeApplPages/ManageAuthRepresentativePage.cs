using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    public class ManageAuthRepresentativePage : IManageAuthRepresentativePage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading'] | //h1[contains(text(),'You have successfully submitted a request to sign ')]"));
        private IWebElement SaveAuthRepresentativeDetailsEle => _driver.WaitForElement(By.Id("buttonSelfServeUpdateContactSubmit"));
        private IWebElement AuthRepresentativeName => _driver.WaitForElement(By.Id("contact-person-name"));
        private IWebElement AuthRepresentativePosition => _driver.WaitForElement(By.Id("contact-person-position"));
        private IWebElement AuthRepresentativeEmailAddress => _driver.WaitForElement(By.Id("contact-person-email"));
        private IWebElement AuthRepresentativeDetails => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Authorised representative')]/..//dd"));
        private By ErrorMessages => By.XPath("//h2[contains(@id,'error-summary-title')]/..//div//a");

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public ManageAuthRepresentativePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void EnterAuthorisedRepresentativeEmailAddress(string emailAddress)
        {
            AuthRepresentativeEmailAddress.SendKeys(emailAddress);
        }

        public void EnterAuthorisedRepresentativeName(string name)
        {
            AuthRepresentativeName.SendKeys(name);
        }

        public void EnterAuthorisedRepresentativePosition(string position)
        {
            AuthRepresentativePosition.SendKeys(position);
        }

        public void SaveAuthorisedRepresentativeDetails()
        {
            SaveAuthRepresentativeDetailsEle.Click();
        }

        public bool VerifyAuthorisedRepresentativeDetailsAs(string name, string position, string emailAddress)
        {
            return AuthRepresentativeDetails.Text.Contains(name) && AuthRepresentativeDetails.Text.Contains(position) && AuthRepresentativeDetails.Text.Contains(emailAddress);
        }

        public bool VerifyErrorMessages(string message1, string message2, string message3, string message4)
        {
            IList<IWebElement> errorsMessages = _driver.FindElements(ErrorMessages);
            bool status = true;
            List<string> errorList = new List<string>();

            foreach (IWebElement errorele in errorsMessages)
            {
                errorList.Add(errorele.Text);
            }

            foreach (string error in errorList) 
            {
                if (!error.Contains(message1))
                    status = false;
            }
            foreach (string error in errorList)
            {
                if (!error.Contains(message2))
                    status = false;
            }
            foreach (string error in errorList)
            {
                if (!error.Contains(message3))
                    status = false;
            }
            foreach (string error in errorList)
            {
                if (!error.Contains(message4))
                    status = false;
            }
            return status;
        }


        #endregion Page Methods

    }

}

