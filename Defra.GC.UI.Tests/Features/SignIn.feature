@Regression
Feature: SignIn

Sign in to General Certificate Page

Scenario: Navigate to General Certificate Page
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'

	Examples: 
	| logininfo |
	| test      |