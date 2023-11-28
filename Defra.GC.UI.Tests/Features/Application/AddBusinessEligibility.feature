@Regression

Feature: AddBusinessEligibility

Complete Eligibility task

 @SmokeTest
Scenario Outline: Complete eligibility task
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'

	Examples:
    | logininfo | Country | Business selection                             |
    | test      | England | ABC ACCOUNTANCY & MARKETING SERVICES LTD.      |

Scenario Outline: Verify error message for not selecting the country
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify next page '<nextPage>' is loaded
	When  select business to sign up '<businessName>'
	Then  verify next page '<nextPage1>' is loaded
	When  Navigate To Regulations Page and confirm Regulations
	Then  verify next page '<nextPage2>' is loaded
	And   click on continue button
	Then  verify dynamic name '<businessName>' in title '<nextPage2>' of page
	Then  verify dynamic name '<businessName>' in error message '<errorMessage>'
	Examples: 
    | logininfo | nextPage                           | businessName                              | nextPage1					        | nextPage2                                             | errorMessage             |
    | test      | Which business do you want to sign | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | Requirements of the Northern Ireland | do under the Northern Ireland Retail Movement Scheme? | will do under the scheme |


Scenario Outline: Verify back button on country page is going to select business page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   Navigate To Regulations Page and confirm Regulations
	And   user clicks back button
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
    | logininfo | Business selection                        | nextPage                                |
    | test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | Requirements of the Northern Ireland    |


Scenario Outline: Verify confirmation error message for Regulations page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   continue eligibility task without Regulations
	Then  verify error message '<errorMessage>' on  Regulations page
	
	Examples: 
    | logininfo | Country | FBONumber | errorMessage                                                  | Business selection                       |
    | test      | England | testFBO   | Confirm that you have understood the guidance and regulations | ABC ACCOUNTANCY & MARKETING SERVICES LTD |

Scenario Outline: Verify back link on Regulations page is navigating to business sign up page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
    And   click on back link
	Then  verify next page '<nextPage>' is loaded
	
	
	Examples: 
    | logininfo | Country | FBONumber | Business selection                        | nextPage                                                                               |
    | test      | England | testFBO   | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | Which business do you want to sign up for the Northern Ireland Retail Movement Scheme? |


Scenario: Verify back link from Another business page is navigated to Select your business page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	Then  verify next page '<nextPage>' is loaded 
    And   click on back link
	Then  verify next page '<nextPage1>' is loaded 

	Examples: 
    | logininfo | Country | Business selection |nextPage                                        |nextPage1                                                                               |
    | test      | England | Another business   |You do not have access to any other businesses  |Which business do you want to sign up for the Northern Ireland Retail Movement Scheme?  |
	

Scenario: Verify manage access link opens a new page on Another business page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	Then  verify next page '<nextPage>' is loaded 
    And   click on manage access link on Another business page
	Then  switch to next opened tab
	Then  verify generic GOV page is loaded

	Examples: 
    | logininfo | Country | Business selection |nextPage                                        |
    | test      | England | Another business   |You do not have access to any other businesses  |
	
	 @SmokeTest 
Scenario Outline: Verify dynamic business name on SPS Assurance page for FBO PHR number
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify dynamic name '<Business selection>' on eligibility task on SPS Assurance page with '<Country>'

	Examples:
    | logininfo | Country | FBONumber | Business selection                             |
    | test      | England | testFBO   | ABC ACCOUNTANCY & MARKETING SERVICES LTD.      |
