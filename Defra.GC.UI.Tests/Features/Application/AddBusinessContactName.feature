@Regression
Feature: AddBusinessContactName

Add Business Contact Name

Scenario: Add business contact name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	And   click on business contact name link
	And   enter business contact name '<contactName>'
	And   click on save and continue on contact full name page
	And   verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country  |contactName   | nextPage |
	| test      | England  |testName      | Sign up  |


Scenario: Verify error message for invalid business contact name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	And   click on business contact name link
	And   enter business contact name '<contactName>'
	And   click on save and continue on contact full name page
	And   verify error message '<errorMessage>' on business contact name page 
	Examples: 
	| logininfo | Country  |contactName  | errorMessage                                                    |
	| test      | England  |invalidTest% | Name must only include letters, numbers, and special characters |


Scenario: Verify error message for blank business contact name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	And   click on business contact name link
	And   enter business contact name '<contactName>'
	And   click on save and continue on contact full name page
	And   verify error message '<errorMessage>' on business contact name page 
	Examples: 
	| logininfo | Country  |contactName | errorMessage  |
	| test      | England  |            | Enter a name. |


Scenario: Verify back link on business contact name page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	Then  navigate to task list page
	And   click on business contact name link
	And   click on back link
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |Country  |
	| test      |England  |

@Ignore
Scenario: Verify save and continue later on business contact name page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	Then  navigate to task list page
	And   click on business contact name link
	And   click save and continue later
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |Country  |
	| test      |England  |
