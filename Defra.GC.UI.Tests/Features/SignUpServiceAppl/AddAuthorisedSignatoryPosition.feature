@Regression
Feature: AddAuthorisedSignatoryPosition

Add Authorised Signatory Position


Scenario: Verify error message for invalid authorised signatory position
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
	When  click on back to dashboard link 
	Then  verify next page '<previousPage>' is loaded 
	When  click on Authorised Signatory link
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	When  user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	Then  verify error message '<errorMessage>' on Authorised signatory position page
	Then  user enters '<Authposition2>' position on Authorised signatory position page
	And   click on save and continue
	Then  verify error message '<errorMessage2>' on Authorised signatory position page
	And   user enters '<Authposition3>' position on Authorised signatory position page
	And   click Save and return to dashboard
	Then  verify next page '<previousPage>' is loaded 

	Examples: 
| logininfo | Business selection   | Country | FBONumber | contactName     | contactPosition | fullName  | Authposition | emailAddress   | telephoneNumber | errorMessage																			   							             |Authposition2|errorMessage2   |previousPage |Authposition3 |
| test      | TestEnv1             | England | testFBO   | testContactName | testPosition    | test Name | test%        | test@gmail.com | 01632 960 001   | Enter a position using only letters, numbers, brackets, full stops, commas, hyphens, underscores, forward slashes or ampersands |             |Enter a position|Sign up      |administrator |

@ignore
Scenario: Verify error message for blank authorised signatory position
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
	Then  verify error message '<errorMessage>' on business contact position page
	When   click on back to dashboard link 
	Then  verify next page '<previousPage>' is loaded 

	Examples: 
	| logininfo | Business selection  | Country | FBONumber | contactName     | contactPosition | fullName  | Authposition | emailAddress   | telephoneNumber | errorMessage     | previousPage |
	| test      | TestEnv1            | England | testFBO   | testContactName | testPosition    | test Name |              | test@gmail.com | 01632 960 001   | Enter a position | Sign up      |


	@ignore
Scenario Outline:Verify user clicks on back to dashboard button and navigates to tasklist page 
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
	When   click on back to dashboard link 
	Then  verify next page '<previousPage>' is loaded 

Examples:
	| logininfo |Business selection	 | Country | FBONumber | previousPage  | contactName | contactPosition | emailAddress   | telephoneNumber |Authposition |fullName|
	| test      |TestEnv1            | England | testFBO   | Sign up	   | test Name   | test            | test@gmail.com | 01632 960 001   |admin        |testname|


	@ignore
Scenario Outline:Verify save and return to dashboard on Authorised Signatory position Page
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
	And   user enters manually '<fullName>' in the full name feild
	And   click on save and continue
	And   user enters '<Authposition>' position on Authorised signatory position page
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

Examples: 
	| logininfo | Business selection  | Country | FBONumber | nextPage | fullName  | contactName | contactPosition | emailAddress   | telephoneNumber | Authposition  |
	| test      | TestEnv1            | England | testFBO   | Sign up  | test name | test name   | test            | test@gmail.com | 01632 960 001   | administrator |

