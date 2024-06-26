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
namespace Defra.Trade.ReMos.AssuranceService.Tests.Features.SelfServeAppl
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ManageAuthorisedRepresentative")]
    [NUnit.Framework.CategoryAttribute("SelfServeRegression")]
    public partial class ManageAuthorisedRepresentativeFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "SelfServeRegression"};
        
#line 1 "ManageAuthorisedRepresentative.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/SelfServeAppl", "ManageAuthorisedRepresentative", "Manage Authorised Representative", ProgrammingLanguage.CSharp, featureTags);
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
        
        public virtual void FeatureBackground()
        {
#line 6
#line hidden
#line 7
 testRunner.Given("Clear Database for user \'test1C\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 9
 testRunner.When("sign in with valid credentials with logininfo \'test1C\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
 testRunner.And("select business to sign up \'TestEnv3\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.And("complete eligibility task with \'England\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.Then("verify eligibility task status as \'COMPLETED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 13
 testRunner.And("user verify the selected business name \'TestEnv3\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 14
 testRunner.When("click on FBOorPHRNumber task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 15
 testRunner.And("enter FBO number \'testFBO\' for FBO or PHR number task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 16
 testRunner.And("click Save and return to dashboard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
 testRunner.Then("verify FBOorPHRNumber task status as \'COMPLETED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 18
 testRunner.And("user verify the business contact details status \'NOT STARTED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
    testRunner.And("user verify the Authorised Signatory status \'CANNOT START YET\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 20
    testRunner.And("user verify the Points of departure status \'NOT STARTED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 21
 testRunner.And("verify Check answers and submit sign up status \'CANNOT START YET\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 22
 testRunner.When("complete Business contact details task with \'contactName\', \'contactPosition\', \'te" +
                    "st@test.com\', \'01234 234 455\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 23
 testRunner.Then("user verify the business contact details status \'COMPLETED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 24
    testRunner.And("user verify the Authorised Signatory status \'NOT STARTED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 25
 testRunner.When("complete contact person Authorised Signatory with Yes Authorisation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 26
 testRunner.When("complete Points of departure with \'EstablishmentName\', \'AddressLine1\', \'London\', " +
                    "\'England\', \'SW7 5HD\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 27
 testRunner.Then("user verify the Points of departure status \'1 ADDED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 28
 testRunner.And("click on Check answers and submit sign up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 29
 testRunner.And("verify next page \'Check your answers\' is loaded", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 30
 testRunner.When("click on continue button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 31
 testRunner.Then("verify next page \'Terms and conditions\' is loaded", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 32
 testRunner.Then("click on the confirm check box on Terms and conditions page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 33
 testRunner.Then("click on submit sign up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 34
 testRunner.Then("verify  \'You have successfully submitted a request to sign up for the NI Retail M" +
                    "ovement Scheme\' on completed sign up page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 35
 testRunner.Then("verify  \'We will review your sign-up request and email you with the outcome withi" +
                    "n 5 working days.\' outcome of my request submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 36
 testRunner.Then("click on signout button and verify the signout message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update Authorised Representative")]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "TestName", "TestPosition", "Changedemail@test.com", null)]
        public void UpdateAuthorisedRepresentative(string logininfo, string businessSelection, string updatedName, string updatedPosition, string updatedEmailAddress, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Business selection", businessSelection);
            argumentsOfScenario.Add("UpdatedName", updatedName);
            argumentsOfScenario.Add("UpdatedPosition", updatedPosition);
            argumentsOfScenario.Add("UpdatedEmailAddress", updatedEmailAddress);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update Authorised Representative", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
#line 6
this.FeatureBackground();
#line hidden
#line 40
 testRunner.Given(string.Format("Approve Sign up request for org \'{0}\' and user \'test1C\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 41
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 42
 testRunner.When(string.Format("sign in to self serve with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 43
 testRunner.And(string.Format("select business \'{0}\' on self serve dashboard", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 44
    testRunner.Then("verify Authorised Representative date format \'Added\' on self serve dashboard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 45
    testRunner.When("click on Authorised Representative change link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 46
 testRunner.And(string.Format("enter Authorised Representative Name \'{0}\'", updatedName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 47
 testRunner.And(string.Format("enter Authorised Representative Position \'{0}\'", updatedPosition), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 48
 testRunner.And(string.Format("enter Authorised Representative Email address \'{0}\'", updatedEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 49
 testRunner.And("click on save Authorised Representative details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 50
 testRunner.Then(string.Format("verify Authorised Representative details as \'{0}\', \'{1}\', \'{2}\'", updatedName, updatedPosition, updatedEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 51
    testRunner.And("verify Authorised Representative date format \'Updated\' on self serve dashboard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify error messages for blank Authorised Representative fields")]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "", "", "", "Enter a name", "Enter an email address", "Enter a position", "Confirm that has read and understood the terms and conditions", null)]
        public void VerifyErrorMessagesForBlankAuthorisedRepresentativeFields(string logininfo, string businessSelection, string updatedName, string updatedPosition, string updatedEmailAddress, string message1, string message2, string message3, string message4, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Business selection", businessSelection);
            argumentsOfScenario.Add("UpdatedName", updatedName);
            argumentsOfScenario.Add("UpdatedPosition", updatedPosition);
            argumentsOfScenario.Add("UpdatedEmailAddress", updatedEmailAddress);
            argumentsOfScenario.Add("Message1", message1);
            argumentsOfScenario.Add("Message2", message2);
            argumentsOfScenario.Add("Message3", message3);
            argumentsOfScenario.Add("Message4", message4);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify error messages for blank Authorised Representative fields", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 58
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
#line 59
 testRunner.Given(string.Format("Approve Sign up request for org \'{0}\' and user \'test1C\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 60
 testRunner.And("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 61
 testRunner.When(string.Format("sign in to self serve with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 62
 testRunner.And(string.Format("select business \'{0}\' on self serve dashboard", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 63
    testRunner.And("click on Authorised Representative change link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 64
 testRunner.And(string.Format("enter Authorised Representative Name \'{0}\'", updatedName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 65
 testRunner.And(string.Format("enter Authorised Representative Position \'{0}\'", updatedPosition), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 66
 testRunner.And(string.Format("enter Authorised Representative Email address \'{0}\'", updatedEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 67
 testRunner.And("click on save Authorised Representative details without confirmation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 68
 testRunner.And(string.Format("verify error messages \'{0}\', \'{1}\', \'{2}\', \'{3}\'", message1, message2, message3, message4), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify error messages for invalid Authorised Representative fields")]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "TestName%", "Test1()%", "test@gmail.com!\"£$%^&*())_+<>?<NBXCVDDDDDDDDDDDDDDDDDdDDDDDDDDDDDDDdSGSSSSSSSSSSS" +
            "SsGGGGGDGERHFGHFGHHFHFGH", "Enter a name using only letters, hyphens or apostrophes", "The email address cannot be longer than 100 characters", "Enter a position using only letters, numbers, brackets, full stops, commas, hyphe" +
            "ns, underscores, forward slashes or ampersands", "has read and understood the terms and conditions", null)]
        public void VerifyErrorMessagesForInvalidAuthorisedRepresentativeFields(string logininfo, string businessSelection, string updatedName, string updatedPosition, string updatedEmailAddress, string message1, string message2, string message3, string message4, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Business selection", businessSelection);
            argumentsOfScenario.Add("UpdatedName", updatedName);
            argumentsOfScenario.Add("UpdatedPosition", updatedPosition);
            argumentsOfScenario.Add("UpdatedEmailAddress", updatedEmailAddress);
            argumentsOfScenario.Add("Message1", message1);
            argumentsOfScenario.Add("Message2", message2);
            argumentsOfScenario.Add("Message3", message3);
            argumentsOfScenario.Add("Message4", message4);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify error messages for invalid Authorised Representative fields", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 75
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
#line 76
 testRunner.Given(string.Format("Approve Sign up request for org \'{0}\' and user \'test1C\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 77
 testRunner.And("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 78
 testRunner.When(string.Format("sign in to self serve with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 79
 testRunner.And(string.Format("select business \'{0}\' on self serve dashboard", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 80
    testRunner.And("click on Authorised Representative change link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 81
 testRunner.And(string.Format("enter Authorised Representative Name \'{0}\'", updatedName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 82
 testRunner.And(string.Format("enter Authorised Representative Position \'{0}\'", updatedPosition), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 83
 testRunner.And(string.Format("enter Authorised Representative Email address \'{0}\'", updatedEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 84
 testRunner.And("click on save Authorised Representative details without confirmation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 85
 testRunner.And(string.Format("verify error messages \'{0}\', \'{1}\', \'{2}\', \'{3}\'", message1, message2, message3, message4), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify Cancel link on update Authorised Representative page")]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "NI Retail Movement Scheme", null)]
        public void VerifyCancelLinkOnUpdateAuthorisedRepresentativePage(string logininfo, string businessSelection, string nextPage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Business selection", businessSelection);
            argumentsOfScenario.Add("nextPage", nextPage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Cancel link on update Authorised Representative page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 91
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
#line 92
 testRunner.Given(string.Format("Approve Sign up request for org \'{0}\' and user \'test1C\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 93
 testRunner.And("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 94
 testRunner.When(string.Format("sign in to self serve with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 95
 testRunner.And(string.Format("select business \'{0}\' on self serve dashboard", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 96
    testRunner.And("click on Authorised Representative change link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 97
 testRunner.And("click on cancel link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 98
 testRunner.Then(string.Format("verify dynamic name \'{0}\' in title \'{1}\' of page", businessSelection, nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify Back link on update Authorised Representative page")]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "NI Retail Movement Scheme", null)]
        public void VerifyBackLinkOnUpdateAuthorisedRepresentativePage(string logininfo, string businessSelection, string nextPage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Business selection", businessSelection);
            argumentsOfScenario.Add("nextPage", nextPage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Back link on update Authorised Representative page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 105
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
#line 106
 testRunner.Given(string.Format("Approve Sign up request for org \'{0}\' and user \'test1C\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 107
 testRunner.And("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 108
 testRunner.When(string.Format("sign in to self serve with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 109
 testRunner.And(string.Format("select business \'{0}\' on self serve dashboard", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 110
    testRunner.And("click on Authorised Representative change link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 111
 testRunner.And("click on back link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 112
 testRunner.Then(string.Format("verify dynamic name \'{0}\' in title \'{1}\' of page", businessSelection, nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
