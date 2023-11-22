@Regression
Feature: FooterLinks

Verify Footer links on SUS


Scenario Outline: Verify Footer links and pages on Sign up page
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
    And   complete eligibility task with '<Country>', '<PHRNumber>' country and PHR no
	Then  verify next page '<nextPage>' is loaded
	Then  verify privacy link '<Privacy Link 1>' '<Privacy Link 2>' in the page footer
	Then  Close Current tab
	Then  switch to previous tab
	Then  verify cookies '<Cookies Link 1>' '<"">' link in the page footer
	Then  Close Current tab
	Then  switch to previous tab
	Then  verify accessibility '<Accessbility Link 1>' '<Acessibility Link 2>' link in the footer page
	Then  Close Current tab
	Then  switch to previous tab
	Then  verify contact link '<Contact Link 1>' '<Contact Link 2>' in the footer page
	Then  Close Current tab
	Then  switch to previous tab
	Then  verify TCs link '<TCs Link 1>' '<TCs Link 2>' in the footer page
	Then  Close Current tab
	Then  switch to previous tab

Examples: 
    | logininfo | Country | PHRNumber |Business selection                         |nextPage | Privacy Link 1              | Privacy Link 2                               |Cookies Link 1									|Accessbility Link 1							|Accessbility Link 2                       |Contact Link 1											| Contact Link 2            |TCs Link 1           |TCs Link 2                 |
    | test      | England | testPHR   |ABC ACCOUNTANCY & MARKETING SERVICES LTD.  |Sign up  |data.protection@defra.gov.uk | DefraGroupDataProtectionOfficer@defra.gov.uk |website for the Information Commissioner Office   |Department for Environment Food & Rural Affairs|advice on making your device easier to use|Northern Ireland Retail Movement Scheme guidance notes  |Find out about call charges|customs requirements |SPS Regulation EU 2023/1231|



Scenario Outline: Verify text and Logo on the footer of Sign up page
    Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
    And   complete eligibility task with '<Country>', '<PHRNumber>' country and PHR no
	Then  verify next page '<nextPage>' is loaded
	Then  verify text and link in the footer page
	Then  verify the logo in the page footer


Examples: 
    | logininfo | Country | PHRNumber |Business selection                         |nextPage | 
    | test      | England | testPHR   |ABC ACCOUNTANCY & MARKETING SERVICES LTD.  |Sign up  |
