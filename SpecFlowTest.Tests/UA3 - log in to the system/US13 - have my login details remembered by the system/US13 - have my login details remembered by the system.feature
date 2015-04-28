Feature: US13 - have my login details remembered by the system
	In order to avoid re-entering my username
	As a user
	I want the system to remember my username

@mytag
Scenario: Add two numbers
	Given I have previously logged into the system
	When I open the login screen
	Then my username should appear in the username textbox
	And the Remember Me tickbox should be ticked
