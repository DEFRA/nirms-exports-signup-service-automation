@Regression
Feature: VerifyManageAccountLink

Verify Manage Account Link

   @SmokeTest
Scenario: Verify Manage Account Link
	Given that I navigate to the NI GC application
	When  sign in with valid credentials with logininfo '<logininfo>'
	Then  verify Manage Account Link
	And   verify Add New Account Link

Examples:
    | logininfo |
    | test      |

