﻿@Regression
Feature: Receive Notice after RequestSubmission

Receive Notice of Signup Request

Scenario: Verify message on signup confirmation for GB establishment
	Given Clear Database for user '<logininfo>'
	When that I navigate to the NI GC application
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
	When  complete contact person Authorised Signatory with Yes Authorisation
    Then  user verify the Authorised Signatory status 'COMPLETED'
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of departure status '1 ADDED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage1>' is loaded
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up
	Then  verify  '<Message>' on completed sign up page
	Then  verify  '<OutcomeMessage>' outcome of my request submission page
	Then  verify  '<GBNIConfirmationMessage>' GB text on request submission page
	And   verify next page '<nextPage2>' is loaded 
	Then  click on signout button and verify the signout message



	Examples: 
	| logininfo | Business selection	| Country | FBONumber| Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1            | Message                                                                                | OutcomeMessage                                                                           | GBNIConfirmationMessage                                                                                                                                                                     |               nextPage2   |
	| test1A    | TestEnv2              | England | testFBO  | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName3      | testAddress1 | London  | England    | Check your answers | Terms and conditions | You have successfully submitted a request to sign up for the NI Retail Movement Scheme | We will review your sign-up request and email you with the outcome within 5 working days.| Your consignee will also need to sign up for the scheme. If their sign-up request is approved, you will be able to apply for General Certificates to send goods to them in Northern Ireland.|NI Retail Movement Scheme  |


Scenario: Verify message on signup confirmation for NI establishment
	Given Clear Database for user '<logininfo>'
	And that I navigate to the NI GC application
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
	When  complete contact person Authorised Signatory with Yes Authorisation
    Then  user verify the Authorised Signatory status 'COMPLETED'
	When  complete Points of destination with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of destination status '1 ADDED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage1>' is loaded
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up
	Then  verify  '<Message>' on completed sign up page
	Then  verify  '<OutcomeMessage>' outcome of my request submission page
	Then  verify  '<GBNIConfirmationMessage>' NI text on request submission page
	And   verify next page '<nextPage2>' is loaded 
	Then  click on signout button and verify the signout message



	Examples: 
	| logininfo | Business selection  | Country          | FBONumber| Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry       | nextPage           | nextPage1            | Message                                                                                | OutcomeMessage                                                                           | GBNIConfirmationMessage                                                                                                                                                                                   |  nextPage2                |
	| test1A    | TestEnv2            | Northern Ireland | testFBO  | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName4      | testAddress1 | Belfast | Northern Ireland | Check your answers | Terms and conditions | You have successfully submitted a request to sign up for the NI Retail Movement Scheme | We will review your sign-up request and email you with the outcome within 5 working days.| Your consignor will also need to sign up for the scheme. If their sign-up request is approved, they will be able to apply for General Certificates (opens in a new tab) to send goods to Northern Ireland.|NI Retail Movement Scheme  |
