@Regression 
Feature: ErrorValidationOnPointOfDepartureEstablishment

Error Validation on GB point of Departure Establishment

Scenario: Verify error message for blank Establishment postcode field
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	#And   enter Establishment postcode '<postcode>'
	#Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Business selection | Country | FBONumber | postcode | errorMessage      |
	| test      | ACME Ltd           | England | testFBO   |          | Enter a postcode. |

Scenario: Verify error messages for GB point of Departure mandatory fields
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link	
	#And   enter Establishment postcode '<postcode>'
	#And   click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Business selection  | Country | FBONumber | postcode | EstablishmentName | AddressLine1 | estCity    | estCountry  | AddrPostcode | errorMessage                                     |
	| test      |	 ACME Ltd         | England | testFBO   | SE10 9NF |                   | testAddress1 | testCity   | testCountry | SE10 9NF     | Enter establishment name                         |
	| test      |    ACME Ltd		  | England | testFBO   | SE10 9NF | testName          |              | testCity   | testCountry | SE10 9NF     | Enter address line 1                             |
	| test      |    ACME Ltd         | England | testFBO   | SE10 9NF | testName          | testAddress1 |            | testCountry | SE10 9NF     | Enter a town or city                             |
	| test      |    ACME Ltd		  | England | testFBO   | SE10 9NF | testName          | testAddress1 | testCity   | testCountry |              | Enter a post code                                |
	| test      |    ACME Ltd         | England | testFBO   | SE10 9NF | testName$%        | testAddress1 | testCity   | testCountry | SE10 9NF     | Enter establishment name using only letters      |
	| test      |    ACME Ltd		  | England | testFBO   | SE10 9NF | testName          | testAddr%$   | testCity   | testCountry | SE10 9NF     | Enter address line 1 using only letters, numbers |
	| test      |    ACME Ltd         | England | testFBO   | SE10 9NF | testName          | testAddress1 | testCity%$ | testCountry | SE10 9NF     | Enter a town or city using only letters, numbers |
	| test      |    ACME Ltd        | England | testFBO   | SE10 9NF | testName          | testAddress1 | testCity   | testCountry | testCode$%   | Enter a real postcode.                           |

Scenario:Verify the error GB Point of Departure Establishment Contact Email Address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	#And   enter Establishment postcode '<AddrPostcode>'
	#And   click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'testcom'
	Then  verify error message '<errorMessage>' on  add a departure page

	Examples: 
	| logininfo | Business selection  | Country | FBONumber | EstablishmentName | AddressLine1 | estCity   | estCountry   | AddrPostcode | errorMessage                                                        |
	| test      |  ACME Ltd			  | England | testFBO   | testName1         | testAddress1 | testCity1 | testCountry1 | SE10 9NF     | Enter an email address in the correct format, like name@example.com |

Scenario: Verify duplicate point of dispatch establishment not allowed 
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
#	And   enter Establishment postcode '<AddrPostcode>'
#	And   click on cannot find establishment link 
#	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on add another establishment address
#	And   enter Establishment postcode '<AddrPostcode2>'
#	And   click on cannot find establishment link 
#	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
    Then  verify duplicate establishment error message '<errorMessage>'
	Examples: 
	| logininfo | Business selection  | Country | FBONumber | EstablishmentName | AddressLine1 | estCity | estCountry | AddrPostcode | errorMessage                                                            |
	| test      |  ACME Ltd			  | England | testFBO   | testName1         | testAddress1 | London  | England    | SE10 9NF     | The entered establishment address is a duplicate of one already entered |
