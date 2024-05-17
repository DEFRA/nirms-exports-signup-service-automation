@Regression @RunOnly
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
	And   click on save and continue
	Then  verify next page '<nextPage1>' is loaded

Examples: 
    | logininfo | Business selection   | Country | FBONumber  | nextPage                                                                |nextPage1                                                            |
    | test      | TestEnv1             | England |            | Food Business Operator (FBO) or Plant Health Registration (PHR) number? |Your business must have an FBO or a PHR number to sign up for NIRMS  |


Scenario Outline: Verify back link on Assurance FBO page is going back to Task list page
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	When  click on FBOorPHRNumber task
	And   click on back to dashboard link
	Then  verify next page '<nextPage>' is loaded

	Examples: 
    | logininfo | Country | nextPage                                   | Business selection   |
    | test      | England | Sign up for the NI Retail Movement Scheme  | TestEnv1             |


Scenario Outline: Verify error message for invalid FBO Number
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	When  click on FBOorPHRNumber task
	And   enter invalid FBO '<FBONumber>'
	Then  verify error message '<errorMessage>' on  SPS_Assurance page
	When  enter invalid FBO '<FBONumber1>'
	Then  verify error message '<errorMessage1>' on  SPS_Assurance page

	Examples: 
    | logininfo | Country | FBONumber       | FBONumber1                    | errorMessage                                               | errorMessage1                            | Business selection |
    | test      | England | *************** | FBO1234567890abcdefghigklmnop | Enter an FBO number using only letters, numbers or hyphens | FBO number must be 25 characters or less | TestEnv1           |



Scenario: Verify error message for invalid PHR number
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	When  click on FBOorPHRNumber task
	And   enter invalid PHR '<PHRNumber>'
	Then  verify error message '<errorMessage>' on  SPS_Assurance page
	When  enter invalid PHR '<PHRNumber1>'
	Then  verify error message '<errorMessage1>' on  SPS_Assurance page

	Examples: 
    | logininfo | Country | PHRNumber       | errorMessage                                                      | PHRNumber1                    | errorMessage1                            | Business selection |
    | test      | England | *************** | Enter a PHR number using only letters, numbers, spaces or hyphens | PHR1234567890abcdefghigklmnop | PHR number must be 25 characters or less | TestEnv1           |


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
    | logininfo | Country | PHRNumber |Business selection   |nextPage                           | 
    | test      | England | testPHR   |TestEnv1             |Who is the contact person for the  |


#Scenario Outline: Complete FBO or PHR number task with no FBO or PHR number option 
#    Given Clear Database for user '<logininfo>'
#	And   that I navigate to the NI GC application
#	When  sign in with valid credentials with logininfo '<logininfo>'
#	And   select business to sign up '<Business selection>'
#	And   complete eligibility task with '<Country>'
#	Then  verify next page '<nextPage2>' is loaded
#	When  click on FBOorPHRNumber task
#	Then  verify next page '<nextPage>' is loaded
#    When  complete FBO or PHR number task without FBO or PHR Number
#	And   click on save and continue  
#	Then  verify next page '<nextPage1>' is loaded
#
#Examples: 
#    | logininfo | Business selection   | Country | nextPage                                                                       | nextPage1                                  | nextPage2 |
#    | test      | TestEnv1             | England | have a Food Business Operator (FBO) or Plant Health Registration (PHR) number? | You can still submit a sign-up request now | Sign up   |


Scenario Outline: Verify back on Your business must have an FBO or a PHR number to sign up for NIRMS page
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	Then  verify next page '<nextPage2>' is loaded
	When  click on FBOorPHRNumber task
	Then  verify next page '<nextPage>' is loaded
    When  complete FBO or PHR number task without FBO or PHR Number
	And   click on save and continue
	And   click on back link
	Then  verify next page '<nextPage>' is loaded 
	When  complete FBO or PHR number task without FBO or PHR Number
	And   click on save and continue
	And   click return to dashboard
	Then  verify next page '<nextPage2>' is loaded

Examples: 
    | logininfo | Business selection | Country | nextPage1                                                           | nextPage                                                                       | nextPage2 |
    | test      | TestEnv1           | England | Your business must have an FBO or a PHR number to sign up for NIRMS | have a Food Business Operator (FBO) or Plant Health Registration (PHR) number? | Sign up   |


Scenario: Verify error message for no radiobutton selected on FBO PHR page
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	When  click on FBOorPHRNumber task
	Then  verify next page '<nextPage>' is loaded 
	Then  click on save and continue
	Then  verify error message '<errorMessage>' on  SPS_Assurance page

	Examples: 
    | logininfo | Country | PHRNumber       | errorMessage									     | Business selection  |nextPage                                                                        |
    | test      | England | *************** | Select if your business has an FBO or PHR number   | TestEnv1            |have a Food Business Operator (FBO) or Plant Health Registration (PHR) number?  |


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
    | logininfo | Country |Business selection   |nextPage														                    |hintText								   															     |
    | test      | England |TestEnv1             |have a Food Business Operator (FBO) or Plant Health Registration (PHR) number?   |You will have an FBO number if you’ve registered with your local authority for a food business licence. |


Scenario Outline: Verify Save and return to dashboard button is displayed on selecting FBO and PHR options
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   complete eligibility task with '<Country>'
	When  click on FBOorPHRNumber task
	Then  verify next page '<nextPage>' is loaded
	When  enter FBO number '<FBONumber>' for FBO or PHR number task
	Then  verify Save and return to dashboard button is displayed
	When  enter PHR number '<PHRNumber>' for FBO or PHR number task
	Then  verify Save and return to dashboard button is displayed
	When  complete FBO or PHR number task without FBO or PHR Number
	Then  verify Save and return to dashboard button is not displayed for No FBO or PHR option

	Examples:
    | logininfo | Country | FBONumber | Business selection    |nextPage                                                                       |PHRNumber|
    | test      | England | testFBO   | TestEnv1              |have a Food Business Operator (FBO) or Plant Health Registration (PHR) number? |testPHR  |
