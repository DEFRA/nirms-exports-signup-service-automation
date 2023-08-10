@Regression
Feature: Business Registered Address 

Add Business Registered Address

@CrossBrowser
Scenario Outline: Add Business Address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  user is in Business name page
 #   And   user enters Business name  '<Business name>'
	#Then  click on save and continue
	#When  user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	#Then  click Save and return to dashboard
	#And   user verify the business name status 'COMPLETED'

	Examples: 
	| logininfo | Business selection                       | AddressLine1 | Town     | AddrPostcode | Country | FBONumber | Business name    |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| testAddress1 | testCity | wd19 7pf     | England | testFBO   | testBusinessname |


Scenario Outline: Verify the error message when user do not select the address fields
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'	
	Then  verify eligibility task status as 'COMPLETED'
	#When  user is in Business name page
 #   And   user enters Business name  '<Business name>'
	#Then  click on save and continue
	#When  user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	#Then  click on save and continue
	#And   user verifies address error message
	#| Key         | Value				  |
	#| Adddress    | Enter address line 1  |
	#| Town        | Enter a town or city  |
	#| Postcode    | Enter a postcode      |
	Examples: 
	| logininfo | Business selection                         | AddressLine1 | Town | AddrPostcode | Country | FBONumber | Business name    |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.  |              |      |              | England | testFBO   | testBusinessname |

	
Scenario: Verify error message for invalid address data
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  user is in Business name page
 #   And   user enters Business name  '<Business name>'
	#Then  click on save and continue
	#When  user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	#Then  click on save and continue
	#And   user verifies invalid error message for address data
	#| Key             | Value                                                                                |
	#| Adddress Line 1 | Enter address line 1 using only letters, numbers, hyphens (-) and apostrophes (')    |
	#| Town            | Enter a town or city using only letters, numbers, hyphens (-) and apostrophes (')    |
	#| Postcode        | Enter a real postcode                                                                |
	Examples: 
	| logininfo | Business selection                       | AddressLine1 | Town  | AddrPostcode | Country | FBONumber | Business name    |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| ****         | ***** | *****        | England | testFBO   | testBusinessname |


Scenario Outline: Verify back to dashboard link is navigated to tasklist page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  user is in Business name page
 #   And   user enters Business name  '<Business name>'
	#Then  click on save and continue
	#When  click on back to dashboard link
	#Then  verify next page '<nextPage>' is loaded 
	Examples: 
	| logininfo | Business selection                         | Country | FBONumber | nextPage   | Business name    |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.  | England | testFBO   | Sign up    | testBusinessname |


Scenario Outline:Verify save and return to dashboard navigating to tasklist page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	#Then  verify eligibility task status as 'COMPLETED'
	#When  user is in Business name page
 #   And   user enters Business name  '<Business name>'
	#Then  click on save and continue
	#When  user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	#And   click Save and return to dashboard
	#Then  verify next page '<nextPage>' is loaded 
	Examples: 
	| logininfo | Business selection                       | Country | FBONumber | nextPage | Business name    | AddressLine1 | Town     | AddrPostcode |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| England | testFBO   | Sign up  | testBusinessname | testAddress1 | testCity | wd19 7pf     |
