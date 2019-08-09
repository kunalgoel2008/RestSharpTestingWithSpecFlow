Feature: Get User By ID
	Test GET posts operations with Resrsharp.net

Scenario: Verify status code of getUsersById
	Given I perform GET operation for "getUsers/{id}"
	And I perform operation for ID "1"
	Then I should see the "StatusCode" as "200"