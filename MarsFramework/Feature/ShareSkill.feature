Feature: Manage a Share skill Listing
	As a seller on this portal
	I want to manage my share skill listing effectively

@ShareSkill
Scenario: Add Skill
	Given I have navigated to Share skill page
	When I add my share skill details
	Then I should be able to see the listing

	@ShareSkill
Scenario: Edit Skill
	Given I have navigated to Manage Listing page
	When I edit my share skill details
	Then I should be able to see the listing

	@ShareSkill
Scenario: Remove Skill
	Given I have navigated to Share skill page
	When I remove my share skill details
	Then I should be able to see the confirmation