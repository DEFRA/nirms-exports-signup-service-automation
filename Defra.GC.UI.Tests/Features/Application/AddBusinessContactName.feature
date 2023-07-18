@Regression
Feature: AddBusinessContactName

Add Business Contact Name

@CrossBrowser
Scenario: Add business contact name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection  | Country | FBONumber | contactName | nextPage |
	| test      |  ACME Ltd           | England | testFBO   | testName    | Position |


Scenario: Verify error message for invalid business contact name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on business contact name page 

	Examples: 
	| logininfo | Business selection | Country | FBONumber | contactName  | errorMessage                                                    |
	| test      |  ACME Ltd          | England | testFBO   | invalidTest% | Name must only include letters, numbers, and special characters |


Scenario: Verify error message for blank business contact name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on business contact name page

	Examples: 
	| logininfo | Business selection | Country | FBONumber | contactName | errorMessage  |
	| test      | ACME Ltd           | England | testFBO   |             | Enter a name. |


Scenario: Verify back link on business contact name page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection | Country | FBONumber | nextPage |
	| test      | ACME Ltd           | England | testFBO   | Sign up  |

Scenario: Verify save and return to dashboard on business contact name page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection  | Country | FBONumber | nextPage | contactName     |
	| test      | ACME Ltd            | England | testFBO   | Sign up  | testcontactName |
