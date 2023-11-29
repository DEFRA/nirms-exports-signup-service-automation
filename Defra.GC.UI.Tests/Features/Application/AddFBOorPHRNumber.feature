@Regression
Feature: Add FBO or PHR Number

Add FBO or PHR Number

 
Scenario: Verify No sign up page appears when no FBO number
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	And   click on FBOorPHRNumber task
	Then  verify next page '<nextPage>' is loaded 
	When  complete FBO or PHR number task without FBO or PHR Number
	Then  verify next page '<nextPage1>' is loaded

Examples: 
    | logininfo | Business selection                        | Country | FBONumber  | nextPage                                                                |nextPage1                                   |
    | test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England |            | Food Business Operator (FBO) or Plant Health Registration (PHR) number? |You can still submit a sign-up request now  |


Scenario Outline: Verify back link on Assurance FBO page is going back to Task list page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	When  click on FBOorPHRNumber task
	And   click on back link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
    | logininfo | Country | nextPage                                                 | Business selection                         |
    | test      | England | Sign up for the Northern Ireland Retail Movement Scheme  | ABC ACCOUNTANCY & MARKETING SERVICES LTD.  |


Scenario Outline: Verify error message for invalid FBO Number
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	When  click on FBOorPHRNumber task
	And   enter invalid FBO '<FBONumber>'
	Then  verify error message '<errorMessage>' on  SPS_Assurance page

	Examples: 
    | logininfo | Country | FBONumber       | errorMessage                                               | Business selection                        |
    | test      | England | *************** | Enter an FBO number using only letters, numbers or hyphens | ABC ACCOUNTANCY & MARKETING SERVICES LTD. |



Scenario: Verify error message for invalid PHR number
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	When  click on FBOorPHRNumber task
	And   enter invalid PHR '<PHRNumber>'
	Then  verify error message '<errorMessage>' on  SPS_Assurance page

	Examples: 
    | logininfo | Country | PHRNumber       | errorMessage                                                      | Business selection                        |
    | test      | England | *************** | Enter a PHR number using only letters, numbers, spaces or hyphens | ABC ACCOUNTANCY & MARKETING SERVICES LTD. |


Scenario Outline: Complete FBO or PHR number task with PHR number option
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
    And   complete eligibility task with '<Country>'
	When  click on FBOorPHRNumber task
	And   enter PHR number '<PHRNumber>' for FBO or PHR number task
	And   click on save and continue
	Then  verify next page '<nextPage>' is loaded

Examples: 
    | logininfo | Country | PHRNumber |Business selection                         |nextPage                           | 
    | test      | England | testPHR   |ABC ACCOUNTANCY & MARKETING SERVICES LTD.  |Who is the contact person for the  |


Scenario Outline: Complete FBO or PHR number task with no FBO or PHR number option 
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify next page '<nextPage2>' is loaded
	When  click on FBOorPHRNumber task
	Then  verify next page '<nextPage>' is loaded
    When  complete FBO or PHR number task without FBO or PHR Number
	Then  verify next page '<nextPage1>' is loaded

Examples: 
    | logininfo | Business selection                        | Country | nextPage                                                                       | nextPage1                                  | nextPage2 |
    | test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | have a Food Business Operator (FBO) or Plant Health Registration (PHR) number? | You can still submit a sign-up request now | Sign up   |


Scenario Outline: Verify back on You can still submit sign up page navigates to FBO or PHR page
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify next page '<nextPage2>' is loaded
	When  click on FBOorPHRNumber task
	Then  verify next page '<nextPage>' is loaded
    When  complete FBO or PHR number task without FBO or PHR Number
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 

Examples: 
    | logininfo | Business selection                        | Country | nextPage1                                  | nextPage                                                                       | nextPage2 |
    | test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD. | England | You can still submit a sign-up request now | have a Food Business Operator (FBO) or Plant Health Registration (PHR) number? | Sign up   |

Scenario: Verify error message for no radiobutton selected on FBO PHR page
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	When  click on FBOorPHRNumber task
	Then  verify next page '<nextPage>' is loaded 
	Then  click on save and continue
	Then  verify dynamic name '<Business selection>' in error message '<errorMessage>'

	Examples: 
    | logininfo | Country | PHRNumber       | errorMessage               | Business selection                        |nextPage                                                                        |
    | test      | England | *************** | has an FBO or PHR number   | ABC ACCOUNTANCY & MARKETING SERVICES LTD. |have a Food Business Operator (FBO) or Plant Health Registration (PHR) number?  |


Scenario Outline: Verify hint text on FBO PHR page
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	When  click on FBOorPHRNumber task
	Then  verify next page '<nextPage>' is loaded
	Then  verify hint text '<hintText>' on FBO PHR page
	

	Examples: 
    | logininfo | Country |Business selection                         |nextPage														                    |hintText								   															     |
    | test      | England |ABC ACCOUNTANCY & MARKETING SERVICES LTD.  |have a Food Business Operator (FBO) or Plant Health Registration (PHR) number?   |You will have an FBO number if you’ve registered with your local authority for a food business licence. |

 @SmokeTest 
Scenario Outline: Verify dynamic business name on SPS Assurance page for FBO PHR number
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify dynamic name '<Business selection>' on eligibility task on SPS Assurance page with '<Country>'

	Examples:
    | logininfo | Country | FBONumber | Business selection                             |
    | test      | England | testFBO   | ABC ACCOUNTANCY & MARKETING SERVICES LTD.      |
