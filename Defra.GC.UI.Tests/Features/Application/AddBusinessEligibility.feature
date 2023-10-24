﻿@Regression
Feature: AddBusinessEligibility

Complete Eligibility task

 @SmokeTest
Scenario Outline: Complete eligibility task
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'

	Examples:
    | logininfo | Country | FBONumber | Business selection                             |
    | test      | England | testFBO   | ABC ACCOUNTANCY & MARKETING SERVICES LTD.      |


Scenario Outline: Verify error message for not selecting the country name
	Given Clear Database for user '<logininfo>'
	And  that I navigate to the NI GC application
	When sign in with valid credentials with logininfo '<logininfo>'
	Then verify next page '<nextPage>' is loaded 

	Examples: 
    | logininfo | nextPage                           |
    | test      | Which business do you want to sign |


Scenario Outline: Verify back button on country page is going to select business page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   user clicks back button
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
    | logininfo | Business selection                        | nextPage                                 |
    | test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | Which business do you want to sign up    |


Scenario Outline: Verify No sign up page appears when no FBO number
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>' and without FBONumber
	Then  verify next page '<nextPage>' is loaded 
	Then  click on continue button
	Then  verify next page '<nextPage1>' is loaded

	Examples: 
    | logininfo | Business selection                        | Country | FBONumber  | nextPage                                   |nextPage1                                                    |
    | test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England |            | You can still submit a sign-up request now |Requirements of the Northern Ireland Retail Movement Scheme  |


Scenario Outline: Verify back link on Assurance FBO page is going country selection page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>'
	And   click on back link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
    | logininfo | Country | nextPage                      | Business selection                         |
    | test      | England | What will your business do    | ABC ACCOUNTANCY & MARKETING SERVICES LTD.  |


Scenario Outline: Verify error message for invalid FBO with Assurance
	#Given Clear Database for user '<logininfo>'
	Given   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with invalid data '<Country>', '<FBONumber>'
	Then  verify error message '<errorMessage>' on  SPS_Assurance page

	Examples: 
    | logininfo | Country | FBONumber       | errorMessage                                               | Business selection                        |
    | test      | England | *************** | Enter an FBO number using only letters, numbers or hyphens | ABC ACCOUNTANCY & MARKETING SERVICES LTD. |


Scenario Outline: Verify confirmation error message for Regulations page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>' without Regulations
	Then  verify error message '<errorMessage>' on  Regulations page
	
	Examples: 
    | logininfo | Country | FBONumber | errorMessage                                                  | Business selection                       |
    | test      | England | testFBO   | Confirm that you have understood the guidance and regulations | ABC ACCOUNTANCY & MARKETING SERVICES LTD |


Scenario Outline: Verify back link on Regulations page is navigating to SPO page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>' and navigate to Regulations page
    And   click on back link
	Then  user navigates to the SPO_Assurance page
	
	
	Examples: 
    | logininfo | Country | FBONumber |Business selection                         |
    | test      | England | testFBO   |ABC ACCOUNTANCY & MARKETING SERVICES LTD.  |


Scenario: Verify error message for invalid PHR with Assurance
	#Given Clear Database for user '<logininfo>'
	Given   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with invalid PHR data '<Country>', '<PHRNumber>'
	Then  verify error message '<errorMessage>' on  SPS_Assurance page

	Examples: 
    | logininfo | Country | PHRNumber       | errorMessage                                                      | Business selection                        |
    | test      | England | *************** | Enter a PHR number using only letters, numbers, spaces or hyphens | ABC ACCOUNTANCY & MARKETING SERVICES LTD. |
	
Scenario Outline: Complete eligibility with PHR number option
    #Given Clear Database for user '<logininfo>'
	Given   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
    And   complete eligibility task with '<Country>', '<PHRNumber>' country and PHR no
	Then  verify next page '<nextPage>' is loaded

Examples: 
    | logininfo | Country | PHRNumber |Business selection                         |nextPage | 
    | test      | England | testPHR   |ABC ACCOUNTANCY & MARKETING SERVICES LTD.  |Sign up  |


Scenario Outline: Complete eligibility with no FBO or PHR number option 
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>' and without FBONumber
	Then  verify next page '<nextPage>' is loaded 
	Then  click on continue button 
	Then  confirm regulation assurance checkbox
	Then  verify next page '<nextPage1>' is loaded

Examples: 
    | logininfo | Business selection                        | Country | nextPage                                   |nextPage1|
    | test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | You can still submit a sign-up request now |Sign up  |


Scenario Outline: Verify back on You can still submit sign up page navigates to FBO or PHR page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>' and without FBONumber
	Then  verify next page '<nextPage>' is loaded 
	And   click on back link
	Then  verify next page '<nextPage1>' is loaded 

Examples: 
    | logininfo | Business selection                        | Country | nextPage                                   |nextPage1                                                                                           |
    | test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | You can still submit a sign-up request now |Does your business have a Food Business Operator (FBO) or Plant Health Registration (PHR) number?   |


Scenario: Verify error message for no radiobutton selected on FBO PHR page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>'
	Then  click on continue button
	Then  verify next page '<nextPage>' is loaded 
	Then  click on continue button
	Then  verify error message '<errorMessage>' on  SPS_Assurance page

	Examples: 
    | logininfo | Country | PHRNumber       | errorMessage                                       | Business selection                        |nextPage                                                                                           |
    | test      | England | *************** | Select if your business has an FBO or PHR number   | ABC ACCOUNTANCY & MARKETING SERVICES LTD. |Does your business have a Food Business Operator (FBO) or Plant Health Registration (PHR) number?  |



Scenario Outline: Verify hint text on FBO PHR page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>'
	Then  verify next page '<nextPage>' is loaded 
	Then  verify hint text '<hintText>' on FBO PHR page
	

	Examples: 
    | logininfo | Country |Business selection                         |nextPage																							   |hintText																								|
    | test      | England |ABC ACCOUNTANCY & MARKETING SERVICES LTD.  |Does your business have a Food Business Operator (FBO) or Plant Health Registration (PHR) number?   |You will have an FBO number if you’ve registered with your local authority for a food business licence. |
	