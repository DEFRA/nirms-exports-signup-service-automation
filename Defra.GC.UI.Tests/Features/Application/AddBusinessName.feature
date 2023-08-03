@Regression
Feature: Business name

Sign in to General Certificate Page and add businessname

@CrossBrowser
Scenario Outline:  Add business name
	Given that I navigate to the NI GC application
	When sign in with valid credentials with logininfo '<logininfo>'
	And  select business to sign up '<Business selection>'
	And  click on eligibility task
	And  complete eligibility task with '<Country>', '<FBONumber>'
	Then verify eligibility task status as 'COMPLETED'
	When user is in Business name page
    And  user enters Business name  '<Business name>'
	Then click on save and continue
	And  verify next page '<nextPage>' is loaded 

 Examples:  
	| logininfo | Business selection                       | Business name  | nextPage                              | Country | FBONumber |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| DEFRA Business | What is the address of your business? | England | testFBO   |


Scenario Outline: Verify error message for invalid characters business name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
    And   user enters Business name  '<Business name>'
	Then  click on save and continue
	Then  user verifies the "Enter your business name using only letters, numbers, brackets, full stops, hyphens (-), underscores (_), slashes (/) or ampersands (&)" error message for Business name

    Examples:   
	| logininfo | Business selection                       | Business name | Country | FBONumber |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| ************  | England | testFBO   |

Scenario Outline:  Verify error message for  blank business name
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
	And   user enters Business name  '<Business name>'
	Then  user verifies the "Enter your business name" error message when user clicks on save button without Business name

    Examples:    
	| logininfo | Business name | Country | FBONumber |  Business selection                          |
	| test      |               | England | testFBO   |   ABC ACCOUNTANCY & MARKETING SERVICES LTD.  |

Scenario Outline:  Verify user clicks on back to dashboard button and navigate to tasklist page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
	When  click on back to dashboard link
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection                        | Country | FBONumber | nextPage                                                |
	| test      |  ABC ACCOUNTANCY & MARKETING SERVICES LTD.| England | testFBO   | Sign up for the Northern Ireland Retail Movement Scheme |

Scenario Outline:  Verify user clicks on save and return to dashboard and navigated to tasklist page 
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
	And   user enters Business name  '<Business name>'
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo |  Business selection                        | Country | FBONumber | Business name    | nextPage                                                |
	| test      |   ABC ACCOUNTANCY & MARKETING SERVICES LTD.| England | testFBO   | TestBusinessName | Sign up for the Northern Ireland Retail Movement Scheme |