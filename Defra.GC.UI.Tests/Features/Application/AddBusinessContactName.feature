@Regression
Feature: AddBusinessContactName

Add Business Contact Name

	@SmokeTest
Scenario: Add business contact name
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
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection        | Country | FBONumber | contactName | nextPage |
	| test2     | AMSAK PROPERTY LIMITED    | England | testFBO   | testName    | position |


Scenario: Verify error message for invalid business contact name
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
	Then  verify error message '<errorMessage>' on business contact name page  
	 
	Examples: 
	| logininfo | Business selection               | Country | FBONumber | contactName  | errorMessage                                            |
	| test2     | AMSAK PROPERTY LIMITED           | England | testFBO   | invalidTest% | Enter a name using only letters, hyphens or apostrophes |


Scenario: Verify error message for blank business contact name
	#Given Clear Database for user '<logininfo>'
	Given   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
    Then verify error message '<errorMessage>' on business contact name page

	Examples: 
	| logininfo | Business selection               | Country | FBONumber | contactName | errorMessage  |
	| test2     | AMSAK PROPERTY LIMITED           | England | testFBO   |             | Enter a name  |


Scenario: Verify back to dashboard link on business contact name page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on business contact details link
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection                | Country | FBONumber | nextPage |
	| test2     | AMSAK PROPERTY LIMITED            | England | testFBO   | Sign up  |

	@SmokeTest
Scenario: Verify save and return to dashboard on business contact name page
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
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection              | Country | FBONumber | nextPage | contactName     |
	| test2     | AMSAK PROPERTY LIMITED          | England | testFBO   | Sign up  | testcontactName |
