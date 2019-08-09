Feature: Get User By Id and Wrong URL

Scenario: Verify status code of getUsersById with wrong URL
	Given I perform GET operation for "getUsersss/{id}"
	And I perform operation for ID "1"
	Then I should see the "StatusCode" as "404"