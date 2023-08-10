@Regression
Feature: View Business Name in Dashboard & Static Page

View Business Name in Dashboard & Static Page

	Scenario: Verify user can click on the Selected Business Name and navigate to static page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	Then  user clicks on Selected business
	Then  verify next page '<nextPage1>' is loaded 

	Examples: 
	| logininfo | Business selection |  nextPage1         |
	| test7     | Tescoman           |  Selected business |
   
   
	Scenario: Verify user can click on the start a new sign up request
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	Then  user clicks on Selected business
	Then  verify next page '<nextPage1>' is loaded 
	Then  user clicks on the start a new sign up request link
	Then  verify next page '<nextPage2>' is loaded 

	Examples: 
	| logininfo | Business selection |  nextPage1         | nextPage2 |
	| test7     | Tescoman           |  Selected business | sign up   |  
   
   Scenario: Verify user can click on the back to dashboard
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	Then  user clicks on Selected business
	Then  verify next page '<nextPage1>' is loaded 
	When  click on back to dashboard link
	Then  verify next page '<nextPage2>' is loaded
	 
	Examples: 
	| logininfo | Business selection |  nextPage1         | nextPage2 |
	| test7     | Tescoman           |  Selected business | Sign up    |  
   
    Scenario: Verify user can click Check eligibility'
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	Then  verify next page '<nextPage1>' is loaded 

	Examples:
    | logininfo | Country | FBONumber | Business selection                        | nextPage1 |
    | test      | England | testFBO   | ABC ACCOUNTANCY & MARKETING SERVICES LTD. |  What will your business          |

