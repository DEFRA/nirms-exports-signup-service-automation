﻿using BoDi;
using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages.SelfServeApplPages;
using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps.SelfServeApplSteps
{

    [Binding]
    public class SelfServeDashboadSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private ISelfServeDashboardPage? selfServeDashboardPage => _objectContainer.IsRegistered<ISelfServeDashboardPage>() ? _objectContainer.Resolve<ISelfServeDashboardPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private ISignInPage? Signin => _objectContainer.IsRegistered<ISignInPage>() ? _objectContainer.Resolve<ISignInPage>() : null;


        public SelfServeDashboadSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"Approve Sign up request for org '([^']*)' and user '([^']*)'")]
        [Given(@"Approve Sign up request for org '([^']*)' and user '([^']*)'")]
        public void ThenApproveSignUpRequest(string Org, string userType)
        {
            var user = UserObject.GetUser(userType);
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;

            string query = "UPDATE dbo.TradeParties SET ApprovalStatus = 1 where PracticeName = '" + Org + "' ";

            if (ConfigSetup.BaseConfiguration != null)
            {
                dataHelperConnections.ExecuteQuery(connectionString, query);
            }
        }


        [When(@"Update establishment status to '([^']*)' of '([^']*)' for business '([^']*)' and user '([^']*)'")]
        [Given(@"Update establishment status to '([^']*)' of '([^']*)' for business '([^']*)' and user '([^']*)'")]
        public void WhebUpdateEstablishmentStatus(string Status, string establihsmentName, string business, string userType)
        {
            var user = UserObject.GetUser(userType);
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;

            int setStatus = 1;

            if (Status.Equals("Removed"))
                setStatus = 6;
            else if (Status.Equals("Suspended"))
                setStatus = 5;

            string query = $"update [dbo].[LogisticsLocation] set ApprovalStatus = '{setStatus}'" +
                $"where Id = (select ll.Id from [dbo].[LogisticsLocation] ll " +
                $"inner join [dbo].[TradeParties] tp " +
                $"on substring(ll.RemosEstablishmentSchemeNumber, 1, len(ll.RemosEstablishmentSchemeNumber)-4) = tp.RemosBusinessSchemeNumber " +
                $"where tp.OrgId = '{user.OrgID}' and  ll.Name = '{establihsmentName}')";

            if (ConfigSetup.BaseConfiguration != null)
            {
                dataHelperConnections.ExecuteQuery(connectionString, query);
            }
        }



        [When(@"select business '([^']*)' on self serve dashboard")]
        public void WhenSelectBusinessToSignUponSelfServe(string businessSelection)
        {
            selfServeDashboardPage.SelectBusinessOnSelfServe(businessSelection);
        }

        [Then(@"verify Business RMS number '([^']*)' on self serve dashboard page")]
        public void ThenVerifyBusinessRMSNumberOnSelfServeDashboardPage(string BusinessRMSNumber)
        {
            Assert.True(selfServeDashboardPage.VerifyBusinessRMSNumber(BusinessRMSNumber), "Business RMS Number is not matching");
        }

        [When(@"verify Contact Person date format '([^']*)' on self serve dashboard")]
        [Then(@"verify Contact Person date format '([^']*)' on self serve dashboard")]
        public void WhenVerifyContactPersonDateFormatOnSelfServeDashboard(string text)
        {
            Assert.True(selfServeDashboardPage.VerifyContactPersonDateFormatOnSelfServeDashboard(text),"Date format not matching");
        }

        [When(@"click on Authorised Representative change link")]
        public void WhenClickOnAuthorisedRepresentativeChangeLink()
        {
            selfServeDashboardPage.ClickOnAuthorisedRepresentativeChangeLink();
        }

        [Then(@"verify Authorised Representative date format '([^']*)' on self serve dashboard")]
        public void ThenVerifyAuthRepresentativeDateFormatOnSelfServeDashboard(string text)
        {
            Assert.True(selfServeDashboardPage.VerifyAuthRepresentativeDateFormatOnSelfServeDashboard(text), "Date format not matching");
        }

        [When(@"click on contact person change link")]
        public void WhenClickOnContactPersonChangeLink()
        {
            selfServeDashboardPage.ClickOnContactPersonChangeLink();
        }

        [When(@"click on cancel link")]
        public void WhenClickOnCancelLink()
        {
            selfServeDashboardPage.ClickOnCancelLink();
        }

        [When(@"verify status '([^']*)' is displayed for the '([^']*)' on self serve dashboard")]
        [Then(@"verify status '([^']*)' is displayed for the '([^']*)' on self serve dashboard")]
        public void VerifyStatusOnSelfServe(string businessSelection, string Status)
        {
            selfServeDashboardPage.VerifyStatusOnSelfServe(businessSelection, Status);
        }

        [When(@"verify link '([^']*)' is displayed for the '([^']*)' on self serve dashboard")]
        [Then(@"verify link '([^']*)' is displayed for the '([^']*)' on self serve dashboard")]
        public void VerifyLinkOnSelfServe(string businessSelection,string selfServeLink)
        {
            selfServeDashboardPage.VerifyLinkOnSelfServe(businessSelection,selfServeLink);
        }

        [When(@"navigate to Self Serve Dashboard URL")]
        public void NavigateToSelfServeDashboard()
        {
            string url = UrlBuilder.Default().Build();
            _driver.Navigate().GoToUrl(url);
            Signin.EnterPAssword();
        }

        [When(@"Reject Sign up request for org '([^']*)'")]
        [Given(@"Reject Sign up request for org '([^']*)'")]
        public void ThenRejectSignUpRequest(string Org)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;

            string query = "UPDATE dbo.TradeParties SET ApprovalStatus = 2 where PracticeName = '" + Org + "' ";

            if (ConfigSetup.BaseConfiguration != null)
            {
                dataHelperConnections.ExecuteQuery(connectionString, query);
            }
        }

        [When(@"click on refresh link on self serve dashboard")]
        [Then(@"click on refresh link on self serve dashboard")]
        public void WhenClickOnRefreshLink()
        {
            selfServeDashboardPage.ClickOnRefreshLink();
        }

        [When(@"click on Add Business Button on self serve dashboard")]
        [Then(@"click on Add Business Button on self serve dashboard")]
        public void WhenClickOnAddBusinessButton()
        {
            selfServeDashboardPage.ClickOnAddBusinessBtn();
        }

        [When(@"Suspend Sign up request for org '([^']*)'")]
        [Given(@"Suspend Sign up request for org '([^']*)'")]
        public void ThenSuspendSignUpRequest(string Org)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;

            string query = "UPDATE dbo.TradeParties SET ApprovalStatus = 5 where PracticeName = '" + Org + "' ";

            if (ConfigSetup.BaseConfiguration != null)
            {
                dataHelperConnections.ExecuteQuery(connectionString, query);
            }
        }

        [When(@"verify status '([^']*)' on self serve business dashboard page")]
        [Then(@"verify status '([^']*)' on self serve business dashboard page")]
        public void VerifyStatusOnSelfServeBusinessDashboard(string Status)
        {
            selfServeDashboardPage.VerifyStatusOnSelfServeBusinessDashboard(Status);
        }
    }
}
