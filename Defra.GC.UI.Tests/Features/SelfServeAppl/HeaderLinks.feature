 @SelfServeRegression
Feature: HeaderLinks

Self serve header page
	
	
	Scenario: Check header page links
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	Then  verify Manage Account Link
	And   verify Add New Account Link
	Then  switch to previous tab
	Then  click on the feedback link
	Then  switch to next opened tab
	Then  verify feedback page is loaded
	Then  switch to previous tab
	Then  click on signout button and verify the signout message
	#Then  switch to next opened tab
	When  that I navigate to the NI GC application
	Then  sign in to self serve with valid credentials with logininfo '<logininfo>'
	Then  Click on GOV.UK link in the header of the page
	Then  verify generic GOV page is loaded

	Examples: 
	| logininfo | Business selection |
	| test1B    | TestEnv4           |
