Feature: Get All Users with Wrong URL

Scenario: Verify status code of getAllUsers with Wrong URL
	Given I perform GET operation for "getAllUsersss"
	And I execute operation
	Then I should see the "StatusCode" as "404"
