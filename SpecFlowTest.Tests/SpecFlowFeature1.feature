Feature: Adding a Client
	In order to create a new client
	As a sales person
	I want to enter the client details and click add

@mytag
Scenario: Add a client
	Given I have the following client details
	| FirstName | LastName |
	| Jeremy    | Pridmore |
	When I press add
	Then the client should be added to the database
