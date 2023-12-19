@SelfServeRegression
Feature: VerifyBusinessRMSNumber

Verify Business RMS Number

Background: 
	Given Clear Database for user 'test1A'
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo 'test1A'
	And   select business to sign up 'Kaka'
	And   complete eligibility task with 'England'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name 'Kaka'
	When  click on FBOorPHRNumber task
	And   enter FBO number 'testFBO' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	And   user verify the business contact details status 'NOT STARTED'
    And   user verify the Authorised Signatory status 'CANNOT START YET'
    And   user verify the Points of departure status 'NOT STARTED'
	And   verify Check answers and submit sign up status 'CANNOT START YET'
	When  complete Business contact details task with 'contactName', 'contactPosition', 'test@test.com', '01234 234 455'
	Then  user verify the business contact details status 'COMPLETED'
    And   user verify the Authorised Signatory status 'NOT STARTED'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of departure with 'EstablishmentName', 'AddressLine1', 'London', 'England', 'SE10 9NF'
	Then  user verify the Points of departure status '1 ADDED'
	And   click on Check answers and submit sign up
	And   verify next page 'Check your answers' is loaded 
	When  click on continue button
	Then  verify next page 'Terms and conditions' is loaded
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up
	Then  verify  'You have successfully submitted a request to sign up for the Northern Ireland Retail Movement Scheme' on completed sign up page
	Then  verify  'We will review your sign-up request and email you with the outcome within 5 working days.' outcome of my request submission page
	Then  click on signout button and verify the signout message

Scenario: Verify business RMS Number
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
	Then  verify dynamic name '<Business selection>' in title '<nextPage>' of page
	Then  verify Business RMS number '<Business RMS Number>' on self serve dashboard page

	Examples: 
	| logininfo | Business selection | Business RMS Number | nextPage                                |
	| test1A    | Kaka               | RMS-GB              | Northern Ireland Retail Movement Scheme |



