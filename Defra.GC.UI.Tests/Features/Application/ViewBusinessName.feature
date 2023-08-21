@Regression
Feature: View Business Name in Dashboard & Static Page

View Business Name in Dashboard & Static Page

	@CrossBrowser @RunOnly @SmokeTest
Scenario: Verify user can click on the Selected Business Name and navigate to static page
	#Given Clear Database for user '<logininfo>'
	Given   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	Then  user clicks on Selected business
	Then  verify next page '<nextPage1>' is loaded 

	Examples: 
	| logininfo | Business selection |  nextPage1         |Country | FBONumber |
	| test7     | Tescoman           |  Selected business |England | testFBO   |
   
   @RunOnly @SmokeTest
Scenario: Verify user can click on the start a new sign up request
	#Given Clear Database for user '<logininfo>'
	Given   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	When  click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user clicks on Selected business
	Then  verify next page '<nextPage1>' is loaded 
	When  user clicks on the start a new sign up request link
	Then  verify next page '<nextPage2>' is loaded 

	Examples: 
	| logininfo | Business selection |  nextPage1         | nextPage2 |Country | FBONumber |
	| test7     | Tescoman           |  Selected business | sign up   |England | testFBO   |
   
   @RunOnly
Scenario: Verify user can click on the back to dashboard
	#Given Clear Database for user '<logininfo>'
	Given   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	When  click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	Then  user clicks on Selected business
	And   verify next page '<nextPage1>' is loaded 
	When  click on back to dashboard link
	Then  verify next page '<nextPage2>' is loaded
	 

	Examples: 
	| logininfo | Business selection |  nextPage1         | nextPage2  |Country | FBONumber |
	| test7     | Tescoman           |  Selected business | Sign up    |England | testFBO   |
   
   @RunOnly
Scenario: Verify user can click Check eligibility
	#Given Clear Database for user '<logininfo>'
	Given   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on eligibility task
	Then  verify next page '<nextPage1>' is loaded 

	Examples:
    | logininfo | Country | FBONumber | Business selection  | nextPage1                |
    | test7     | England | testFBO   | Tescoman            | What will your business  |

