Feature: Delete User

Scenario: Verify status code of deleteUsers
	Given I perform DELETE operation for "deleteUsers/{id}"
	And I perform operation to ID "18"
	Then I should see the "StatusCode" for DELETE as "200"