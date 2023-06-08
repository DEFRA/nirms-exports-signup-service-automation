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

Scenario: Verify error messages for GB point of Departure mandatory fields
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	And   verify Add a point of departure Page loaded
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   Add GB point of Departure establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<City>', '<AddrPostcode>'
	And   verify error message '<errorMessage>' on Add a point of departure page

	Examples: 
	| logininfo | postcode | EstablishmentName | AddressLine1 | City     | AddrPostcode | errorMessage             |
	| test      | testcode |                   | testAddress1 | testCity | testCode     | Enter establishment name |
	| test      | testcode | testName          |              | testCity | testCode     | Enter address line 1     |
	| test      | testcode | testName          | testAddress1 |          | testCode     | Enter a town or city     |
	| test      | testcode | testName          | testAddress1 | testCity |              | Enter a post code        |