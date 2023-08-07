@Regression
Feature: VerifyTaskStatus

Verify the status of each task on Signup page

Scenario Outline: Verify status of Business Details task
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the business name status 'NOT STARTED'
	When  user is in Business name page
    And   user enters Business name  '<Business name>'
	And   click Save and return to dashboard
	Then  user verify the business name status 'IN PROGRESS'
	When  user is in Business name page
	And   click on save and continue
	And   user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	And   click Save and return to dashboard
	Then  user verify the business name status 'COMPLETED'

	Examples: 
	| logininfo | Business selection | Country | FBONumber | nextPage                                                | Business name    | AddressLine1 | Town     | AddrPostcode |
	| test1     | AM                 | England | testFBO   | Sign up for the Northern Ireland Retail Movement Scheme | testBusinessname | testAddress1 | testCity | wd19 7pf     |


	Scenario: Verify status of Contact person task
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click Save and return to dashboard
	Then  user verify the business contact details status 'IN PROGRESS'
	When  click on business contact details link
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click Save and return to dashboard
	Then  user verify the business contact details status 'IN PROGRESS'
	When  click on business contact details link
	And   click on save and continue
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click Save and return to dashboard
	Then  user verify the business contact details status 'IN PROGRESS'
	When  click on business contact details link
	And   click on save and continue
	And   click on save and continue
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click Save and return to dashboard
	Then  user verify the business contact details status 'COMPLETED'

	Examples: 
	| logininfo | Business selection | Country | FBONumber | contactName     | contactPosition | emailAddress  | telephoneNumber |
	| test1     |  AM                | England | testFBO   | testContactName | testPosition    | test@test.com | 01632 960 001   |


Scenario: Verify status of Authorised Signatory task with Yes Authorisation
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   select 'Yes' to the contact person is the Authorised Signatory without save
	And   click Save and return to dashboard
	Then  user verify the Authorised Signatory status 'COMPLETED'

	Examples: 
	| logininfo | Business selection   | Country | FBONumber |
	| test1     | AM                   | England | testFBO   |
	

Scenario: Verify status of Authorised Signatory task with No Authorisation
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on Authorised Signatory link
	And   select 'No' to the contact person is the Authorised Signatory without save
	And   click Save and return to dashboard
	Then  user verify the Authorised Signatory status 'IN PROGRESS'
	When  click on Authorised Signatory link
	And   click on save and continue
	And   user is on Authorised Signatory Enter name page
	And   user enters manually '<fullName>' in the full name feild
	And   click Save and return to dashboard
	Then  user verify the Authorised Signatory status 'IN PROGRESS'
	When  click on Authorised Signatory link
	And   click on save and continue
	And   click on save and continue
	And   user enters '<Authposition>' position on Authorised signatory position page
	And   click Save and return to dashboard
	Then  user verify the Authorised Signatory status 'IN PROGRESS'
	When  click on Authorised Signatory link
	And   click on save and continue
	And   click on save and continue
	And   click on save and continue
	And   user is on Authorised Signatory Email address page
    And   user enters manually '<emailAddress>' in email address page
	And   click Save and return to dashboard
	Then  user verify the Authorised Signatory status 'COMPLETED'

	Examples: 
	| logininfo | Business selection | Country | FBONumber | fullName  | emailAddress   | Authposition |
	| test1     | AM                 | England | testFBO   | test name | test@gmail.com | administrator|


Scenario: Verify the status of Check answers and submit sign task
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   select business to sign up '<Business selection>'
	And   click on eligibility task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  user is in Business name page
    And   user enters Business name  '<Business name>'
	And   click Save and return to dashboard
	When  user is in Business name page
	And   click on save and continue
	And   user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	And   click Save and return to dashboard
	Then  user verify the business name status 'COMPLETED'
	When  click on Authorised Signatory link
	And   select 'Yes' to the contact person is the Authorised Signatory without save
	And   click Save and return to dashboard
	Then  user verify the Authorised Signatory status 'COMPLETED'
	When  click on Authorised Signatory link
	And   select 'No' to the contact person is the Authorised Signatory without save
	And   click Save and return to dashboard
	Then  user verify the Authorised Signatory status 'IN PROGRESS'
	When  click on points of departure link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on I have finished adding points of departure
	And   click Save and return to dashboard
	Then  user verify the Points of departure status 'COMPLETED'
	And   verify Check answers and submit sign up status 'CANNOT START YET'

	Examples: 
	| logininfo | Business selection | Country | FBONumber | contactName | EstablishmentName | AddressLine1 | estCity | estCountry | AddrPostcode |
	| test1     | AM                 | England | testFBO   | contactName | EstName1          | testAddress1 | London  | England    | SE9 0AW      |
