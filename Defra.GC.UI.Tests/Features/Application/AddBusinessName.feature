@Regression
Feature: Business name

Sign in to General Certificate Page and add businessname

Scenario Outline:  Add business name
	Given that I navigate to the NI GC application
	When sign in with valid credentials with logininfo '<logininfo>'
	And  click on check eligibilty task
	And  complete eligibility task with '<Country>', '<FBONumber>'
	Then verify eligibility task status as 'COMPLETED'
	When user is in Business details page
    And  user enters Business name  '<Business name>'
	Then click on save and continue on Business Name page
	And  verify next page '<nextPage>' is loaded 
	And  user verify the business status 'COMPLETED'

 Examples:  
	| logininfo | Business name  | nextPage | Country | FBONumber |
	| test      | DEFRA Business |          | England | testFBO   |


Scenario Outline: Verify error message for  invalid characters business name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
    And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business details page
    And   user enters Business name  '<Business name>'
	Then  click on save and continue on Business Name page
	Then  user verifies the "Enter your business name using only letters, numbers, and special characters -_./()&" error message for Business name

    Examples:   
	| logininfo | Business name | Country       |FBONumber |
	| test      | ************  | England       |testFBO   |

Scenario Outline:  Verify error message for  blank business name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business details page
	 And  user enters Business name  '<Business name>'
	Then  user verifies the "Enter your business name" error message when user clicks on save button without Business name

    Examples:    
	| logininfo | Business name | Country    |FBONumber |
	| test      |               | England    |testFBO   |

Scenario Outline:  Verify user clicks on back button  and navigate 
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business details page
	When  user clicks back button
	Then  user  navigates back to task list page

	Examples: 
	| logininfo | Country      |FBONumber |
	| test      | England      |testFBO   |

@ignore
Scenario Outline:  Verify user clicks on save and continue later  and navigated to tasklist page 
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business details page
	And   user clicks on Save and continue later link
	Then  user  navigates back to task list page

	Examples: 
	| logininfo | Country | FBONumber |
	| test      | England | testFBO   |