@Regression
Feature: AddBusinessContactPosition

Add Business Contact contactPosition

Scenario: Add business contact position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	Then  navigate to business contact position page
	And   enter business contact position '<contactPosition>'
	And   click on save and continue on contact position page
	And   verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country  |contactPosition   | nextPage |
	| test      | England  |testPosition      |          |

	
Scenario: Verify error message for invalid business contact position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	Then  navigate to business contact position page
	And   enter business contact position '<contactPosition>'
	And   click on save and continue on contact position page
	And   verify error message '<errorMessage>' on business contact position page
	Examples: 
	| logininfo | Country  |contactPosition | errorMessage                           |
	| test      | England  |testPosition%   | Enter a position using only letters    |


Scenario: Verify error message for blank business contact position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	Then  navigate to business contact position page
	And   enter business contact position '<contactPosition>'
	And   click on save and continue on contact position page
	And   verify error message '<errorMessage>' on business contact position page
	Examples: 
	| logininfo | Country  |contactPosition | errorMessage                              |
	| test      | England  |                | Enter the position of the contact person  |


Scenario: Verify back link on business contact position page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	Then  navigate to task list page
	And   click on business contact position link
	And   click on back link
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |Country  |
	| test      |England  |

@Ignore
Scenario: Verify save and continue later on business contact position page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	Then  navigate to task list page
	And   click on business contact position link
	And   click save and continue later
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |Country  |
	| test      |England  |
