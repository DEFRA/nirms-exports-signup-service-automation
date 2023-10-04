@Regression
Feature: ErrorValidationOnPointOfDepartureEstablishment

Error Validation on GB point of Departure Establishment


Scenario: Verify error message for blank Establishment postcode field & non GB post code
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Business selection                         | Country | FBONumber | postcode | errorMessage      |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.  | England | testFBO   |          | Enter a postcode  |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.  | England | testFBO   | BT93 8AD | Enter a postcode in England, Scotland or Wales  |



Scenario: Verify zero address  error message for GB postcode
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	Then  verify error message '<errorMessage>' on Add a place of departure page
	When  click on back link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Business selection                        | Country | FBONumber | postcode | errorMessage											   | nextPage    |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | TE1 3DS  | 0 results for TE1 3DS in England, Scotland and Wales    | of dispatch |


Scenario: Verify error messages for GB point of Departure mandatory fields
	Given Clear Database for user '<logininfo>'
	And that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link	
	And   enter Establishment postcode '<postcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Business selection                                  | Country | FBONumber | postcode | EstablishmentName | AddressLine1 | estCity    | estCountry  | AddrPostcode | errorMessage                                     |
	| test      |	 ABC ACCOUNTANCY & MARKETING SERVICES LTD.        | England | testFBO   | SE10 9NF |                   | testAddress1 | testCity   | testCountry | SE10 9NF     | Enter an establishment name                      |
	| test      |    ABC ACCOUNTANCY & MARKETING SERVICES LTD.		  | England | testFBO   | SE10 9NF | testErrorName1    |              | testCity   | testCountry | SE10 9NF     | Enter address line 1                             |
	| test      |    ABC ACCOUNTANCY & MARKETING SERVICES LTD.        | England | testFBO   | SE10 9NF | testErrorName2    | testAddress1 |            | testCountry | SE10 9NF     | Enter a town or city                             |
	| test      |    ABC ACCOUNTANCY & MARKETING SERVICES LTD.		  | England | testFBO   | SE10 9NF | testErrorName3    | testAddress1 | testCity   | testCountry |              | Enter a postcode                                 |
	| test      |    ABC ACCOUNTANCY & MARKETING SERVICES LTD.        | England | testFBO   | SE10 9NF | testErrorName4$%  | testAddress1 | testCity   | testCountry | SE10 9NF     | Enter establishment name using only letters, numbers, brackets, full stops, underscores, forward slashes, hyphens, apostrophes or ampersands |
	| test      |    ABC ACCOUNTANCY & MARKETING SERVICES LTD.		  | England | testFBO   | SE10 9NF | testErrorName5    | testAddr%$   | testCity   | testCountry | SE10 9NF     | Enter address line 1 using only letters, numbers, brackets, full stops, underscores, forward slashes, hyphens, apostrophes or ampersands     |
	| test      |    ABC ACCOUNTANCY & MARKETING SERVICES LTD.        | England | testFBO   | SE10 9NF | testErrorName6    | testAddress1 | testCity%$ | testCountry | SE10 9NF     | Enter a town or city using only letters, numbers, brackets, full stops, underscores, forward slashes, hyphens, apostrophes or ampersands     |
	| test      |    ABC ACCOUNTANCY & MARKETING SERVICES LTD.        | England | testFBO   | SE10 9NF | testErrorName7    | testAddress1 | testCity   | testCountry | testCode$%   | Enter a real postcode                            |


	
	Scenario:Verify the error GB Point of Departure Establishment Contact Email Address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'testcom'
	Then  verify error message '<errorMessage>' on  add a departure page

	Examples: 
	| logininfo | Business selection                          | Country | FBONumber | EstablishmentName | AddressLine1 | estCity   | estCountry   | AddrPostcode | errorMessage                                                        |
	| test      |  ABC ACCOUNTANCY & MARKETING SERVICES LTD.  | England | testFBO   | testErrorName8    | testAddress1 | testCity1 | testCountry1 | SE10 9NF     | Enter an email address in the correct format, like name@example.com |

Scenario: Verify duplicate point of dispatch establishment not allowed 
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on add another establishment address
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
    Then  verify duplicate establishment error message '<errorMessage>'
	Examples: 
	| logininfo | Business selection                          | Country | FBONumber | EstablishmentName | AddressLine1 | estCity | estCountry | AddrPostcode | errorMessage                                                            |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.   | England | testFBO   | testErrorName9    | testAddress1 | London  | England    | SE10 9NF     | This address has already been added as a place of dispatch - enter a different address |
