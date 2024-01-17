using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium.Interactions;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    public class ManageAuthRepresentativePage : IManageAuthRepresentativePage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading'] | //h1[contains(text(),'You have successfully submitted a request to sign ')]"));
        private IWebElement SaveAuthRepresentativeDetailsEle => _driver.WaitForElement(By.Id("buttonSelfServeUpdateAuthRepSubmit"));
        private IWebElement AuthRepresentativeName => _driver.WaitForElement(By.Id("Name"));
        private IWebElement AuthRepresentativePosition => _driver.WaitForElement(By.Id("Position"));
        private IWebElement AuthRepresentativeEmailAddress => _driver.WaitForElement(By.Id("Email"));
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
            AuthRepresentativeEmailAddress.Clear();
            AuthRepresentativeEmailAddress.SendKeys(emailAddress);
        }

        public void EnterAuthorisedRepresentativeName(string name)
        {
            AuthRepresentativeName.Clear();
            AuthRepresentativeName.SendKeys(name);
        }

        public void EnterAuthorisedRepresentativePosition(string position)
        {
            AuthRepresentativePosition.Clear();
            AuthRepresentativePosition.SendKeys(position);
        }

        public void SaveAuthorisedRepresentativeDetails()
        {
            PageHeading.Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,3000)", "");
            Thread.Sleep(1000);
            IWebElement checkBox = _driver.WaitForElementExists(By.XPath("//div[contains(@class,'govuk-checkboxes__item')]/input"));
            Actions actions = new Actions(_driver);
            actions.MoveToElement(checkBox).Click().Build().Perform();
            SaveAuthRepresentativeDetailsEle.Click();
        }

        public void SaveAuthorisedRepresentativeDetailsWithoutConfirm()
        {
            PageHeading.Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,3000)", "");
            Thread.Sleep(1000);
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
                if (error.Contains(message1))
                {
                    status = true;
                    break;
                } 
                else
                status = false;
            }
            foreach (string error in errorList)
            {
                if (error.Contains(message2))
                {
                    status = true;
                    break;
                }
                else
                    status = false;
            }
            foreach (string error in errorList)
            {
                if (error.Contains(message3))
                {
                    status = true;
                    break;
                }
                else
                    status = false;
            }
            foreach (string error in errorList)
            {
                if (error.Contains(message4))
                {
                    status = true;
                    break;
                }
                else
                    status = false;
            }
            return status;
        }


        #endregion Page Methods

    }

}

