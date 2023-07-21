@Regression
Feature: AddAuthorisedSignatoryPosition

Add Authorised Signatory Position

@CrossBrowser
Scenario: Add Authorised Signatory position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	And   user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	And   verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Business selection | Country | FBONumber | contactName     | contactPosition | fullName  | Authposition  | nextPage                              | emailAddress   | telephoneNumber |
	| test      | ACME Ltd           | England | testFBO   | testContactName | testPosition    | test Name | administrator | Email address of Authorised Signatory | test@gmail.com | 01632 960 001   |

	
Scenario: Verify error message for invalid authorised signatory position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	When  user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	Then  verify error message '<errorMessage>' on Authorised signatory position page

	Examples: 
| logininfo | Business selection  | Country | FBONumber | contactName     | contactPosition | fullName  | Authposition | emailAddress   | telephoneNumber | errorMessage                                                                |
| test      | ACME Ltd            | England | testFBO   | testContactName | testPosition    | test Name | test%        | test@gmail.com | 01632 960 001   | Position must only include letters, numbers, and special characters -_./()& |


Scenario: Verify error message for blank authorised signatory position
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	When  user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	Then  user enters '<Authposition>' position on Authorised signatory position page
	And   click on save and continue
	Then  verify error message '<errorMessage>' on business contact position page

	Examples: 
	| logininfo | Business selection | Country | FBONumber | contactName     | contactPosition | fullName  | Authposition | emailAddress   | telephoneNumber | errorMessage      |
	| test      |  ACME Ltd          | England | testFBO   | testContactName | testPosition    | test Name |              | test@gmail.com | 01632 960 001   | Enter a position. |

Scenario: Verify back link on authorised signatory position page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	When  user is on Authorised Signatory Enter name page
	Then  user enters manually '<fullName>' in the full name feild
	Then  click on save and continue
	And   click on back to dashboard link
	Then  verify next page '<previousPage>' is loaded 

	Examples: 
	| logininfo | Business selection  | Country | FBONumber | contactName     | contactPosition | fullName  | Authposition  | emailAddress   | telephoneNumber | previousPage |
	| test      | ACME Ltd            | England | testFBO   | testContactName | testPosition    | test Name | administrator | test@gmail.com | 01632 960 001   | Sign up      |


Scenario Outline:Verify save and return to dashboard on Authorised Signatory position Page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>', '<Business selection>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on business contact details link
	And   enter business contact person '<contactName>'
	And   click on save and continue
	And   enter business contact position '<contactPosition>'
	And   click on save and continue
	And   enter email address '<emailAddress>'
	And   click on save and continue
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue
	When  select 'No' to the contact person is the Authorised Signatory without save
	And   click on save and continue
	When  user is on Authorised Signatory Enter name page
	And   user enters manually '<fullName>' in the full name feild
	And   click on save and continue
	And   user enters '<Authposition>' position on Authorised signatory position page
	And   click Save and return to dashboard
	Then  verify next page '<nextPage>' is loaded 

Examples: 
	| logininfo | Business selection | Country | FBONumber | nextPage | fullName  | contactName | contactPosition | emailAddress   | telephoneNumber | Authposition  |
	| test      | ACME Ltd           | England | testFBO   | Sign up  | test name | test name   | test            | test@gmail.com | 01632 960 001   | administrator |

