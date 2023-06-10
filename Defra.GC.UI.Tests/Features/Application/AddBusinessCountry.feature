@Regression
Feature: country name

Sign in to General Certificate Page and add country name

Scenario Outline: Add Country name
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When user clicks on Check eligibility link
	When user selects country name and click on save continue
	Examples: 
	| logininfo |
	|	test      |

	Scenario Outline: Verify error message for not selecting the country name
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When user clicks on Check eligibility link
	Then user verifies the "Enter a country" error message
	Examples: 
	| logininfo |
	|	test      |

	Scenario Outline: Verify back button on country page is going tasklist page
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When user clicks on Check eligibility link
	When user clicks back button
	Then user  navigates back to task list page

	Examples: 
	| logininfo |
	| test      |
