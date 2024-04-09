   @SmokeTest 
Feature: SusSmokeTesting 

Sus Smoke Testing 

Scenario: Add Authorised Signatory and navigated to tasklist page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
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
	When  click on Authorised Signatory link
	And   select 'Yes' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection  | Country | FBONumber | nextPage                | contactName     | contactPosition | emailAddress  | telephoneNumber |
	| test      | TestEnv1            | England | testFBO   | Add a place of dispatch | testContactName | testPosition    | test@test.com | 01632 960 001   |


Scenario: Add Authorised Signatory Email Address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	When  user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	When  user is on Authorised Signatory Email address page
	Then  verify dynamic name '<fullName>' in title '<nextPage1>' of page 
    Then  user enters manually '<emailAddress>' in email address page
    And   click Save and return to dashboard
	And   verify next page '<nextPage>' is loaded 

	
	Examples: 
	| logininfo | Business selection   | Country | FBONumber | nextPage  | fullName  | contactName | contactPosition | emailAddress  | telephoneNumber | Authposition |nextPage1     |
	| test      | TestEnv1             | England | testFBO   | Sign up   | test name | test name   | test            | test@gmail.com  | 01632 960 001 | administrator|email address |


Scenario: Add Authorised Signatory name
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	Then  verify dynamic name '<Business selection>' in title '<nextPage>' of page 
	When  user is on Authorised Signatory Enter name page
	And   user enters manually '<fullName>' in the full name feild
	And   click on save and continue
	Then  verify dynamic name '<Business selection>' in title '<nextPage1>' of page 
	And   verify dynamic name '<contactName>' in title '<nextPage1>' of page 

	
	Examples: 
	| logininfo | Business selection  | Country | FBONumber | nextPage1|nextPage					   | fullName  | contactName | contactPosition | emailAddress   | telephoneNumber |
	| test      | TestEnv1            | England | testFBO   | position |authorised representative      | test name | test name   | test            | test@gmail.com | 01632 960 001   |


Scenario: Add Authorised Signatory position
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	And   user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  verify dynamic name '<Business selection>' in title '<nextPage1>' of page 
	Then  verify dynamic name '<fullName>' in title '<nextPage1>' of page 
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	Then  verify dynamic name '<fullName>' in title '<nextPage>' of page 

	Examples: 
	| logininfo | Business selection  | Country | FBONumber | contactName     | contactPosition | fullName  | Authposition  | nextPage      | emailAddress   | telephoneNumber | nextPage1 |
	| test      | TestEnv1            | England | testFBO   | testContactName | testPosition    | test Name | administrator | email address | test@gmail.com | 01632 960 001   | position  |


Scenario: Add contact email address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	When  click on save and continue
	Then  verify dynamic name '<contactName>' in title '<nextPage>' of page 

	Examples: 
	| logininfo | Business selection      | Country | FBONumber | contactName     | contactPosition | emailAddress  | nextPage         |
	| test      | TestEnv1                | England | testFBO   | testContactName | testPosition    | test@test.com | telephone number |


Scenario: Add business contact name
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	Then  verify dynamic name '<Business selection>' in title '<nextPage>' of page 
	Then  verify dynamic name '<Business selection>' in hint text
	And   enter business contact person '<contactName>'
	And   click on save and continue
	Then  verify dynamic name '<Business selection>' in title '<nextPage1>' of page 
	Then  verify dynamic name '<contactName>' in title '<nextPage1>' of page 

	Examples: 
	| logininfo | Business selection        | Country | FBONumber | contactName | nextPage1| nextPage | 
	| test2     | AMSAK PROPERTY LIMITED    | England | testFBO   | testName    | position | contact  |


Scenario: Verify save and return to dashboard on business contact name page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection              | Country | FBONumber | nextPage | contactName     |
	| test2     | AMSAK PROPERTY LIMITED          | England | testFBO   | Sign up  | testcontactName |


Scenario: Add business contact position
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	Then  verify dynamic name '<contactName>' in title '<nextPage>' of page 

	Examples: 
	| logininfo | Business selection                  | Country | FBONumber | contactName     | contactPosition | nextPage      |
	| test4     | NORTH WEST TELUGU SANGAM            | England | testFBO   | testContactName | testPosition    | email address |


