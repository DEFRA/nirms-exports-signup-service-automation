﻿@Regression 
Feature: Terms and Conditions

Check Terms and conditions and clicking on the Submit signup button


Scenario: Verify Terms and conditions page loaded 
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
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of departure status '1 ADDED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage1>' is loaded
	Then  click on back link
	And   verify next page '<nextPage>' is loaded
	When  click on continue button
	Then  verify next page '<nextPage1>' is loaded
	Then  verify dynamic name '<Business selection>' and the text '<TCstext>' on Terms and conditions page
	Then  verify the current date is shows on ReMoS Terms & Conditions Declaration  page
	Then  click on submit sign up
	Then  verify error message '<errorMessage>' on ReMoS Terms & Conditions Declaration  page
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up

	Examples: 
	| logininfo | Business selection   | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1            |errorMessage                                                                                             |TCstext                                                                                                                                                                                                                          |
	| test      | TestEnv1             | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstNameT1     | testAddress1 | London  | England    | Check your answers | Terms and conditions |Confirm that the authorised representative - contactName has read and understood the terms and conditions|authorised representative - contactName - has read and understood the terms and conditions of the NI Retail Movement Scheme. contactName is responsible for ensuring the requirements of the scheme are followed by the business.|
