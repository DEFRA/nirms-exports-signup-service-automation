@Regression
Feature: Business Registered Address 

Add Business Registered Address

Scenario Outline: Add Business Address
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	When  user navigates to registered address page
	And   user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	Then  click on save and continue on Address page
	And   user verify the address status 'COMPLETED'
	Examples: 
	| logininfo |  AddressLine1 | Town     | AddrPostcode | Country |
	| test      | testAddress1  | testCity | wd19 7pf     | England |

Scenario Outline: Verify the error message when user do not select the address fields
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	When  user navigates to registered address page
	And   user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	Then  click on save and continue on Address page
	And   user verifies address error message
	| Key         | Value				  |
	| Adddress    | Enter address line 1. |
	| Town        | Enter a town or city. |
	| Postcode    | Enter a post code.    |
	Examples: 
	| logininfo |  AddressLine1 | Town     | AddrPostcode | Country  |
	| test      |				|		   |			  | England  |

	
Scenario: Verify error message for invalid address data
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	When  user navigates to registered address page
	And   user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	Then  click on save and continue on Address page
	And   user verifies invalid error message for address data
	| Key             | Value                                                                                |
	| Adddress Line 1 | Enter address line 1 using only letters, numbers, hyphens (-) and apostrophes (').   |
	| Town            | Enter a town or city using only letters, numbers, hyphens (-) and apostrophes (').   |
	| Postcode        | Enter a real postcode.                                                               |
	Examples: 
	| logininfo |  AddressLine1 | Town     | AddrPostcode | Country  |
	| test      |  ****         | *****    | *****        | England  |

Scenario Outline: Verify back button is navigated to tasklist page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	When  user navigates to registered address page
	And   user clicks back button Business address page
	Then  user  navigates back to task list page from Address page
		Examples: 
	| logininfo   | Country  |
	|	test      | England  |

@ignore
Scenario Outline:Verify save and continue later navigating to tasklist page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   click on check eligibilty task
	And   complete eligibility task with '<Country>'
	Then  Verify eligibility task status as 'COMPLETED'
	When  user navigates to registered address page
	And   user clicks back button Business address page
	Then  user  navigates back to task list page from Address page
		Examples: 
	| logininfo   | Country  |
	|	test      | England  |
