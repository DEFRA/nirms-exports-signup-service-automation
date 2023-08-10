@Regression
Feature: AddAuthorisedSignatoryName

Add Authorised Signatory name

Scenario: Add Authorised Signatory name
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
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	And   user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	And   verify next page '<nextPage>' is loaded 

	
	Examples: 
	| logininfo | Business selection						| Country | FBONumber | nextPage  | fullName  | contactName | contactPosition | emailAddress   | telephoneNumber |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   |  position | test name | test name   | test            | test@gmail.com | 01632 960 001   |



Scenario: Verify error message for invalid Authorised Signatory name
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
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	And   user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then click on save and continue
	Then  user verifies the '<errorMsg>' error message for Authorised Signatory name

    Examples:    
	| logininfo |Business selection						   | fullName  | Country | FBONumber | errorMsg																																								 | contactName | contactPosition | emailAddress   | telephoneNumber |
	| test      |ABC ACCOUNTANCY & MARKETING SERVICES LTD. | test%name | England | testFBO   | Enter the full name of the authorised representative using only letters, numbers, brackets, full stops, hyphens (-), underscores (_), slashes (/) or ampersands (&)   | test Name   | test            | test@gmail.com | 01632 960 001   |


Scenario Outline: Verify error message for blank Authorised Signatory name
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
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	And   user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user verifies the '<errorMsg>' error message for Authorised Signatory name

    Examples:    
	| logininfo | Business selection						| fullName | Country | FBONumber | errorMsg														     | contactName | contactPosition | emailAddress   | telephoneNumber |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. |          | England | testFBO   | Enter the name of the authorised representative for your business | test Name   | test            | test@gmail.com | 01632 960 001   |


Scenario Outline:Verify user clicks on back to dashboard button and navigates to previous page 
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
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	And   user is on Authorised Signatory Enter name page
	When   click on back to dashboard link 
	Then  verify next page '<previousPage>' is loaded 

Examples:
	| logininfo |Business selection						   | Country | FBONumber | previousPage  | contactName | contactPosition | emailAddress   | telephoneNumber |
	| test      |ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | Sign up		 | test Name   | test            | test@gmail.com | 01632 960 001   |


Scenario Outline:Verify save and return to dashboard on Authorised Signatory Name Page
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
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	When  user is on Authorised Signatory Enter name page
	And   user enters manually '<fullName>' in the full name feild
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

Examples: 
	| logininfo | Business selection					    |Country | FBONumber | nextPage| fullName |contactName     |contactPosition |emailAddress  |telephoneNumber |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. |England | testFBO   | Sign up | test name|test name       |test            |test@gmail.com|01632 960 001   |




