@Regression
Feature: AddBusinessContactEmailAddress

Add Contact Email address

@CrossBrowser
Scenario: Add contact email address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business name task with '<Business name>', '<AddressLine1>', '<Town>', '<AddrPostcode>'
	Then  user verify the business name status 'COMPLETED'
	When  click on business contact details link
	And   enter business contact name '<contactName>'
	And   click on save and continue on contact full name page
	And   enter business contact position '<contactPosition>'
	And   click on save and continue on contact position page
	And   enter email address '<emailAddress>'
	And   click on save and continue on contact email address page
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | Business name    |AddressLine1 | Town     | AddrPostcode |contactName     |contactPosition |emailAddress  | nextPage |
	| test      | England | testFBO   | testBusinessname |testAddress1 | testCity | wd19 7pf     |testContactName | testPosition   |test@test.com | Sign up  |


Scenario: Verify error message for invalid contact email address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business name task with '<Business name>', '<AddressLine1>', '<Town>', '<AddrPostcode>'
	Then  user verify the business name status 'COMPLETED'	
	When  click on business contact details link
	And   enter business contact name '<contactName>'
	And   click on save and continue on contact full name page
	And   enter business contact position '<contactPosition>'
	And   click on save and continue on contact position page
	And   enter email address '<emailAddress>'
	And   click on save and continue on contact email address page
	Then  verify error message '<errorMessage>' on contact email address page

	Examples: 
	| logininfo | Country  |FBONumber |Business name    |AddressLine1 | Town     | AddrPostcode |contactName     |contactPosition |emailAddress     | errorMessage                                   |
	| test      | England  |testFBO   |testBusinessname |testAddress1 | testCity | wd19 7pf     |testContactName | testPosition   |test£$@£         | Enter an email address in the correct format   |


Scenario: Verify error message for blank contact email address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business name task with '<Business name>', '<AddressLine1>', '<Town>', '<AddrPostcode>'
	Then  user verify the business name status 'COMPLETED'
	When  click on business contact details link
	And   enter business contact name '<contactName>'
	And   click on save and continue on contact full name page
	And   enter business contact position '<contactPosition>'
	And   click on save and continue on contact position page
	And   enter email address '<emailAddress>'
	And   click on save and continue on contact email address page
	Then  verify error message '<errorMessage>' on contact email address page

	Examples: 
	| logininfo | Country  |FBONumber |contactName     |contactPosition |emailAddress | errorMessage                                       |
	| test      | England  |testFBO   |testContactName | testPosition   |             | Enter the email address of the contact person      |


Scenario: Verify back link on contact email address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business name task with '<Business name>', '<AddressLine1>', '<Town>', '<AddrPostcode>'
	Then  user verify the business name status 'COMPLETED'
	When  click on business contact details link
	And   enter business contact name '<contactName>'
	And   click on save and continue on contact full name page
	And   enter business contact position '<contactPosition>'
	And   click on save and continue on contact position page
	And   click on back link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Country | FBONumber | contactName     |contactPosition |nextPage |
	| test      | England | testFBO   | testContactName | testPosition   |Replace  |

@Ignore
Scenario: Verify save and continue later on contact email address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
    And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business name task with '<Business name>', '<AddressLine1>', '<Town>', '<AddrPostcode>'
	Then  user verify the business name status 'COMPLETED'
	When  click on business contact details link
	And   enter business contact name '<contactName>'
	And   click on save and continue on contact full name page
	And   enter business contact position '<contactPosition>'
	And   click on save and continue on contact position page
	And   click save and continue later
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Country | FBONumber | contactName     |contactPosition |nextPage |
	| test      | England | testFBO   | testContactName | testPosition   |Replace  |