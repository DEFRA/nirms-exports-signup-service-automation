@Regression
Feature: AddBusinessSPS_Assurance

Complete SPS Assurance page

Scenario Outline: Complete eligibility task with Assurance
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	
	Examples: 
    | logininfo | Country | FBONumber |
    | test      | England | testFBO   |

	Scenario Outline:  Verify No sign up page appears when no FBO number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task without '<Country>', '<FBONumber>'
	Then  verify no signp page appears

	Examples: 
    | logininfo | Country | FBONumber |
    | test      | England |    |

	Scenario Outline: Verify back link on Assurance is going country selecting page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	And   click on back link
	Then  user  navigates to the Country selection page

	Examples: 
    | logininfo | Country | 
    | test      | England |    

	Scenario Outline: Verify error message for invalid task with Assurance
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then   verify error message '<errorMessage>' on  SPS_Assurance page

	Examples: 
    | logininfo | Country | FBONumber |  errorMessage                                   |
    | test      | England | ***************   | Enter FBO number using only letters, numbers and hyphens - |