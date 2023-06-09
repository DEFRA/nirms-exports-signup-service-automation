@Regression
Feature: country name

Sign in to General Certificate Page and add country name

Scenario Outline: Navigate to General Certificate Page and Add Country name
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When user clicks on Check eligibility link
	When user selects country name and click on save continue
	Examples: 
	| logininfo |
	|	test      |

	Scenario Outline: Navigate to General Certificate Page and  do not select the country name
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When user clicks on Check eligibility link
	Then user verifies the "Enter a country" error message
	Examples: 
	| logininfo |
	|	test      |

	Scenario Outline: Navigate to General Certificate Page and back button on country page
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When user clicks on Check eligibility link
	When user clicks back button
	Then user  navigates back to task list page

	Examples: 
	| logininfo |
	| test      |
