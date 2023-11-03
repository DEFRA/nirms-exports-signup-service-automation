using BoDi;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Steps
{
    [Binding]
    public class ReceiveNotificationStep
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private ICheckYourAnswersPage? checkYourAnswersPage => _objectContainer.IsRegistered<ICheckYourAnswersPage>() ? _objectContainer.Resolve<ICheckYourAnswersPage>() : null;

        private IReceiveNotificationPage? CompletionPage => _objectContainer.IsRegistered<IReceiveNotificationPage>() ? _objectContainer.Resolve<IReceiveNotificationPage>() : null;

        public ReceiveNotificationStep(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"verify  '([^']*)' on completed sign up page")]
        public void ThenVerifyOnCompletedSignUpPage(string message)
        {
            Assert.True(CompletionPage.VerifyNotificationMessage(message), "Mismatching the content on the completion page");
        }

        [Then(@"verify  '([^']*)' outcome of my request submission page")]
        public void ThenVerifyOutcomeOfMyRequestSubmissionPage(string message)
        {
            Assert.True(CompletionPage.VerifyNotificationOutcomeMessage(message), "Mismatching the content on the completion page");
        }

        [Then(@"verify  '([^']*)' GB text on request submission page")]
        public void ThenVerifyGBConfirmationOfMyRequestSubmissionPage(string message)
        {
            Assert.True(CompletionPage.VerifyGbConfirmationMessage(message), "Mismatching the GB content on the completion page");
        }

        [Then(@"verify  '([^']*)' NI text on request submission page")]
        public void ThenVerifyNIConfirmationOfMyRequestSubmissionPage(string message)
        {
            Assert.True(CompletionPage.VerifyNiConfirmationMessage(message), "Mismatching the NI content on the completion page");
        }
    }
}