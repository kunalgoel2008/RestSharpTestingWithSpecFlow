Feature: Get User By Id and Wrong Method

Scenario: Verify status code of getUsersById with Wrong Method
	Given I perform POST operation for "getUsers/{id}"
	And I perform operation for ID "1"
	Then I should see the "StatusCode" as "405"