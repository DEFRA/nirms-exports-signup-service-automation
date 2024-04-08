@SelfServeRegression @RunOnly
Feature: FooterLinks

Self serve footer page

	Scenario: Check footer page links
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   click privacy link on footer page
	And   switch to next opened tab
	Then  verify the page title in Footer page '<Privacy page title>'
	And   verify the link in Footer page details '<Privacy Link 1>'
	And   verify the link in Footer page details '<Privacy Link 2>'
	And   Close Current tab
	And   switch to previous tab
	When  click cookies link on footer page
	And   switch to next opened tab
	Then  verify the page title in Footer page '<Cookies page Title>'
	And   verify the link in Footer page details '<Cookies Link 1>'
	Then  Close Current tab
	And   switch to previous tab
	When  click accessibility link on footer page
	And   switch to next opened tab
	Then   verify the page title in Footer page '<Accessibility page title>'
	And   verify the link in Footer page details '<Accessibility Link 1>'
	And   verify the link in Footer page details '<Accessibility Link 2>'
	And   Close Current tab
	And   switch to previous tab
	When  click contact link on footer page
	And   switch to next opened tab
	Then  verify the page title in Footer page '<Contact page title>'
	And   verify the link in Footer page details '<Contact Link 1>'
	And   verify the link in Footer page details '<Contact Link 2>'
	And   Close Current tab
	And   switch to previous tab
	When  click TCs link on footer page
	And   switch to next opened tab
	Then  verify the page title in Footer page '<TCs page title>'
	And   verify the link in Footer page details '<TCs Link 1>'
	And   verify the link in Footer page details '<TCs Link 2>'
	And   Close Current tab
	And   switch to previous tab

	Examples: 
	| logininfo | Business selection |Privacy page title|Privacy Link 1				  |Privacy Link 2                              |Cookies page Title |Cookies Link 1             |Accessibility page title              |Accessibility Link 1                           |Accessibility Link 2                      |Contact page title|Contact Link 1                                       |Contact Link 2             |TCs page title    |TCs Link 1          |TCs Link 2                 |
	| test1B    | TestEnv4           |privacy notice    |data.protection@defra.gov.uk |DefraGroupDataProtectionOfficer@defra.gov.uk|Cookies            |website for the Information|Accessibility statement for Move goods|Department for Environment Food & Rural Affairs|advice on making your device easier to use|Contact           |NI Retail Movement Scheme guidance note|Find out about call charges|Terms & Conditions|customs requirements|SPS Regulation EU 2023/1231|
