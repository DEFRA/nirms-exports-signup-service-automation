@Regression
Feature: Business name

Sign in to General Certificate Page and add businessname

@CrossBrowser
Scenario Outline:  Add business name
	Given that I navigate to the NI GC application
	When sign in with valid credentials with logininfo '<logininfo>'
	And  complete eligibility task with '<Country>', '<FBONumber>'
	Then verify eligibility task status as 'COMPLETED'
	When user is in Business name page
    And  user enters Business name  '<Business name>'
	Then click on save and continue on Business Name page
	And  verify next page '<nextPage>' is loaded 

 Examples:  
	| logininfo | Business name  | nextPage                                        | Country | FBONumber |
	| test      | DEFRA Business | What is the registered address of your business | England | testFBO   |


Scenario Outline: Verify error message for invalid characters business name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
    And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
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
	When  user is in Business name page
	And   user enters Business name  '<Business name>'
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
	When  user is in Business name page
	When  user clicks back button
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | nextPage                                                |
	| test      | England | testFBO   | Sign up for the Northern Ireland Retail Movement Scheme |

@ignore
Scenario Outline:  Verify user clicks on save and continue later  and navigated to tasklist page 
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
	And   user clicks on Save and continue later link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber |nextPage                                                |
	| test      | England | testFBO   |Sign up for the Northern Ireland Retail Movement Scheme |