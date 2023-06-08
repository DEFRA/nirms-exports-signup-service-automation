@Regression
Feature: Address 

Sign in to General Certificate Page and add Address

Scenario Outline: Navigate to General Certificate Page and Address
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'
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
	| Postcode      | Enter a post code.    |



	
	Scenario: Navigate to General Certificate Page and  Enter invalid data, Verify the error message
	#Given that I navigate to the NI GC application
	#Then  sign in with valid credentials with logininfo '<logininfo>'
	When user navigates to registered address page
	When user enters invalid adderror message for Business nameress and click on save continue
	Then user verifies invalid error message
	| Key      | Value      |
	| Adddress Line 1   | Enter address line 1 using only letters, numbers, hyphens (-) and apostrophes (').    |
	| Town      | Enter a town or city using only letters, numbers, hyphens (-) and apostrophes (').     |
	| Postcode     | Enter a real postcode.|
	

	Scenario Outline: Navigate to General Certificate Page and back button on Address page
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When user navigates to registered address page
	When user clicks back button
	Then user  navigates back to task list page


	#Scenario Outline: Navigate to General Certificate Page and Clickiing save and continue button navigates back to tasklist page
	##Given that I navigate to the NI GC application
	##Then  sign in with valid credentials with logininfo '<logininfo>'
	#When user navigates to registered address page
	#When user clicks on Save and continue later link
	

	Examples: 
	| logininfo |
	| test      |
