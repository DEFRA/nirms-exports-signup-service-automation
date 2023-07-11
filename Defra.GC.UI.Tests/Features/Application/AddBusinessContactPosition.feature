@Regression
Feature: AddBusinessContactPosition

Add Business Contact contactPosition

@CrossBrowser
Scenario: Add business contact position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | contactName     | contactPosition | nextPage       |
	| test      | England | testFBO   | testContactName | testPosition    | Email address  |

	
Scenario: Verify error message for invalid business contact position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on business contact position page

	Examples: 
	| logininfo | Country  |FBONumber |contactName     |contactPosition | errorMessage                           |
	| test      | England  |testFBO   |testContactName |testPosition%   | Enter a position using only letters    |


Scenario: Verify error message for blank business contact position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on business contact position page

	Examples: 
	| logininfo | Country  |FBONumber |contactName     |contactPosition | errorMessage                              |
	| test      | England  |testFBO   |testContactName |                | Enter the position of the contact person  |


Scenario: Verify back link on business contact position page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | contactName     | nextPage   |
	| test      | England | testFBO   | testContactName | Full name  |


@Ignore
Scenario: Verify save and continue later on business contact position page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   click save and continue later
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | contactName     |nextPage   |
	| test      | England | testFBO   | testContactName |Full name  |
