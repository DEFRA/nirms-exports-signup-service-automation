@Regression @RunOnly

Feature: AddBusinessEligibility

Complete Eligibility task

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
    | logininfo | nextPage                  | businessName   | nextPage1			  | nextPage2                               | errorMessage             |
    | test      | NI Retail Movement Scheme | TestEnv1       | Requirements of the NI | do under the NI Retail Movement Scheme? | will do under the scheme |


Scenario Outline: Verify back button on country page is going to select business page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   Navigate To Regulations Page and confirm Regulations
	And   user clicks back button
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
    | logininfo | Business selection     | nextPage                  |
    | test      | TestEnv1               | Requirements of the NI    |


Scenario Outline: Verify confirmation error message for Regulations page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   continue eligibility task without Regulations
	Then  verify error message '<errorMessage>' on  Regulations page
	
	Examples: 
    | logininfo | Country | FBONumber | errorMessage                                                  | Business selection |
    | test      | England | testFBO   | Confirm that you have understood the guidance and regulations | TestEnv1           |

Scenario Outline: Verify back link on Regulations page is navigating to business sign up page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
    And   click on back link
	Then  verify next page '<nextPage>' is loaded
	
	
	Examples: 
    | logininfo | Country | FBONumber | Business selection   | nextPage                  |
    | test      | England | testFBO   | TestEnv1             | NI Retail Movement Scheme |
	

Scenario: Verify text on Purpose of Business page  
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on Purpose Of Business task
	Then  verify '<PurposeOfBusinessText>' on purpose of business page 

	Examples:
    | logininfo | Country		   | FBONumber | Business selection  |PurposeOfBusinessText                                                                                                   |
    | test      | England		   | testFBO   | TestEnv1            |Your business will be sending consignments from Great Britain to Northern Ireland under the NI Retail Movement Scheme.  |
    | test1A    | Northern Ireland | testFBO   | TestEnv2            |Your business will be receiving consignments from Great Britain to Northern Ireland under the NI Retail Movement Scheme.|

	@ignore
Scenario: Verify back to dashboard link on Purpose of Business page  
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on Purpose Of Business task
	Then  click on back to dashboard link
	Then  verify next page '<nextPage>' is loaded 

	Examples:
    | logininfo | Country		   | FBONumber | Business selection  |nextPage |                                                                                             
	| test      | England		   | testFBO   | TestEnv1            |Sign up  | 


Scenario: Verify Start new SignUp request link on Purpose of Business page navigates to select business page  
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on Purpose Of Business task
	Then  click on back to dashboard link
	Then  verify next page '<nextPage>' is loaded 
	When  click on Purpose Of Business task
	Then  click on Start a new SignUp Request on Purpose Of Business page
	Then  verify next page '<nextPage1>' is loaded 

	Examples:
    | logininfo | Country | FBONumber | Business selection | nextPage | nextPage1                 |
    | test      | England | testFBO   | TestEnv1           | Sign up  | NI Retail Movement Scheme |



Scenario: Verify requirements of Northern Ireland Retail Movement scheme page is diplayed on selecting business for rejected status
	Given Clear Database for user '<logininfo>'
	Given  that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of departure with '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  user verify the Points of departure status '1 ADDED'
	And   click on Check answers and submit sign up
	When  click on continue button
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up
	Then  click on signout button and verify the signout message
	When  Reject signup request in Database for user '<logininfo>'
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>' 
	Then  verify next page '<nextPage>' is loaded
	Examples: 
	| logininfo | Business selection | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry |nextPage                                     |
	| test1C    | TestEnv3           | England | testFBO   | testName      | testAddress | London | Wv1 3EB      | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName       | testAddress1 | London  | England    |Requirements of the NI Retail Movement Scheme|
