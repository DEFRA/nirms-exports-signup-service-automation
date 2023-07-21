@Regression 
Feature: Adddion Point Of Destination Establishment

Add Point of Destination Establishment

@CrossBrowser
Scenario: Check Add the Destination establishment address manually link
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
#	And   enter Establishment postcode '<postcode>'
#	Then  verify next page '<nextPage>' is loaded 
#	When  click on cannot find establishment link 
#	And   click on the add establishment address manually link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |Business selection   | Country          | FBONumber | postcode | nextPage                   |
	| test      | ACME Ltd            | Northern Ireland | testFBO   | BT52 2AJ | Add a place of destination |

Scenario: Add point of Destination establishment address manually
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
#	And   enter Establishment postcode '<postcode>'
#	Then  verify next page '<nextPage>' is loaded 
#	When  click on cannot find establishment link 
#	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | postcode | nextPage                   | EstablishmentName | AddressLine1    | estCity  | estCountry      | AddrPostcode |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | BT52 2AJ | Add a place of destination | Coleraine         | Crown Buildings | Millburn | Northen Ireland | BT52 2AJ     |


Scenario: Verify back link on enter  Destination establishment postcode page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	And   click on back to dashboard link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | nextPage |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | Sign up  |

Scenario: Verify back link on select Destination establishment address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
    When  click on points of destination link
	#And   enter Establishment postcode '<postcode>'
	#Then  verify next page '<nextPage>' is loaded 
	When  click on back to dashboard link
	#Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | postcode | nextPage |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | BT52 2AJ | Sign up  |

Scenario: Verify back link on add Destination  establishment address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	#And   enter Establishment postcode '<postcode>'
	#Then  verify next page '<nextPage>' is loaded 
	#When  click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   click on back to dashboard link
	#Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Business selection | Country          | FBONumber | postcode | nextPage  |
	| test      |      ACME Ltd       | Northern Ireland | testFBO   | BT52 2AJ | Sign up   |

	Scenario: Verify back link on the  Do you want to add another point of destination Page ?
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	#And   enter Establishment postcode '<postcode>'
	#Then  verify next page '<nextPage>' is loaded 
	#Then  click on select address button
	#Then  click on continue button
	And   click on back to dashboard link
	#Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Business selection  | Country          | FBONumber | postcode | nextPage  |
	| test      |    ACME Ltd          | Northern Ireland | testFBO   | BT52 2AJ | Sign up   |

	
	Scenario: Verify back link on the Establishment email address optional page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link	
	#And   enter Establishment postcode '<postcode>'
	#Then  verify next page '<nextPage>' is loaded 
	#Then  click on select address button
	And   click on back to dashboard link
	#Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | postcode | nextPage |
	| test      |  ACME Ltd          | Northern Ireland | testFBO   | BT52 2AJ | Sign up  |

Scenario: Modify point of destination establishment email address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	#And   enter Establishment postcode '<AddrPostcode>'
	#And   click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on change establishment email address
	And   verify add establishment email address page loaded
	And   add establishment email address 'test2@test.com'
	Then  verify changed establishment email address 'test2@test.com'

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity  | estCountry      | AddrPostcode |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | testName1         | testAddress1 | Millburn | Northen Ireland | BT52 2AJ     |
	
Scenario: Add Another point of Destination establishment address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	#And   enter Establishment postcode '<AddrPostcode>'
	#And   click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on add another establishment address
	#And   enter Establishment postcode '<AddrPostcode2>'
	#And   click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	And   add establishment email address 'test2@test.com'
	Then  verify more than 1 establishment addresses added
	Examples: 
	| logininfo | Business selection  | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity   | estCountry       | AddrPostcode | EstablishmentName2 | AddressLine2         | estCity2  | estCountry2      | AddrPostcode2 |
	| test      | ACME Ltd            | Northern Ireland | testFBO   | testName1         | testAddress1 | testCity1 | Northern Ireland | BT30 6LZ     | Market Street      | Demesne of Down Acre | testCity2 | Northern Ireland | BT52 2AJ      |


Scenario: Finish adding  point of Destination  establishment address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	#And   enter Establishment postcode '<AddrPostcode>'
	#And   click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on I have finished adding points of departure
	And   click on save and continue
	Then  verify next page '<nextPage>' is loaded 
	Examples: 
	| logininfo | Business selection | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity         | estCountry       | AddrPostcode | nextPage          |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | Coleraine         | testAddress1 | Crown Buildings | Northern Ireland | BT52 2AJ     | Check your answers         |

	
