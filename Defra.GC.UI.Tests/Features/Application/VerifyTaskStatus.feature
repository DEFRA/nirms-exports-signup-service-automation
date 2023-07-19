@Regression
Feature: VerifyTaskStatus

Verify the status of each task on Signup page

Scenario: Verify the status of each task on Signup task list page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the business name status 'IN PROGRESS'
	And   user verify the business contact details status 'NOT STARTED'
    And   user verify the Authorised Signatory status 'NOT STARTED'
    And   user verify the Points of departure status 'NOT STARTED'
	And   verify Check answers and submit sign up status 'CANNOT START YET'

	Examples: 
	| logininfo | Business selection | Country | FBONumber |
	| test      | ACME Ltd           | England | testFBO   |

Scenario: Verify the status of each task on Signup task list page when tasks are completed
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	Then  user verify the business name status 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	Then  user verify the business contact details status 'COMPLETED'
	When  complete contact person Authorised Signatory with Yes Authorisation
	Then  user verify the Authorised Signatory status 'COMPLETED'
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of departure status 'COMPLETED'
	And   verify Check answers and submit sign up status 'NOT STARTED'
	And   verify Check answers and submit sign up link is enabled

	Examples: 
	| logininfo | Business selection   | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry |
	| test      |   ACME Ltd           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    |


