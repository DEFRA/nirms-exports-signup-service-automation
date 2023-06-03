@Regression
Feature: Address 

Sign in to General Certificate Page and add Address

Scenario Outline: Navigate to General Certificate Page and Address
	#Given that I navigate to the NI GC application
	#Then  sign in with valid credentials with logininfo '<logininfo>'
	When user navigates to registered address page
	When user enters address and click on save continue
	
	Examples: 
	| logininfo |
	|	test      |
#
	Scenario: Navigate to General Certificate Page and  do not select the address fields
	#Given that I navigate to the NI GC application
	#Then  sign in with valid credentials with logininfo '<logininfo>'
	When user navigates to registered address page
	When user clicks  save continue button without entering value
	Then user verifies address error message
	| Key      | Value      |
	| Adddress    | Enter address line 1.    |
	| Town      | Enter a town or city.      |
	| Postcosw      | Enter a post code.    |



	
##
###
##	Scenario Outline: Navigate to General Certificate Page and missing  business name
##	#Given that I navigate to the NI GC application
##	#Then  sign in with valid credentials with logininfo '<logininfo>'
##	When user is in Business details page
##	Then user verifies the  error message for the missing field
##	Then user verifies the "Enter your business name" error message
##
##	Examples: 
##	| logininfo |
##	| test      |
##
#	Scenario Outline: Navigate to General Certificate Page and back button on country page
#	#Given that I navigate to the NI GC application
#	#Then  sign in with valid credentials with logininfo '<logininfo>'
#	When user is in country details page
#	When user clicks back button
#	Then user  navigates back to task list page
#
#	Examples: 
#	| logininfo |
#	| test      |
