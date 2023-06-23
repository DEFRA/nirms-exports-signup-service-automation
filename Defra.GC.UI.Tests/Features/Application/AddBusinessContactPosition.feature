@Regression
Feature: AddBusinessContactPosition

Add Business Contact contactPosition

@CrossBrowser
Scenario: Add business contact position
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
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | Business name    | AddressLine1 | Town     | AddrPostcode | contactName     | contactPosition | nextPage |
	| test      | England | testFBO   | testBusinessname | testAddress1 | testCity | wd19 7pf     | testContactName | testPosition    | Sign up  |

	
Scenario: Verify error message for invalid business contact position
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
	And   verify error message '<errorMessage>' on business contact position page

	Examples: 
	| logininfo | Country  |FBONumber |Business name    |AddressLine1 | Town     | AddrPostcode |contactName     |contactPosition | errorMessage                           |
	| test      | England  |testFBO   |testBusinessname |testAddress1 | testCity | wd19 7pf     |testContactName |testPosition%   | Enter a position using only letters    |


Scenario: Verify error message for blank business contact position
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
	Then  verify error message '<errorMessage>' on business contact position page

	Examples: 
	| logininfo | Country  |FBONumber |Business name    |AddressLine1 | Town     | AddrPostcode |contactName     |contactPosition | errorMessage                              |
	| test      | England  |testFBO   |testBusinessname |testAddress1 | testCity | wd19 7pf     |testContactName |                | Enter the position of the contact person  |


Scenario: Verify back link on business contact position page
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
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | Business name    | AddressLine1 | Town     | AddrPostcode |contactName     | nextPage |
	| test      | England | testFBO   | testBusinessname | testAddress1 | testCity | wd19 7pf     |testContactName | Replace  |


@Ignore
Scenario: Verify save and continue later on business contact position page
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
	And   click save and continue later
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | Business name    | AddressLine1 | Town     | AddrPostcode | contactName     |nextPage |
	| test      | England | testFBO   | testBusinessname | testAddress1 | testCity | wd19 7pf     | testContactName |Replace  |
