@Regression
Feature: AddBusinessContactEmailAddress

Add Contact Email address

@CrossBrowser
Scenario: Add contact email address
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
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | contactName     |contactPosition |emailAddress  | nextPage          |
	| test      | England | testFBO   | testContactName | testPosition   |test@test.com | Telephone number  |


Scenario: Verify error message for invalid contact email address
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
	Then  verify error message '<errorMessage>' on contact email address page

	Examples: 
	| logininfo | Country  |FBONumber |contactName     |contactPosition |emailAddress     | errorMessage                                   |
	| test      | England  |testFBO   |testContactName | testPosition   |test£$@£         | Enter an email address in the correct format   |


Scenario: Verify error message for blank contact email address
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
	Then  verify error message '<errorMessage>' on contact email address page

	Examples: 
	| logininfo | Country  |FBONumber |contactName     |contactPosition |emailAddress | errorMessage                                       |
	| test      | England  |testFBO   |testContactName | testPosition   |             | Enter the email address of the contact person      |


Scenario: Verify back link on contact email address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   click on back link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Country | FBONumber | contactName     |contactPosition |nextPage |
	| test      | England | testFBO   | testContactName | testPosition   |Position |

Scenario: Verify save and return to dashboard on contact email address page
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
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Country | FBONumber | contactName     | contactPosition | nextPage | emailAddress     |
	| test      | England | testFBO   | testContactName | testPosition    | Sign up  | contact@test.com |