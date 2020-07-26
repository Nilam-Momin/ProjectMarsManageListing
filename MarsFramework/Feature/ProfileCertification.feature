Feature: Add a certification
	As a seller on this portal
	I want to manage my certifications in profile effectively

@Certification
Scenario:1 Add certification
	Given I am on profile page
	When I add certification
	Then I should be able to find the certification

@Certification
Scenario:2 Update certification
	Given I am on profile page
	When I update certification
	Then I should be able to find the updated certification

@Certification
Scenario:3 Delete certification
	Given I am on profile page
	When I delete certification
	Then It should be able to remove from certification
