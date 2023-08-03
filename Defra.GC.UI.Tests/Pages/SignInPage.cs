using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Data;
using System.Data.SqlClient;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public class SignInPage : ISignInPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        #region Page Objects
        private IWebElement StartNew => _driver.WaitForElement(By.Id("button-rbIndexSave"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement UserId => _driver.FindElement(By.Id("user_id"));
        private IWebElement Password => _driver.FindElement(By.Id("password"));
        private IWebElement SignIn => _driver.WaitForElement(By.Id("continue"));
        private IWebElement SignInConfirm => _driver.WaitForElement(By.Id("Link-SignOut"));
        private By SignInConfirmBy => By.Id("Link-SignOut");
        private IWebElement SignOutConfirmMessage => _driver.WaitForElement(By.CssSelector("h1.govuk-heading-xl"));

        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public SignInPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public bool IsPageLoaded()
        {
            return PageHeading.Text.Contains("Sign in using Government Gateway");
        }

        public bool IsSignedIn(string userName, string password)
        {
            UserId.SendKeys(userName);
            Password.SendKeys(password);
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SignIn)).Click();
            int count = _driver.WaitForElements(SignInConfirmBy).Count(d => d.Text.Trim().Equals("Sign out"));

            return count > 0;
        }

        public void ClickSignedOut()
        {
            _driver.WaitForElements(SignInConfirmBy).SingleOrDefault(d => d.Text.Trim().Equals("Sign out")).Click();
        }

        public bool IsSignedOut()
        {
            ClickSignedOut();
            return SignOutConfirmMessage.Text.Contains("Page not found");
        }

        //public static SqlConnection DBConnect this SqlConnection sqlConnection, ClearDatabase()
        //{
        //    SqlConnection Connection = DriverManager.getConnection("ConnetionString", "Username", "Password");
        //    ;
        //    DataSet ds = new DataSet();
        //    Connection con = new SqlConnection(vConnectionString);
        //    Connection.Open();
        //    SqlDataAdapter adp = new SqlDataAdapter(vQuery, Connection);
        //}
    }
}

