Feature: Language
In order to update my profile 
	As a skill trader 
	I want to add, update and delete the languages that I know

Background: 01 Click on the Language tab
	Given I clicked on the language tab under Profile page

@Project Mars

Scenario: 02 Check if user could able to add a Language 
	When I add a new language 
	Then that language should be displayed on my listings

Scenario: 03 Check if user could edit the existing language
	Given One or more language is available
	When I edit a lanaguage
	Then I should successfully see the updated lanaguage

Scenario: 04 Check if user could delete the existing language
	Given One or more language is available
	When I delete a lanaguage
	Then that particular language should be deleted successfully

Scenario: 05 Check if user could reset a Language
	When I entered a new language
	And I click on cancel button
	Then that form should successfully reset and hide

Scenario: 06 Check if user did not add a Language
	When I add a new language without data
	Then Error message should be displayed to ask to enter the data

Scenario: 07 Check if user add a Language with invalid data
	When I add a new language with invalid data
	Then that language should not be displayed on my listings