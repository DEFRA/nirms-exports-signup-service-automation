using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using OpenQA.Selenium;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;


namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages
{
    public class ManageContactPersonPage : IManageContactPersonPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading'] | //h1[contains(text(),'You have successfully submitted a request to sign ')]"));
        private IWebElement SaveContactPersonDetailsEle => _driver.WaitForElement(By.Id("buttonSelfServeUpdateContactSubmit"));
        private IWebElement ContactPersonName => _driver.WaitForElement(By.Id("Name"));
        private IWebElement ContactPersonPosition => _driver.WaitForElement(By.Id("Position"));
        private IWebElement ContactPersonEmailAddress => _driver.WaitForElement(By.Id("Email"));
        private IWebElement ContactPersonTelephoneNum => _driver.WaitForElement(By.Id("PhoneNumber"));
        private IWebElement ContactPersonDetails => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Contact person')]/..//dd"));


        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public ManageContactPersonPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void clickOnSaveContactPersonDetails()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,3000)", "");
            Thread.Sleep(1000); 
            SaveContactPersonDetailsEle.Click();
        }

        public void enterContactPersonEmailAddress(string emailAddress)
        {
            ContactPersonEmailAddress.Clear();
            ContactPersonEmailAddress.SendKeys(emailAddress);
        }
        public void enterContactPersonName(string name)
        {
            ContactPersonName.Clear();
            ContactPersonName.SendKeys(name);
        }

        public void enterContactPersonposition(string position)
        {
            ContactPersonPosition.Clear();
            ContactPersonPosition.SendKeys(position);
        }

        public void enterContactPersonTelephoneNumber(string telephoneNumber)
        {   
            ContactPersonTelephoneNum.Clear();
            ContactPersonTelephoneNum.SendKeys(telephoneNumber);
        }

        public bool verifyContactPersonDetails(string name, string position, string emailAddress, string telephoneNumber)
        {
            return ContactPersonDetails.Text.Contains(name) && ContactPersonDetails.Text.Contains(position) && ContactPersonDetails.Text.Contains(emailAddress) && ContactPersonDetails.Text.Contains(telephoneNumber);
        }

        #endregion Page Methods

    }

}
