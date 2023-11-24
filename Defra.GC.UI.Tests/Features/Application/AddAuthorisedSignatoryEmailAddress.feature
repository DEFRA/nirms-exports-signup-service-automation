@Regression
Feature: AddAuthorisedSignatoryEmailAddress

Add Authorised Signatory Email Address

   @SmokeTest 
Scenario: Add Authorised Signatory Email Address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
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
	When  user is on Authorised Signatory Email address page
	Then  verify dynamic name '<fullName>' in title '<nextPage1>' of page 
    Then  user enters manually '<emailAddress>' in email address page
    And   click Save and return to dashboard
	And   verify next page '<nextPage>' is loaded 

	
	Examples: 
	| logininfo | Business selection						 | Country | FBONumber | nextPage  | fullName  | contactName | contactPosition | emailAddress  | telephoneNumber | Authposition |nextPage1     |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.  | England | testFBO   | Sign up   | test name | test name   | test            | test@gmail.com  | 01632 960 001 | administrator|email address |


Scenario: Verify error message for invalid Authorised Signatory Email Address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
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
	When  user is on Authorised Signatory Email address page
    Then  user enters manually '<AuthemailAddress>' in email address page
    Then  click on save and continue 
	Then  verify error message '<errorMsg>' on authorised signatory email address page

    Examples:    
	| logininfo | Business selection						 | fullName  | Country | FBONumber | errorMsg                                                            | contactName | contactPosition | emailAddress   | telephoneNumber | AuthemailAddress | Authposition |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.  | test name | England | testFBO   | Enter an email address in the correct format, like name@example.com | test Name   | test            | test@gmail.com | 01632 960 001   | test%gmail.com   | COO          |

Scenario Outline:  Verify error message for blank Authorised Signatory Email Address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
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
	When  user is on Authorised Signatory Email address page
    Then  user enters manually '<AuthemailAddress>' in email address page
    Then  click on save and continue 
	Then  verify error message '<errorMsg>' on authorised signatory email address page

    Examples:    
	| logininfo | Business selection						| fullName  | Country | FBONumber | errorMsg               | contactName | contactPosition | emailAddress   | telephoneNumber | AuthemailAddress | Authposition |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | test name | England | testFBO   | Enter an email address | test Name   | test            | test@gmail.com | 01632 960 001   |                  | COO          |


Scenario Outline:Verify user clicks on back to dashboard link and navigates to tasklist page 
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
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
	When  user is on Authorised Signatory Email address page
	When   click on back to dashboard link
	Then  verify next page '<previousPage>' is loaded 

Examples:
	| logininfo | Business selection						 | Country | FBONumber | previousPage | fullName  | contactName | contactPosition | emailAddress   | telephoneNumber | Authposition  |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.  | England | testFBO   | Sign up      | test name | test name   | test            | test@gmail.com | 01632 960 001   | administrator |


Scenario Outline:Verify save and return to dashboard on Authorised Signatory Email address Page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
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
	When  user is on Authorised Signatory Email address page
    And   user enters manually '<AuthemailAddress>' in email address page
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

Examples: 
	| logininfo | Business selection						 | Country | FBONumber | nextPage | fullName  | contactName | contactPosition | emailAddress   | telephoneNumber | Authposition  | AuthemailAddress |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.  | England | testFBO   | Sign up  | test name | test name   | test            | test@gmail.com | 01632 960 001   | administrator | auth@gmail.com   |

