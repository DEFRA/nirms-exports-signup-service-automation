@SelfServeRegression
Feature: SelfServeDashboard

Verify Self serve dashboard

Background: 
	Given Clear Database for user 'test1A'

	
Scenario: Verify different statuses on self serve dashboard
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   verify status 'Not signed-up' is displayed for the '<Business selection>' on self serve dashboard
	And   verify link 'Sign up' is displayed for the '<Business selection>' on self serve dashboard
	And   select business '<Business selection>' on self serve dashboard
	And   click on back link
	And   verify status 'Sign-up started' is displayed for the '<Business selection>' on self serve dashboard
	And   verify link 'Continue' is displayed for the '<Business selection>' on self serve dashboard
	And   select business '<Business selection>' on self serve dashboard 
	Then  verify next page 'Requirements of the Northern Ireland Retail Movement Scheme' is loaded
	When  complete eligibility task with 'England'
	Then  verify eligibility task status as 'Completed'
	Then  verify next page 'Sign up' is loaded
	When  complete Business contact details task with 'contactName', 'contactPosition', 'test@test.com', '01234 234 455'
	Then  user verify the business contact details status 'Completed'
	When  click on FBOorPHRNumber task
	And   enter FBO number 'testFBO' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'Completed'
	When  complete Business contact details task with 'contactName', 'contactPosition', 'test@test.com', '01234 234 455'
	Then  user verify the business contact details status 'Completed'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of departure with 'NewEstablishment2', 'AddressLine', 'London', 'England', 'SE2 9BS'
	Then  user verify the Points of departure status '1 added'
	And   click on Check answers and submit sign up
	And   verify next page 'Check your answers' is loaded 
	When  click on continue button
	Then  verify next page 'Terms and conditions' is loaded
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up
	Then  verify  'You have successfully submitted a request to sign up for the Northern Ireland Retail Movement Scheme' on completed sign up page
	When  navigate to Self Serve Dashboard URL
	Then  verify status 'Pending approval' is displayed for the '<Business selection>' on self serve dashboard
	When  Approve Sign up request for org '<Business selection>' and user '<logininfo>'
	Then  click on refresh link on self serve dashboard
	And   verify status 'Approved for NIRMS' is displayed for the '<Business selection>' on self serve dashboard
	And   verify link 'Manage' is displayed for the '<Business selection>' on self serve dashboard
	When  select business '<Business selection>' on self serve dashboard
	Then  verify dynamic name '<Business selection>' in title 'Northern Ireland Retail Movement Scheme' of page
	When  click on contact person change link
	And   enter contact person Name 'Updated Name'
	And   click on save contact person details
	And   verify Contact Person date format 'Updated' on self serve dashboard
	And   click on back link
	When  Reject Sign up request for org '<Business selection>'
	Then  click on refresh link on self serve dashboard
	And   verify status 'Sign-up rejected' is displayed for the '<Business selection>' on self serve dashboard
	And   verify link 'Sign up again' is displayed for the '<Business selection>' on self serve dashboard
	When  select business '<Business selection>' on self serve dashboard
	Then  verify next page 'Requirements of the Northern Ireland Retail Movement Scheme' is loaded
	When  Suspend Sign up request for org '<Business selection>'
	And   navigate to Self Serve Dashboard URL
	And   verify status 'Suspended' is displayed for the '<Business selection>' on self serve dashboard
	And   verify link 'View' is displayed for the '<Business selection>' on self serve dashboard
	And   select business '<Business selection>' on self serve dashboard 
	Then  verify status 'Suspended from NIRMS' on self serve business dashboard page
	Then  verify dynamic name '<Business selection>' in title '<nextPage>' of page
	Then  verify Business RMS number '<Business RMS Number>' on self serve dashboard page


	Examples: 
	| logininfo | Business selection | Business RMS Number | nextPage                                |
	| test1A    | TestEnv2           | RMS-GB              | Northern Ireland Retail Movement Scheme |


Scenario: Verify Add business button on self serve dashboard
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	Then  click on Add Business Button on self serve dashboard
	Then  verify next page 'Add a business' is loaded
	And   click on back link
	Then  verify next page 'Northern Ireland Retail Movement Scheme' is loaded

Examples: 
	| logininfo | 
	| test1A    | 