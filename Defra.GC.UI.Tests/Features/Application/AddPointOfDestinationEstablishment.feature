@Regression
Feature: Adddion Point Of Destination Establishment

Add Point of Destination Establishment


Scenario: Check Add the Destination establishment address manually link
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	Then  verify dynamic name '<Business selection>' in warning text '<warningText>' on establishment page
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	When  click on cannot find establishment link 
	And   click on the add establishment address manually link
	Then  verify next page '<nextPage>' is loaded 
	
	Examples: 
	| logininfo | Business selection | Country          | FBONumber | postcode | nextPage       | warningText                                                   |
	| test1A    | Kaka               | Northern Ireland | testFBO   | BT52 2AJ | of destination | You do not need to enter establishments that do not belong to |

Scenario: Add point of Destination establishment address manually
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	When  click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | postcode | nextPage       | EstablishmentName | AddressLine1    | estCity  | estCountry      | AddrPostcode |
	| test1A    | Kaka               | Northern Ireland | testFBO   | BT52 2AJ | of destination | Coleraine         | Crown Buildings | Millburn | Northen Ireland | BT52 2AJ     |


Scenario: Verify back to dashboard link on enter Destination establishment postcode page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	And   click on back to dashboard link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection  | Country          | FBONumber | nextPage |
	| test1A    | Kaka                | Northern Ireland | testFBO   | Sign up  |

Scenario: Verify back to dashboard link on select Destination establishment address page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
    When  click on points of destination link
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	When  click on back to dashboard link
	Then  verify next page '<nextPage1>' is loaded 
	
	 
	Examples: 
	| logininfo | Business selection     | Country          | FBONumber | postcode | nextPage        | nextPage1  |
	| test1A    | Kaka                   | Northern Ireland | testFBO   | BT7 2JB  | of destination  | Sign up    |

Scenario: Verify back to dashboard link on add Destination establishment address page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	When  click on cannot find establishment link 
	And   click on the add establishment address manually link
	When  click on back to dashboard link
	Then  verify next page '<nextPage1>' is loaded 

	Examples: 
	| logininfo |  Business selection | Country          | FBONumber | postcode | nextPage       |nextPage1  |
	| test1A    |  Kaka               | Northern Ireland | testFBO   | BT52 2AJ | of destination |Sign up    |


	Scenario: Verify back to dashboard link on the Do you want to add another point of destination Page ?
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	And   enter Establishment postcode '<postcode>'
	Then  click on select address button
	Then  click on save and continue
	Then  click on continue button
	When  click on back to dashboard link
	Then  verify next page '<nextPage1>' is loaded
	Then  user verify the Points of destination status '1 ADDED'
	
	Examples: 
	| logininfo | Business selection                        | Country          | FBONumber | postcode | nextPage       | nextPage1 |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | Northern Ireland | testFBO   | BT7 2JB | of destination | Sign up         |

	
	Scenario: Verify back to dashboard link on the Establishment email address optional page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link	
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	Then  click on select address button
	When  click on back to dashboard link
	Then  verify next page '<nextPage1>' is loaded 

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | postcode | nextPage       |nextPage1|
	| test1A    | Kaka               | Northern Ireland | testFBO   | BT93 8AD | of destination |Sign up  |

Scenario: Modify point of destination establishment email address
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
	And   click on change establishment email address
	And   verify add establishment email address page loaded
	And   add establishment email address 'test2@test.com'
	Then  verify changed establishment email address 'test2@test.com'

	Examples: 
	| logininfo | Business selection  | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity  | estCountry      | AddrPostcode |
	| test1A    | Kaka                | Northern Ireland | testFBO   | testName1         | testAddress1 | Millburn | Northen Ireland | BT52 2AJ     |
	
Scenario: Add Another point of Destination establishment address
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
	And   enter Establishment postcode '<AddrPostcode2>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	And   add establishment email address 'test2@test.com'
	Then  verify more than 1 establishment addresses added
	Examples: 
	| logininfo | Business selection   | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity   | estCountry       | AddrPostcode | EstablishmentName2 | AddressLine2         | estCity2  | estCountry2      | AddrPostcode2 |
	| test1A    | Kaka                 | Northern Ireland | testFBO   | testName2         | testAddress1 | testCity1 | Northern Ireland | BT30 6LZ     | Market Street      | Demesne of Down Acre | testCity2 | Northern Ireland | BT52 2AJ      |

	@SmokeTest
