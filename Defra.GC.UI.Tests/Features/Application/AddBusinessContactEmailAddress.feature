@Regression
Feature: AddBusinessContactEmailAddress

Add Contact Email address

Scenario: Add contact email address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   click on contact email address link
	And   enter email address '<emailAddress>'
	And   click on save and continue on contact email address page
	And   verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | emailAddress  | nextPage |
	| test      | England | testFBO   | test@test.com | Sign up  |


Scenario: Verify error message for invalid contact email address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   click on contact email address link
	And   enter email address '<emailAddress>'
	And   click on save and continue on contact email address page
	And   verify error message '<errorMessage>' on contact email address page

	Examples: 
	| logininfo | Country  |FBONumber |emailAddress     | errorMessage                                   |
	| test      | England  |testFBO   |test£$@£         | Enter an email address in the correct format   |


Scenario: Verify error message for blank contact email address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   click on contact email address link
	And   enter email address '<emailAddress>'
	And   click on save and continue on contact email address page
	And   verify error message '<errorMessage>' on contact email address page
	Examples: 
	| logininfo | Country  |FBONumber |emailAddress | errorMessage                                       |
	| test      | England  |testFBO   |             | Enter the email address of the contact person      |


Scenario: Verify back link on contact email address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	Then  navigate to task list page
	And   click on contact email address link
	And   click on back link
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |Country  |FBONumber |
	| test      |England  |testFBO   |

@Ignore
Scenario: Verify save and continue later on contact email address page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
    And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	Then  navigate to task list page
	And   click on contact email address link
	And   click save and continue later
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |Country  |FBONumber |
	| test      |England  |testFBO   |