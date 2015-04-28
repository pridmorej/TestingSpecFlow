Feature: US12 - create a user
	As a admin
	I want to create a user
	So that I can store details about them
	
@mytag
Scenario: Create a User
	Given I have the following user details
	| FirstName | LastName |
	| Jeremy    | Pridmore |
	When I press Create
	Then the user should be added to the database
