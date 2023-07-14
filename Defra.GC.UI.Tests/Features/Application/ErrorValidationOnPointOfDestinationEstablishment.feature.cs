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
    [NUnit.Framework.DescriptionAttribute("Error Validation Point Of Destination Establishment")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    public partial class ErrorValidationPointOfDestinationEstablishmentFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "Regression"};
        
#line 1 "ErrorValidationOnPointOfDestinationEstablishment.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Application", "Error Validation Point Of Destination Establishment", "Error Validation Point Of Destination Establishment", ProgrammingLanguage.CSharp, featureTags);
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
        [NUnit.Framework.DescriptionAttribute("Verify validation error message for blank Destination Establishment postcode fiel" +
            "d")]
        [NUnit.Framework.TestCaseAttribute("test", "Northern Ireland", "testFBO", "", "Enter a postcode.", null)]
        public void VerifyValidationErrorMessageForBlankDestinationEstablishmentPostcodeField(string logininfo, string country, string fBONumber, string postcode, string errorMessage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("FBONumber", fBONumber);
            argumentsOfScenario.Add("postcode", postcode);
            argumentsOfScenario.Add("errorMessage", errorMessage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify validation error message for blank Destination Establishment postcode fiel" +
                    "d", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 9
 testRunner.And(string.Format("complete eligibility task with \'{0}\', \'{1}\'", country, fBONumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 10
 testRunner.Then("verify eligibility task status as \'COMPLETED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 11
    testRunner.When("click on points of destination link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify valid error messages for point of Destination mandatory fields")]
        [NUnit.Framework.TestCaseAttribute("test", "Northern Ireland", "testFBO", "EC4R 9HA", "", "testAddress1", "testCity", "testCountry", "SE10 9NF", "Enter establishment name", null)]
        [NUnit.Framework.TestCaseAttribute("test", "Northern Ireland", "testFBO", "EC4R 9HA", "testName", "", "testCity", "testCountry", "SE10 9NF", "Enter address line 1", null)]
        [NUnit.Framework.TestCaseAttribute("test", "Northern Ireland", "testFBO", "EC4R 9HA", "testName", "testAddress1", "", "testCountry", "SE10 9NF", "Enter a town or city", null)]
        [NUnit.Framework.TestCaseAttribute("test", "Northern Ireland", "testFBO", "EC4R 9HA", "testName", "testAddress1", "testCity", "testCountry", "", "Enter a post code", null)]
        [NUnit.Framework.TestCaseAttribute("test", "Northern Ireland", "testFBO", "EC4R 9HA", "testName$%", "testAddress1", "testCity", "testCountry", "SE10 9NF", "Enter establishment name using only letters", null)]
        [NUnit.Framework.TestCaseAttribute("test", "Northern Ireland", "testFBO", "EC4R 9HA", "testName", "testAddr%$", "testCity", "testCountry", "SE10 9NF", "Enter address line 1 using only letters, numbers", null)]
        [NUnit.Framework.TestCaseAttribute("test", "Northern Ireland", "testFBO", "EC4R 9HA", "testName", "testAddress1", "testCity%$", "testCountry", "SE10 9NF", "Enter a town or city using only letters, numbers", null)]
        [NUnit.Framework.TestCaseAttribute("test", "Northern Ireland", "testFBO", "EC4R 9HA", "testName", "testAddress1", "testCity", "testCountry", "SE10 9NF$%", "Enter a real postcode.", null)]
        public void VerifyValidErrorMessagesForPointOfDestinationMandatoryFields(string logininfo, string country, string fBONumber, string postcode, string establishmentName, string addressLine1, string estCity, string estCountry, string addrPostcode, string errorMessage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("FBONumber", fBONumber);
            argumentsOfScenario.Add("postcode", postcode);
            argumentsOfScenario.Add("EstablishmentName", establishmentName);
            argumentsOfScenario.Add("AddressLine1", addressLine1);
            argumentsOfScenario.Add("estCity", estCity);
            argumentsOfScenario.Add("estCountry", estCountry);
            argumentsOfScenario.Add("AddrPostcode", addrPostcode);
            argumentsOfScenario.Add("errorMessage", errorMessage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify valid error messages for point of Destination mandatory fields", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 20
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 21
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 22
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 23
 testRunner.And(string.Format("complete eligibility task with \'{0}\', \'{1}\'", country, fBONumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 24
 testRunner.Then("verify eligibility task status as \'COMPLETED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 25
 testRunner.When("click on points of destination link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 29
 testRunner.And(string.Format("add establishment address manually with fields \'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\'", establishmentName, addressLine1, estCity, estCountry, addrPostcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 30
 testRunner.Then(string.Format("verify error message \'{0}\' on establishment page", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify error message on add another point of Destination page")]
        [NUnit.Framework.TestCaseAttribute("test", "Northern Ireland", "testFBO", "testName1", "testAddress1", "testCity1", "testCountry1", "EC4R 9HA", "Select yes if you want to add another place of destination", null)]
        public void VerifyErrorMessageOnAddAnotherPointOfDestinationPage(string logininfo, string country, string fBONumber, string establishmentName, string addressLine1, string estCity, string estCountry, string addrPostcode, string errorMessage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("FBONumber", fBONumber);
            argumentsOfScenario.Add("EstablishmentName", establishmentName);
            argumentsOfScenario.Add("AddressLine1", addressLine1);
            argumentsOfScenario.Add("estCity", estCity);
            argumentsOfScenario.Add("estCountry", estCountry);
            argumentsOfScenario.Add("AddrPostcode", addrPostcode);
            argumentsOfScenario.Add("errorMessage", errorMessage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify error message on add another point of Destination page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 44
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 45
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 46
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 47
 testRunner.And(string.Format("complete eligibility task with \'{0}\', \'{1}\'", country, fBONumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 48
 testRunner.Then("verify eligibility task status as \'COMPLETED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 49
 testRunner.When("click on points of destination link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 53
 testRunner.And(string.Format("add establishment address manually with fields \'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\'", establishmentName, addressLine1, estCity, estCountry, addrPostcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
 testRunner.And("add establishment email address \'test1@test.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 55
 testRunner.And("click on save and continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 56
 testRunner.Then(string.Format("verify error message \'{0}\' on establishment page", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify duplicate point of destination establishment not allowed")]
        [NUnit.Framework.TestCaseAttribute("test", "Northern Ireland", "testFBO", "testName1", "testAddress1", "testCity1", "Northern Ireland", "BT30 6LZ", "The entered establishment address is a duplicate of one already entered", null)]
        public void VerifyDuplicatePointOfDestinationEstablishmentNotAllowed(string logininfo, string country, string fBONumber, string establishmentName, string addressLine1, string estCity, string estCountry, string addrPostcode, string errorMessage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Country", country);
            argumentsOfScenario.Add("FBONumber", fBONumber);
            argumentsOfScenario.Add("EstablishmentName", establishmentName);
            argumentsOfScenario.Add("AddressLine1", addressLine1);
            argumentsOfScenario.Add("estCity", estCity);
            argumentsOfScenario.Add("estCountry", estCountry);
            argumentsOfScenario.Add("AddrPostcode", addrPostcode);
            argumentsOfScenario.Add("errorMessage", errorMessage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify duplicate point of destination establishment not allowed", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
#line 62
    testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 63
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 64
 testRunner.And(string.Format("complete eligibility task with \'{0}\', \'{1}\'", country, fBONumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 65
 testRunner.Then("verify eligibility task status as \'COMPLETED\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.When("click on points of destination link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 70
 testRunner.And(string.Format("add establishment address manually with fields \'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\'", establishmentName, addressLine1, estCity, estCountry, addrPostcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 71
 testRunner.And("add establishment email address \'test1@test.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 72
 testRunner.And("click on add another establishment address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 76
 testRunner.And(string.Format("add establishment address manually with fields \'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\'", establishmentName, addressLine1, estCity, estCountry, addrPostcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 77
    testRunner.Then(string.Format("verify duplicate establishment error message \'{0}\'", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
