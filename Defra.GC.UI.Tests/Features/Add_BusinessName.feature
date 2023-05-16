@Regression
Feature: Business name

Sign in to General Certificate Page and add businessname

Scenario Outline: Navigate to General Certificate Page and Add business name
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When user is in Business details page
	When user enters Business name and click on save continue
	Then user verifys sucessfully addded business name

	Examples: 
	| logininfo |
	| test      |

