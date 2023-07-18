@Regression
Feature: Business Registered Address 

Add Business Registered Address

@CrossBrowser
Scenario Outline: Add Business Address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
    And   user enters Business name  '<Business name>'
	Then  click on save and continue
	When  user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	Then  click Save and return to dashboard
	And   user verify the business name status 'COMPLETED'

	Examples: 
	| logininfo | Business selection | AddressLine1 | Town     | AddrPostcode | Country | FBONumber | Business name    |
	| test      | ACME Ltd           | testAddress1 | testCity | wd19 7pf     | England | testFBO   | testBusinessname |

Scenario Outline: Verify the error message when user do not select the address fields
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
    And   user enters Business name  '<Business name>'
	Then  click on save and continue
	When  user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	Then  click on save and continue
	And   user verifies address error message
	| Key         | Value				  |
	| Adddress    | Enter address line 1. |
	| Town        | Enter a town or city. |
	| Postcode    | Enter a post code.    |
	Examples: 
	| logininfo | Business selection | AddressLine1 | Town | AddrPostcode | Country | FBONumber | Business name    |
	| test      | ACME Ltd           |              |      |              | England | testFBO   | testBusinessname |

	
Scenario: Verify error message for invalid address data
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
    And   user enters Business name  '<Business name>'
	Then  click on save and continue
	When  user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	Then  click on save and continue
	And   user verifies invalid error message for address data
	| Key             | Value                                                                                |
	| Adddress Line 1 | Enter address line 1 using only letters, numbers, hyphens (-) and apostrophes (').   |
	| Town            | Enter a town or city using only letters, numbers, hyphens (-) and apostrophes (').   |
	| Postcode        | Enter a real postcode.                                                               |
	Examples: 
	| logininfo | Business selection | AddressLine1 | Town  | AddrPostcode | Country | FBONumber | Business name    |
	| test      | ACME Ltd           | ****         | ***** | *****        | England | testFBO   | testBusinessname |

Scenario Outline: Verify back button is navigated to previous page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
    And   user enters Business name  '<Business name>'
	Then  click on save and continue
	When  click on back link
	Then  verify next page '<nextPage>' is loaded 
	Examples: 
	| logininfo | Business selection | Country | FBONumber | nextPage                           | Business name    |
	| test      | ACME Ltd           | England | testFBO   | What is the name of your business? | testBusinessname |

Scenario Outline:Verify save and return to dashboard navigating to tasklist page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
    And   user enters Business name  '<Business name>'
	Then  click on save and continue
	When  user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 
	Examples: 
	| logininfo | Business selection | Country | FBONumber | nextPage                                                | Business name    | AddressLine1 | Town     | AddrPostcode |
	| test      | ACME Ltd           | England | testFBO   | Sign up for the Northern Ireland Retail Movement Scheme | testBusinessname | testAddress1 | testCity | wd19 7pf     |
