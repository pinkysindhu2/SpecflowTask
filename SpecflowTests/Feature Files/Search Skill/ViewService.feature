Feature: ViewService
In order to manage my serices
	As a skill trader
	I want to view my Service

Background: Pre-Conditions
	Given I am logged into Project Mars

@Project Mars

Scenario: View Services
	Given There are one or more service list on ManageList page
	When I have clicked one of the service
	Then I should successfully see the Service list with Seller's Profile pic and Name.