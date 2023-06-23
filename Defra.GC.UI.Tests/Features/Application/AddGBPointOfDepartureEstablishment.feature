@Regression
Feature: AddGBPointOfDepartureEstablishment

Add GB point of Departure Establishment

@CrossBrowser
Scenario: Check Add the establishment address manually link
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	When  click on cannot find establishment link 
	And   click on the add establishment address manually link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |postcode | nextPage                 |
	| test      | England | testFBO   |SE10 9NF | Add a point of departure |

Scenario: Add GB point of Departure establishment address manually
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	When  click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |postcode | nextPage                 | EstablishmentName | AddressLine1 | estCity  | estCountry | AddrPostcode |
	| test      | England | testFBO   |SE10 9NF | Add a point of departure | testName          | testAddress1 | testCity | testCountry| SE10 9NF     |


Scenario: Verify error message for blank Establishment postcode field
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Country | FBONumber |postcode | errorMessage      |
	| test      | England | testFBO   |         | Enter a postcode. |

Scenario: Verify back link on enter establishment postcode page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   click on back link
	Then  verify signUp task list page is loaded

	Examples: 
	| logininfo |Country | FBONumber |
	| test      |England | testFBO   |

Scenario: Verify back link on select establishment address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link	
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	When  click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |postcode | nextPage                 |
	| test      | England | testFBO   |SE10 9NF | Add a point of departure |

Scenario: Verify back link on add establishment address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link	
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	When  click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |postcode | nextPage                 |
	| test      | England | testFBO   |SE10 9NF | Add a point of departure |

Scenario: Verify error messages for GB point of Departure mandatory fields
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
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

Scenario: Add Another GB point of Departure establishment address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
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
	Examples: 
	| logininfo | Country | FBONumber |EstablishmentName | AddressLine1 | estCity  | estCountry  | AddrPostcode |EstablishmentName2 | AddressLine2 | estCity2  | estCountry2 | AddrPostcode2 |
	| test      | England | testFBO   |testName1         | testAddress1 | testCity1| testCountry1| SE10 9NF     |testName2          | testAddress2 | testCity2 | testCountry2| EC4R 9HA      |

Scenario: Finish adding GB point of Departure establishment address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on I have finished adding points of departure
	Then  verify signUp task list page is loaded
	Examples: 
	| logininfo | Country | FBONumber |EstablishmentName | AddressLine1 | estCity  | estCountry  | AddrPostcode |
	| test      | England | testFBO   |testName1         | testAddress1 | testCity1| testCountry1| EC4R 9HA     |


Scenario: Verify no establishment address listed after removing last address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   remove establishment address '<EstablishmentName>'
	Then  verify establishment address count '0'
	And   verify search for establishment address page loaded

	Examples: 
	| logininfo | Country | FBONumber |EstablishmentName | AddressLine1 | estCity  | estCountry  | AddrPostcode |
	| test      | England | testFBO   |testName1         | testAddress1 | testCity1| testCountry1| EC4R 9HA     |


Scenario: Verify remaining establishment address listed after removing one address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
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
	And   remove establishment address '<EstablishmentName>'
	Then  verify establishment address count '1'
	Examples: 
	| logininfo | Country | FBONumber |EstablishmentName | AddressLine1 | estCity  | estCountry  | AddrPostcode |EstablishmentName2 | AddressLine2 | estCity2  | estCountry2 | AddrPostcode2 |
	| test      | England | testFBO   |testName1         | testAddress1 | testCity1| testCountry1| SE10 9NF     |testName2          | testAddress2 | testCity2 | testCountry2| EC4R 9HA      |

	
Scenario: Change manually added establishment address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on change establishment address '<EstablishmentName>'
	And   verify add establishment address manually page loaded
	And   add establishment address manually with fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	And   add establishment email address 'test2@test.com'
	And   verify changed establishment address fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'

	Examples: 
	| logininfo | Country | FBONumber |EstablishmentName | AddressLine1 | estCity  | estCountry  | AddrPostcode |EstablishmentName2 | AddressLine2 | estCity2  | estCountry2 | AddrPostcode2 |
	| test      | England | testFBO   |testName1         | testAddress1 | testCity1| testCountry1| SE10 9NF     |testName2          | testAddress2 | testCity2 | testCountry2| EC4R 9HA      |


Scenario: Change establishment address postcode
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on change link next to Establishment postcode
	Then  verify search for establishment address page loaded
	When  enter Establishment postcode '<AddrPostcode1>'
	Then  verify establishment postcode changed to '<AddrPostcode1>'

	Examples: 
	| logininfo | Country | FBONumber | AddrPostcode | AddrPostcode1 |
	| test      | England | testFBO   | EC4R 9HA     | SE10 9NF      |


Scenario: Change establishment email address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on change establishment email address
	And   verify add establishment email address page loaded
	And   add establishment email address 'test2@test.com'
	Then  verify changed establishment email address 'test2@test.com'

	Examples: 
	| logininfo | Country | FBONumber |EstablishmentName | AddressLine1 | estCity  | estCountry  | AddrPostcode |
	| test      | England | testFBO   |testName1         | testAddress1 | testCity1| testCountry1| SE10 9NF     |


