Feature: SkillSearch
	In order to seek a particular Skill
	As a user
	I want to look into the Seller's profile details.

Background: 01 Pre-Conditions
	Given Enter Cypress into Search bar on Home page
	When I have clicked on Search button
	Then I should see services regarding my search

@Project Mars

@important
Scenario: 02 Check if user could see the Seller’s profile on Searched Services 
	Given  I should successfully seen seller’s profile pic and name

Scenario: 03 Check if user could navigate to Seller's Profile page 
	When I have clicked on either of seller’s pic or name
	Then I should successfully see Seller’s profile in more detailed way 

Scenario: 04 Check if user could see Seller's info on Service Detailed Information page
	Given I have clicked on the one of the Listed Services
	And Seller’s profile info is on right hand side of Service Listing Page
	When I have clicked on Seller's profile
	Then I should successfully see Seller’s profile in more detailed way 