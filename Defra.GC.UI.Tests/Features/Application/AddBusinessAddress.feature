@Regression
Feature: Address 

Sign in to General Certificate Page and add Address

Scenario Outline: Add Business Address
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When user navigates to registered address page
	And user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	Then click on save and continue on Address page
	And user verify the address status
	Examples: 
	| logininfo |  AddressLine1 | Town     | AddrPostcode |
	| test      | testAddress1 | testCity | wd19 7pf     |

	Scenario Outline: Verify the error message when  user do not select the address fields
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	When user navigates to registered address page
	And user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	Then user verifies address error message
	| Key      | Value      |
	| Adddress    | Enter address line 1.    |
	| Town      | Enter a town or city.      |
	| Postcode      | Enter a post code.    |
	Examples: 
	| logininfo |  AddressLine1 | Town     | AddrPostcode |
	| test      |  |  |    |

	
	Scenario: Verify error message for invalid address data
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When user navigates to registered address page
	And user enters manually all address fields  '<AddressLine1>', '<Town>',  '<AddrPostcode>'
	Then user verifies invalid error message for address data
	| Key      | Value      |
	| Adddress Line 1   | Enter address line 1 using only letters, numbers, hyphens (-) and apostrophes (').    |
	| Town      | Enter a town or city using only letters, numbers, hyphens (-) and apostrophes (').     |
	| Postcode     | Enter a real postcode.|
		
	Examples: 
	| logininfo |  AddressLine1 | Town     | AddrPostcode |
	| test      | **** | ***** | *****     |

	Scenario Outline: Verify back button is navigated to tasklist page
	Given that I navigate to the NI GC application
	Then  sign in with valid credentials with logininfo '<logininfo>'
	When user navigates to registered address page
	When user clicks back button Business address page
	Then user  navigates back to task list page from Address page
		Examples: 
	| logininfo |
	|	test      |


	#Scenario Outline: Navigate to General Certificate Page and Clickiing save and continue button navigates back to tasklist page
	##Given that I navigate to the NI GC application
	##Then  sign in with valid credentials with logininfo '<logininfo>'
	#When user navigates to registered address page
	#When user clicks on Save and continue later link
	
#
#	Examples: 
#	| logininfo |
#	| test      |
