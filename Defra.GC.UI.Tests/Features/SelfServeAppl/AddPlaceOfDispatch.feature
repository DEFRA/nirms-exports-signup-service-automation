@SelfServeRegression 
Feature: AddPlaceOfDispatch

Add Place of Dispatch

 
Background: 
	Given Clear Database for user 'test1C'
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo 'test1C'
	And   select business to sign up 'TestEnv3'
	And   complete eligibility task with 'England'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name 'TestEnv3'
	When  click on FBOorPHRNumber task
	And   enter FBO number 'testFBO' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	And   user verify the business contact details status 'NOT STARTED'
    And   user verify the Authorised Signatory status 'CANNOT START YET'
    And   user verify the Points of departure status 'NOT STARTED'
	And   verify Check answers and submit sign up status 'CANNOT START YET'
	When  complete Business contact details task with 'contactName', 'contactPosition', 'test@test.com', '01234 234 455'
	Then  user verify the business contact details status 'COMPLETED'
    And   user verify the Authorised Signatory status 'NOT STARTED'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of departure with 'EstablishmentName', 'AddressLine1', 'London', 'England', 'NW1 5LR'
	Then  user verify the Points of departure status '1 ADDED'
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

   @RunOnly
Scenario: Verify remove establishment scenario and back link on Place Of Dispatch page
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
	And   click on link 'Add a place of dispatch'
	Then  verify next page '<nextPage>' is loaded
	And   verify dynamic name '<Business selection>' in warning text '<warningText>' on establishment page 
	When  click on back link
	Then  verify dynamic name '<Business selection>' in title '<PageTitle>' of page
	When  click on link 'Add a place of dispatch'
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
	And   click on back link
	And   click on back link
	And   click on back link
	Then  verify next page '<nextPage>' is loaded
	When  enter Establishment postcode '<AddrPostcode3>'
	And   click on select address button
	Then  verify next page '<nextPage>' is loaded
	When  click on save and continue
	Then  verify next page '<nextPage>' is loaded
	When  click on save and continue
	Then  verify next page '<nextPage>' is loaded
	When  click on continue button
	Then  verify next page '<PageTitle2>' is loaded
	When  click on button 'Add place of dispatch'
	Then  verify next page '<PageTitle3>' is loaded
	When  click on back to dashboard link
	Then  verify next page '<PageTitle>' is loaded
	When  click on establishment '<EstablishmentName>'
	Then  verify next page '<PageTitle4>' is loaded
	Then  click on remove establishment button on establishment details page
	Then  verify next page '<PageTitle5>' is loaded
	When  click on button 'Remove place of dispatch'
	Then  verify next page '<PageTitle6>' is loaded
	Then  verify text '<RemovedText>' on removed establishment page

	Examples: 
	| logininfo | Business selection | PageTitle                               | nextPage                | warningText                                  | PageTitle2                                                  | PageTitle3                           | EstablishmentName | AddressLine1 | estCity | estCountry | AddrPostcode | EstablishmentName2 | AddressLine2 | estCity2  | estCountry2 | AddrPostcode2 | AddrPostcode3 |PageTitle4 |PageTitle5                     |PageTitle6 |RemovedText                                                |
	| test1C    | TestEnv3           | Northern Ireland Retail Movement Scheme | Add a place of dispatch | You do not need to add an establishment that | Requirements of the Northern Ireland Retail Movement Scheme | Place of dispatch successfully added | testName11        | testAddress1 | London  | England    | SE10 9NF     | testName12         | testAddress2 | Liverpool | England     | L1 0AN        | SE10 9GB      |testName11 |Are you sure you want to remove|removed    |This establishment will not be available to add as a place |


Scenario: Verify zero results page on Place Of Dispatch page
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
	And   click on link 'Add a place of dispatch'
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
	| logininfo | Business selection | nextPage                | AddrPostcode | errorMessage |
	| test1C    | TestEnv3           | Add a place of dispatch | SE9 1EE      | 0 results    |


Scenario: Verify error messages for place of dispatch mandatory fields
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on link 'Add a place of dispatch'
	And   enter Establishment postcode '<postcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Business selection   | postcode | EstablishmentName | AddressLine1 | estCity    | estCountry  | AddrPostcode | errorMessage                                     |
	| test1C      |	   TestEnv3        | SE10 9NF |                   | testAddress1 | testCity   | testCountry | SE10 9NF     | Enter an establishment name                      |
	| test1C      |    TestEnv3		   | SE10 9NF | testErrorName1    |              | testCity   | testCountry | SE10 9NF     | Enter address line 1                             |
	| test1C      |    TestEnv3        | SE10 9NF | testErrorName2    | testAddress1 |            | testCountry | SE10 9NF     | Enter a town or city                             |
	| test1C      |    TestEnv3		   | SE10 9NF | testErrorName3    | testAddress1 | testCity   | testCountry |              | Enter a postcode                                 |
	| test1C      |    TestEnv3        | SE10 9NF | testErrorName4$%  | testAddress1 | testCity   | testCountry | SE10 9NF     | Enter an establishment name using only letters, numbers, brackets, full stops, hyphens, underscores, forward slashes, apostrophes or ampersands |
	| test1C      |    TestEnv3		   | SE10 9NF | testErrorName5    | testAddr%$   | testCity   | testCountry | SE10 9NF     | Enter address line 1 using only letters, numbers, brackets, full stops, hyphens, underscores, forward slashes, apostrophes or ampersands     |
	| test1C      |    TestEnv3        | SE10 9NF | testErrorName6    | testAddress1 | testCity%$ | testCountry | SE10 9NF     | Enter a town or city using only letters, numbers, brackets, full stops, hyphens, underscores, forward slashes, apostrophes or ampersands     |
	| test1C      |    TestEnv3        | SE10 9NF | testErrorName7    | testAddress1 | testCity   | testCountry | testCode$%   | Enter a real postcode                            |


Scenario: Verify error message for blank Establishment postcode field & non GB post code
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on link 'Add a place of dispatch'
	And   enter Establishment postcode '<postcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Business selection | postcode  | errorMessage      |
	| test1C    | TestEnv3           |           | Enter a postcode. |
	| test1C    | TestEnv3           | BT93 8AD  | Enter a postcode in England, Scotland or Wales |