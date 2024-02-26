using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class ApplicationSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        public ApplicationSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"Clear Database for user '([^']*)'")]
        [Given(@"Clear Database for user '([^']*)'")]
        public void ThenClearDatabase(string userType)
        {
            var user = UserObject.GetUser(userType);
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;

            //string query = "DELETE FROM AuthorisedSignatory;DELETE FROM LogisticsLocation;DELETE FROM TradeContacts;DELETE FROM TradeParties;DELETE FROM TradeAddresses;";
            string query = "EXEC DeleteOrganisationById '" + user.OrgID + "' ";

            if (ConfigSetup.BaseConfiguration != null)
            {
                dataHelperConnections.ExecuteQuery(connectionString, query);
            }
        }

        [When(@"Reject signup request in Database for user '([^']*)'")]
        [Given(@"Reject signup request in Database for user '([^']*)'")]
        public void ThenRejectSignUpRequest(string userType)
        {
            var user = UserObject.GetUser(userType);
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;

            string query = "EXEC sp_RejectTradeParty '" + user.OrgID + "' ";

            if (ConfigSetup.BaseConfiguration != null)
            {
                dataHelperConnections.ExecuteQuery(connectionString, query);
            }
        }


        [When(@"Update establishment status to '([^']*)' of '([^']*)' for business '([^']*)'")]
        [Given(@"Update establishment status to '([^']*)' of '([^']*)' for business '([^']*)'")]
        public void WhebUpdateEstablishmentStatus(string Status,string establihsmentName, string userType)
        {
            var user = UserObject.GetUser(userType);
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;

            string Logistics_Id = null ;
            string query1 = "select ll.Id AS Logistics_Id from [dbo].[LogisticsLocation] ll inner join [dbo].[TradeParties] tp substring(ll.RemosEstablishmentSchemeNumber, 1, len(ll.RemosEstablishmentSchemeNumber)-4) = tp.RemosBusinessSchemeNumber where tp.OrgId = '" + user.OrgID + "' and  ll.Name = '" + establihsmentName +"' ";


            if (ConfigSetup.BaseConfiguration != null)
            {
                dataHelperConnections.ExecuteQuery(connectionString, query1);
            }

            int setStatus = 1;

            if (Status.Equals("Removed"))
                setStatus = 6; 
            else if (Status.Equals("Suspended"))
                setStatus = 5;

            string query2 = "update [dbo].[LogisticsLocation]  set ApprovalStatus = '" + setStatus + "' where Id = '" + Logistics_Id + "'";
            
            if (ConfigSetup.BaseConfiguration != null)
            {
                dataHelperConnections.ExecuteQuery(connectionString, query2);
            }

        }

        [When(@"click on save and continue")]
        [Then(@"click on save and continue")]
        public void ThenClickOnSaveAndContinue()
        {
            applicationPage.ClickOnSaveAndContinue();
        }

        [When(@"click on continue button")]
        [Then(@"click on continue button")]
        public void ThenClickOnContinueButton()
        {
            applicationPage.ClickOnContinue();
        }

        [Then(@"verify next page '([^']*)' is loaded")]
        public void ThenVerifyNextPageIsLoaded(string pageName)
        {
            Assert.True(applicationPage.VerifyNextPageIsLoaded(pageName), "Expected page not loaded");
        }

        [Then(@"verify the APHA email support '([^']*)' is appears bottom of the page")]
        public void ThenVerifyTheAPHAEmailSupportIsAppearsBottomOfThePage(string link)
        {
            Assert.True(applicationPage.VerifyAPHAEmail(link), "Link is not loaded");
        }

        [When(@"click on back link")]
        [Then(@"click on back link")]
        public void ThenClickOnBackLink()
        {
            applicationPage.ClickOnBackLink();
        }

        [Then(@"click on the feedback link")]
        public void ThenClickOnTheFeedbackLink()
        {
            applicationPage.ClickOnFeedBackLink();
        }

        [Then(@"verify feedback page is loaded")]
        public void ThenVerifyFeedbackPageIsLoaded()
        {
            Assert.True(applicationPage.VerifyFeedbackPageLoaded(), "Feed back page not loaded");
        }

        [Then(@"verify generic GOV page is loaded")]
        public void ThenVerifygenericGOVPageIsLoaded()
        {
            Assert.True(applicationPage.VerifyGenericGOVPageLoaded(), "Generic GOV page not loaded");
        }

        [When(@"click on back to dashboard link")]
        [Then(@"click on back to dashboard link")]
        public void WhenClickOnBackToDashboardLink()
        {
            applicationPage.ClickonBackToDashboardlink();
        }

        [Then(@"navigate to task list page")]
        public void ThenNavigateToTaskListPage()
        {
            applicationPage.NavigateToTaskListPage();
        }

        [Then(@"verify signUp task list page is loaded")]
        public void ThenVerifySignUpTaskListPageIsLoaded()
        {
            Assert.True(applicationPage.VerifySignUpTaskListPageIsLoaded(), "Signup task list page not loaded");
        }

        [When(@"click Save and return to dashboard")]
        [Then(@"click Save and return to dashboard")]
        public void ThenClickSaveAndreturnToDashboard()
        {
            applicationPage.ClickSaveAndReturnToDashboard();
        }

        [When(@"click return to dashboard")]
        [Then(@"click return to dashboard")]
        public void ThenClickReturnToDashboard()
        {
            applicationPage.ClickReturnToDashboard();
        }

        [When(@"switch to next opened tab")]
        [Then(@"switch to next opened tab")]
        public void SwitchToTab()
        {
            applicationPage.SwitchToNextTab();
            _driver.ElementImplicitWait();
        }

        [When(@"switch to previous tab")]
        [Then(@"switch to previous tab")]
        public void SwitchToPreviousTab()
        {
            applicationPage.SwitchToPreviousOpenTab();
        }

        [Then(@"verify dynamic name '([^']*)' in title '([^']*)' of page")]
        public void ThenVerifyDynamicNameInTitleOfPage(string Name, string title)
        {
            Assert.True(applicationPage.VerifyDynamicNameInTitleOfPage(Name, title), "Signup task list page not loaded");
        }

        [Then(@"verify dynamic name '([^']*)' in error message '([^']*)'")]
        public void ThenVerifyDynamicNameErrorMessage(string Name, string errorMessage)
        {
            Assert.True(applicationPage.VerifyDynamicNameErrorMessage(Name, errorMessage), "Dynamic name not matching error message");
        }

        [Then(@"verify dynamic name '([^']*)' in hint text")]
        public void ThenVerifyDynamicNameInHintTextMessage(string BusinessName)
        {
            Assert.True(applicationPage.VerifyDynamicHintTextMessage(BusinessName), "Dynamic name not matching in hint text");
        }

        [Then(@"Close Current tab")]
        public void CloseCurrentTab()
        {
            applicationPage.CloseCurrentTab();
        }
    }
}