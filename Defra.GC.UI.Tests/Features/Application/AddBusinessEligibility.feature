@Regression
Feature: AddBusinessEligibility

Complete Eligibility task

@CrossBrowser
Scenario Outline: Complete eligibility task
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	
	Examples: 
    | logininfo | Country | FBONumber |
    | test      | England | testFBO   |

Scenario Outline: Verify error message for not selecting the country name
	Given that I navigate to the NI GC application
	When sign in with valid credentials with logininfo '<logininfo>'
	Then user verifies the "Enter a country" error message

	Examples: 
    | logininfo | 
	| test      |  

Scenario Outline: Verify back button on country page is going tasklist page
	Given that I navigate to the NI GC application
	When sign in with valid credentials with logininfo '<logininfo>'
	And  user clicks back button
	Then verify next page '<nextPage>' is loaded 

	Examples: 
    | logininfo | nextPage            |
    | test      | Existing Submission |

@ignore
Scenario Outline: Verify save and continue later navigating to tasklist page
	Given that I navigate to the NI GC application
	When sign in with valid credentials with logininfo '<logininfo>'
	And  complete eligibility task with '<Country>', '<FBONumber>'
	And  user clicks on Save and continue later link
	Then verify next page '<nextPage>' is loaded 
	Examples: 
    | logininfo | Country | FBONumber | nextPage |
    | test      | England | testFBO   | Replace  |


	
Scenario Outline:  Verify No sign up page appears when no FBO number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task without '<Country>', '<FBONumber>'
	Then  verify no signp page appears

	Examples: 
    | logininfo | Country | FBONumber |
    | test      | England |           |

Scenario Outline: Verify back link on Assurance is going country selecting page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>'
	And   click on back link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
    | logininfo | Country | nextPage                      |
    | test      | England | Where is your business based? |

Scenario Outline: Verify error message for invalid FBO with Assurance
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with invalid data '<Country>', '<FBONumber>'
	Then  verify error message '<errorMessage>' on  SPS_Assurance page

	Examples: 
    | logininfo | Country | FBONumber |  errorMessage                                   |
    | test      | England | ***************   | Enter FBO number using only letters, numbers and hyphens - |

Scenario Outline: Verify confirmation error message for Regulations page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' without Regulations
	Then  verify error message '<errorMessage>' on  Regulations page
	
	Examples: 
    | logininfo | Country | FBONumber | errorMessage |
    | test      | England | testFBO   | Confirm that you have understood the guidance and regulations|


Scenario Outline: Verify back link on Regulations page is navigating to SPO page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>' and navigate to Regulations page
    And   click on back link
	Then  user navigates to the SPO_Assurance page
	
	
	Examples: 
    | logininfo | Country | FBONumber |
    | test      | England | testFBO   |     