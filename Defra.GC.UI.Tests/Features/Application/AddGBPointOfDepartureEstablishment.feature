@Regression
Feature: AddGBPointOfDepartureEstablishment

Add GB point of Departure Establishment


Scenario: Verify Point of Departure link for GB countries
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   verify points of destination link not visible on tasklist page
	When  click on points of departure link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Business selection                        | Country  | FBONumber | postcode | nextPage    |
	| test      |  ABC ACCOUNTANCY & MARKETING SERVICES LTD. | Wales    | testFBO   | SE10 9NF | of dispatch |
	| test      |  ABC ACCOUNTANCY & MARKETING SERVICES LTD. | Scotland | testFBO   | SE10 9NF | of dispatch |


Scenario: Check Add the establishment address manually link
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	When  click on cannot find establishment link 
	And   click on the add establishment address manually link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Business selection                         | Country | FBONumber | postcode | nextPage    |
	| test      |  ABC ACCOUNTANCY & MARKETING SERVICES LTD.  | England | testFBO   | SE10 9NF | of dispatch |


Scenario: Add GB point of Departure establishment address manually
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
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
	| logininfo | Business selection                       | Country  | FBONumber | postcode | nextPage                | EstablishmentName | AddressLine1 | estCity | estCountry | AddrPostcode |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| England  | testFBO   | SE10 9NF | Add a place of dispatch | testName1         | testAddress1 | London  | England    | SE10 9NF     |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| Wales    | testFBO   | CF10 1AA | Add a place of dispatch | testName2         | testAddress2 | Cardiff | Wales      | CF10 1AA     |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| Scotland | testFBO   | G1 1AB   | Add a place of dispatch | testName3         | testAddress3 | Glasgow | Scotland   | G1 1AB       |


Scenario: Verify back to dashboard link on enter establishment postcode page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   click on back to dashboard link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection                        | Country | FBONumber | nextPage |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | Sign up  |


Scenario: Verify back to dashboard link on select establishment address page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link	
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage1>' is loaded 
	When  click on back to dashboard link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Business selection                       | Country | FBONumber | postcode | nextPage  |nextPage1               |
	| test      |  ABC ACCOUNTANCY & MARKETING SERVICES LTD.| England | testFBO   | SE10 9NF | Sign up   |Add a place of dispatch |

	@RunOnly
Scenario: Verify back to dashboard link on add establishment address page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link	
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage1>' is loaded 
	When  click on cannot find establishment link 
	And   click on the add establishment address manually link
	When  click on back to dashboard link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection                       | Country | FBONumber | postcode | nextPage |nextPage1               |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| England | testFBO   | SE10 9NF | Sign up  |Add a place of dispatch |



	Scenario: Verify back to dashboard link on then Do you want to add another point of departure Page ?
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link	
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	Then  click on select address button
	Then  click on save and continue
	When   click on back to dashboard link
	Then  verify next page '<nextPage1>' is loaded 

	Examples: 
	| logininfo | Business selection                        | Country | FBONumber | postcode | nextPage                | nextPage1 |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | SE10 9NF | Add a place of dispatch |  Sign up    |


	Scenario: Verify back to dashboard link on the Establishment email address optional page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link	
	And   enter Establishment postcode '<postcode>'
	Then  verify next page '<nextPage>' is loaded 
	Then  click on select address button
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	When   click on back to dashboard link
	Then  verify next page '<nextPage1>' is loaded 

	Examples: 
	| logininfo | Business selection                        | Country | FBONumber | postcode | nextPage1 | EstablishmentName | AddressLine1 | estCity | estCountry | AddrPostcode | nextPage |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | SE10 9NF | Sign up   | testName4         | testAddress1 | London  | England    | SE10 9NF     | Add a place of dispatch        |


	@SmokeTest  @RunOnly
Scenario: Add Another GB point of Departure establishment address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
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
	| logininfo | Business selection                       | Country | FBONumber | EstablishmentName | AddressLine1 | estCity | estCountry | AddrPostcode | EstablishmentName2 | AddressLine2 | estCity2  | estCountry2 | AddrPostcode2 |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| England | testFBO   | testName1         | testAddress5 | London  | England    | SE10 9NF     | testName6          | testAddress  | Liverpool | England     | L1 0AN        |



