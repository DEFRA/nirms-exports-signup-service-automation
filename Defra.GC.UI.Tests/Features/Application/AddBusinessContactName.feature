@Regression
Feature: AddBusinessContactName

Add Business Contact Name

@CrossBrowser
Scenario: Add business contact name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue on business contact name page
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | contactName | nextPage  |
	| test      | England | testFBO   | testName    | Position  |


Scenario: Verify error message for invalid business contact name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue on business contact name page
	Then  verify error message '<errorMessage>' on business contact name page 

	Examples: 
	| logininfo | Country  |FBONumber |contactName  | errorMessage                                                    |
	| test      | England  |testFBO   |invalidTest% | Name must only include letters, numbers, and special characters |


Scenario: Verify error message for blank business contact name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue on business contact name page
	Then  verify error message '<errorMessage>' on business contact name page

	Examples: 
	| logininfo | Country  |FBONumber |contactName | errorMessage  |
	| test      | England  |testFBO   |            | Enter a name. |


Scenario: Verify back link on business contact name page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | nextPage                                                |
	| test      | England | testFBO   | Sign up for the Northern Ireland Retail Movement Scheme |

@Ignore
Scenario: Verify save and continue later on business contact name page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	Then  navigate to task list page
	When  click on business contact details link
	And   click save and continue later
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | nextPage                                                |
	| test      | England | testFBO   | Sign up for the Northern Ireland Retail Movement Scheme |
