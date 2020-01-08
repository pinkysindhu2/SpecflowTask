Feature: Skill
In order to update my profile 
	As a skill trader 
	I want to add the skills that I have
	I want to update my skill
	I want to delete a particular skill of mine

Background: 01 Click on the Skill tab
	Given I clicked on the Skill tab under Profile page

@Project Mars

Scenario: 02 Check if user could able to add a Skill 
	When I add a new skill 
	Then that skill should be displayed on my listings

Scenario: 03 Check if user could edit the existing Skill
	Given One or more Skill is available
	When I edit a skill
	Then I should successfully see the updated skill

Scenario: 04 Check if user could delete the existing Skill
	Given One or more Skill is available
	When I delete skill
	Then that particular skill should be deleted successfully

Scenario: 05 Check if user could reset a Skill
	When I add a new skill
	And I click on cancel button
	Then that form should successfully reset and hide

Scenario: 06 Check if user did not add a skill
	When I add a new skill without data
	Then Error message should be displayed to ask to enter the data

Scenario: 07 Check if user add a Skill with invalid data
	When I add a new skill with invalid data
	Then that skill should not be displayed on my listings