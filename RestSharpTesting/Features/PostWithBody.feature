Feature: Post With Body

Scenario: Verify status code of createUser
	Given I perform POST operation for "createUser" with body
	 | id | first_name | last_name | position_id | organisation_id | address_id | mob_no     | alt_mob_no | email   | isDeleted | add_id | add_type                             | street_1 | street_2 | street_id | pin_code |
	 | 24 | Kunal      | Goel      | 1           | 1               | 1          | 9999123987 | abcdefghij | a@g.com | false     | 52     | 6411641C-F93C-4923-8D28-21FD0F36ADD6 | ABC      | PQR      | 1         | 110098   | 
	Then I should see the "StatusCode" For POST as "200"
