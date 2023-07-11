@Regression
Feature: AddBusinessContactTelephoneNumber

Add Contact telephone number

@CrossBrowser
Scenario: Add contact Telephone Number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	Then  user verify the business contact details status 'COMPLETED'

	Examples: 
	| logininfo | Country | FBONumber | contactName     |contactPosition |emailAddress  |telephoneNumber | nextPage |
	| test      | England | testFBO   | testContactName | testPosition   |test@test.com |01632 960 001   | Sign up  |


Scenario: Verify error message for invalid contact Telephone Number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
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
	| logininfo | Country  |FBONumber |contactName     |contactPosition |emailAddress  |telephoneNumber | errorMessage                                     |
	| test      | England  |testFBO   |testContactName | testPosition   |test@test.com |abc123          | Enter a telephone number in the correct format   |


Scenario: Verify error message for blank contact telephone number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
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
	| logininfo | Country  |FBONumber |contactName     |contactPosition |emailAddress  |telephoneNumber | errorMessage                                  |
	| test      | England  |testFBO   |testContactName | testPosition   |test@test.com |                | Enter the phone number of the contact person  |


Scenario: Verify back link on contact telephone number page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
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
	| logininfo | Country | FBONumber | contactName     |contactPosition |emailAddress  |nextPage       |
	| test      | England | testFBO   | testContactName | testPosition   |test@test.com |Email address  |

@Ignore
Scenario: Verify save and continue later on contact telephone number page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And  click on save and continue
	And   click save and continue later
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | contactName     |contactPosition |emailAddress  |nextPage       |
	| test      | England | testFBO   | testContactName | testPosition   |test@test.com |Email address  |