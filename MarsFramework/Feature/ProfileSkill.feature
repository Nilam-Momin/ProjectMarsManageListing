Feature: Add Skill
	As a seller on this portal
	I want to manage my Skill in profile effectively

@Skill
Scenario:1 Add Skill
	Given I am on profile page
	When I add Skill
	Then I should be able to find the Skill

@Skill
Scenario:2 Update Skill
	Given I am on profile page
	When I update Skill
	Then I should be able to find the updated Skill

@Skill
Scenario:3 Delete Skill
	Given I am on profile page
	When I delete Skill
	Then It should be able to remove from Skill
