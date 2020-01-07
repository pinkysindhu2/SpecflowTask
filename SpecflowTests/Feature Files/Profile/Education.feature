Feature: Education
In order to update my profile 
	As a skill trader
	I want to and add my Education Background
	I want to update my education details
	I want to delete my education

Background: Click on the Education tab
	Given I clicked on the Education tab under Profile page

@Project Mars

Scenario: Check if user could able to add a Education 
	When I add a new education
	Then that education should be displayed on my listings

Scenario: Check if user could edit the existing Education
	Given One or more Education is available
	When I edit a education
	Then I should successfully see the updated education

Scenario: Check if user could delete the existing Education
	Given One or more Education is available
	When I delete education
	Then that particular education should be deleted successfully

Scenario: Check if user could reset a Education
	When I add a new education
	And I click on cancel button
	Then that form should successfully reset and hide

Scenario: Check if user did not add a Education
	When I add a new education without data
	Then Error message should be displayed to ask to enter the data

Scenario: Check if user add a Education with invalid data
	When I add a new education with invalid data
	Then that education should not be displayed on my listings