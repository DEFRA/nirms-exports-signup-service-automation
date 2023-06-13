@Regression
Feature: AddBusinessContactPosition

Add Business Contact contactPosition

Scenario: Add business contact position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   click on business contact position link
	And   enter business contact position '<contactPosition>'
	And   click on save and continue on contact position page
	And   verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | contactPosition | nextPage |
	| test      | England | testFBO   | testPosition    | Sign up  |

	
Scenario: Verify error message for invalid business contact position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   click on business contact position link
	And   enter business contact position '<contactPosition>'
	And   click on save and continue on contact position page
	And   verify error message '<errorMessage>' on business contact position page
	Examples: 
	| logininfo | Country  |FBONumber |contactPosition | errorMessage                           |
	| test      | England  |testFBO   |testPosition%   | Enter a position using only letters    |


Scenario: Verify error message for blank business contact position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   click on business contact position link
	And   enter business contact position '<contactPosition>'
	And   click on save and continue on contact position page
	And   verify error message '<errorMessage>' on business contact position page
	Examples: 
	| logininfo | Country  |FBONumber |contactPosition | errorMessage                              |
	| test      | England  |testFBO   |                | Enter the position of the contact person  |


Scenario: Verify back link on business contact position page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   navigate to task list page
	And   click on business contact position link
	And   click on back link
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |Country  |FBONumber |
	| test      |England  |testFBO   |


@Ignore
Scenario: Verify save and continue later on business contact position page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   navigate to task list page
	And   click on business contact position link
	And   click save and continue later
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |Country  |FBONumber |
	| test      |England  |testFBO   |
