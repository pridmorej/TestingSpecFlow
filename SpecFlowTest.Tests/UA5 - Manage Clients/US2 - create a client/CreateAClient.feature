Feature: Create a Client
	As a user
	I want to create a client
	So that I can store details about them
	
@mytag
Scenario: Create a Client
	Given I have the following client details
	| FirstName | LastName |
	| Jeremy    | Pridmore |
	When I press Create
	Then the client should be added to the database
