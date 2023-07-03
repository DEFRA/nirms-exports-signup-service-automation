Feature: AddAuthorisedSignatory

Add Authorised Signatory

Scenario: Add Authorised Signatory and navigated to tasklist page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   select 'Yes' to the contact person is the Authorised Signatory
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Country | FBONumber |                        nextPage                                  |
	| test      |  England | testFBO   |   Sign up for the Northern Ireland Retail Movement Scheme        |
	

Scenario: No to the contact person of the Authorised Signatory and navigted to full name Authorised page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   select 'No' to the contact person is the Authorised Signatory
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | AddressLine1 | Town     | AddrPostcode | Country | FBONumber | Business name    |nextPage                                  |
	| test      | testAddress1 | testCity | wd19 7pf     | England | testFBO   | testBusinessname |Full name of Authorised Signatory         |
	

Scenario: Verify error messages if user do not select Authorised Signatory 
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   click on save and continue
	Then  verify error message '<errorMessage>' on Authorised Signatory page

	Examples: 
	| logininfo | AddressLine1 | Town     | AddrPostcode | Country | FBONumber |  errorMessage           |
	| test      | testAddress1 | testCity | wd19 7pf     | England | testFBO   | Fill in Yes or No       |

Scenario: Verify back link navigated to tasklist page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Country | FBONumber |                        nextPage                                  |
	| test      |  England | testFBO   |   Sign up for the Northern Ireland Retail Movement Scheme        |
