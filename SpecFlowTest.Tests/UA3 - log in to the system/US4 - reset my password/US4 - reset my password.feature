Feature: US4 - reset my password
	In order to reset my password
	As a user
	I want to be able to request a new password

@mytag
Scenario: reset my password
	Given I have forgotten my password
	And I have opened the login page
	When I press the Reset Password button
	Then I should receive an email with a new password
	And my password in the database should be updated
