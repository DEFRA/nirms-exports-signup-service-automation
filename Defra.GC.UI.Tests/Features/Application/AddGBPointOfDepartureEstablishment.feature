@Regression
Feature: AddGBPointOfDepartureEstablishment

Add GB point of Departure Establishment

Scenario: Check Add the establishment address manually link
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	And   verify Add a point of departure Page loaded
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | postcode | nextPage                 |
	| test      | testcode | Add a point of departure |

Scenario: Add GB point of Departure establishment address manually
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	And   verify Add a point of departure Page loaded
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   Add GB point of Departure establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<City>', '<AddrPostcode>'
	And   verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | postcode | nextPage                 | EstablishmentName | AddressLine1 | City     | AddrPostcode |
	| test      | testCode | Add a point of departure | testName          | testAddress1 | testCity | testCode1    |


Scenario: Verify error message for blank Establishment postcode field
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	And   verify error message '<errorMessage>' on Add a point of departure page

	Examples: 
	| logininfo | postcode | errorMessage      |
	| test      |          | Enter a postcode. |

Scenario: Verify back link on enter establishment postcode page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  click on points of departure link
	And   click on back link
	And   verify signUp task list page is loaded

	Examples: 
	| logininfo |
	| test      |

Scenario: Verify back link on select establishment address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	And   verify Add a point of departure Page loaded
	And   click on back link
	And   verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | postcode | nextPage                 |
	| test      | testCode | Add a point of departure |

Scenario: Verify back link on add establishment address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	And   verify Add a point of departure Page loaded
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   click on back link
	And   verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | postcode | nextPage                 |
	| test      | testCode | Add a point of departure |

Scenario: Verify error messages for GB point of Departure mandatory fields
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	And   verify Add a point of departure Page loaded
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   Add GB point of Departure establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<City>', '<Country>', '<AddrPostcode>'
	And   verify error message '<errorMessage>' on Add a point of departure page

	Examples: 
	| logininfo | postcode | EstablishmentName | AddressLine1 | City       | Country     | AddrPostcode  | errorMessage                                     |
	| test      | testcode |                   | testAddress1 | testCity   | testCountry | testCode      | Enter establishment name                         |
	| test      | testcode | testName          |              | testCity   | testCountry | testCode      | Enter address line 1                             |
	| test      | testcode | testName          | testAddress1 |            | testCountry | testCode      | Enter a town or city                             |
	| test      | testcode | testName          | testAddress1 | testCity   | testCountry |               | Enter a post code                                |
	| test      | testcode | testName$%        | testAddress1 | testCity   | testCountry | testCode      | Enter establishment name using only letters      |
	| test      | testcode | testName          | testAddr%$   | testCity   | testCountry | testCode      | Enter address line 1 using only letters, numbers |
	| test      | testcode | testName          | testAddress1 | testCity%$ | testCountry | testCode      | Enter a town or city using only letters, numbers |
	| test      | testcode | testName          | testAddress1 | testCity   | testCountry | testCode$%    | Enter a real postcode.                           |