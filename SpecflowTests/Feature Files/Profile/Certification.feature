﻿Feature: Certification
In order to update my profile 
	As a skill trader
	I want to add my Certifications that I have 
	I want to update a particular certification
	I want to delete a particular certification

Background: 01 Click on Cetrificate tab
	Given I clicked on the Certification tab under Profile page

@Project Mars

Scenario: 02 Check if user could able to add a Certification 	
	When I add a new certification
	Then that certification should be successfully displayed on my listings

Scenario: 03 Check if user could edit the existing Certification
	Given One or more Certification is available
	When I edit a certification
	Then I should successfully see the updated certification

Scenario: 04 Check if user could delete the existing Certification
	Given One or more Certification is available
	When I delete a certification
	Then that particular certification should be deleted successfully

Scenario: 05 Check if user could see changes after logout and comeback again
	And my certfication has been added successfully after login and logout

Scenario: 06 Check if user could reset a Certification
	Given I click on add new Certification
	When I click on cancel button
	Then that form should successfully reset and hide

Scenario: 07 Check if user did not add a Certification
	When I add a new certification without data
	Then Error message should be displayed to ask to enter the data

Scenario: 08 Check if user add a Certification with invalid data
	When I add a new certification with invalid data
	Then that certification should not be displayed on my listings