@Regression
Feature: AddAuthorisedSignatory

Add Authorised Signatory

Scenario: Add Authorised Signatory and navigated to tasklist page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   select 'Yes' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection						| Country | FBONumber | nextPage                |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | Add a place of dispatch |
	

Scenario: No to the contact person of the Authorised Signatory and navigted to full name Authorised page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection						| AddressLine1 | Town     | AddrPostcode | Country | FBONumber | Business name    | nextPage											   |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | testAddress1 | testCity | wd19 7pf     | England | testFBO   | testBusinessname | Who is the authorised representative at your business? |
	

Scenario: Verify error messages if user do not select Authorised Signatory 
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   click on save and continue
	Then  verify error message '<errorMessage>' on Authorised Signatory page

	Examples: 
	| logininfo | Business selection						 | AddressLine1 | Town     | AddrPostcode | Country | FBONumber | errorMessage													 |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.  | testAddress1 | testCity | wd19 7pf     | England | testFBO   | Select if the contact person is the authorised representative  |

Scenario: Verify back to dashboard link navigated to tasklist page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   click on back to dashboard link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection						| Country | FBONumber | nextPage                                                |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | Sign up for the Northern Ireland Retail Movement Scheme |

	
Scenario: Verify Save and return to dashboard on Authorised Signatory page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	When  select 'Yes' to the contact person is the Authorised Signatory without save
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Business selection						|Country | FBONumber |                        nextPage                                  |
	| test      |  ABC ACCOUNTANCY & MARKETING SERVICES LTD.|England | testFBO   |   Sign up for the Northern Ireland Retail Movement Scheme        |

Scenario Outline:Verify save and return to dashboard on Authorised Signatory page after completing Contact person
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
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
	When  select 'Yes' to the contact person is the Authorised Signatory without save
	And   click Save and return to dashboard
	Then  verify next page '<nextPage1>' is loaded 

Examples: 
	| logininfo | Business selection						|Country | FBONumber | nextPage                  | fullName  | contactName | contactPosition | emailAddress   | telephoneNumber | Authposition  | nextPage1 |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. |England | testFBO   | authorised representative | test name | test name   | test            | test@gmail.com | 01632 960 001   | administrator | Sign up   |

