@Regression
Feature: AddAuthorisedSignatory

Add Authorised Signatory


Scenario: No to the contact person of the Authorised Signatory and navigted to full name Authorised page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	Then  user verify the business contact details status 'COMPLETED'
	When  click on Authorised Signatory link
	And   click on save and continue
	Then  verify dynamic name '<contactName>' in error message '<errorMessage>'
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	Then  verify dynamic name '<Business selection>' in title '<nextPage>' of page

	Examples: 
	| logininfo | Business selection  | Country | FBONumber | nextPage								| contactName     | contactPosition | emailAddress  | telephoneNumber |errorMessage                       |
	| test      | TestEnv1            | England | testFBO   | Who is the authorised representative at | testContactName | testPosition    | test@test.com | 01632 960 001   |is the authorised representative |
	
	@ignore
Scenario: Verify error messages if user do not select Authorised Signatory 
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
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	Then  user verify the business contact details status 'COMPLETED'
	When  click on Authorised Signatory link
	And   click on save and continue
	Then  verify dynamic name '<contactName>' in error message '<errorMessage>'
	And   click on back to dashboard link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Business selection  | Country | FBONumber | errorMessage				        |contactName     | contactPosition | emailAddress   | telephoneNumber |nextPage                                                |
	| test      | TestEnv1            | England | testFBO   | is the authorised representative  |testContactName | testPosition    | test@test.com | 01632 960 001    | Sign up for the Northern Ireland Retail Movement Scheme|
	
	@ignore
Scenario: Verify Save and return to dashboard on Authorised Signatory page
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
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	Then  user verify the business contact details status 'COMPLETED'
	When  click on Authorised Signatory link
	When  select 'Yes' to the contact person is the Authorised Signatory without save
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Business selection	|Country | FBONumber |                        nextPage                                  |contactName     | contactPosition | emailAddress  | telephoneNumber |
	| test      |  TestEnv1             |England | testFBO   |   Sign up for the Northern Ireland Retail Movement Scheme        |testContactName | testPosition    | test@test.com | 01632 960 001   |


Scenario Outline:Verify save and return to dashboard on Authorised Signatory page after completing Contact person
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
	Then  verify dynamic name '<Business selection>' in title '<nextPage>' of page
	And   verify dynamic name '<contactName>' in title '<nextPage>' of page
	When  select 'Yes' to the contact person is the Authorised Signatory without save
	And   click Save and return to dashboard
	Then  verify next page '<nextPage1>' is loaded 

Examples: 
	| logininfo | Business selection  |Country | FBONumber | nextPage                  | fullName  | contactName | contactPosition | emailAddress   | telephoneNumber | Authposition  | nextPage1 |
	| test      | TestEnv1            |England | testFBO   | authorised representative | test name | test name   | test            | test@gmail.com | 01632 960 001   | administrator | Sign up   |

