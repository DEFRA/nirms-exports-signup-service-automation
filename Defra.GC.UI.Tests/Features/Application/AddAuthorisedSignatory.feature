@Regression
Feature: AddAuthorisedSignatory

Add Authorised Signatory

Scenario: Add Authorised Signatory and navigated to tasklist page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   select 'Yes' to the contact person is the Authorised Signatory
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection   | Country | FBONumber | nextPage                                                |
	| test      | ACME Ltd             | England | testFBO   | Sign up for the Northern Ireland Retail Movement Scheme |
	

Scenario: No to the contact person of the Authorised Signatory and navigted to full name Authorised page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   select 'No' to the contact person is the Authorised Signatory
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection | AddressLine1 | Town     | AddrPostcode | Country | FBONumber | Business name    | nextPage                          |
	| test      | ACME Ltd           | testAddress1 | testCity | wd19 7pf     | England | testFBO   | testBusinessname | Full name of Authorised Signatory |
	

Scenario: Verify error messages if user do not select Authorised Signatory 
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   click on save and continue
	Then  verify error message '<errorMessage>' on Authorised Signatory page

	Examples: 
	| logininfo | Business selection | AddressLine1 | Town     | AddrPostcode | Country | FBONumber | errorMessage      |
	| test      | ACME Ltd           | testAddress1 | testCity | wd19 7pf     | England | testFBO   | Fill in Yes or No |

Scenario: Verify back link navigated to tasklist page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Country | FBONumber |                        nextPage                                  |
	| test      |  England | testFBO   |   Sign up for the Northern Ireland Retail Movement Scheme        |

	
Scenario: Verify Save and return to dashboard on Authorised Signatory page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Country | FBONumber |                        nextPage                                  |
	| test      |  England | testFBO   |   Sign up for the Northern Ireland Retail Movement Scheme        |

Scenario Outline:Verify save and return to dashboard on Authorised Signatory page after completing Contact person
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
	Then  verify next page '<nextPage>' is loaded 
	And   click Save and return to dashboard
	Then  verify next page '<nextPage1>' is loaded 

Examples: 
	| logininfo | Country | FBONumber | nextPage             | fullName  | contactName | contactPosition | emailAddress   | telephoneNumber | Authposition  | nextPage1 |
	| test      | England | testFBO   | Authorised Signatory | test name | test name   | test            | test@gmail.com | 01632 960 001   | administrator | Sign up   |

