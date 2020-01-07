Feature: Description
In order to update my profile 
	As a skill trader
	I want to add a short profile description

Background: Click on the Description tab
	Given I clicked on the Description tab under Profile page

@Project Mars
Scenario: Check if user could able to add a Description
	When I save a short summary 
	Then that short summary should be displayed on my listings

Scenario: Check if user could reset a Description
	When I add a new Description
	And I click on cancel button
	Then that form should successfully reset and hide

Scenario: Check if user did not add a Description
	When I save without a short description 
	Then Error message should be displayed to ask to enter a description

Scenario: Check if user could add a Description more than 600 characters
	When I save a very long description
	Then that long description should not be accepted

Scenario: Check if user could update a Description 
	When I save a edited description
	Then that description should be successfully updated