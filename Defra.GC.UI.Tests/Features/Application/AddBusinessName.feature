@Regression
Feature: Business name

Sign in to General Certificate Page and add businessname

@CrossBrowser
Scenario Outline:  Add business name
	Given that I navigate to the NI GC application
	When sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then verify eligibility task status as 'COMPLETED'
	When user is in Business name page
    And  user enters Business name  '<Business name>'
	Then click on save and continue
	And  verify next page '<nextPage>' is loaded 

 Examples:  
	| logininfo | Business selection | Business name  | nextPage                                        | Country | FBONumber |
	| test      | ACME Ltd           | DEFRA Business | What is the registered address of your business | England | testFBO   |


Scenario Outline: Verify error message for invalid characters business name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
    And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
    And   user enters Business name  '<Business name>'
	Then  click on save and continue
	Then  user verifies the "Enter your business name using only letters, numbers, and special characters -_./()&" error message for Business name

    Examples:   
	| logininfo | Business selection | Business name | Country | FBONumber |
	| test      | ACME Ltd           | ************  | England | testFBO   |

Scenario Outline:  Verify error message for  blank business name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
	And   user enters Business name  '<Business name>'
	Then  user verifies the "Enter your business name" error message when user clicks on save button without Business name

    Examples:    
	| logininfo | Business name | Country | FBONumber |  Business selection |
	| test      |               | England | testFBO   |   ACME Ltd          |

Scenario Outline:  Verify user clicks on back button  and navigate 
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
	When  user clicks back button
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection | Country | FBONumber | nextPage                                                |
	| test      |  ACME Ltd          | England | testFBO   | Sign up for the Northern Ireland Retail Movement Scheme |

Scenario Outline:  Verify user clicks on save and return to dashboard and navigated to tasklist page 
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
	And   user enters Business name  '<Business name>'
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Business selection | Country | FBONumber | Business name    | nextPage                                                |
	| test      |   ACME Ltd          | England | testFBO   | TestBusinessName | Sign up for the Northern Ireland Retail Movement Scheme |