Scenario: Finish adding point of Destination establishment address
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
	And   verify message for '<Business selection>' on establishment page
	And   click on I have finished adding points of departure
	And   click on save and continue
	Then  verify next page '<nextPage>' is loaded 
	Examples: 
	| logininfo | Business selection   | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity         | estCountry       | AddrPostcode | nextPage |
	| test1A    | Kaka                 | Northern Ireland | testFBO   | Coleraine1        | testAddress1 | Crown Buildings | Northern Ireland | BT52 2AJ     | Sign up  |

	
Scenario: Verify no point of destination establishment address listed after removing last address
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
	And   remove establishment address '<EstablishmentName>'
	Then  verify next page '<nextPage>' is loaded 

	
	Examples: 
	| logininfo | Business selection | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity         | estCountry       | AddrPostcode | nextPage        |
	| test1A    | Kaka               | Northern Ireland | testFBO   | Coleraine3        | testAddress1 | Crown Buildings | Northern Ireland | BT52 2AJ     | of destination  |

	
Scenario: Verify remaining point of destination establishment address listed after removing one address
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
	And   enter Establishment postcode '<AddrPostcode2>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	And   add establishment email address 'test2@test.com'
	And   remove establishment address '<EstablishmentName>'
	Then  verify establishment address count '1'
	Examples: 
	| logininfo | Business selection  | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity   | estCountry       | AddrPostcode | EstablishmentName2 | AddressLine2         | estCity2  | estCountry2      | AddrPostcode2 |
	| test1A    | Kaka                | Northern Ireland | testFBO   | testName3         | testAddress1 | testCity1 | Northern Ireland | BT30 6LZ     | Market Street3     | Demesne of Down Acre | testCity2 | Northern Ireland | BT52 2AJ      |

Scenario: Change manually added destination establishment address
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
	And   click on change establishment address '<EstablishmentName>'
	And   verify add establishment address manually page loaded
	And   add establishment address manually with fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	And   add establishment email address 'test2@test.com'
	And   verify changed establishment address fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'

	Examples: 
	| logininfo | Business selection | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity   | estCountry       | AddrPostcode | EstablishmentName2 | AddressLine2         | estCity2  | estCountry2      | AddrPostcode2 |
	| test1A    | Kaka               | Northern Ireland | testFBO   | testName4         | testAddress1 | testCity1 | Northern Ireland | BT30 6LZ     | Market Street4     | Demesne of Down Acre | testCity2 | Northern Ireland | BT52 2AJ      |

	
Scenario: Change destination establishment address postcode
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on change link next to Establishment postcode
	Then  verify search for establishment address page loaded
	When  enter Establishment postcode '<AddrPostcode1>'
	Then  verify establishment postcode changed to '<AddrPostcode1>'

	Examples: 
	| logininfo | Business selection  | Country          | FBONumber | AddrPostcode | AddrPostcode1 |
	| test1A    | Kaka                | Northern Ireland | testFBO   | BT30 6LZ     | BT52 2AJ      |



Scenario: Change destination establishment email address
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
	And   click on change establishment email address
	And   verify add establishment email address page loaded
	And   add establishment email address 'test2@test.com'
	Then  verify changed establishment email address 'test2@test.com'

	Examples:  
	| logininfo |  Business selection  | Country          | FBONumber | EstablishmentName | AddressLine1    | estCity | estCountry       | AddrPostcode |
	| test1A    |  Kaka                | Northern Ireland | testFBO   | Coleraine4        | Crown Buildings | Belfast | Northern Ireland | BT30 6LZ     |


	Scenario:Verify different post code link is navigated to Add a point of deastination page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on a different postcode error link
	Then  verify next page '<nextPage>' is loaded 
	 
	Examples: 
	| logininfo | Business selection  | Country          | FBONumber | AddrPostcode      | nextPage       |
	| test1A    | Kaka                | Northern Ireland | testFBO   | BT43 4TT          | of destination |

Scenario:Verify Enter a Address manually link is navigated to Add a place of destination page
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
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Business selection | Country          | FBONumber | AddrPostcode | nextPage       |
	| test1A    |  Kaka               | Northern Ireland | testFBO   | BT52 2AJ       | of destination |


Scenario:Verify save and return to dashboard on Add a place of destination page
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
	And   click on I have finished adding points of departure
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection  | Country          | FBONumber | nextPage  |EstablishmentName | AddressLine1    | estCity | estCountry       | AddrPostcode |
	| test1A    | Kaka                | Northern Ireland | testFBO   | Sign up   |Coleraine5        | Crown Buildings | Belfast | Northern Ireland | BT30 6LZ     |