Scenario: Verify no point of destination  establishment address listed after removing last address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	#And   enter Establishment postcode '<AddrPostcode>'
	#And   click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   remove establishment address '<EstablishmentName>'
	Then  verify establishment address count '0'
	#And   verify search for establishment address page loaded

	Examples: 
	| logininfo |  Business selection  | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity         | estCountry       | AddrPostcode |
	| test      |     ACME Ltd         | Northern Ireland | testFBO   | Coleraine         | testAddress1 | Crown Buildings | Northern Ireland | BT52 2AJ     |

	
Scenario: Verify remaining  point of destination  establishment address listed after removing one address
    Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	#And   enter Establishment postcode '<AddrPostcode>'
	#And   click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on add another establishment address
	#And   enter Establishment postcode '<AddrPostcode2>'
	#And   click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	And   add establishment email address 'test2@test.com'
	And   remove establishment address '<EstablishmentName>'
	#And   click on back link
	Then  verify establishment address count '1'
	Examples: 
	| logininfo | Business selection | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity   | estCountry       | AddrPostcode | EstablishmentName2 | AddressLine2         | estCity2  | estCountry2      | AddrPostcode2 |
	| test      |   ACME Ltd         | Northern Ireland | testFBO   | testName1         | testAddress1 | testCity1 | Northern Ireland | BT30 6LZ     | Market Street      | Demesne of Down Acre | testCity2 | Northern Ireland | BT52 2AJ      |

Scenario: Change manually added  destination establishment address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	#And   enter Establishment postcode '<AddrPostcode>'
	#And   click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on change establishment address '<EstablishmentName>'
	And   verify add establishment address manually page loaded
	And   add establishment address manually with fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	And   add establishment email address 'test2@test.com'
	And   verify changed establishment address fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'

	Examples: 
	| logininfo |  Business selection | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity   | estCountry       | AddrPostcode | EstablishmentName2 | AddressLine2         | estCity2  | estCountry2      | AddrPostcode2 |
	| test      |   ACME Ltd          | Northern Ireland | testFBO   | testName1         | testAddress1 | testCity1 | Northern Ireland | BT30 6LZ     | Market Street      | Demesne of Down Acre | testCity2 | Northern Ireland | BT52 2AJ      |

	
Scenario: Change destination establishment address postcode
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	#And   enter Establishment postcode '<AddrPostcode>'
	#And   click on change link next to Establishment postcode
	#Then  verify search for establishment address page loaded
	#When  enter Establishment postcode '<AddrPostcode1>'
	#Then  verify establishment postcode changed to '<AddrPostcode1>'

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | AddrPostcode | AddrPostcode1 |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | BT30 6LZ     | BT52 2AJ      |



Scenario: Change destination establishment email address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	#And   enter Establishment postcode '<AddrPostcode>'
	#And   click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on change establishment email address
	And   verify add establishment email address page loaded
	And   add establishment email address 'test2@test.com'
	Then  verify changed establishment email address 'test2@test.com'

	Examples:  
	| logininfo |  Business selection  | Country          | FBONumber | EstablishmentName | AddressLine1    | estCity | estCountry       | AddrPostcode |
	| test      |   ACME Ltd           | Northern Ireland | testFBO   | Coleraine         | Crown Buildings | Belfast | Northern Ireland | BT30 6LZ     |

	Scenario:Verify different post code link is navigated to Add a point of deastination page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	#And   enter Establishment postcode '<AddrPostcode>'
	#And   click on a different postcode error link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | AddrPostcode | nextPage                   |
	| test      | ACME Ltd           | Northern Ireland | testFBO   | N3 3NA       | Add a place of destination |

Scenario:Verify Enter a Address manually link is navigated to Add a place of destination page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
    When  click on points of destination link
	#And   enter Establishment postcode '<AddrPostcode>'
	#And   click on a enter an address manually error link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Business selection  | Country          | FBONumber | AddrPostcode | nextPage                   |
	| test      |     ACME Ltd         | Northern Ireland | testFBO   | N3 3NA       | Add a place of destination |


Scenario:Verify save and return to dashboard on Add a place of destination page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on I have finished adding points of departure
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection  | Country          | FBONumber | nextPage  |EstablishmentName | AddressLine1    | estCity | estCountry       | AddrPostcode |
	| test      | ACME Ltd            | Northern Ireland | testFBO   | Sign up   |Coleraine         | Crown Buildings | Belfast | Northern Ireland | BT30 6LZ     |