Feature: Post Without Body

Scenario: Verify status code of createUser without body
	Given I perform POST operation for "createUser" without body
	Then I should see the "StatusCode" For POST as "400"