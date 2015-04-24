Feature: Create a Client
	In order to create a new client
	As a sales person
	I want to enter the client details and click add

@mytag
Scenario: Create a Client
	Given I have the following client details
	| FirstName | LastName |
	| Jeremy    | Pridmore |
	When I press Create
	Then the client should be added to the database
