Feature: Get User By Id with Wrong Data Type


Scenario: Verify status code of getUsersById with Wrong Data Type
	Given I perform GET operation for "getUsers/{id}"
	And I perform operation for ID "ABC"
	Then I should see the "StatusCode" as "400"