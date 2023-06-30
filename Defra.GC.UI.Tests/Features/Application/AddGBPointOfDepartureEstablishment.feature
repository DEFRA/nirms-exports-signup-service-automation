﻿@Regression
Feature: AddGBPointOfDepartureEstablishment

Add GB point of Departure Establishment

Scenario: Verify Point of Departure link for GB countries
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   verify points of destination link not visible on tasklist page
	When  click on points of departure link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country  | FBONumber |postcode | nextPage                 |
	| test      | Wales    | testFBO   |SE10 9NF | Add a point of departure |
	| test      | Scotland | testFBO   |SE10 9NF | Add a point of departure |

@CrossBrowser
Scenario: Check Add the establishment address manually link
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
#	And   enter Establishment postcode '<postcode>'
#	Then  verify next page '<nextPage>' is loaded 
#	When  click on cannot find establishment link 
#	And   click on the add establishment address manually link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |postcode | nextPage                 |
	| test      | England | testFBO   |SE10 9NF | Add a point of departure |

Scenario: Add GB point of Departure establishment address manually
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
#	And   enter Establishment postcode '<postcode>'
#	Then  verify next page '<nextPage>' is loaded 
#	When  click on cannot find establishment link 
#	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country  | FBONumber |postcode | nextPage                 | EstablishmentName | AddressLine1 | estCity   | estCountry | AddrPostcode |
	| test      | England  | testFBO   |SE10 9NF | Add a point of departure | testName1         | testAddress1 | London    | England    | SE10 9NF     |
	| test      | Wales    | testFBO   |CF10 1AA | Add a point of departure | testName2         | testAddress2 | Cardiff   | Wales      | CF10 1AA     |
	| test      | Scotland | testFBO   |G1 1AB   | Add a point of departure | testName3         | testAddress3 | Glasgow   | Scotland   | G1 1AB       |


Scenario: Verify back link on enter establishment postcode page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
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
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link	
#	And   enter Establishment postcode '<postcode>'
#	Then  verify next page '<nextPage>' is loaded 
	When  click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |postcode | nextPage                 |
	| test      | England | testFBO   |SE10 9NF | Add a point of departure |

Scenario: Verify back link on add establishment address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link	
#	And   enter Establishment postcode '<postcode>'
#	Then  verify next page '<nextPage>' is loaded 
#	When  click on cannot find establishment link 
#	And   click on the add establishment address manually link
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |postcode | nextPage                 |
	| test      | England | testFBO   |SE10 9NF | Add a point of departure |



	Scenario: Verify back link on the  Do you want to add another point of departure Page ?
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link	
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	Then  click on select address button
	Then  click on continue button
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |postcode | nextPage                 |
	| test      | England | testFBO   |SE10 9NF | Add a point of departure |

	
	Scenario: Verify back link on the Establishment email address optional page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link	
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	Then  click on select address button
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |postcode | nextPage                 |
	| test      | England | testFBO   |SE10 9NF | Add a point of departure |



Scenario: Add Another GB point of Departure establishment address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
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
	And   add establishment address manually with fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	And   add establishment email address 'test2@test.com'
	Then  verify more than 1 establishment addresses added
	Examples: 
	| logininfo | Country | FBONumber |EstablishmentName | AddressLine1 | estCity  | estCountry  | AddrPostcode |EstablishmentName2 | AddressLine2 | estCity2  | estCountry2 | AddrPostcode2 |
	| test      | England | testFBO   |testName1         | testAddress1 | London   | England     | SE10 9NF     |testName2          | testAddress2 | Liverpool | England     | L1 0AN        |

Scenario: Finish adding GB point of Departure establishment address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
#	And   enter Establishment postcode '<AddrPostcode>'
#	And   click on cannot find establishment link 
#	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on I have finished adding points of departure
	Then  verify signUp task list page is loaded
	Examples: 
	| logininfo | Country | FBONumber |EstablishmentName | AddressLine1 | estCity  | estCountry  | AddrPostcode |
	| test      | England | testFBO   |testName1         | testAddress1 | London   | England     | EC4R 9HA     |


