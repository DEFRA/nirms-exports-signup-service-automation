@Regression
Feature: CheckAnswers

Check Answers and Submit the application

Scenario: Check answers and submit sign up link verification on GB points of establishment with save and continue
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>' with save and continue
	#Then  verify next page '<nextPage1>' is loaded 
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>' with save and continue
	Then  verify next page '<nextPage2>' is loaded 
	When  complete contact person Authorised Signatory with Yes Authorisation with save and continue
	Then  verify next page '<nextPage3>' is loaded 
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>' with save and continue
	Then  verify next page '<nextPage4>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage5>' is loaded
    Then  click on the confirm check box on Terms and conditions page
	#Then  click on submit sign up

	Examples: 
	| logininfo | Business selection                       | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage1                 | nextPage2                     | nextPage3   | nextPage4          | nextPage5            |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName1      | testAddress1 | London  | England    | Who is the contact person | contact person the authorised | of dispatch | Check your answers | Terms and conditions |


Scenario: Check answers and submit sign up link verification on NI points of establishment with save and continue
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>' with save and continue
	#Then  verify next page '<nextPage1>' is loaded 
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>' with save and continue
	Then  verify next page '<nextPage2>' is loaded 
	When  complete contact person Authorised Signatory with Yes Authorisation with save and continue
	Then  verify next page '<nextPage3>' is loaded 
	When  complete Points of destination with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>' with save and continue
	Then  verify next page '<nextPage4>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage5>' is loaded
	Then  click on the confirm check box on Terms and conditions page
	#Then  click on submit sign up

	Examples: 
	| logininfo | Business selection  | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry       | nextPage1                 | nextPage2                     | nextPage3      | nextPage4          | nextPage5            |
	| test1     | Kaka                | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName2      | testAddress1 | Belfast | Northern Ireland | Who is the contact person | contact person the authorised | of destination | Check your answers | Terms and conditions |


Scenario: Check answers and submit sign up link verification on GB points of establishment
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	#Then  user verify the business name status 'COMPLETED'
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
	#Then  click on submit sign up

	Examples: 
	| logininfo |  Business selection                        | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1            |
	| test      |  ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName3      | testAddress1 | London  | England    | Check your answers | Terms and conditions |

Scenario: Check answers and submit sign up link verification on NI points of establishment
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	#Then  user verify the business name status 'COMPLETED'
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
	#Then  click on submit sign up

	Examples: 
	| logininfo | Business selection  | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry       | nextPage           | nextPage1            |
	| test1     | Kaka                | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName4      | testAddress1 | Belfast | Northern Ireland | Check your answers | Terms and conditions |


	Scenario: Edit Check answers for GB Retail Movement Scheme sign up
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	#Then  user verify the business name status 'COMPLETED'
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
	| logininfo | Business selection                                  | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | FieldName                                  | FieldValue          |
	| test2     | AMSAK PROPERTY LIMITED           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName5      | testAddress1 | London  | England    | Business name                              | ChangedName         |
	| test2     | AMSAK PROPERTY LIMITED           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName6      | testAddress1 | London  | England    | Business address                           | ChangedAddr         |
	| test2     | AMSAK PROPERTY LIMITED           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName7      | testAddress1 | London  | England    | FBO number                                 | ChangeFBO           |
	| test2     | AMSAK PROPERTY LIMITED           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName8      | testAddress1 | London  | England    | Contact name                               | ChangedName         |
	| test2     | AMSAK PROPERTY LIMITED           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName9      | testAddress1 | London  | England    | Contact position                           | ChangedPosition     |
	| test3     | EASYJET UK LIMITED           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName10     | testAddress1 | London  | England    | Contact email address                      | change@test.com     |
	| test3     | EASYJET UK LIMITED           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName11     | testAddress1 | London  | England    | Contact telephone number                   | 01632 960 999       |
	| test3     | EASYJET UK LIMITED           | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName12     | testAddress1 | London  | England    | Address                                    | ChangedAddress      |
	| test7     | Tescoman                     | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName13     | testAddress1 | London  | England    | Email address                              | Changed@address.com |
	| test7     | Tescoman                     | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName14     | testAddress1 | London  | England    | Contact person is the authorised representative | No                  |


	Scenario: Edit Authorised Signatory on Check answers for GB Retail Movement Scheme sign up
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	#Then  user verify the business name status 'COMPLETED'
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
	| logininfo | Business selection   | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | FieldName                                       | FieldValue                          |
	| test3      | EASYJET UK LIMITED  | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName15     | testAddress1 | London  | England    | Contact person is the authorised representative | Yes                                 |
	| test3      | EASYJET UK LIMITED  | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName16     | testAddress1 | London  | England    | Authorised Signatory name                  | ChangedAuthorisedName               |
	| test3      | EASYJET UK LIMITED  | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName17     | testAddress1 | London  | England    | Authorised Signatory position              | ChangedAuthorisedPosition           |
	| test3      | EASYJET UK LIMITED  | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName18     | testAddress1 | London  | England    | Authorised Signatory email address         | Changed@AuthorisedSignatoryname.com |


	Scenario: Edit Check answers for Northern Ireland Retail Movement Scheme sign up
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	#Then  user verify the business name status 'COMPLETED'
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
	| logininfo | Business selection       | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry       | FieldName                                  | FieldValue          |
	| test4     | NORTH WEST TELUGU SANGAM | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName19     | testAddress1 | Belfast | Northern Ireland | Business name                              | ChangedName         |
	| test4     | NORTH WEST TELUGU SANGAM | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName20     | testAddress1 | Belfast | Northern Ireland | Business address                           | ChangedAddr         |
	| test4     | NORTH WEST TELUGU SANGAM | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName21     | testAddress1 | Belfast | Northern Ireland | FBO number                                 | ChangeFBO           |
	| test4     | NORTH WEST TELUGU SANGAM | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName22     | testAddress1 | Belfast | Northern Ireland | Contact name                               | ChangedName         |
	| test4     | NORTH WEST TELUGU SANGAM | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName23     | testAddress1 | Belfast | Northern Ireland | Contact position                           | ChangedPosition     |
	| test5     | SND NON UK User          | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName24     | testAddress1 | Belfast | Northern Ireland | Contact email address                      | change@test.com     |
	| test5     | SND NON UK User          | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName25     | testAddress1 | Belfast | Northern Ireland | Contact telephone number                   | 01632 960 999       |
	| test5     | SND NON UK User          | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName26     | testAddress1 | Belfast | Northern Ireland | Address                                    | ChangedAddress      |
	| test5     | SND NON UK User          | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName27     | testAddress1 | Belfast | Northern Ireland | Email address                                   | Changed@Address.com |
	| test5     | SND NON UK User          | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName28     | testAddress1 | Belfast | Northern Ireland | Contact person is the authorised representative | No                  |

	Scenario: Edit Authorised Signatory on Check answers for Northern Ireland Retail Movement Scheme sign up
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	#Then  user verify the business name status 'COMPLETED'
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
	| logininfo | Business selection | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry       | FieldName                                       | FieldValue                            |
	| test5     | SND NON UK User    | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName29     | testAddress1 | Belfast | Northern Ireland | Contact person is the authorised representative | Yes                                   |
	| test5     | SND NON UK User    | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName30     | testAddress1 | Belfast | Northern Ireland | Authorised Signatory name                  | Changed Authorised Signatory name     |
	| test5     | SND NON UK User    | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName31     | testAddress1 | Belfast | Northern Ireland | Authorised Signatory position              | Changed Authorised Signatory position |
	| test5     | SND NON UK User    | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName32     | testAddress1 | Belfast | Northern Ireland | Authorised Signatory email address         | Changed@AuthorisedSignatoryname.com   |

	
	
	Scenario: Verify place of dispatch link on check your answers page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	#Then  user verify the business name status 'COMPLETED'
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
	#Then  click on submit sign up

	Examples: 
	| logininfo | Business selection     | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | EstablishmentName1 | AddressLine2 | estCity | estCountry | nextPage           | nextPage1               |
	| test7     | Tescoman               | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName33     | testAddress1 | SecondEstName      | EstAddress2  | London  | England    | Check your answers | Add a place of dispatch |


	Scenario: Verify place of destination link on check your answers page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	#Then  user verify the business name status 'COMPLETED'
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
	#Then  click on submit sign up

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | EstablishmentName1 | AddressLine2 | estCity | estCountry       | nextPage           | nextPage1                  |
	| test5     | SND NON UK User  	 | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName34     | testAddress1 | SecondEstName      | EastAddr1    | Belfast | Northern Ireland | Check your answers | Add a place of destination |

