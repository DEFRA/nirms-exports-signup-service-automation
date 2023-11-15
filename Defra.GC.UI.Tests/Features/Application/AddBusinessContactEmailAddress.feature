@Regression
Feature: AddBusinessContactEmailAddress

Add Contact Email address

	@SmokeTest
Scenario: Add contact email address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	When  click on save and continue
	#Then  verify dynamic name '<contactName>' in title '<nextPage>' of page 

	Examples: 
	| logininfo | Business selection                                 | Country | FBONumber | contactName     | contactPosition | emailAddress  | nextPage         |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.          | England | testFBO   | testContactName | testPosition    | test@test.com | telephone number |


Scenario: Verify error message for invalid contact email address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on contact email address page

	Examples: 
	| logininfo | Business selection                                 | Country | FBONumber | contactName     | contactPosition | emailAddress | errorMessage                                 |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.          | England | testFBO   | testContactName | testPosition    | test£$@£     | Enter an email address in the correct format |


Scenario: Verify error message for blank contact email address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on contact email address page

	Examples: 
	| logininfo | Business selection                                 | Country | FBONumber | contactName     | contactPosition | emailAddress | errorMessage           |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.          | England | testFBO   | testContactName | testPosition    |              | Enter an email address |


Scenario: Verify back to dashboard link on contact email address page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   click on back link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Business selection                                  | Country | FBONumber | contactName     | contactPosition | nextPage |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.           | England | testFBO   | testContactName | testPosition    | Sign up for the Northern Ireland Retail Movement Scheme |


Scenario: Verify save and return to dashboard on contact email address page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Business selection                                 | Country | FBONumber | contactName     | contactPosition | nextPage | emailAddress     |
	| test      |  ABC ACCOUNTANCY & MARKETING SERVICES LTD.         | England | testFBO   | testContactName | testPosition    | Sign up  | contact@test.com |