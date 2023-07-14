@Regression
Feature: AddAuthorisedSignatoryEmailAddress

Add Authorised Signatory Email Address

Scenario: Add Authorised Signatory Email Address
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
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	When  user is on Authorised Signatory Email address page
    Then  user enters manually '<emailAddress>' in email address page
    Then  click on save and continue 
	And   verify next page '<nextPage>' is loaded 

	
	Examples: 
	| logininfo | Country | FBONumber | nextPage| fullName |contactName     |contactPosition |emailAddress  |telephoneNumber |Authposition |
	| test      | England | testFBO   | Sign up | test name|test name       |test            |test@gmail.com|01632 960 001   |administrator|



Scenario: Verify error message for invalid Authorised Signatory Email Address
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
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	When  user is on Authorised Signatory Email address page
    Then  user enters manually '<AuthemailAddress>' in email address page
    Then  click on save and continue 
	Then  verify error message '<errorMsg>' on authorised signatory email address page

    Examples:    
	| logininfo | fullName      | Country    |FBONumber |errorMsg                                                            |contactName     |contactPosition |emailAddress  |telephoneNumber |AuthemailAddress|Authposition |
	| test      | test name     | England    |testFBO   |Enter an email address in the correct format, like name@example.com |test Name       |test            |test@gmail.com|01632 960 001   |test%gmail.com  |COO          |


Scenario Outline:  Verify error message for blank Authorised Signatory Email Address
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
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	When  user is on Authorised Signatory Email address page
    Then  user enters manually '<AuthemailAddress>' in email address page
    Then  click on save and continue 
	Then  verify error message '<errorMsg>' on authorised signatory email address page

    Examples:    
	| logininfo | fullName      | Country    |FBONumber |errorMsg                                             |contactName     |contactPosition |emailAddress  |telephoneNumber |AuthemailAddress|Authposition |
	| test      | test name     | England    |testFBO   |Enter the email address of the authorised signatory. |test Name       |test            |test@gmail.com|01632 960 001   |                |COO          |



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
	And   select 'No' to the contact person is the Authorised Signatory
	When  user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	When  user is on Authorised Signatory Email address page
	When  click on back link
	Then  verify next page '<previousPage>' is loaded 

Examples:
	| logininfo | Country | FBONumber | previousPage| fullName |contactName     |contactPosition |emailAddress  |telephoneNumber |Authposition |
	| test      | England | testFBO   | Position    | test name|test name       |test            |test@gmail.com|01632 960 001   |administrator|




@ignore
Scenario Outline:Verify save and continue later navigating to tasklist page
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
	Then  user verify the business contact details status 'COMPLETED'
	When  click on Authorised Signatory link
	And   select 'No' to the contact person is the Authorised Signatory
	When  user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	When  user is on Authorised Signatory Email address page
    Then  user enters manually '<AuthemailAddress>' in email address page
	Then  user enter save and continue later link

Examples: 
	| logininfo | Country | FBONumber | previousPage| fullName |contactName     |contactPosition |emailAddress  |telephoneNumber |Authposition |
	| test      | England | testFBO   | Position    | test name|test name       |test            |test@gmail.com|01632 960 001   |administrator|

