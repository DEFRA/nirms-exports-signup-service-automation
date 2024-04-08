@Regression @RunOnly
Feature: AddBusinessContactEmailAddress

Add Contact Email address


Scenario: Verify error message for invalid contact email address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on contact email address page

	Examples: 
	| logininfo | Business selection      | Country | FBONumber | contactName     | contactPosition | emailAddress                                                                                                                                                                  | errorMessage                                           |
	| test      | TestEnv1                | England | testFBO   | testContactName | testPosition    | TestAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAaa  | The email address cannot be longer than 100 characters |


Scenario: Verify error message for blank contact email address
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on contact email address page
	And   click on back link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Business selection      | Country | FBONumber | contactName     | contactPosition | emailAddress | errorMessage           | nextPage |
	| test      | TestEnv1                | England | testFBO   | testContactName | testPosition    |              | Enter an email address |Sign up for the NI Retail Movement Scheme |

	@ignore
Scenario: Verify back to dashboard link on contact email address page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   click on back link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Business selection       | Country | FBONumber | contactName     | contactPosition | nextPage |
	| test      | TestEnv1                 | England | testFBO   | testContactName | testPosition    | Sign up for the NI Retail Movement Scheme |


Scenario: Verify save and return to dashboard on contact email address page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded

	Examples: 
	| logininfo | Business selection     | Country | FBONumber | contactName     | contactPosition | nextPage | emailAddress     |
	| test      | TestEnv1               | England | testFBO   | testContactName | testPosition    | Sign up  | contact@test.com |