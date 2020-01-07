Feature: AddService
In order to trade my skills 
	As a skill trader
	I want to create a new Service

Background: Pre-Conditions
	Given I am logged into Project Mars

@Project Mars

Scenario: Click on Share Skill button
	Given I am on Profile Details Page
	When I have clicked on the Share Skill button
	Then I should successfully naviaged to Service Listing Form.

Scenario: Create a new Service
	Given Empty Service form is listed
	And I have filled the form with the valid data
	When I have clicked on Save button
	Then I should successfully created a Service to share.