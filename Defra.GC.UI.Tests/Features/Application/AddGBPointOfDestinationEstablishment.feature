@Regression
Feature: AddGBPointOfDestinationEstablishment

Add GB point of Destination Establishment

Scenario: Check Add the Destination establishment address manually link
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination  link
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	When  click on cannot find establishment link 
	And   click on the add establishment address manually link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |postcode | nextPage                 |
	| test      | England | testFBO   |testcode | Add a point of destination  |

Scenario: Add GB point of Destination establishment address manually
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination  link
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	When  click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |postcode | nextPage                 | EstablishmentName | AddressLine1 | estCity  | estCountry | AddrPostcode |
	| test      | England | testFBO   |testCode | Add a point of destination (optional) | testName          | testAddress1 | testCity | testCountry| testCode1    |


Scenario: Verify error message for blank  Destination Establishment postcode field
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
    When  click on points of destination  link
	And   enter Establishment postcode '<postcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Country | FBONumber |postcode | errorMessage      |
	| test      | England | testFBO   |         | Enter a postcode. |

Scenario: Verify back link on enter  Destination establishment postcode page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination  link
	And   click on back link
	Then  verify signUp task list page is loaded

	Examples: 
	| logininfo |Country | FBONumber |
	| test      |England | testFBO   |

Scenario: Verify back link on select Destination establishment address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
    When  click on points of destination  link 	
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	When  click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |postcode | nextPage                 |
	| test      | England | testFBO   |testCode | Add a point of destination (optional) |

Scenario: Verify back link on add Destination  establishment address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination  link
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	When  click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |postcode | nextPage                 |
	| test      | England | testFBO   |testCode | Add a point of destination (optional) |

Scenario: Verify error messages for GB point of Destination mandatory fields
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination  link
	And   enter Establishment postcode '<postcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Country | FBONumber |postcode | EstablishmentName | AddressLine1 | estCity    | estCountry  | AddrPostcode  | errorMessage                                     |
	| test      | England | testFBO   |testcode |                   | testAddress1 | testCity   | testCountry | testCode      | Enter establishment name                         |
	| test      | England | testFBO   |testcode | testName          |              | testCity   | testCountry | testCode      | Enter address line 1                             |
	| test      | England | testFBO   |testcode | testName          | testAddress1 |            | testCountry | testCode      | Enter a town or city                             |
	| test      | England | testFBO   |testcode | testName          | testAddress1 | testCity   | testCountry |               | Enter a post code                                |
	| test      | England | testFBO   |testcode | testName$%        | testAddress1 | testCity   | testCountry | testCode      | Enter establishment name using only letters      |
	| test      | England | testFBO   |testcode | testName          | testAddr%$   | testCity   | testCountry | testCode      | Enter address line 1 using only letters, numbers |
	| test      | England | testFBO   |testcode | testName          | testAddress1 | testCity%$ | testCountry | testCode      | Enter a town or city using only letters, numbers |
	| test      | England | testFBO   |testcode | testName          | testAddress1 | testCity   | testCountry | testCode$%    | Enter a real postcode.                           |