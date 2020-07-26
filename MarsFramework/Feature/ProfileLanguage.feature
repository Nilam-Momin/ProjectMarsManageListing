Feature: Add Language
	As a seller on this portal
	I want to manage my language in profile effectively

@Language
Scenario:1 Add language
	Given I am on profile page
	When I add language
	Then I should be able to find the language

@Language
Scenario:2 Update language
	Given I am on profile page
	When I update language
	Then I should be able to find the updated language

@Language
Scenario:3 Delete language
	Given I am on profile page
	When I delete language
	Then It should be able to remove from language
