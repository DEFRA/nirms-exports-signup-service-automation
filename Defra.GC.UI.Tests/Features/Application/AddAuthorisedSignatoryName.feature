@Regression
Feature: AddAuthorisedSignatoryName

Add Authorised Signatory name

Scenario: Add Authorised Signatory name
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
	When  select 'No' to the contact person is the Authorised Signatory
	And   user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	And   verify next page '<nextPage>' is loaded 

	
	Examples: 
	| logininfo | Country | FBONumber | nextPage						 | fullName |contactName     |contactPosition |emailAddress  |telephoneNumber |
	| test      | England | testFBO   | Position of Authorised Signatory | test name|test name       |test            |test@gmail.com|01632 960 001   |



Scenario: Verify error message for invalid Authorised Signatory name
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
	When  select 'No' to the contact person is the Authorised Signatory
	And   user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then click on save and continue
	Then  user verifies the '<errorMsg>' error message for Authorised Signatory name

    Examples:    
	| logininfo | fullName      | Country    |FBONumber |errorMsg                                                                   |contactName     |contactPosition |emailAddress  |telephoneNumber |
	| test      | test%name     | England    |testFBO   |Name must only include letters, numbers, and special characters -_./()&    |test Name       |test            |test@gmail.com|01632 960 001   |


Scenario Outline:  Verify error message for blank Authorised Signatory name
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
	When  select 'No' to the contact person is the Authorised Signatory
	And   user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user verifies the '<errorMsg>' error message for Authorised Signatory name

    Examples:    
	| logininfo | fullName      | Country    |FBONumber |errorMsg      |contactName     |contactPosition |emailAddress  |telephoneNumber |
	| test      |               | England    |testFBO   |Enter a name. |test Name       |test            |test@gmail.com|01632 960 001   |


Scenario Outline:Verify user clicks on back button and navigates to previous page 
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
	When  select 'No' to the contact person is the Authorised Signatory
	And   user is on Authorised Signatory Enter name page
	And   click on back link
	Then  verify next page '<previousPage>' is loaded 

Examples:
	| logininfo | Country | FBONumber | previousPage                                        |contactName     |contactPosition |emailAddress  |telephoneNumber |
	| test      | England | testFBO   | Is the contact person the Authorised Signatory at ? |test Name       |test            |test@gmail.com|01632 960 001   |


Scenario Outline:Verify save and return to dashboard on Authorised Signatory Name Page
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
	And   select 'No' to the contact person is the Authorised Signatory
	When  user is on Authorised Signatory Enter name page
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

Examples: 
	| logininfo | Country | FBONumber | nextPage| fullName |contactName     |contactPosition |emailAddress  |telephoneNumber |
	| test      | England | testFBO   | Sign up | test name|test name       |test            |test@gmail.com|01632 960 001   |




