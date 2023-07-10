﻿@Regression
Feature: Error Validation Point Of Destination Establishment

Error Validation Point Of Destination Establishment

Scenario: Verify validation error message for blank Destination Establishment postcode field
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
    When  click on points of destination link
	#And   enter Establishment postcode '<postcode>'
	#Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Country          | FBONumber | postcode | errorMessage      |
	| test      | Northern Ireland | testFBO   |          | Enter a postcode. |


Scenario: Verify valid error messages for point of Destination mandatory fields
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	#And   enter Establishment postcode '<postcode>'
	#And   click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	Then  verify error message '<errorMessage>' on establishment page

	Examples: 
	| logininfo | Country          | FBONumber |postcode | EstablishmentName | AddressLine1 | estCity    | estCountry  | AddrPostcode  | errorMessage                                     |
	| test      | Northern Ireland | testFBO   |EC4R 9HA |                   | testAddress1 | testCity   | testCountry | SE10 9NF      | Enter establishment name                         |
	| test      | Northern Ireland | testFBO   |EC4R 9HA | testName          |              | testCity   | testCountry | SE10 9NF       | Enter address line 1                             |
	| test      | Northern Ireland | testFBO   |EC4R 9HA | testName          | testAddress1 |            | testCountry | SE10 9NF       | Enter a town or city                             |
	| test      | Northern Ireland | testFBO   |EC4R 9HA | testName          | testAddress1 | testCity   | testCountry |               | Enter a post code                                |
	| test      | Northern Ireland | testFBO   |EC4R 9HA | testName$%        | testAddress1 | testCity   | testCountry | SE10 9NF       | Enter establishment name using only letters      |
	| test      | Northern Ireland | testFBO   |EC4R 9HA | testName          | testAddr%$   | testCity   | testCountry | SE10 9NF       | Enter address line 1 using only letters, numbers |
	| test      | Northern Ireland | testFBO   |EC4R 9HA | testName          | testAddress1 | testCity%$ | testCountry | SE10 9NF       | Enter a town or city using only letters, numbers |
	| test      | Northern Ireland | testFBO   |EC4R 9HA | testName          | testAddress1 | testCity   | testCountry | SE10 9NF$%    | Enter a real postcode.                           |


Scenario: Verify error message on add another point of Destination page
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	And   complete eligibility task with '<Country>', '<FBONumber>'
	Then  verify eligibility task status as 'COMPLETED'
	When  click on points of destination link
	#And   enter Establishment postcode '<AddrPostcode>'
	#And   click on cannot find establishment link 
	#And   click on the add establishment address manually link
	And   add establishment address manually with fields '<EstablishmentName>', '<AddressLine1>', '<estCity>', '<estCountry>', '<AddrPostcode>'
	And   add establishment email address 'test1@test.com'
	And   click on save and continue
	Then  verify error message '<errorMessage>' on establishment page
	Examples: 
	| logininfo | Country          | FBONumber | EstablishmentName | AddressLine1 | estCity   | estCountry   | AddrPostcode | errorMessage                                             |  
	| test      | Northern Ireland | testFBO   | testName1         | testAddress1 | testCity1 | testCountry1 | EC4R 9HA     | Select yes if you want to add another place of destination  |

