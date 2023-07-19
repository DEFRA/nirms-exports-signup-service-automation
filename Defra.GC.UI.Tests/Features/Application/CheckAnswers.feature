@Regression
Feature: CheckAnswers

Check Answers and Submit the application

Scenario: Check answers and submit sign up link verification on GB points of establishment
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
	And   click on Check answers and submit sign up
	Then  verify next page '<nextPage>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage1>' is loaded
    Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up

	Examples: 
	| logininfo |  Business selection  | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1            |
	| test      |  ACME Ltd            | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Check your answers | Terms and conditions |

Scenario: Check answers and submit sign up link verification on NI points of establishment
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
	When  complete Points of destination with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of destination status 'COMPLETED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage1>' is loaded
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up

	Examples: 
	| logininfo | Business selection  | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry       | nextPage           | nextPage1            |
	| test      | ACME Ltd            | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Check your answers | Terms and conditions |


	Scenario: Edit Check answers for GB Retail Movement Scheme sign up
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
	And   click on Check answers and submit sign up
	When  edit value of '<FieldName>' to '<FieldValue>' on Check answers page
	Then  verify edited value of '<FieldName>' to '<FieldValue>' on Check answers page   
	Examples: 
	| logininfo | Business selection | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | FieldName                                  | FieldValue          |
	| test      | ACME Ltd           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Business name                              | ChangedName         |
	| test      | ACME Ltd           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Business address                           | ChangedAddr         |
	| test      | ACME Ltd           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | FBO number                                 | ChangeFBO           |
	| test      | ACME Ltd           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Contact name                               | ChangedName         |
	| test      | ACME Ltd           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Contact position                           | ChangedPosition     |
	| test      | ACME Ltd           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Contact email address                      | change@test.com     |
	| test      | ACME Ltd           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Contact telephone number                   | 01632 960 999       |
	| test      | ACME Ltd           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Address                                    | ChangedAddress      |
	| test      | ACME Ltd           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Email address                              | Changed@address.com |
	| test      | ACME Ltd           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Contact person is the Authorised Signatory | No                  |


	Scenario: Edit Authorised Signatory on Check answers for GB Retail Movement Scheme sign up
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	Then  user verify the business name status 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	Then  user verify the business contact details status 'COMPLETED'
	When  complete contact person Authorised Signatory with No option
    Then  user verify the Authorised Signatory status 'COMPLETED'
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of departure status 'COMPLETED'
	And   click on Check answers and submit sign up
	When  edit value of '<FieldName>' to '<FieldValue>' on Check answers page
	Then  verify edited value of '<FieldName>' to '<FieldValue>' on Check answers page   
	Examples: 
	| logininfo | Business selection  | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | FieldName                                  | FieldValue                          |
	| test      | ACME Ltd			  | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Contact person is the Authorised Signatory | Yes                                 |
	| test      | ACME Ltd			  | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Authorised Signatory name                  | ChangedAuthorisedName               |
	| test      | ACME Ltd			  | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Authorised Signatory position              | ChangedAuthorisedPosition           |
	| test      | ACME Ltd			  | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Authorised Signatory email address         | Changed@AuthorisedSignatoryname.com |


	Scenario: Edit Check answers for Northern Ireland Retail Movement Scheme sign up
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
	When  complete Points of destination with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of destination status 'COMPLETED'
	And   click on Check answers and submit sign up
	When  edit value of '<FieldName>' to '<FieldValue>' on Check answers page
	Then  verify edited value of '<FieldName>' to '<FieldValue>' on Check answers page

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry       | FieldName                                  | FieldValue          |
	| test      | ACME Ltd		     | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Business name                              | ChangedName         |
	| test      | ACME Ltd			 | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Business address                           | ChangedAddr         |
	| test      | ACME Ltd			 | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | FBO number                                 | ChangeFBO           |
	| test      | ACME Ltd			 | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Contact name                               | ChangedName         |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Contact position                           | ChangedPosition     |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Contact email address                      | change@test.com     |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Contact telephone number                   | 01632 960 999       |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Address                                    | ChangedAddress      |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Email address                              | Changed@Address.com |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Contact person is the Authorised Signatory | No                  |

	Scenario: Edit Authorised Signatory on Check answers for Northern Ireland Retail Movement Scheme sign up
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	Then  user verify the business name status 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	Then  user verify the business contact details status 'COMPLETED'
	When  complete contact person Authorised Signatory with No option
	Then  user verify the Authorised Signatory status 'COMPLETED'
	When  complete Points of destination with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of destination status 'COMPLETED'
	And   click on Check answers and submit sign up
	When  edit value of '<FieldName>' to '<FieldValue>' on Check answers page
	Then  verify edited value of '<FieldName>' to '<FieldValue>' on Check answers page

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry       | FieldName                                  | FieldValue                            |
	| test      | ACME Ltd			 | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Contact person is the Authorised Signatory | Yes                                   |
	| test      | ACME Ltd			 | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Authorised Signatory name                  | Changed Authorised Signatory name     |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Authorised Signatory position              | Changed Authorised Signatory position |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | Belfast | Northern Ireland | Authorised Signatory email address         | Changed@AuthorisedSignatoryname.com   |

	
	
	Scenario: Verify place of dispatch link on check your answers page
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
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on Add another point of departure link
	Then  verify next page '<nextPage1>' is loaded
	When  complete Points of departure with '<EstablishmentName1>', '<AddressLine2>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   click on Check answers and submit sign up
	Then  verify more than 1 establishment addresses added on Check your answers page
	When  click on continue button
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up

	Examples: 
	| logininfo | Business selection  | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | EstablishmentName1 | AddressLine2 | estCity | estCountry | nextPage           | nextPage1               |
	| test      | ACME Ltd            | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | SecondEstName      | EstAddress2  | London  | England    | Check your answers | Add a place of dispatch |


	Scenario: Verify place of destination link on check your answers page
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
	When  complete Points of destination with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of destination status 'COMPLETED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on Add another point of destination link
	Then  verify next page '<nextPage1>' is loaded
	When  complete Points of destination with '<EstablishmentName1>', '<AddressLine2>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   click on Check answers and submit sign up
	Then  verify more than 1 establishment addresses added on Check your answers page
	When  click on continue button
    Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | EstablishmentName1 | AddressLine2 | estCity | estCountry       | nextPage           | nextPage1                  |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | SecondEstName      | EastAddr1    | Belfast | Northern Ireland | Check your answers | Add a place of destination |