Scenario: Finish adding GB point of Departure establishment address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on I have finished adding points of departure
	And   click on save and continue
	#Then  verify next page '<nextPage>' is loaded 
	Examples: 
	| logininfo | Business selection                       | Country | FBONumber | EstablishmentName | AddressLine1 | estCity | estCountry | AddrPostcode | nextPage           |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| England | testFBO   | testName7         | testAddress1 | London  | England    | EC4R 9HA     | Sign up            |

	@SmokeTest 
Scenario: Verify no establishment address listed after removing last address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   remove establishment address '<EstablishmentName>'
	Then  verify next page '<nextPage>' is loaded 


	Examples: 
	| logininfo | Business selection                        | Country | FBONumber | EstablishmentName | AddressLine1 | estCity | estCountry | AddrPostcode | nextPage				  |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | testName8         | testAddress1 | London  | England    | EC4R 9HA     | Add a place of dispatch  |



Scenario: Verify remaining establishment address listed after removing one address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
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
	| logininfo | Business selection                          | Country | FBONumber | EstablishmentName | AddressLine1 | estCity | estCountry | AddrPostcode | EstablishmentName2 | AddressLine2 | estCity2  | estCountry2 | AddrPostcode2 |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.   | England | testFBO   | testName9         | testAddress1 | London  | England    | SE10 9NF     | testName10         | testAddress2 | Liverpool | England     | L1 0AN        |


Scenario: Change manually added establishment address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
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
	| logininfo | Business selection                        | Country | FBONumber | EstablishmentName | AddressLine1 | estCity | estCountry | AddrPostcode | EstablishmentName2 | AddressLine2 | estCity2  | estCountry2 | AddrPostcode2 |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | testName11        | testAddress1 | London  | England    | SE10 9NF     | testName12         | testAddress2 | Liverpool | England     | L1 0AN        |


Scenario: Change establishment address postcode
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on change link next to Establishment postcode
	Then  verify search for establishment address page loaded
	When  enter Establishment postcode '<AddrPostcode1>'
	Then  verify establishment postcode changed to '<AddrPostcode1>'

	Examples: 
	| logininfo | Business selection                        | Country | FBONumber | AddrPostcode | AddrPostcode1 |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | EC4R 9HA     | SE10 9NF      |


Scenario: Change establishment email address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
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
	| logininfo | Business selection                        | Country | FBONumber | EstablishmentName | AddressLine1 | estCity | estCountry | AddrPostcode |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | testName13        | testAddress1 | London  | England    | SE10 9NF     |

	
Scenario:Verify back to dashboard link from address page navigated to Add a place of dispatch  page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   click on back to dashboard link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection                       | Country | FBONumber | EstablishmentName | AddressLine1 | estCity   | estCountry   | AddrPostcode | nextPage                |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| England | testFBO   | testName14        | testAddress1 | testCity1 | testCountry1 | SE10 9NF     | Sign up |


Scenario:Verify different post code link is navigated to Add a place of dispatch page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection                       | Country | FBONumber | AddrPostcode | nextPage    |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| England | testFBO   | Test         | of dispatch |

	
Scenario:Verify Enter a Address manually link is navigated to Add a place of dispatch page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on the add establishment address manually link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection                       | Country | FBONumber | AddrPostcode | nextPage    |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| England | testFBO   | TTTT       | of dispatch |


Scenario:Verify save and return to dashboard on Add a place of dispatch page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of departure link
	And   enter Establishment postcode '<AddrPostcode>'
	And   click on cannot find establishment link 
	And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on I have finished adding points of departure
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection                        | Country | FBONumber | nextPage  |EstablishmentName | AddressLine1 | estCity   | estCountry   | AddrPostcode |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | Sign up   |testName15        | testAddress1 | testCity1 | testCountry1 | SE10 9NF     |

