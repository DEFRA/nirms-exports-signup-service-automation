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
    [NUnit.Framework.DescriptionAttribute("AddPlaceOfDispatch")]
    [NUnit.Framework.CategoryAttribute("SelfServeRegression")]
    public partial class AddPlaceOfDispatchFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "SelfServeRegression"};
        
#line 1 "AddPlaceOfDispatch.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/SelfServeAppl", "AddPlaceOfDispatch", "Add Place of Dispatch", ProgrammingLanguage.CSharp, featureTags);
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
                    "\'England\', \'NW1 5LR\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
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
#line 37
 testRunner.Given("Approve Sign up request for org \'TestEnv3\' and user \'test1C\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify back link on Place Of Dispatch page")]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "NI Retail Movement Scheme", "Add a place of dispatch", "Requirements of the NI Retail Movement Scheme", "Place of dispatch successfully added", "testName11", "testAddress1", "London", "England", "SE10 9NF", "testName12", "testAddress2", "Liverpool", "England", "L1 0AN", "SE10 9GB", null)]
        public void VerifyBackLinkOnPlaceOfDispatchPage(
                    string logininfo, 
                    string businessSelection, 
                    string pageTitle, 
                    string nextPage, 
                    string pageTitle2, 
                    string pageTitle3, 
                    string establishmentName, 
                    string addressLine1, 
                    string estCity, 
                    string estCountry, 
                    string addrPostcode, 
                    string establishmentName2, 
                    string addressLine2, 
                    string estCity2, 
                    string estCountry2, 
                    string addrPostcode2, 
                    string addrPostcode3, 
                    string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Business selection", businessSelection);
            argumentsOfScenario.Add("PageTitle", pageTitle);
            argumentsOfScenario.Add("nextPage", nextPage);
            argumentsOfScenario.Add("PageTitle2", pageTitle2);
            argumentsOfScenario.Add("PageTitle3", pageTitle3);
            argumentsOfScenario.Add("EstablishmentName", establishmentName);
            argumentsOfScenario.Add("AddressLine1", addressLine1);
            argumentsOfScenario.Add("estCity", estCity);
            argumentsOfScenario.Add("estCountry", estCountry);
            argumentsOfScenario.Add("AddrPostcode", addrPostcode);
            argumentsOfScenario.Add("EstablishmentName2", establishmentName2);
            argumentsOfScenario.Add("AddressLine2", addressLine2);
            argumentsOfScenario.Add("estCity2", estCity2);
            argumentsOfScenario.Add("estCountry2", estCountry2);
            argumentsOfScenario.Add("AddrPostcode2", addrPostcode2);
            argumentsOfScenario.Add("AddrPostcode3", addrPostcode3);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify back link on Place Of Dispatch page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 40
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
 testRunner.And("click on link \'Add a place of dispatch\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 45
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 46
 testRunner.When("click on back link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 47
 testRunner.Then(string.Format("verify dynamic name \'{0}\' in title \'{1}\' of page", businessSelection, pageTitle), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 48
 testRunner.When("click on link \'Add a place of dispatch\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 49
 testRunner.And(string.Format("enter Establishment postcode \'{0}\'", addrPostcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 50
 testRunner.And("click on back link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 51
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 52
 testRunner.And(string.Format("enter Establishment postcode \'{0}\'", addrPostcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 53
 testRunner.When("click on change link next to Establishment postcode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 54
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 55
 testRunner.When(string.Format("enter Establishment postcode \'{0}\'", addrPostcode2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 56
 testRunner.Then(string.Format("verify establishment postcode changed to \'{0}\'", addrPostcode2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 57
 testRunner.And("click on cannot find establishment link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 58
 testRunner.And("click on the add establishment address manually link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 59
 testRunner.And("click on back link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 60
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 61
 testRunner.When("click on cannot find establishment link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 62
 testRunner.And("click on the add establishment address manually link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 63
 testRunner.And(string.Format("add establishment address manually with fields \'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\'", establishmentName, addressLine1, estCity, estCountry, addrPostcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 64
 testRunner.And("add establishment email address \'test1@test.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 65
 testRunner.And(string.Format("click on change establishment address \'{0}\'", establishmentName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 66
 testRunner.And("verify add establishment address manually page loaded", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 67
 testRunner.And(string.Format("add establishment address manually with fields \'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\'", establishmentName2, addressLine2, estCity2, estCountry2, addrPostcode2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 68
 testRunner.And("add establishment email address \'test2@test.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 69
 testRunner.And(string.Format("verify changed establishment address fields \'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\'", establishmentName2, addressLine2, estCity2, estCountry2, addrPostcode2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 70
 testRunner.And("click on back link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 71
 testRunner.And("click on back link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 72
 testRunner.And("click on back link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 73
 testRunner.And("click on back link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 74
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 75
 testRunner.When(string.Format("enter Establishment postcode \'{0}\'", addrPostcode3), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 76
 testRunner.And("click on select address button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 77
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 78
 testRunner.When("click on save and continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 79
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 80
 testRunner.When("click on save and continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 81
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 82
 testRunner.When("click on continue button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 83
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", pageTitle2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 84
 testRunner.When("click on button \'Add place of dispatch\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 85
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", pageTitle3), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 86
 testRunner.When("click on back to dashboard link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 87
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", pageTitle), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify zero results page on Place Of Dispatch page")]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "Add a place of dispatch", "SE9 1EE", "0 results", null)]
        public void VerifyZeroResultsPageOnPlaceOfDispatchPage(string logininfo, string businessSelection, string nextPage, string addrPostcode, string errorMessage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Business selection", businessSelection);
            argumentsOfScenario.Add("nextPage", nextPage);
            argumentsOfScenario.Add("AddrPostcode", addrPostcode);
            argumentsOfScenario.Add("errorMessage", errorMessage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify zero results page on Place Of Dispatch page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 94
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
#line 95
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 96
 testRunner.When(string.Format("sign in to self serve with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 97
 testRunner.And(string.Format("select business \'{0}\' on self serve dashboard", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 98
 testRunner.And("click on link \'Add a place of dispatch\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 99
 testRunner.And(string.Format("enter Establishment postcode \'{0}\'", addrPostcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 100
 testRunner.Then(string.Format("verify error message \'{0}\' on Add a place of departure page", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 101
 testRunner.And("click on back link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 102
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 103
 testRunner.When(string.Format("enter Establishment postcode \'{0}\'", addrPostcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 104
 testRunner.And("click on a different postcode error link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 105
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 106
 testRunner.When(string.Format("enter Establishment postcode \'{0}\'", addrPostcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 107
 testRunner.And("click on the add establishment address manually link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 108
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify error messages for place of dispatch mandatory fields")]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "SE10 9NF", "", "testAddress1", "testCity", "testCountry", "SE10 9NF", "Enter an establishment name", null)]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "SE10 9NF", "testErrorName1", "", "testCity", "testCountry", "SE10 9NF", "Enter address line 1", null)]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "SE10 9NF", "testErrorName2", "testAddress1", "", "testCountry", "SE10 9NF", "Enter a town or city", null)]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "SE10 9NF", "testErrorName3", "testAddress1", "testCity", "testCountry", "", "Enter a postcode", null)]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "SE10 9NF", "testErrorName4$%", "testAddress1", "testCity", "testCountry", "SE10 9NF", "Enter an establishment name using only letters, numbers, brackets, full stops, hy" +
            "phens, underscores, forward slashes, apostrophes or ampersands", null)]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "SE10 9NF", "testErrorName5", "testAddr%$", "testCity", "testCountry", "SE10 9NF", "Enter address line 1 using only letters, numbers, brackets, full stops, hyphens, " +
            "underscores, forward slashes, apostrophes or ampersands", null)]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "SE10 9NF", "testErrorName6", "testAddress1", "testCity%$", "testCountry", "SE10 9NF", "Enter a town or city using only letters, numbers, brackets, full stops, hyphens, " +
            "underscores, forward slashes, apostrophes or ampersands", null)]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "SE10 9NF", "testErrorName7", "testAddress1", "testCity", "testCountry", "testCode$%", "Enter a real postcode", null)]
        public void VerifyErrorMessagesForPlaceOfDispatchMandatoryFields(string logininfo, string businessSelection, string postcode, string establishmentName, string addressLine1, string estCity, string estCountry, string addrPostcode, string errorMessage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Business selection", businessSelection);
            argumentsOfScenario.Add("postcode", postcode);
            argumentsOfScenario.Add("EstablishmentName", establishmentName);
            argumentsOfScenario.Add("AddressLine1", addressLine1);
            argumentsOfScenario.Add("estCity", estCity);
            argumentsOfScenario.Add("estCountry", estCountry);
            argumentsOfScenario.Add("AddrPostcode", addrPostcode);
            argumentsOfScenario.Add("errorMessage", errorMessage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify error messages for place of dispatch mandatory fields", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 115
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
#line 116
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 117
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 118
 testRunner.And(string.Format("select business to sign up \'{0}\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 119
 testRunner.And("click on link \'Add a place of dispatch\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 120
 testRunner.And(string.Format("enter Establishment postcode \'{0}\'", postcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 121
 testRunner.And("click on cannot find establishment link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 122
 testRunner.And("click on the add establishment address manually link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 123
 testRunner.And(string.Format("add establishment address manually with fields \'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\'", establishmentName, addressLine1, estCity, estCountry, addrPostcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 124
 testRunner.Then(string.Format("verify error message \'{0}\' on establishment page", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify error message for blank Establishment postcode field & non GB post code")]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "", "Enter a postcode.", null)]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "BT93 8AD", "Enter a postcode in England, Scotland or Wales", null)]
        public void VerifyErrorMessageForBlankEstablishmentPostcodeFieldNonGBPostCode(string logininfo, string businessSelection, string postcode, string errorMessage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Business selection", businessSelection);
            argumentsOfScenario.Add("postcode", postcode);
            argumentsOfScenario.Add("errorMessage", errorMessage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify error message for blank Establishment postcode field & non GB post code", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 138
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
#line 139
 testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 140
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 141
 testRunner.And(string.Format("select business to sign up \'{0}\'", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 142
 testRunner.And("click on link \'Add a place of dispatch\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 143
 testRunner.And(string.Format("enter Establishment postcode \'{0}\'", postcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 144
 testRunner.Then(string.Format("verify error message \'{0}\' on establishment page", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify browser back and error page on Add a place of dispatch")]
        [NUnit.Framework.TestCaseAttribute("test1C", "TestEnv3", "NI Retail Movement Scheme", "Place of dispatch successfully added", "testName11", "testAddress1", "London", "England", "SE10 9NF", "You cannot access this page or perform this action", "Add a place of dispatch", null)]
        public void VerifyBrowserBackAndErrorPageOnAddAPlaceOfDispatch(string logininfo, string businessSelection, string pageTitle, string pageTitle1, string establishmentName, string addressLine1, string estCity, string estCountry, string addrPostcode, string pageTitle2, string pageTitle4, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("Business selection", businessSelection);
            argumentsOfScenario.Add("PageTitle", pageTitle);
            argumentsOfScenario.Add("PageTitle1", pageTitle1);
            argumentsOfScenario.Add("EstablishmentName", establishmentName);
            argumentsOfScenario.Add("AddressLine1", addressLine1);
            argumentsOfScenario.Add("estCity", estCity);
            argumentsOfScenario.Add("estCountry", estCountry);
            argumentsOfScenario.Add("AddrPostcode", addrPostcode);
            argumentsOfScenario.Add("PageTitle2", pageTitle2);
            argumentsOfScenario.Add("PageTitle4", pageTitle4);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify browser back and error page on Add a place of dispatch", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 152
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
#line 153
testRunner.Given("that I navigate to the NI GC application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 154
 testRunner.When(string.Format("sign in to self serve with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 155
 testRunner.And(string.Format("select business \'{0}\' on self serve dashboard", businessSelection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 156
 testRunner.And("click on link \'Add a place of dispatch\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 157
 testRunner.And(string.Format("enter Establishment postcode \'{0}\'", addrPostcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 158
 testRunner.And("click on cannot find establishment link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 159
 testRunner.And("click on the add establishment address manually link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 160
 testRunner.And(string.Format("add establishment address manually with fields \'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\'", establishmentName, addressLine1, estCity, estCountry, addrPostcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 161
 testRunner.And("add establishment email address \'test1@test.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 162
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", pageTitle4), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 163
 testRunner.When("click on continue button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 164
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", pageTitle), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 165
 testRunner.When("click on button \'Add place of dispatch\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 166
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", pageTitle1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 167
 testRunner.When("click browser back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 168
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", pageTitle2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
