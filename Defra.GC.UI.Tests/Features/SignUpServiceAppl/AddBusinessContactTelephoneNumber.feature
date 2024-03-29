﻿@Regression
Feature: AddBusinessContactTelephoneNumber

Add Contact telephone number

Scenario: Verify error message for invalid contact Telephone Number
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
     And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on contact telephone number page

	Examples: 
	| logininfo | Business selection      | Country | FBONumber | contactName     | contactPosition | emailAddress  | telephoneNumber | errorMessage                                                                    |
	| test      | TestEnv1                | England | testFBO   | testContactName | testPosition    | test@test.com | abc123          | Enter a telephone number, like 01632 960 001, 07700 900 982 or +44 808 157 0192 |


Scenario: Verify error message for blank contact telephone number
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue on contact position page
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on contact telephone number page

	Examples: 
	| logininfo |  Business selection     | Country | FBONumber | contactName     | contactPosition | emailAddress  | telephoneNumber | errorMessage             |
	| test      |  TestEnv1      		  | England | testFBO   | testContactName | testPosition    | test@test.com |                 | Enter a telephone number |


Scenario: Verify back to dashboard link contact telephone number page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection         | Country | FBONumber | contactName     | contactPosition | emailAddress  | nextPage      |
	| test      | TestEnv1       			 | England | testFBO   | testContactName | testPosition    | test@test.com | Sign up       |


Scenario: Verify save and return to dashboard on contact telephone number page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |   Business selection   | Country | FBONumber | contactName     | contactPosition | emailAddress  | nextPage | telephoneNumber |
	| test      |	TestEnv1    		 | England | testFBO   | testContactName | testPosition    | test@test.com | Sign up  | 01632 960 001   |