Feature: Add a profile
	As a seller on this portal
	I want to manage my profile effectively

	@Availability
Scenario: Add availability in the profile
	Given I am on profile page
	When I add availability 
	Then I should be able to get confirmation message

	@AvailabilityHour
Scenario: Add AvailabilityHour in the profile
	Given I am on profile page
	When I add AvailabilityHour 
	Then I should be able to get confirmation message

	@EarnTarget
Scenario: Add EarnTarget in the profile
	Given I am on profile page
	When I add EarnTarget 
	Then I should be able to get confirmation message

	@Description
Scenario: Add Description in the profile
	Given I am on profile page
	When I update Description 
	Then I should be able to get description saved message

	@Password
Scenario: Change the password
	Given I am on profile page
	And I have navigated to the change password
	When I add new password detail
	Then I should be able to change the password

	@SearchSkill
Scenario: Search Skill
	Given I am on profile page
	And I searched for a skill
	When I filter the serach result
	Then I should be able to view the skill I want