Scenario: Add contact Telephone Number
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click Save and return to dashboard
	Then  user verify the business contact details status 'COMPLETED'

	Examples: 
	| logininfo |  Business selection      | Country | FBONumber | contactName     | contactPosition | emailAddress  | telephoneNumber | nextPage |
	| test      |  TestEnv1                | England | testFBO   | testContactName | testPosition    | test@test.com | 01632 960 001   | Sign up  |


Scenario Outline: Complete eligibility task
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'

	Examples:
    | logininfo | Country | Business selection  |
    | test      | England | TestEnv1            |


Scenario Outline: Verify dynamic business name on SPS Assurance page for FBO PHR number
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify dynamic name '<Business selection>' on eligibility task on SPS Assurance page with '<Country>'

	Examples:
    | logininfo | Country | FBONumber | Business selection     |
    | test      | England | testFBO   | TestEnv1               |


Scenario: Add Another GB point of Departure establishment address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on add another establishment address
	And   enter Establishment postcode '<AddrPostcode2>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	And   add establishment email address 'test2@test.com'
	Then  verify more than 1 establishment addresses added
	And   verify message for '<Business selection>' on establishment page
	When  click on I have finished adding points of departure
	And   click on save and continue
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection | Country | FBONumber | EstablishmentName | AddressLine1 | estCity | estCountry | AddrPostcode | EstablishmentName2 | AddressLine2 | estCity2  | estCountry2 | AddrPostcode2 | nextPage |
	| test      | TestEnv1           | England | testFBO   | testName1         | testAddress5 | London  | England    | SE10 9NF     | testName6          | testAddress  | Liverpool | England     | L1 0AN        | Sign up  |


Scenario: Finish adding point of Destination establishment address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on points of destination link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   verify message for '<Business selection>' on establishment page
	And   click on I have finished adding points of departure
	And   click on save and continue
	Then  verify next page '<nextPage>' is loaded 
	Examples: 
	| logininfo | Business selection   | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity         | estCountry       | AddrPostcode | nextPage |
	| test1A    | TestEnv2             | Northern Ireland | testFBO   | Coleraine1        | testAddress1 | Crown Buildings | Northern Ireland | BT52 2AJ     | Sign up  |

		@CrossBrowser
Scenario: Check answers and submit sign up link verification on GB points of establishment with save and continue
	Given Clear Database for user '<logininfo>'
	Given   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>' with save and continue
	Then  verify next page '<nextPage2>' is loaded 
	When  complete contact person Authorised Signatory with Yes Authorisation with save and continue
	Then  verify next page '<nextPage3>' is loaded 
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>' with save and continue
	Then  verify next page '<nextPage4>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage5>' is loaded
    When  click on the confirm check box on Terms and conditions page
	And   click on submit sign up
	Then  verify next page '<nextPage6>' is loaded

	Examples: 
	| logininfo | Business selection       | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage1                 | nextPage2                     | nextPage3   | nextPage4          | nextPage5            | nextPage6                                                                              |
	| test      | TestEnv1                 | England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName1      | testAddress1 | London  | England    | Who is the contact person | the authorised representative | of dispatch | Check your answers | Terms and conditions | You have successfully submitted a request to sign up for the NI Retail Movement Scheme |


		@CrossBrowser 
Scenario: Check answers and submit sign up link verification on NI points of establishment with save and continue
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>' with save and continue
	Then  verify next page '<nextPage2>' is loaded 
	When  complete contact person Authorised Signatory with Yes Authorisation with save and continue
	Then  verify next page '<nextPage3>' is loaded 
	When  complete Points of destination with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>' with save and continue
	Then  verify next page '<nextPage4>' is loaded 
	When  click on continue button
	Then  verify next page '<nextPage5>' is loaded
	When  click on the confirm check box on Terms and conditions page
	And   click on submit sign up
	Then  verify next page '<nextPage6>' is loaded

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | Business name | AddressLine | Town    | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry       | nextPage1                 | nextPage2                     | nextPage3      | nextPage4          | nextPage5            | nextPage6                                                                                            |
	| test1A    | TestEnv2           | Northern Ireland | testFBO   | testName      | testAddress | Belfast | BT29 4AB     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName2      | testAddress1 | Belfast | Northern Ireland | Who is the contact person | the authorised representative | of destination | Check your answers | Terms and conditions | You have successfully submitted a request to sign up for the Northern Ireland Retail Movement Scheme |

