Feature: Add Education
	As a seller on this portal
	I want to manage my education in profile effectively

@Education
Scenario:1 Add education
	Given I am on profile page
	When I add education
	Then I should be able to find the education

@Education
Scenario:2 Update education
	Given I am on profile page
	When I update education
	Then I should be able to find the updated education

@Education
Scenario:3 Delete education
	Given I am on profile page
	When I delete education
	Then It should be able to remove from education
