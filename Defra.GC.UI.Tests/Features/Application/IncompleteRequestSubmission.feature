@Regression
Feature: Incomplete Request submission feature


Scenario: Verify tasklist page is displayed with missing info from check your answers page 
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>' with save and continue
	Then  verify next page '<nextPage2>' is loaded 
	When  complete contact person Authorised Signatory with Yes Authorisation with save and continue
	Then  verify next page '<nextPage3>' is loaded 
	And   enter Establishment postcode '<AddrPostcode>'
	Then  click on select address button
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	When  click on back to dashboard link
	Then  verify next page '<nextPage4>' is loaded
	Then  open check your answers in different tab
	Then  click on points of departure link
	When  remove establishment address '<EstablishmentName>'
	Then  switch to next opened tab
	When  click on continue button
	Then  verify next page '<nextPage4>' is loaded

	Examples: 
	| logininfo | Business selection                       | Country | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage1                 | nextPage2                     | nextPage3   | nextPage4 |
	| test      | ABC ACCOUNTANCY & MARKETING SERVICES LTD.| England | testFBO   | testName      | testAddress | London | SE10 9NF     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName1      | testAddress1 | London  | England    | Who is the contact person | the authorised representative | of dispatch | Sign up   |


Scenario: Verify tasklist page is displayed with with missing info from Terms & Conditions page 
	Given Clear Database for user '<logininfo>'
	And   that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  complete Business contact details task with '<contactName>', '<contactPosition>', '<emailAddress>', '<telephoneNumber>' with save and continue
	Then  verify next page '<nextPage2>' is loaded 
	When  complete contact person Authorised Signatory with Yes Authorisation with save and continue
	Then  verify next page '<nextPage3>' is loaded 
	And   enter Establishment postcode '<AddrPostcode>'
	Then  click on select address button
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	When  click on back to dashboard link
	Then  verify next page '<nextPage4>' is loaded
	Then  open check your answers in different tab
	Then  switch to next opened tab
	When  click on continue button
	Then  switch to previous tab
	When  click on Authorised Signatory link
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click Save and return to dashboard
	Then  switch to next opened tab
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up
	Then  verify next page '<nextPage4>' is loaded

	Examples: 
	| logininfo | Business selection  | Country           | FBONumber | Business name | AddressLine | Town   | AddrPostcode | contactName | contactPosition | emailAddress  | telephoneNumber | EstablishmentName | AddressLine1 | estCity | estCountry | nextPage1                 | nextPage2                     | nextPage3   | nextPage4 |
	| test1A    |  Kaka               |  Northern Ireland | testFBO   | testName      | testAddress | London | BT93 8AD     | contactName | contactPosition | test@test.com | 01234 234 455   | testEstName1      | testAddress1 | London  | England    | Who is the contact person | the authorised representative | destination | Sign up   |
