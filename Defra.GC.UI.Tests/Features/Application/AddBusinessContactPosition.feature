@Regression
Feature: AddBusinessContactPosition

Add Business Contact contactPosition

Scenario: Add business contact position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to business contact position page
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | contactPosition   | nextPage |
	| test      |                   |          |


Scenario: Verify error message for invalid business contact position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to business contact position page
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   verify error message on business contact position page
	Examples: 
	| logininfo | contactPosition      |
	| test      |                  |


Scenario: Verify error message for blank business contact position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to business contact position page
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   verify error message on business contact position page
	Examples: 
	| logininfo | contactPosition |
	| test      |                 |


Scenario: Verify back link on business contact position page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to task list page
	And   click on business contact position link
	And   click on back link
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |
	| test      |


Scenario: Verify save and continue later on business contact position page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to task list page
	And   click on business contact position link
	And   click save and continue later
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |
	| test      |
