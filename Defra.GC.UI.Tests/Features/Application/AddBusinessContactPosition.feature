@Regression
Feature: AddBusinessContactPosition

Add Business Contact contactPosition

	@CrossBrowser @RunOnly @SmokeTest
Scenario: Add business contact position
	Given Clear Database
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
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection                                   | Country | FBONumber | contactName     | contactPosition | nextPage      |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.            | England | testFBO   | testContactName | testPosition    | email address |

	@RunOnly
Scenario: Verify error message for invalid business contact position
	Given Clear Database
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
	Then  verify error message '<errorMessage>' on business contact position page

	Examples: 
	| logininfo | Business selection                        | Country | FBONumber | contactName     | contactPosition | errorMessage |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | testFBO   | testContactName | testPosition%   |  Enter the position of the contact person using only letters, numbers, brackets, full stops, hyphens (-), underscores (_), slashes (/) or ampersands (&)            |

	@RunOnly
Scenario: Verify error message for blank business contact position
	Given Clear Database
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
	Then  verify error message '<errorMessage>' on business contact position page

	Examples: 
	| logininfo |     Business selection                             | Country | FBONumber | contactName     | contactPosition | errorMessage                             |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.          | England | testFBO   | testContactName |                 | Enter the position of the contact person |

	@RunOnly
Scenario: Verify back to dashboard link on business contact position page
	Given Clear Database
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
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |         Business selection                         | Country | FBONumber | contactName     | nextPage  |
	| test      |  ABC ACCOUNTANCY & MARKETING SERVICES LTD.         | England | testFBO   | testContactName | Sign up |

	@RunOnly
Scenario: Verify save and return to dashboard on business contact position page
	Given Clear Database
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
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |    Business selection                           | Country | FBONumber | contactName     | nextPage | contactPosition     |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.       | England | testFBO   | testContactName | Sign up  | testcontactPosition |
