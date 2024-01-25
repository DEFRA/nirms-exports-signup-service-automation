@Regression
Feature: SignIn

Sign in to General Certificate Page

Background: 
	Given that I navigate to the NI GC application

Scenario: Navigate to General Certificate Page
	Then  sign in with valid credentials with logininfo '<logininfo>'

	Examples: 
	| logininfo |
	| test1A    |

Scenario: SignOut
	Then sign in with valid credentials with logininfo '<logininfo>'
	And  click on signout button and verify the signout message

	Examples: 
	| logininfo |
	| test1A    |
