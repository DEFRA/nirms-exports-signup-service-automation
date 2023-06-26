@Regression 
Feature: ErrorValidationOnPointOfDepartureEstablishment

Error Validation on GB point of Departure Establishment

Scenario: Verify error message for blank Establishment postcode field
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Country | FBONumber |postcode | errorMessage      |
	| test      | England | testFBO   |         | Enter a postcode. |

Scenario: Verify error messages for GB point of Departure mandatory fields
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link	
	And   enter Establishment postcode '<postcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Country | FBONumber |postcode | EstablishmentName | AddressLine1 | estCity    | estCountry  | AddrPostcode  | errorMessage                                     |
	| test      | England | testFBO   |SE10 9NF |                   | testAddress1 | testCity   | testCountry | SE10 9NF      | Enter establishment name                         |
	| test      | England | testFBO   |SE10 9NF | testName          |              | testCity   | testCountry | SE10 9NF      | Enter address line 1                             |
	| test      | England | testFBO   |SE10 9NF | testName          | testAddress1 |            | testCountry | SE10 9NF      | Enter a town or city                             |
	| test      | England | testFBO   |SE10 9NF | testName          | testAddress1 | testCity   | testCountry |               | Enter a post code                                |
	| test      | England | testFBO   |SE10 9NF | testName$%        | testAddress1 | testCity   | testCountry | SE10 9NF      | Enter establishment name using only letters      |
	| test      | England | testFBO   |SE10 9NF | testName          | testAddr%$   | testCity   | testCountry | SE10 9NF      | Enter address line 1 using only letters, numbers |
	| test      | England | testFBO   |SE10 9NF | testName          | testAddress1 | testCity%$ | testCountry | SE10 9NF      | Enter a town or city using only letters, numbers |
	| test      | England | testFBO   |SE10 9NF | testName          | testAddress1 | testCity   | testCountry | testCode$%    | Enter a real postcode.                           |

