@Regression
Feature: CheckAnswers

Check Answers and Submit the application

Scenario: Check answers and submit sign up link verification on GB points of establishment
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
	When  click on continue
	Then  verify next page '<nextPage1>' is loaded
	And   confirm Sanitary and phytosanitary (SPS) assurance commitment
	And   click on continue

	Examples: 
	| logininfo | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1                  |
	| test      | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Check your answers | Sanitary and phytosanitary |

Scenario: Check answers and submit sign up link verification on NI points of establishment
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	Then  user verify the business name status 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	Then  user verify the business contact details status 'COMPLETED'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of destination with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of destination status 'COMPLETED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on continue
	Then  verify next page '<nextPage1>' is loaded
	And   confirm Sanitary and phytosanitary (SPS) assurance commitment
	And   click on continue

	Examples: 
	| logininfo | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry       | nextPage           |nextPage1                  |
	| test      | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Check your answers |Sanitary and phytosanitary |


	Scenario: Edit Check answers for GB Retail Movement Scheme sign up
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
	When  edit value of <FieldName> to <FieldValue>
	Examples: 
	| logininfo | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1                  | FieldName     | FieldValue  |
	| test      | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Check your answers | Sanitary and phytosanitary | Business name | ChangedName |
	| test      | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Check your answers | Sanitary and phytosanitary | Business name | ChangedName |


	Scenario: Edit Check answers for Northern Ireland Retail Movement Scheme sign up
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
	When  click on continue
	Then  verify next page '<nextPage1>' is loaded
	And   confirm Sanitary and phytosanitary (SPS) assurance commitment
	And   click on continue

	Examples: 
	| logininfo | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1                  |
	| test      | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Check your answers | Sanitary and phytosanitary |
