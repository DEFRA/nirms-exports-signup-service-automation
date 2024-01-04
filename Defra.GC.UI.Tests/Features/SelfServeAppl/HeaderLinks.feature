@SelfServeRegression
Feature: HeaderLinks

Self serve header page

	Scenario: Check header page links
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'

	Examples: 
	| logininfo | Business selection |
	| test1B    | Tesco London       |
