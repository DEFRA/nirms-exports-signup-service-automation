@Regression
Feature: Receive Notice after RequestSubmission
Receive Notice of Signup Request
Scenario: Receive Notice of after completion of Signup Request 
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	Then  user verify the business name status 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	Then  user verify the business contact details status 'COMPLETED'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of departure status 'COMPLETED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage1>' is loaded
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up
	Then  verify  '<Message>' on completed sign up page

	Examples: 
	| logininfo | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1            | Message                                                                                              | 
	| test      | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Check your answers | Terms and conditions | You have successfully submitted a request to sign up for the Northern Ireland Retail Movement Scheme |          


Scenario:  Verify outcome message  after completion of Signup Request 
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	Then  user verify the business name status 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	Then  user verify the business contact details status 'COMPLETED'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of departure status 'COMPLETED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage1>' is loaded
    Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up
	Then  verify  '<OutcomeMessage>' outcome of my request submission page

	Examples: 
	| logininfo | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1             |      OutcomeMessage                                 |
	| test      | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Check your answers | Terms and conditions  | We will review your sign up request and email you   |

