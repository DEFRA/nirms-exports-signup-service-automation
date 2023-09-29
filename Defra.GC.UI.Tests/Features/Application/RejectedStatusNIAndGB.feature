﻿@Regression
Feature: RejectedStatus for NI & GB Establishment

Scenario: Verify select business page is displayed for user with rejected signup status
	Given Clear Database for user '<logininfo>'
	Given   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of departure status '1 ADDED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage1>' is loaded
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up
	Then  verify  '<Message>' on completed sign up page
	Then  click on signout button and verify the signout message
	When  Reject signup request in Database for user '<logininfo>'
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	Then  verify next page '<nextPage3>' is loaded



	Examples: 
	| logininfo | Business selection | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1            | Message                                                                                              | OutcomeMessage                                    | nextPage2                           |nextPage3                                                                      |
	| test1C    | Org New            | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Check your answers | Terms and conditions | You have successfully submitted a request to sign up for the Northern Ireland Retail Movement Scheme | We will review your sign-up request and email you | Your business has already submitted |What will your business do under the Northern Ireland Retail Movement Scheme?  |

	@RunOnly
Scenario: Verify Add departure displayed for user with rejected signup status
	Given Clear Database for user '<logininfo>'
	Given   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of departure status '1 ADDED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage1>' is loaded
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up
	Then  verify  '<Message>' on completed sign up page
	Then  click on signout button and verify the signout message
	When  Reject signup request in Database for user '<logininfo>'
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	Then  verify next page '<nextPage3>' is loaded
	When  complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of departure status '1 ADDED'
	When  click on points of departure link
	Then  verify next page '<nextPage4>' is loaded 
	

	Examples: 
	| logininfo | Business selection | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1            | Message                                                                                              | OutcomeMessage                                    | nextPage2                           | nextPage3                                                                     | nextPage4    |
	| test1C    | Org New            | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Check your answers | Terms and conditions | You have successfully submitted a request to sign up for the Northern Ireland Retail Movement Scheme | We will review your sign-up request and email you | Your business has already submitted | What will your business do under the Northern Ireland Retail Movement Scheme? | of dispatch  |

	@RunOnly
	Scenario: Verify Add destination displayed for user with rejected signup status
	Given Clear Database for user '<logininfo>'
	Given   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of destination with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of destination status '1 ADDED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage1>' is loaded
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up
	Then  verify  '<Message>' on completed sign up page
	Then  click on signout button and verify the signout message
	When  Reject signup request in Database for user '<logininfo>'
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	Then  verify next page '<nextPage3>' is loaded
	When  complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of destination with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test2@test.com'
	Then  user verify the Points of destination status '1 ADDED'
	

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry       | nextPage           | nextPage1            | Message                                                                                              | OutcomeMessage                                    | nextPage2                           | nextPage3                                                                     | nextPag4                     |
	| test1A    | Kaka               | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT30 6LZ     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Check your answers | Terms and conditions | You have successfully submitted a request to sign up for the Northern Ireland Retail Movement Scheme | We will review your sign-up request and email you | Your business has already submitted | What will your business do under the Northern Ireland Retail Movement Scheme? |  Places of destination       |