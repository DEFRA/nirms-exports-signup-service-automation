@SelfServeRegression 
Feature: VerifyGBEstablishmentStatus

Verify GB Establishment Status

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
	Then  verify  'You have successfully submitted a request to sign up for the NI Retail Movement Scheme' on completed sign up page
	Then  verify  'We will review your sign-up request and email you with the outcome within 5 working days.' outcome of my request submission page
	Then  click on signout button and verify the signout message
	Given Approve Sign up request for org 'TestEnv3' and user 'test1C'
	When  Update establishment status to 'Active' of 'EstablishmentName' for business 'TestEnv3' and user 'test1C'


Scenario: Verify GB establishment details for different statuses
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
	Then  verify establishment details on table for '<EstablishmentName>' as '<Status1>', '<AddrPostcode1>'	
	When  click on establishment '<EstablishmentName>'
	Then  verify establishment details for '<EstablishmentName>' with '<Status1>', '<AddrPostcode1>', '<EmailAddress>'
	When  Update establishment status to '<Status3>' of '<EstablishmentName>' for business '<Business selection>' and user '<logininfo>'
	And   refresh NI GC application
	And   select business '<Business selection>' on self serve dashboard 
	Then  verify establishment details on table for '<EstablishmentName>' as '<Status3>', '<AddrPostcode1>'
	When  click on establishment '<EstablishmentName>'
	Then  verify establishment details for '<EstablishmentName>' with '<Status3>', '<AddrPostcode1>', '<EmailAddress>'
	When  Update establishment status to '<Status4>' of '<EstablishmentName>' for business '<Business selection>' and user '<logininfo>'
	And   refresh NI GC application
	And   select business '<Business selection>' on self serve dashboard 
	Then  verify establishment details on table for '<EstablishmentName>' as '<Status4>', '<AddrPostcode1>'
	When  click on establishment '<EstablishmentName>'
	Then  verify establishment details for '<EstablishmentName>' with '<Status4>', '<AddrPostcode1>', '<EmailAddress>'
	And   click on back link
	When  click on link 'Add a place of dispatch'
	And   add establishment as a draft with '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	Then  verify establishment details on table for '<EstablishmentName2>' as '<Status2>', '<AddrPostcode2>'
	When  click on establishment '<EstablishmentName2>'
	Then  verify establishment details for '<EstablishmentName2>' with '<Status2>', '<AddrPostcode2>', '<EmailAddress>'
	When  click on continue button
	When  click on button 'Add place of dispatch'
	When  click on back to dashboard link
	Then  verify establishment details on table for '<EstablishmentName2>' as '<Status1>', '<AddrPostcode2>'

	Examples: 
	| logininfo | Business selection | EstablishmentName | EstablishmentName2  | AddressLine2 | estCity2 | estCountry2 | AddrPostcode1 | AddrPostcode2 | EmailAddress  | Status1 | Status2 | Status3 | Status4   |
	| test1C    | TestEnv3           | EstablishmentName | TestEstablishment13 | testAddress2 | London   | England     | NW1 5LR       | NW1 5LT       | test@test.com | Active  | Draft   | Removed | Suspended |
