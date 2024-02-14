@SelfServeRegression
Feature: AddPlaceOfDestination

Add Place of Destination

Background: 
	Given Clear Database for user 'test1C'
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo 'test1C'
	And   select business to sign up 'TestEnv3'
	And   complete eligibility task with 'Northern Ireland'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name 'TestEnv3'
	When  click on FBOorPHRNumber task
	And   enter FBO number 'testFBO' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	And   user verify the business contact details status 'NOT STARTED'
    And   user verify the Authorised Signatory status 'CANNOT START YET'
    And   user verify the Points of destination status 'NOT STARTED'
	And   verify Check answers and submit sign up status 'CANNOT START YET'
	When  complete Business contact details task with 'contactName', 'contactPosition', 'test@test.com', '01234 234 455'
	Then  user verify the business contact details status 'COMPLETED'
    And   user verify the Authorised Signatory status 'NOT STARTED'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of destination with 'EstablishmentName', 'AddressLine1', 'London', 'England', 'BT1 1HS'
	Then  user verify the Points of destination status '1 ADDED'
	And   click on Check answers and submit sign up
	And   verify next page 'Check your answers' is loaded 
	When  click on continue button
	Then  verify next page 'Terms and conditions' is loaded
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up
	Then  verify  'You have successfully submitted a request to sign up for the Northern Ireland Retail Movement Scheme' on completed sign up page
	Then  verify  'We will review your sign-up request and email you with the outcome within 5 working days.' outcome of my request submission page
	Then  click on signout button and verify the signout message
	Given Approve Sign up request for org 'TestEnv3'


	Scenario: Verify back link on Place Of Destination page
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
	And   click on link 'Add a place of destination'
	Then  verify next page '<nextPage>' is loaded
	And   verify dynamic name '<Business selection>' in warning text '<warningText>' on establishment page 
	When  click on back link
	Then  verify dynamic name '<Business selection>' in title '<PageTitle>' of page
	When  click on link 'Add a place of destination'
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on back link
	Then  verify next page '<nextPage>' is loaded
	And   enter Establishment postcode '<AddrPostcode>'
	When  click on change link next to Establishment postcode
	Then  verify next page '<nextPage>' is loaded
	When  enter Establishment postcode '<AddrPostcode2>'
	Then  verify establishment postcode changed to '<AddrPostcode2>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   click on back link
	Then  verify next page '<nextPage>' is loaded
	When  enter Establishment postcode '<AddrPostcode2>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on change establishment address '<EstablishmentName>'
	And   verify add establishment address manually page loaded
	And   add establishment address manually with fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	And   add establishment email address 'test2@test.com'
	And   verify changed establishment address fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	And   click on back link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Business selection | PageTitle                               | nextPage                   | warningText                                  | EstablishmentName | AddressLine1 | estCity   | estCountry       | AddrPostcode | EstablishmentName2 | AddressLine2 | estCity2  | estCountry2      | AddrPostcode2 |
	| test1C    | TestEnv3           | Northern Ireland Retail Movement Scheme | Add a place of destination | You do not need to add an establishment that | testName11        | testAddress1 | testCity1 | Northern Ireland | BT30 6LZ     | testName12         | testAddress2 | testCity2 | Northern Ireland | BT52 2AJ      |


Scenario: Verify zero results page on Place Of Destination page
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
	And   click on link 'Add a place of destination'
	And   enter Establishment postcode '<AddrPostcode>'
	Then  verify error message '<errorMessage>' on Add a place of departure page
	And   click on back link
	Then  verify next page '<nextPage>' is loaded
	When  enter Establishment postcode '<AddrPostcode>'
	And   click on a different postcode error link
	Then  verify next page '<nextPage>' is loaded
	When  enter Establishment postcode '<AddrPostcode>'
	And   click on the add establishment address manually link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Business selection | nextPage                   | AddrPostcode | errorMessage |
	| test1C    | TestEnv3           | Add a place of destination | BT43 4TT     | 0 results    |


Scenario: Verify error messages for place of destination mandatory fields
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on link 'Add a place of destination'
	And   enter Establishment postcode '<postcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Business selection   | postcode | EstablishmentName | AddressLine1 | estCity    | estCountry  | AddrPostcode | errorMessage                                     |
	| test1C    |	 TestEnv3       | BT93 8AD |                   | testAddress1 | testCity   | testCountry | BT93 8AD     | Enter an establishment name                      |
	| test1C    |    TestEnv3	    | BT93 8AD | testErrorName1    |              | testCity   | testCountry | BT93 8AD     | Enter address line 1                             |
	| test1C    |    TestEnv3       | BT93 8AD | testErrorName2    | testAddress1 |            | testCountry | BT93 8AD     | Enter a town or city                             |
	| test1C    |    TestEnv3		| BT93 8AD | testErrorName3    | testAddress1 | testCity   | testCountry |              | Enter a postcode                                 |
	| test1C    |    TestEnv3       | BT93 8AD | testErrorName4$%  | testAddress1 | testCity   | testCountry | BT93 8AD     | Enter an establishment name using only letters, numbers, brackets, full stops, hyphens, underscores, forward slashes, apostrophes or ampersands |
	| test1C    |    TestEnv3		| BT93 8AD | testErrorName5    | testAddr%$   | testCity   | testCountry | BT93 8AD     | Enter address line 1 using only letters, numbers, brackets, full stops, hyphens, underscores, forward slashes, apostrophes or ampersands     |
	| test1C    |    TestEnv3       | BT93 8AD | testErrorName6    | testAddress1 | testCity%$ | testCountry | BT93 8AD     | Enter a town or city using only letters, numbers, brackets, full stops, hyphens, underscores, forward slashes, apostrophes or ampersands     |
	| test1C    |    TestEnv3       | BT93 8AD | testErrorName7    | testAddress1 | testCity   | testCountry | BT93 8AD$%   | Enter a real postcode                            |


Scenario: Verify validation error message for blank Destination Establishment postcode field and non NI postcode
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on link 'Add a place of destination'
	And   enter Establishment postcode '<postcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Business selection | postcode  | errorMessage      |
	| test1C    | TestEnv3           |           | Enter a postcode. |
	| test1C    | TestEnv3           | wd19 7pf  | Enter a postcode in Northern Ireland |