Scenario: Remove GB establishment on check your answers page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	#Then  user verify the business name status 'COMPLETED'
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
	#Then  verify total '2' establishment addresses added
	When  click on remove link on estblishment '<EstablishmentName1>' on check answers page
	#Then  verify total '1' establishment addresses added

	Examples: 
	| logininfo | Business selection | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | EstablishmentName1 | AddressLine1 | estCity | estCountry | nextPage           | nextPage1               |
	| test7     | Tescoman      	 | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | RemoveEstName35   | testEstNameRemove  | testAddress1 | London  | England    | Check your answers | Add a place of dispatch |


	Scenario: Remove NI establishment on check your answers page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	#Then  user verify the business name status 'COMPLETED'
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
	#Then  verify total '2' establishment addresses added
	When  click on remove link on estblishment '<EstablishmentName1>' on check answers page
	#Then  verify total '1' establishment addresses added

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | EstablishmentName1 | AddressLine1 | estCity | estCountry       | nextPage           | nextPage1                  |
	| test5     | SND NON UK User	 | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | RemoveEstAddress  | testEstRemove      | testAddress1 | Belfast | Northern Ireland | Check your answers | Add a place of destination |


	Scenario: Verify back to dashboard link on Check answers page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	#When  complete Business name task with '<Business name>', '<AddressLine>', '<Town>', '<AddrPostcode>'
	#Then  user verify the business name status 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	Then  user verify the business contact details status 'COMPLETED'
	When  complete contact person Authorised Signatory with Yes Authorisation
    Then  user verify the Authorised Signatory status 'COMPLETED'
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of departure status 'COMPLETED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	When  click on back to dashboard link
	Then  verify next page '<nextPage1>' is loaded

	Examples: 
	| logininfo | Business selection   | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1 |
	| test7     |  Tescoman            | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName37     | testAddress1 | London  | England    | Check your answers | Sign up   |

	
	Scenario: Navigated to 'Selected business' page through the Signup link on check your answer page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	Then  user verify the business contact details status 'COMPLETED'
	When  complete contact person Authorised Signatory with Yes Authorisation
    Then  user verify the Authorised Signatory status 'COMPLETED'
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of departure status 'COMPLETED'
	And   click on Check answers and submit sign up
	And   verify next page '<nextPage>' is loaded 
	And   verify '<Business selection>' selected displayed on Check your answer page
	When  click on Signup another business link
	Then  verify next page '<nextPage1>' is loaded 

	Examples: 
	| logininfo | Business selection | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage           | nextPage1         |
	| test7     | Tescoman           | England | testFBO   | testName      | testAddress | London | SE11 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName40     | testAddress1 | London  | England    | Check your answers | Selected business |
   