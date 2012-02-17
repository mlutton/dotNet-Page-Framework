Feature: Sample Login

@mytag
Scenario: Login With Valid Credentials
	Given I am on the login page
	When I enter valid credentials
	Then I should be logged in
