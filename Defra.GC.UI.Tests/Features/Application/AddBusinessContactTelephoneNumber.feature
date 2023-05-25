@Regression
Feature: AddBusinessContactTelephoneNumber

Add Contact telephone number

Scenario: Add contact Telephone Number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to contact telephone number page
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	And   verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | telephoneNumber  | nextPage |
	| test      | test@test.com |          |


Scenario: Verify error message for invalid contact Telephone Number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to contact telephone number page
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	And   verify error message on contact telephone number page
	Examples: 
	| logininfo | telephoneNumber      |
	| test      | test£$@£test.com  |


Scenario: Verify error message for blank contact telephone number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to contact telephone number page
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	And   verify error message on contact telephone number page
	Examples: 
	| logininfo | telephoneNumber |
	| test      |              |


Scenario: Verify back link on contact telephone number page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to task list page
	And   click on contact telephone number link
	And   click on back link
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |
	| test      |


Scenario: Verify save and continue later on contact telephone number page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  navigate to task list page
	And   click on contact telephone number link
	And   click save and continue later
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |
	| test      |