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
        [NUnit.Framework.CategoryAttribute("RunOnly")]
        [NUnit.Framework.TestCaseAttribute("test", "England", "testFBO", "ABC ACCOUNTANCY & MARKETING SERVICES LTD.", null)]
        public void CompleteEligibilityTask(string logininfo, string country, string fBONumber, string businessSelection, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CrossBrowser",
                    "RunOnly"};
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
 testRunner.Given("Clear Database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 9
 testRunner.And("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 10
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 11
 testRunner.And(string.Format("select business to sign up \'{0}\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.And("click on eligibility task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 13
 testRunner.And(string.Format("complete eligibility task with \'{0}\', \'{1}\'", country, fBONumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 14
 testRunner.Then("verify eligibility task status as \'COMPLETED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 15
 testRunner.And(string.Format("user verify the selected business name \'{0}\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify error message for not selecting the country name")]
        [NUnit.Framework.CategoryAttribute("RunOnly")]
        [NUnit.Framework.TestCaseAttribute("test", "Which business do you want to sign", null)]
        public void VerifyErrorMessageForNotSelectingTheCountryName(string logininfo, string nextPage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RunOnly"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("nextPage", nextPage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify error message for not selecting the country name", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 22
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 24
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 25
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 26
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify back button on country page is going task list page")]
        [NUnit.Framework.CategoryAttribute("RunOnly")]
        [NUnit.Framework.TestCaseAttribute("test", "ABC ACCOUNTANCY & MARKETING SERVICES LTD.", "Which business do you want to sign up", null)]
        public void VerifyBackButtonOnCountryPageIsGoingTaskListPage(string logininfo, string businessSelection, string nextPage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RunOnly"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Business selection", businessSelection);
            argumentsOfScenario.Add("nextPage", nextPage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify back button on country page is going task list page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 33
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 35
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 36
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 37
 testRunner.And(string.Format("select business to sign up \'{0}\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 38
 testRunner.And("click on eligibility task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 39
 testRunner.And("user clicks back button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 40
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify No sign up page appears when no FBO number")]
        [NUnit.Framework.CategoryAttribute("RunOnly")]
        [NUnit.Framework.TestCaseAttribute("test", "ABC ACCOUNTANCY & MARKETING SERVICES LTD.", "England", "", "You cannot sign up your business", null)]
        public void VerifyNoSignUpPageAppearsWhenNoFBONumber(string logininfo, string businessSelection, string country, string fBONumber, string nextPage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RunOnly"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Business selection", businessSelection);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("FBONumber", fBONumber);
            argumentsOfScenario.Add("nextPage", nextPage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify No sign up page appears when no FBO number", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 47
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 49
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 50
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 51
 testRunner.And(string.Format("select business to sign up \'{0}\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 52
 testRunner.And("click on eligibility task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 53
 testRunner.And(string.Format("complete eligibility task with \'{0}\' and without FBONumber", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify back link on Assurance FBO page is going country selection page")]
        [NUnit.Framework.CategoryAttribute("RunOnly")]
        [NUnit.Framework.TestCaseAttribute("test", "England", "What will your business do", "ABC ACCOUNTANCY & MARKETING SERVICES LTD.", null)]
        public void VerifyBackLinkOnAssuranceFBOPageIsGoingCountrySelectionPage(string logininfo, string country, string nextPage, string businessSelection, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RunOnly"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("nextPage", nextPage);
            argumentsOfScenario.Add("Business selection", businessSelection);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify back link on Assurance FBO page is going country selection page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 61
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 63
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 64
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 65
 testRunner.And(string.Format("select business to sign up \'{0}\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 66
 testRunner.And("click on eligibility task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 67
 testRunner.And(string.Format("complete eligibility task with \'{0}\'", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 68
 testRunner.And("click on back link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 69
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify error message for invalid FBO with Assurance")]
        [NUnit.Framework.CategoryAttribute("RunOnly")]
        [NUnit.Framework.TestCaseAttribute("test", "England", "***************", "Enter an FBO number containing only letters, numbers or hyphens", "ABC ACCOUNTANCY & MARKETING SERVICES LTD.", null)]
        public void VerifyErrorMessageForInvalidFBOWithAssurance(string logininfo, string country, string fBONumber, string errorMessage, string businessSelection, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RunOnly"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("FBONumber", fBONumber);
            argumentsOfScenario.Add("errorMessage", errorMessage);
            argumentsOfScenario.Add("Business selection", businessSelection);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify error message for invalid FBO with Assurance", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 76
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 78
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 79
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 80
 testRunner.And(string.Format("select business to sign up \'{0}\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 81
 testRunner.And("click on eligibility task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 82
 testRunner.And(string.Format("complete eligibility task with invalid data \'{0}\', \'{1}\'", country, fBONumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 83
 testRunner.Then(string.Format("verify error message \'{0}\' on  SPS_Assurance page", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify confirmation error message for Regulations page")]
        [NUnit.Framework.CategoryAttribute("RunOnly")]
        [NUnit.Framework.TestCaseAttribute("test", "England", "testFBO", "Confirm that you have understood the guidance and regulations", "ABC ACCOUNTANCY & MARKETING SERVICES LTD", null)]
        public void VerifyConfirmationErrorMessageForRegulationsPage(string logininfo, string country, string fBONumber, string errorMessage, string businessSelection, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RunOnly"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("FBONumber", fBONumber);
            argumentsOfScenario.Add("errorMessage", errorMessage);
            argumentsOfScenario.Add("Business selection", businessSelection);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify confirmation error message for Regulations page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 90
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 92
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 93
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 94
 testRunner.And(string.Format("select business to sign up \'{0}\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 95
 testRunner.And("click on eligibility task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 96
 testRunner.And(string.Format("complete eligibility task with \'{0}\', \'{1}\' without Regulations", country, fBONumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 97
 testRunner.Then(string.Format("verify error message \'{0}\' on  Regulations page", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify back link on Regulations page is navigating to SPO page")]
        [NUnit.Framework.CategoryAttribute("RunOnly")]
        [NUnit.Framework.TestCaseAttribute("test", "England", "testFBO", "ABC ACCOUNTANCY & MARKETING SERVICES LTD.", null)]
        public void VerifyBackLinkOnRegulationsPageIsNavigatingToSPOPage(string logininfo, string country, string fBONumber, string businessSelection, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RunOnly"};
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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify back link on Regulations page is navigating to SPO page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 104
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 106
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 107
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 108
 testRunner.And(string.Format("select business to sign up \'{0}\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 109
 testRunner.And("click on eligibility task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 110
 testRunner.And(string.Format("complete eligibility task with \'{0}\', \'{1}\' and navigate to Regulations page", country, fBONumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 111
    testRunner.And("click on back link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 112
 testRunner.Then("user navigates to the SPO_Assurance page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
