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
	|	test      |

	Scenario Outline: Navigate to General Certificate Page and Add invalid characters business name
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When user is in Business details page
	When user enters invalid Business name
	Then user verifies the invalid error message

	Examples: 
	| logininfo |
	| test      |
#
#
#	Scenario Outline: Navigate to General Certificate Page and missing  business name
#	Given that I navigate to the NI GC application
#	Then  sign in with valid credentials with logininfo '<logininfo>'
#	When user is in Business details page
#	When user do not enter Business name
#	Then  user verifies the  error message for the missing field
#
#	Examples: 
#	| logininfo |
#	| test      |
#
#
#	Scenario Outline: Navigate to General Certificate Page and back button 
#	Given that I navigate to the NI GC application
#	Then  sign in with valid credentials with logininfo '<logininfo>'
#	When user is in Business details page
#	When user clicks back button
#	Then user  navigates back to task list page
#
#	Examples: 
#	| logininfo |
#	| test      |
#
#	Scenario Outline: Navigate to General Certificate Page and Save and continue later
#	Given that I navigate to the NI GC application
#	Then  sign in with valid credentials with logininfo '<logininfo>'
#	When user is in Business details page
#	When user enters Business name and click on save continue
#	Then user verifys sucessfully addded business name
#
#	Examples: 
#	| logininfo |
#	| test      |