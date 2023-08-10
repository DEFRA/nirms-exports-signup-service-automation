@Regression
Feature: AddBusinessContactTelephoneNumber

Add Contact telephone number

@CrossBrowser
Scenario: Add contact Telephone Number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click Save and return to dashboard
	Then  user verify the business contact details status 'COMPLETED'

	Examples: 
	| logininfo |       Business selection                            | Country | FBONumber | contactName     | contactPosition | emailAddress  | telephoneNumber | nextPage |
	| test      |  ABC ACCOUNTANCY & MARKETING SERVICES LTD.          | England | testFBO   | testContactName | testPosition    | test@test.com | 01632 960 001   | Sign up  |


Scenario: Verify error message for invalid contact Telephone Number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
     And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on contact telephone number page

	Examples: 
	| logininfo |     Business selection                             | Country | FBONumber | contactName     | contactPosition | emailAddress  | telephoneNumber | errorMessage                                   |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.          | England | testFBO   | testContactName | testPosition    | test@test.com | abc123          | Enter a telephone number in the correct format, like 01632 960 001, 07700 900 982 or +44 808 157 019 |


Scenario: Verify error message for blank contact telephone number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue on contact position page
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on contact telephone number page

	Examples: 
	| logininfo |             Business selection                      | Country | FBONumber | contactName     | contactPosition | emailAddress  | telephoneNumber | errorMessage                                 |
	| test      |  ABC ACCOUNTANCY & MARKETING SERVICES LTD. 		  | England | testFBO   | testContactName | testPosition    | test@test.com |                 | Enter the phone number of the contact person |


Scenario: Verify back to dashboard link contact telephone number page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |           Business selection                           | Country | FBONumber | contactName     | contactPosition | emailAddress  | nextPage      |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. 			 | England | testFBO   | testContactName | testPosition    | test@test.com | Sign up       |

Scenario: Verify save and return to dashboard on contact telephone number page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |                      Business selection            | Country | FBONumber | contactName     | contactPosition | emailAddress  | nextPage | telephoneNumber |
	| test      |	ABC ACCOUNTANCY & MARKETING SERVICES LTD.		 | England | testFBO   | testContactName | testPosition    | test@test.com | Sign up  | 01632 960 001   |