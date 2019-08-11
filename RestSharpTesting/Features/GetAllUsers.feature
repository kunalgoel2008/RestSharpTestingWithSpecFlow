Feature: Get All Users
	
Scenario: As an application user, When I fetch all user details
	Given As an application user, I fetch all users details
	Then I should receive all available users


Scenario: As an application user, When I fetch a particular user by Id
	Given As an application user, I fetch details of user with Id "1"
	Then I should receive the First Name as "Pranab"


Scenario: As an application user, When I fetch a particular user by Id with different Data Type
	Given As an application user, I fetch details of user with Id "ABC"
	Then I should not receive the user with that id


Scenario: As an application user, When I create a user
	Given As an application user, I will enter the below details
	 | id | first_name | last_name | position_id | organisation_id | address_id | mob_no | alt_mob_no | email     | isDeleted | add_id | add_type                             | street_1 | street_2 | street_id | pin_code |
	 | 23 | KG         | G         | 1           | 1               | 1          | absd   | injh       | kj@hn.com | false     | 12      | 6411641C-F93C-4923-8D28-21FD0F36ADD6 | asdf     | sedr     | 1         | 110090   |
	Then I should get a "OK" response
	
Scenario: As an application user, When I create a user without giving any details
	Given As an application user, I will not enter any detail
	Then I should get a "BadRequest" response

Scenario: As an application user, When I create a user and fetch its details
	Given As an application user, I will enter the below details
	 | id | first_name | last_name | position_id | organisation_id | address_id | mob_no     |alt_mob_no  | email   | isDeleted | add_id | add_type                             | street_1 | street_2 | street_id | pin_code |
	 | 4  | Kunal      | Goel      | 1           | 1               | 1          | 9999123987 | abcdefghij | a@g.com | false     | 2      | 6411641C-F93C-4923-8D28-21FD0F36ADD6 | ABC      | PQR      | 1         | 110098   | 
	And As an application user, I fetch details of the created user
	Then I should get the correct details

Scenario: As an application user, When I want to delete a user
	Given As an application user, I delete the user with id "46"
	Then The user should be deleted