Scenario: Verify no establishment address listed after removing last address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
#	And   enter Establishment postcode '<AddrPostcode>'
#	And   click on cannot find establishment link 
#	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   remove establishment address '<EstablishmentName>'
	Then  verify establishment address count '0'
	And   verify search for establishment address page loaded

	Examples: 
	| logininfo | Country | FBONumber |EstablishmentName | AddressLine1 | estCity  | estCountry  | AddrPostcode |
	| test      | England | testFBO   |testName1         | testAddress1 | London   | England     | EC4R 9HA     |


Scenario: Verify remaining establishment address listed after removing one address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
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
	And   add establishment address manually with fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	And   add establishment email address 'test2@test.com'
	And   remove establishment address '<EstablishmentName>'
	Then  verify establishment address count '1'
	Examples: 
	| logininfo | Country | FBONumber |EstablishmentName | AddressLine1 | estCity  | estCountry  | AddrPostcode |EstablishmentName2 | AddressLine2 | estCity2  | estCountry2 | AddrPostcode2 |
	| test      | England | testFBO   |testName1         | testAddress1 | London   | England     | SE10 9NF     |testName2          | testAddress2 | Liverpool | England     | L1 0AN        |

	
Scenario: Change manually added establishment address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
#	And   enter Establishment postcode '<AddrPostcode>'
#	And   click on cannot find establishment link 
#	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on change establishment address '<EstablishmentName>'
	And   verify add establishment address manually page loaded
	And   add establishment address manually with fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'
	And   add establishment email address 'test2@test.com'
	And   verify changed establishment address fields '<EstablishmentName2>', '<AddressLine2>', '<estCity2>', '<estCountry2>', '<AddrPostcode2>'

	Examples: 
	| logininfo | Country | FBONumber |EstablishmentName | AddressLine1 | estCity  | estCountry  | AddrPostcode |EstablishmentName2 | AddressLine2 | estCity2  | estCountry2 | AddrPostcode2 |
	| test      | England | testFBO   |testName1         | testAddress1 | London   | England     | SE10 9NF     |testName2          | testAddress2 | Liverpool | England     | L1 0AN        |


Scenario: Change establishment address postcode
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
#	And   enter Establishment postcode '<AddrPostcode>'
#	And   click on change link next to Establishment postcode
#	Then  verify search for establishment address page loaded
#	When  enter Establishment postcode '<AddrPostcode1>'
#	Then  verify establishment postcode changed to '<AddrPostcode1>'

	Examples: 
	| logininfo | Country | FBONumber | AddrPostcode | AddrPostcode1 |
	| test      | England | testFBO   | EC4R 9HA     | SE10 9NF      |


Scenario: Change establishment email address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
#	And   enter Establishment postcode '<AddrPostcode>'
#	And   click on cannot find establishment link 
#	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on change establishment email address
	And   verify add establishment email address page loaded
	And   add establishment email address 'test2@test.com'
	Then  verify changed establishment email address 'test2@test.com'

	Examples: 
	| logininfo | Country | FBONumber |EstablishmentName | AddressLine1 | estCity  | estCountry  | AddrPostcode |
	| test      | England | testFBO   |testName1         | testAddress1 | London   | England     | SE10 9NF     |

Scenario:Verify Back link  from address page navigated to Add a point of departure page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | EstablishmentName | AddressLine1 | estCity   | estCountry   | AddrPostcode | nextPage                 |
	| test      | England | testFBO   | testName1         | testAddress1 | testCity1 | testCountry1 | SE10 9NF     | Add a point of departure |

	
Scenario:Verify different post code link is navigated to Add a point of departure page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on a different postcode error link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |    AddrPostcode |  nextPage                 |
	| test      | England | testFBO   |    N3 3NA       |  Add a point of departure |

Scenario:Verify Enter a Address manually link is navigated to Add a point of departure page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on a enter an address manually error link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |    AddrPostcode |  nextPage                 |
	| test      | England | testFBO   |    N3 3NA       |  Add a point of departure |