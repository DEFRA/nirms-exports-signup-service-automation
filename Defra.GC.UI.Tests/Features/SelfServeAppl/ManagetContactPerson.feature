@SelfServeRegression
Feature: ManageContactPerson

Manage Contact Person

Background: 
	Given Clear Database for user 'test1B'
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo 'test1B'
	And   select business to sign up 'TestEnv4'
	And   complete eligibility task with 'England'
	Then  verify eligibility task status as 'COMPLETED'
	And   user verify the selected business name 'TestEnv4'
	When  click on FBOorPHRNumber task
	And   enter FBO number 'testFBO' for FBO or PHR number task
	And   click Save and return to dashboard
	Then  verify FBOorPHRNumber task status as 'COMPLETED'
	And   user verify the business contact details status 'NOT STARTED'
    And   user verify the Authorised Signatory status 'CANNOT START YET'
    And   user verify the Points of departure status 'NOT STARTED'
	And   verify Check answers and submit sign up status 'CANNOT START YET'
	When  complete Business contact details task with 'contactName', 'contactPosition', 'test@test.com', '01234 234 455'
	Then  user verify the business contact details status 'COMPLETED'
    And   user verify the Authorised Signatory status 'NOT STARTED'
	When  complete contact person Authorised Signatory with Yes Authorisation
	When  complete Points of departure with 'EstablishmentName', 'AddressLine1', 'London', 'England', 'SE1 7PB'
	Then  user verify the Points of departure status '1 ADDED'
	And   click on Check answers and submit sign up
	And   verify next page 'Check your answers' is loaded 
	When  click on continue button
	Then  verify next page 'Terms and conditions' is loaded
	Then  click on the confirm check box on Terms and conditions page
	Then  click on submit sign up
	Then  verify  'You have successfully submitted a request to sign up for the Northern Ireland Retail Movement Scheme' on completed sign up page
	Then  verify  'We will review your sign-up request and email you with the outcome within 5 working days.' outcome of my request submission page
	Then  click on signout button and verify the signout message


	Scenario: Update contact person
	Given Approve Sign up request for org '<Business selection>'
	And   that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
    Then  verify Contact Person date format 'Added' on self serve dashboard
    When  click on contact person change link
	And   enter contact person Name '<UpdatedName>'
	And   enter contact person Position '<UpdatedPosition>'
	And   enter contact person Email address '<UpdatedEmailAddress>'
	And   enter contact person Telephone number '<UpdatedTelephoneNumber>'
	And   click on save contact person details
	Then  verify contact person details as '<UpdatedName>', '<UpdatedPosition>', '<UpdatedEmailAddress>', '<UpdatedTelephoneNumber>'
    And   verify Contact Person date format 'Updated' on self serve dashboard

	Examples: 
	| logininfo | Business selection | UpdatedName     | UpdatedPosition    | UpdatedEmailAddress   | UpdatedTelephoneNumber |
	| test1B    | TestEnv4           | TestNameChange  | TestPositionChange | Changedemail@test.com | 01632 960 001          |


	Scenario: Verify error messages for blank contact person fields
	Given Approve Sign up request for org '<Business selection>'
	And   that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
    And   click on contact person change link
	And   enter contact person Name '<UpdatedName>'
	And   enter contact person Position '<UpdatedPosition>'
	And   enter contact person Email address '<UpdatedEmailAddress>'
	And   enter contact person Telephone number '<UpdatedTelephoneNumber>'
	And   click on save contact person details
	Then  verify error messages '<Message1>', '<Message2>', '<Message3>', '<Message4>'

	Examples: 
	| logininfo | Business selection | UpdatedName | UpdatedPosition | UpdatedEmailAddress   | UpdatedTelephoneNumber | Message1     | Message2               | Message3         | Message4                 |
	| test1B    | TestEnv4           |             |                 |                       |                        | Enter a name | Enter an email address | Enter a position | Enter a telephone number |


	Scenario: Verify error messages for invalid contact person fields
	Given Approve Sign up request for org '<Business selection>'
	And   that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
    And   click on contact person change link
	And   enter contact person Name '<UpdatedName>'
	And   enter contact person Position '<UpdatedPosition>'
	And   enter contact person Email address '<UpdatedEmailAddress>'
	And   enter contact person Telephone number '<UpdatedTelephoneNumber>'
	And   click on save contact person details
	Then  verify error messages '<Message1>', '<Message2>', '<Message3>', '<Message4>'

	Examples: 
	| logininfo | Business selection | UpdatedName  | UpdatedPosition  | UpdatedEmailAddress                                                                                      | UpdatedTelephoneNumber  | Message1                                                | Message2                                               | Message3                                                                                                                        | Message4                                                                        |
	| test1B    | TestEnv4           | TestName%    | Test1()%         | test@gmail.com!"£$%^&*())_+<>?<NBXCVDDDDDDDDDDDDDDDDDdDDDDDDDDDDDDDdSGSSSSSSSSSSSSsGGGGGDGERHFGHFGHHFHFGH| 01632 960 001%          | Enter a name using only letters, hyphens or apostrophes | The email address cannot be longer than 100 characters | Enter a position using only letters, numbers, brackets, full stops, commas, hyphens, underscores, forward slashes or ampersands | Enter a telephone number, like 01632 960 001, 07700 900 982 or +44 808 157 0192 |

	Scenario: Verify Cancel link on update contact person page
	Given Approve Sign up request for org '<Business selection>'
	And   that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
    And   click on contact person change link
	And   click on cancel link
	Then  verify dynamic name '<Business selection>' in title '<nextPage>' of page

	Examples: 
	| logininfo | Business selection   |nextPage                                |
	| test1B    | TestEnv4             |Northern Ireland Retail Movement Scheme |


	Scenario: Verify Back link on update contact person page
	Given Approve Sign up request for org '<Business selection>'
	And   that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
    And   click on contact person change link
	And   click on back link
	Then  verify dynamic name '<Business selection>' in title '<nextPage>' of page

	Examples: 
	| logininfo | Business selection   |nextPage                                |
	| test1B    | TestEnv4             |Northern Ireland Retail Movement Scheme |