@Regression
Feature: Provide Feedback on the SuS

@RunOnly
Scenario: Verify Provide Feedback link opens iin new tab
	#Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	Then click on the feedback link
	Then  switch to next opened tab
	Then  verify feedback page is loaded
	Examples: 
	| logininfo | Business selection                       | 
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| 