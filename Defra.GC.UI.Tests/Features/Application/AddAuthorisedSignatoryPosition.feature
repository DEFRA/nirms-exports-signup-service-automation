@Regression
Feature: AddAuthorisedSignatoryPosition

Add Authorised Signatory Position

   @SmokeTest
Scenario: Add Authorised Signatory position
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
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
	Then  verify dynamic name '<Business selection>' in title '<nextPage1>' of page 
	Then  verify dynamic name '<fullName>' in title '<nextPage1>' of page 
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	Then  verify dynamic name '<fullName>' in title '<nextPage>' of page 

	Examples: 
	| logininfo | Business selection						| Country | FBONumber | contactName     | contactPosition | fullName  | Authposition  | nextPage      | emailAddress   | telephoneNumber | nextPage1 |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | testContactName | testPosition    | test Name | administrator | email address | test@gmail.com | 01632 960 001   | position  |


Scenario: Verify error message for invalid authorised signatory position
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
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
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	Then  verify error message '<errorMessage>' on Authorised signatory position page

	Examples: 
| logininfo | Business selection						| Country | FBONumber | contactName     | contactPosition | fullName  | Authposition | emailAddress   | telephoneNumber | errorMessage																			   							              |
| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | testContactName | testPosition    | test Name | test%        | test@gmail.com | 01632 960 001   | Enter a position using only letters, numbers, brackets, full stops, commas, hyphens, underscores, forward slashes or ampersands |


Scenario: Verify error message for blank authorised signatory position
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
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
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	Then  verify error message '<errorMessage>' on business contact position page

	Examples: 
	| logininfo | Business selection                        | Country | FBONumber | contactName     | contactPosition | fullName  | Authposition | emailAddress   | telephoneNumber | errorMessage     |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | testContactName | testPosition    | test Name |              | test@gmail.com | 01632 960 001   | Enter a position |


Scenario Outline:Verify user clicks on back to dashboard button and navigates to tasklist page 
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
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
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user enters '<Authposition>' position on Authorised signatory position page
	When   click on back to dashboard link 
	Then  verify next page '<previousPage>' is loaded 

Examples:
	| logininfo |Business selection						   | Country | FBONumber | previousPage  | contactName | contactPosition | emailAddress   | telephoneNumber |Authposition |fullName|
	| test      |ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | Sign up		 | test Name   | test            | test@gmail.com | 01632 960 001   |admin        |testname|


Scenario Outline:Verify save and return to dashboard on Authorised Signatory position Page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
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
	And   click on save and continue
	And   user enters '<Authposition>' position on Authorised signatory position page
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

Examples: 
	| logininfo | Business selection 						| Country | FBONumber | nextPage | fullName  | contactName | contactPosition | emailAddress   | telephoneNumber | Authposition  |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | Sign up  | test name | test name   | test            | test@gmail.com | 01632 960 001   | administrator |

