Feature: Get All Users with Wrong Method

Scenario: Verify status code of getAllUsers with Wrong Method
	Given I perform POST operation for "getAllUsers"
	And I execute operation
	Then I should see the "StatusCode" as "405"
