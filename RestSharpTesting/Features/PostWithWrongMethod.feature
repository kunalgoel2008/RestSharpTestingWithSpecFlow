Feature: Post With Wrong Method

Scenario: Verify status code of createUser with Wrong Method
	Given I perform GET operation for "createUser" without body
	Then I should see the "StatusCode" For POST as "405"
