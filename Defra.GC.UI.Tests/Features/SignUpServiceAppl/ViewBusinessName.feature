Feature: View Business Name in Dashboard & Static Page

View Business Name in Dashboard & Static Page

	 @SmokeTest
Scenario: Verify user can click on the start a new sign up request
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name '<Business selection>'
	When  click on FBOorPHRNumber task
	And   enter FBO number '<FBONumber>' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	When  user clicks on Selected business
	Then  verify next page '<nextPage1>' is loaded 
	When  user clicks on the start a new sign up request link
	Then  verify next page '<nextPage2>' is loaded 
	When  user clicks on Selected business
	And   click on back to dashboard link
	Then  verify next page '<nextPage3>' is loaded

	Examples: 
	| logininfo | Business selection | nextPage1         | nextPage2                               | nextPage3 | Country | FBONumber |
	| test7     | Tescoman           | Selected business | Northern Ireland Retail Movement Scheme | Sign up   | England | testFBO   |
   