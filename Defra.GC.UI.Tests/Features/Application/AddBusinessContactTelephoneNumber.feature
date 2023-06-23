﻿@Regression
Feature: AddBusinessContactTelephoneNumber

Add Contact telephone number

@CrossBrowser
Scenario: Add contact Telephone Number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   click on contact telephone number link
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue on Contact Number page
	And   verify next page '<nextPage>' is loaded 

	Examples: 
	| logininfo | Country | FBONumber | telephoneNumber | nextPage |
	| test      | England | testFBO   | 01632 960 001   | Sign up  |


Scenario: Verify error message for invalid contact Telephone Number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
    And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   click on contact telephone number link
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue on Contact Number page
	And   verify error message '<errorMessage>' on contact telephone number page
	Examples: 
	| logininfo | Country  |FBONumber |telephoneNumber | errorMessage                                     |
	| test      | England  |testFBO   |abc123          | Enter a telephone number in the correct format   |


Scenario: Verify error message for blank contact telephone number
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   click on contact telephone number link
	And   enter telephone number '<telephoneNumber>'
	And   click on save and continue on Contact Number page
	And   verify error message '<errorMessage>' on contact telephone number page
	Examples: 
	| logininfo | Country  |FBONumber |telephoneNumber | errorMessage                                  |
	| test      | England  |testFBO   |                | Enter the phone number of the contact person  |


Scenario: Verify back link on contact telephone number page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   navigate to task list page
	And   click on contact telephone number link
	And   click on back link
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |Country  |FBONumber |
	| test      |England  |testFBO   |

@Ignore
Scenario: Verify save and continue later on contact telephone number page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	And   navigate to task list page
	And   click on contact telephone number link
	And   click save and continue later
	And   verify signUp task list page is loaded
	Examples: 
	| logininfo |Country  |FBONumber |
	| test      |England  |testFBO   |