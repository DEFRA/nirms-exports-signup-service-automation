@Regression
Feature: country name

Sign in to General Certificate Page and add country name

Scenario Outline: Add Country name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	
	Examples: 
    | logininfo | Country  |
	| test      | England  |

Scenario Outline: Verify error message for not selecting the country name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	Then user verifies the "Enter a country" error message

	Examples: 
    | logininfo | 
	| test      |  

Scenario Outline: Verify back button on country page is going tasklist page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	When user clicks back button
	Then user  navigates back to task list page

	Examples: 
    | logininfo | Country  |
	| test      | England  |
