﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Defra.Trade.ReMos.AssuranceService.Tests.Features.Application
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AddBusinessEligibility")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    public partial class AddBusinessEligibilityFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "Regression"};
        
#line 1 "AddBusinessEligibility.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Application", "AddBusinessEligibility", "Complete Eligibility task", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Complete eligibility task")]
        [NUnit.Framework.CategoryAttribute("CrossBrowser")]
        [NUnit.Framework.TestCaseAttribute("test", "England", "testFBO", "ACME Ltd", null)]
        public void CompleteEligibilityTask(string logininfo, string country, string fBONumber, string businessSelection, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CrossBrowser"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("FBONumber", fBONumber);
            argumentsOfScenario.Add("Business selection", businessSelection);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Complete eligibility task", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 9
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
 testRunner.And(string.Format("complete eligibility task with \'{0}\', \'{1}\', \'{2}\'", country, fBONumber, businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.Then("verify eligibility task status as \'COMPLETED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify error message for not selecting the country name")]
        [NUnit.Framework.TestCaseAttribute("test", "Which business do you want to sign", null)]
        public void VerifyErrorMessageForNotSelectingTheCountryName(string logininfo, string nextPage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("nextPage", nextPage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify error message for not selecting the country name", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 17
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 18
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 19
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 20
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify back button on country page is going tasklist page")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.TestCaseAttribute("test", "Existing Submission", null)]
        public void VerifyBackButtonOnCountryPageIsGoingTasklistPage(string logininfo, string nextPage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("nextPage", nextPage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify back button on country page is going tasklist page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 28
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 29
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 30
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 31
 testRunner.And("user clicks back button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 32
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify No sign up page appears when no FBO number")]
        [NUnit.Framework.TestCaseAttribute("test", "ACME Ltd", "England", "", "You cannot sign up your business", null)]
        public void VerifyNoSignUpPageAppearsWhenNoFBONumber(string logininfo, string businessSelection, string country, string fBONumber, string nextPage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Business selection", businessSelection);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("FBONumber", fBONumber);
            argumentsOfScenario.Add("nextPage", nextPage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify No sign up page appears when no FBO number", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 39
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 40
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 41
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 42
 testRunner.And(string.Format("complete eligibility task without \'{0}\', \'{1}\', \'{2}\'", businessSelection, country, fBONumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 43
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify back link on Assurance is going country selecting page")]
        [NUnit.Framework.TestCaseAttribute("test", "England", "Where is your business based?", "ACME Ltd", null)]
        public void VerifyBackLinkOnAssuranceIsGoingCountrySelectingPage(string logininfo, string country, string nextPage, string businessSelection, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("nextPage", nextPage);
            argumentsOfScenario.Add("Business selection", businessSelection);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify back link on Assurance is going country selecting page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 49
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 50
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 51
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 52
 testRunner.And(string.Format("complete eligibility task with \'{0}\', \'{1}\'", businessSelection, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 53
 testRunner.And("click on back link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify error message for invalid FBO with Assurance")]
        [NUnit.Framework.TestCaseAttribute("test", "England", "***************", "Enter FBO number using only letters, numbers and hyphens -", "ACME Ltd", null)]
        public void VerifyErrorMessageForInvalidFBOWithAssurance(string logininfo, string country, string fBONumber, string errorMessage, string businessSelection, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("FBONumber", fBONumber);
            argumentsOfScenario.Add("errorMessage", errorMessage);
            argumentsOfScenario.Add("Business selection", businessSelection);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify error message for invalid FBO with Assurance", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 60
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 61
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 62
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 63
 testRunner.And(string.Format("complete eligibility task with invalid data \'{0}\', \'{1}\', \'{2}\'", country, fBONumber, businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 64
 testRunner.Then(string.Format("verify error message \'{0}\' on  SPS_Assurance page", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify confirmation error message for Regulations page")]
        [NUnit.Framework.TestCaseAttribute("test", "England", "testFBO", "Confirm that you have understood the guidance and regulations", "ACME Ltd", null)]
        public void VerifyConfirmationErrorMessageForRegulationsPage(string logininfo, string country, string fBONumber, string errorMessage, string businessSelection, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("FBONumber", fBONumber);
            argumentsOfScenario.Add("errorMessage", errorMessage);
            argumentsOfScenario.Add("Business selection", businessSelection);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify confirmation error message for Regulations page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 70
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 71
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 72
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 73
 testRunner.And(string.Format("complete eligibility task with \'{0}\', \'{1}\', \'{2}\' without Regulations", businessSelection, country, fBONumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 74
 testRunner.Then(string.Format("verify error message \'{0}\' on  Regulations page", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify back link on Regulations page is navigating to SPO page")]
        [NUnit.Framework.TestCaseAttribute("test", "England", "testFBO", "ACME Ltd", null)]
        public void VerifyBackLinkOnRegulationsPageIsNavigatingToSPOPage(string logininfo, string country, string fBONumber, string businessSelection, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("FBONumber", fBONumber);
            argumentsOfScenario.Add("Business selection", businessSelection);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify back link on Regulations page is navigating to SPO page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 81
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 82
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 83
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 84
 testRunner.And(string.Format("complete eligibility task with \'{0}\', \'{1}\', \'{2}\' and navigate to Regulations pa" +
                            "ge", businessSelection, country, fBONumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 85
    testRunner.And("click on back link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 86
 testRunner.Then("user navigates to the SPO_Assurance page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
