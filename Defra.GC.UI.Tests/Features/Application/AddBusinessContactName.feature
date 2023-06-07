@Regression
Feature: AddBusinessContactName

Add Business Contact Name

Scenario: Add business contact name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to business contact name page
	And   enter business contact name '<contactName>'
	And   click on save and continue on contact full name page
	And   verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | contactName   | nextPage |
	| test      | testName      |          |


Scenario: Verify error message for invalid business contact name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to business contact name page
	And   enter business contact name '<contactName>'
	And   click on save and continue on contact full name page
	And   verify error message '<errorMessage>' on business contact name page 
	Examples: 
	| logininfo | contactName  | errorMessage                                                    |
	| test      | invalidTest% | Name must only include letters, numbers, and special characters |


Scenario: Verify error message for blank business contact name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to business contact name page
	And   enter business contact name '<contactName>'
	And   click on save and continue on contact full name page
	And   verify error message '<errorMessage>' on business contact name page 
	Examples: 
	| logininfo | contactName | errorMessage  |
	| test      |             | Enter a name. |


Scenario: Verify back link on business contact name page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to task list page
	And   click on business contact name link
	And   click on back link
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |
	| test      |


Scenario: Verify save and continue later on business contact name page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to task list page
	And   click on business contact name link
	And   click save and continue later
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |
	| test      |
