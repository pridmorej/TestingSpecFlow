Feature: US1 - login with a username and password
    As a user
    I want to login with a username and password
    So that I can do work

@mytag
Scenario: login with a username and password
	Given I have opened the login page
	And I have entered my username and password
	When I press Login
	Then the main window should open
	And I should be logged into the system
