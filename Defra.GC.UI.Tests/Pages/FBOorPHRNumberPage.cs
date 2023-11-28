

using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class FBOorPHRNumberPage : IFBOorPHRNumberPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects
        
        private IWebElement FBOorPHRNumber => _driver.WaitForElement(By.XPath("//a[contains(text(),'FBO or PHR number')]"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement SaveAndContinue => _driver.WaitForElement(By.XPath("//button[contains(@id,'button-rbCountrySubmit')]"));
        private IWebElement FBONumberEle => _driver.WaitForElement(By.Id("FboNumber"));
        private IWebElement PHRNumberEle => _driver.WaitForElement(By.Id("PhrNumber"));
        private IWebElement FBOContinue => _driver.WaitForElement(By.Id("button-rbFboSubmit"));
        private IWebElement ErrorMessage => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-error-summary__body')]"));
        private IWebElement FBOorPHRTaskStatus => _driver.WaitForElement(By.Id("fbophr"));
        private IWebElement HintText => _driver.WaitForElement(By.XPath("(//p[contains(@class,'govuk-hint')])[1]"));
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public FBOorPHRNumberPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods
        public bool ClickOnFBOorPHRNumberTask()
        {
            if (PageHeading.Text.Contains("Sign up"))
            {
                FBOorPHRNumber.Click();
            }
            return PageHeading.Text.Contains("have a Food Business Operator (FBO) or Plant Health Registration (PHR) number?");
        }

        public void ContinueFBOorPHRNumberTaskWithoutFBOorPHRNumber()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,3000)", "");
            Thread.Sleep(1000);
            _driver.ClickRadioButton("does not have either of these numbers");
            FBOContinue.Click();
        }

        public void EditFBONumberToCompleteFBOorPHRNumberTask(string FBONumber)
        {
            CompleteFBOorPHRNumberTaskWithFBONumber(FBONumber);
            applicationPage.ClickSaveAndReturnToDashboard();
        }

        public void EditPHRNumberToCompleteEligibility(string PHRNumber)
        {
            CompleteFBOorPHRNumberTaskWithPHRNumber(PHRNumber);
            applicationPage.ClickSaveAndReturnToDashboard();
        }

        public void InvaildFBOdata(string FBONumber)
        {
            CompleteFBOorPHRNumberTaskWithFBONumber(FBONumber);
            applicationPage.ClickOnSaveAndContinue();
        }

        public void CompleteFBOorPHRNumberTaskWithFBONumber(string FBONumber)
        {
            _driver.ClickRadioButton("has an FBO");
            FBONumberEle.Clear();
            FBONumberEle.SendKeys(FBONumber);
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,4000)", "");
            Thread.Sleep(1000);
            //FBOContinue.Click();
        }

        public void InvaildPHRdata(string PHRNumber)
        {
            CompleteFBOorPHRNumberTaskWithPHRNumber(PHRNumber);
            applicationPage.ClickOnSaveAndContinue();
        }

        public void CompleteFBOorPHRNumberTaskWithPHRNumber(string PHRNumber)
        {
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,6000)", "");
            Thread.Sleep(2000);
            _driver.ClickRadioButton("has a PHR");
            PHRNumberEle.Clear();
            PHRNumberEle.SendKeys(PHRNumber);
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,4000)", "");
            Thread.Sleep(1000);
            //FBOContinue.Click();
        }

        public bool VerifyHintTextMessage(string hintText)
        {
            return HintText.Text.Contains(hintText);
        }

        public bool VerifyFBOorPHRNumberTaskStatus(string status)
        {
            string text = FBOorPHRTaskStatus.Text;
            return FBOorPHRTaskStatus.Text.Contains(status);
        }
        #endregion Page Methods






    }
}