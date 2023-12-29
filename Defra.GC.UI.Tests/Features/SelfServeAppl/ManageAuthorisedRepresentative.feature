@SelfServeRegression @RunOnly
Feature: ManageAuthorisedRepresentative

Manage Authorised Representative

#Background: 
#	Given Clear Database for user 'test1C'
#	Given that I navigate to the NI GC application
#	When  sign in with valid credentials with logininfo 'test1C'
#	And   select business to sign up 'Tesco York'
#	And   complete eligibility task with 'England'
#	Then  verify eligibility task status as 'COMPLETED'
#	And   user verify the selected business name 'Tesco York'
#	When  click on FBOorPHRNumber task
#	And   enter FBO number 'testFBO' for FBO or PHR number task
#	And   click Save and return to dashboard
#	Then  verify FBOorPHRNumber task status as 'COMPLETED'
#	And   user verify the business contact details status 'NOT STARTED'
#    And   user verify the Authorised Signatory status 'CANNOT START YET'
#    And   user verify the Points of departure status 'NOT STARTED'
#	And   verify Check answers and submit sign up status 'CANNOT START YET'
#	When  complete Business contact details task with 'contactName', 'contactPosition', 'test@test.com', '01234 234 455'
#	Then  user verify the business contact details status 'COMPLETED'
#    And   user verify the Authorised Signatory status 'NOT STARTED'
#	When  complete contact person Authorised Signatory with Yes Authorisation
#	When  complete Points of departure with 'EstablishmentName', 'AddressLine1', 'London', 'England', 'SE10 9NF'
#	Then  user verify the Points of departure status '1 ADDED'
#	And   click on Check answers and submit sign up
#	And   verify next page 'Check your answers' is loaded 
#	When  click on continue button
#	Then  verify next page 'Terms and conditions' is loaded
#	Then  click on the confirm check box on Terms and conditions page
#	Then  click on submit sign up
#	Then  verify  'You have successfully submitted a request to sign up for the Northern Ireland Retail Movement Scheme' on completed sign up page
#	Then  verify  'We will review your sign-up request and email you with the outcome within 5 working days.' outcome of my request submission page
#	Then  click on signout button and verify the signout message

	Scenario: Verify submitted date for Authorised Representative
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
    Then  verify Authorised Representative date format 'Submitted on' on self serve dashboard
	Examples: 
	| logininfo | Business selection   |
	| test1C    | Tesco York           |

	Scenario: Update Authorised Representative
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
    And   click on Authorised Representative change link
	And   enter Authorised Representative Name '<UpdatedName>'
	And   enter Authorised Representative Position '<UpdatedPosition>'
	And   enter Authorised Representative Email address '<UpdatedEmailAddress>'
	And   click on save Authorised Representative details
	Then  verify Authorised Representative details as '<UpdatedName>', '<UpdatedPosition>', '<UpdatedEmailAddress>'
    And   verify Authorised Representative date format 'Last updated' on self serve dashboard

	Examples: 
	| logininfo | Business selection | UpdatedName | UpdatedPosition       | UpdatedEmailAddress   | 
	| test1C    | Tesco York         | TestName    | TestPosition          | Changedemail@test.com |


	Scenario: Verify error messages for blank Authorised Representative fields
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
    And   click on Authorised Representative change link
	And   enter Authorised Representative Name '<UpdatedName>'
	And   enter Authorised Representative Position '<UpdatedPosition>'
	And   enter Authorised Representative Email address '<UpdatedEmailAddress>'
	And   click on save Authorised Representative details
	And   verify error messages '<Message1>', '<Message2>', '<Message3>', '<Message4>'

	Examples: 
	| logininfo | Business selection | UpdatedName | UpdatedPosition | UpdatedEmailAddress   | Message1     | Message2               | Message3         | Message4                 |
	| test1C    | Tesco York         |             |                 |                       | Enter a name | Enter an email address | Enter a position | Confirm that has read and understood the terms and conditions |


	Scenario: Verify error messages for invalid Authorised Representative fields
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
    And   click on Authorised Representative change link
	And   enter Authorised Representative Name '<UpdatedName>'
	And   enter Authorised Representative Position '<UpdatedPosition>'
	And   enter Authorised Representative Email address '<UpdatedEmailAddress>'
	And   click on save Authorised Representative details
	And   verify error messages '<Message1>', '<Message2>', '<Message3>', '<Message4>'

	Examples: 
	| logininfo | Business selection | UpdatedName  | UpdatedPosition  | UpdatedEmailAddress    | Message1     | Message2               | Message3         | Message4                 |
	| test1C    | Tesco York         | TestName%    | Test1()%         | Changedemail%@test.com | Enter a name using only letters, hyphens or apostrophes | Enter an email address in the correct format, like name@example.com | Enter a position using only letters, numbers, brackets, full stops, commas, hyphens, underscores, forward slashes or ampersands | has read and understood the terms and conditions|

	Scenario: Verify Cancel link on update Authorised Representative page
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
    And   click on Authorised Representative change link
	And   click on cancel link
	Then  verify dynamic name '<Business selection>' in title '<nextPage>' of page

	Examples: 
	| logininfo | Business selection   |nextPage                                |
	| test1C    | Tesco York           |Northern Ireland Retail Movement Scheme |


	Scenario: Verify Back link on update Authorised Representative page
	Given that I navigate to the NI GC application
	When  sign in to self serve with valid credentials with logininfo '<logininfo>'
	And   select business '<Business selection>' on self serve dashboard 
    And   click on Authorised Representative change link
	And   click on back link
	Then  verify dynamic name '<Business selection>' in title '<nextPage>' of page

	Examples: 
	| logininfo | Business selection   |nextPage                                |
	| test1C    | Tesco York           |Northern Ireland Retail Movement Scheme |