Scenario: Remove GB establishment on check your answers page
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
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on Add another point of departure link
	Then  verify next page '<nextPage1>' is loaded
	When  complete Points of departure with '<EstablishmentName1>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   click on Check answers and submit sign up
	Then  verify total '2' establishment addresses added
	When  click on remove link on estblishment '<EstablishmentName1>' on check answers page
	Then  verify total '1' establishment addresses added

	Examples: 
	| logininfo | Business selection | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | EstablishmentName1 | AddressLine1 | estCity | estCountry | nextPage           | nextPage1               |
	| test      | ACME Ltd			 | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testEstNameRemove  | testAddress1 | London  | England    | Check your answers | Add a place of dispatch |


	Scenario: Remove NI establishment on check your answers page
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
	When  complete Points of destination with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of destination status 'COMPLETED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on Add another point of destination link
	Then  verify next page '<nextPage1>' is loaded
	When  complete Points of destination with '<EstablishmentName1>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   click on Check answers and submit sign up
	Then  verify total '2' establishment addresses added
	When  click on remove link on estblishment '<EstablishmentName1>' on check answers page
	Then  verify total '1' establishment addresses added

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | EstablishmentName1 | AddressLine1 | estCity | estCountry       | nextPage           | nextPage1                  |
	| test      | ACME Ltd			 | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testEstRemove      | testAddress1 | Belfast | Northern Ireland | Check your answers | Add a place of destination |


	Scenario: Verify back link on Check answers page
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
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on back link
	Then  verify next page '<nextPage1>' is loaded

	Examples: 
	| logininfo | Business selection | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1 |
	| test      |  ACME Ltd          | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    | Check your answers | Sign up   |
