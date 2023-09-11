@Regression
Feature: Error Validation Point Of Destination Establishment

Error Validation Point Of Destination Establishment

Scenario: Verify validation error message for blank Destination Establishment postcode field and non NI postcode
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
    When  click on points of destination link
	And   enter Establishment postcode '<postcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | postcode  | errorMessage      |
	| test1A    | Kaka               | Northern Ireland | testFBO   |           | Enter a postcode. |
	| test1A    | Kaka               | Northern Ireland | testFBO   | wd19 7pf  | Enter a postcode in Northern Ireland |

	Scenario: Verify zero  address results  error message for postcode NI
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	And   enter Establishment postcode '<postcode>'
	Then  verify error message '<errorMessage>' on Add a place of destination page
	When  click on back to dashboard link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | postcode | errorMessage | nextPage |
	| test1A    | Kaka               | Northern Ireland | testFBO   | BT11 A11 | 0 results    |   Sign up       |

Scenario: Verify valid error messages for point of Destination mandatory fields
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	And   enter Establishment postcode '<postcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | postcode | EstablishmentName | AddressLine1 | estCity    | estCountry  | AddrPostcode | errorMessage                                     |
	| test1A    |  Kaka              | Northern Ireland | testFBO   | EC4R 9HA |                   | testAddress1 | testCity   | testCountry | SE10 9NF     | Enter an establishment name                      |
	| test1A    |  Kaka              | Northern Ireland | testFBO   | EC4R 9HA | testErrorName1    |              | testCity   | testCountry | SE10 9NF     | Enter address line 1                             |
	| test1A    |  Kaka              | Northern Ireland | testFBO   | EC4R 9HA | testErrorName2    | testAddress1 |            | testCountry | SE10 9NF     | Enter a town or city                             |
	| test1A    |  Kaka			     | Northern Ireland | testFBO   | EC4R 9HA | testErrorName3    | testAddress1 | testCity   | testCountry |              | Enter a postcode                                 |
	| test1A    |  Kaka			     | Northern Ireland | testFBO   | EC4R 9HA | testErrorName4%   | testAddress1 | testCity   | testCountry | SE10 9NF     | Enter establishment name using only letters, numbers, commas, brackets, full stops, underscores, forward slashes, hyphens, apostrophes or ampersands|
	| test1A    |  Kaka			     | Northern Ireland | testFBO   | EC4R 9HA | testErrorName5    | testAddr%$   | testCity   | testCountry | SE10 9NF     | Enter address line 1 using only letters, numbers, commas, brackets, full stops, underscores, forward slashes, hyphens, apostrophes or ampersands    |
	| test1A    |  Kaka			     | Northern Ireland | testFBO   | EC4R 9HA | testErrorName6    | testAddress1 | testCity%$ | testCountry | SE10 9NF     | Enter a town or city using only letters, numbers, commas, brackets, full stops, underscores, forward slashes, hyphens, apostrophes or ampersands    |
	| test1A    |  Kaka			     | Northern Ireland | testFBO   | EC4R 9HA | testErrorName7    | testAddress1 | testCity   | testCountry | SE10 9NF$%   | Enter a real postcode                            |


Scenario: Verify error message on add another point of Destination page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on establishment page
	Examples: 
	| logininfo | Business selection | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity   | estCountry   | AddrPostcode | errorMessage                                            |
	| test1A    | Kaka		         | Northern Ireland | testFBO   | testErrorName8    | testAddress1 | testCity1 | testCountry1 | EC4R 9HA     | Select if you have added all your places of destination |
	
Scenario: Verify duplicate point of destination establishment not allowed
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
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
	| logininfo | Business selection | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity   | estCountry       | AddrPostcode | errorMessage                                                            |
	| test1A    | Kaka   			 | Northern Ireland | testFBO   | testErrorName9    | testAddress1 | testCity1 | Northern Ireland | BT30 6LZ     | This address has already been added as a place of destination - enter a different address |

