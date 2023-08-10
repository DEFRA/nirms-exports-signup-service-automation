@Regression
Feature: AddBusinessEligibility

Complete Eligibility task

@CrossBrowser
Scenario Outline: Complete eligibility task
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'

	Examples:
    | logininfo | Country | FBONumber | Business selection                             |
    | test      | England | testFBO   | ABC ACCOUNTANCY & MARKETING SERVICES LTD.      |

Scenario Outline: Verify error message for not selecting the country name
	Given that I navigate to the NI GC application
	When sign in with valid credentials with logininfo '<logininfo>'
	Then verify next page '<nextPage>' is loaded 

	Examples: 
    | logininfo | nextPage                           |
    | test      | Which business do you want to sign |


Scenario Outline: Verify back button on country page is going task list page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   user clicks back button
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
    | logininfo | Business selection                        | nextPage   |
    | test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | Sign up    |

	
Scenario Outline: Verify No sign up page appears when no FBO number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task without FBONumber
	Then  verify next page '<nextPage>' is loaded 

	Examples: 
    | logininfo | Business selection                        | Country | FBONumber  | nextPage                         |
    | test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England |            | You cannot sign up your business |

Scenario Outline: Verify back link on Assurance FBO page is going country selection page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>'
	And   click on back link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
    | logininfo | Country | nextPage                      | Business selection                         |
    | test      | England | What will your business do    | ABC ACCOUNTANCY & MARKETING SERVICES LTD.  |

Scenario Outline: Verify error message for invalid FBO with Assurance
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with invalid data '<Country>', '<FBONumber>'
	Then  verify error message '<errorMessage>' on  SPS_Assurance page

	Examples: 
    | logininfo | Country | FBONumber       | errorMessage                                                 | Business selection                        |
    | test      | England | *************** | Enter FBO number using only letters, numbers and hyphens (-) | ABC ACCOUNTANCY & MARKETING SERVICES LTD. |

Scenario Outline: Verify confirmation error message for Regulations page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>' without Regulations
	Then  verify error message '<errorMessage>' on  Regulations page
	
	Examples: 
    | logininfo | Country | FBONumber | errorMessage                                                  | Business selection                       |
    | test      | England | testFBO   | Confirm that you have understood the guidance and regulations | ABC ACCOUNTANCY & MARKETING SERVICES LTD |


Scenario Outline: Verify back link on Regulations page is navigating to SPO page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>' and navigate to Regulations page
    And   click on back link
	Then  user navigates to the SPO_Assurance page
	
	
	Examples: 
    | logininfo | Country | FBONumber |Business selection                         |
    | test      | England | testFBO   |ABC ACCOUNTANCY & MARKETING SERVICES LTD.  |