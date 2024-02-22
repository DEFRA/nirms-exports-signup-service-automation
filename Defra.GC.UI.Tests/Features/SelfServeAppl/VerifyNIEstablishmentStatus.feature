@SelfServeRegression
Feature: VerifyNIEstablishmentStatus

Verify NI Establishment Status

Background: 
	Given Clear Database for user 'test1C'
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo 'test1C'
	And   select business to sign up 'TestEnv3'
	And   complete eligibility task with 'England'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name 'TestEnv3'
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
	When  complete Points of departure with 'EstablishmentName', 'AddressLine1', 'London', 'England', 'NW1 5LR'
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
	Given Approve Sign up request for org 'TestEnv3'


Scenario: Verify NI establishment status
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
	#Then  verify establishment status for '<EstablishmentName>' as '<Status1>'
	#When  add establishment as a draft with '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	#Then  verify establishment status for '<EstablishmentName2>' as '<Status2>'
	#When  Update establishment status to '<Status2>' of '<EstablishmentName>' for business '<Business selection>' 
	#Then  verify establishment status for '<EstablishmentName>' as '<Status3>'
	#When  Update establishment status to '<Status3>' of '<EstablishmentName>' for business '<Business selection>' 
	#Then  verify establishment status for '<EstablishmentName>' as '<Status4>'

	Examples: 
	| logininfo | Business selection | EstablishmentName | EstablishmentName2  | AddressLine2 | estCity2  | estCountry2 | AddrPostcode2 | Status1 | Status2 | Status3 | Status4   |
	| test1C    | TestEnv3           | EstablishmentName | TestEstablishment12 | testAddress2 | Liverpool | England     | L1 0AN        | Active  | Draft   | Removed | Suspended |
