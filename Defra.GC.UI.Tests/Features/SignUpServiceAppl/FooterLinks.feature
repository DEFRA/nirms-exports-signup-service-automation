@Regression 
Feature: FooterLinks

Verify Footer links on SUS


Scenario Outline: Verify Footer links and pages on Sign up page
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
	Then  verify next page '<nextPage>' is loaded
	Then  click privacy link on footer page
	Then  switch to next opened tab
	Then  verify the page title in Footer page '<Privacy page title>'
	Then  verify the link in Footer page details '<Privacy Link 1>'
	Then  verify the link in Footer page details '<Privacy Link 2>'
	Then  Close Current tab
	Then  switch to previous tab
	Then  click cookies link on footer page
	Then  switch to next opened tab
	Then  verify the page title in Footer page '<Cookies page Title>'
	Then  verify the link in Footer page details '<Cookies Link 1>'
	Then  Close Current tab
	Then  switch to previous tab
	Then  click accessibility link on footer page
	Then  switch to next opened tab
	Then  verify the page title in Footer page '<Accessibility page title>'
	Then  verify the link in Footer page details '<Accessibility Link 1>'
	Then  verify the link in Footer page details '<Accessibility Link 2>'
	Then  Close Current tab
	Then  switch to previous tab
	Then  click contact link on footer page
	Then  switch to next opened tab
	Then  verify the page title in Footer page '<Contact page title>'
	Then  verify the link in Footer page details '<Contact Link 1>'
	Then  verify the link in Footer page details '<Contact Link 2>'
	Then  Close Current tab
	Then  switch to previous tab
	Then  click TCs link on footer page
	Then  switch to next opened tab
	Then  verify the page title in Footer page '<TCs page title>'
	Then  verify the link in Footer page details '<TCs Link 1>'
	Then  verify the link in Footer page details '<TCs Link 2>'
	Then  Close Current tab
	Then  switch to previous tab

Examples: 
    | logininfo | Country | FBONumber |Business selection  |nextPage |Privacy page title|Privacy Link 1				  |Privacy Link 2                              |Cookies page Title |Cookies Link 1             |Accessibility page title              |Accessibility Link 1                           |Accessibility Link 2                      |Contact page title|Contact Link 1                                       |Contact Link 2             |TCs page title    |TCs Link 1          |TCs Link 2                 |
	| test      | England | testFBO   |TestEnv1            |Sign up  |privacy notice    |data.protection@defra.gov.uk  |DefraGroupDataProtectionOfficer@defra.gov.uk|Cookies            |website for the Information|Accessibility statement for Move goods|Department for Environment Food & Rural Affairs|advice on making your device easier to use|Contact           |NI Retail Movement Scheme guidance note|Find out about call charges|Terms & Conditions|customs requirements|SPS Regulation EU 2023/1231|



Scenario Outline: Verify text and Logo on the footer of Sign up page
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
	Then  verify next page '<nextPage>' is loaded
	Then  verify text '<FooterText>' on the page footer
	Then  verify the link in Footer page details '<FooterPageLink>'
	Then  verify the link in Footer page details '<FooterLogoLink>'


Examples: 
    | logininfo | Country | FBONumber |Business selection |nextPage | FooterText                        |FooterPageLink              |FooterLogoLink |
    | test      | England | testFBO   |TestEnv1           |Sign up  |All content is available under the |Open Government Licence v3.0|Crown copyright|
