@Regression
Feature: AddBusinessContactName

Add Business Contact Name

@CrossBrowser
Scenario: Add business contact name
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
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | Business name    |AddressLine1 | Town     | AddrPostcode |contactName | nextPage |
	| test      | England | testFBO   | testBusinessname |testAddress1 | testCity | wd19 7pf     |testName    | Replace  |


Scenario: Verify error message for invalid business contact name
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
	Then  verify error message '<errorMessage>' on business contact name page 

	Examples: 
	| logininfo | Country  |FBONumber |Business name    |AddressLine1 | Town     | AddrPostcode |contactName  | errorMessage                                                    |
	| test      | England  |testFBO   |testBusinessname |testAddress1 | testCity | wd19 7pf     |invalidTest% | Name must only include letters, numbers, and special characters |


Scenario: Verify error message for blank business contact name
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
	Then  verify error message '<errorMessage>' on business contact name page

	Examples: 
	| logininfo | Country  |FBONumber |Business name    |AddressLine1 | Town     | AddrPostcode |contactName | errorMessage  |
	| test      | England  |testFBO   |testBusinessname |testAddress1 | testCity | wd19 7pf     |           | Enter a name. |


Scenario: Verify back link on business contact name page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business name task with '<Business name>', '<AddressLine1>', '<Town>', '<AddrPostcode>'
	Then  user verify the business name status 'COMPLETED'
	Then  navigate to task list page
	When  click on business contact details link
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | Business name    | AddressLine1 | Town     | AddrPostcode | nextPage                                                |
	| test      | England | testFBO   | testBusinessname | testAddress1 | testCity | wd19 7pf     | Sign up for the Northern Ireland Retail Movement Scheme |

@Ignore
Scenario: Verify save and continue later on business contact name page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business name task with '<Business name>', '<AddressLine1>', '<Town>', '<AddrPostcode>'
	Then  user verify the business name status 'COMPLETED'
	Then  navigate to task list page
	When  click on business contact details link
	And   click save and continue later
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | Business name    | AddressLine1 | Town     | AddrPostcode | nextPage                                                |
	| test      | England | testFBO   | testBusinessname | testAddress1 | testCity | wd19 7pf     | Sign up for the Northern Ireland Retail Movement Scheme |
