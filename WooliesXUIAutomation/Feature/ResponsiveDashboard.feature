Feature: ResponsiveDashboard

@Regression
Scenario: Visit first page and create a warrior
	Given I call the URL
	And I see covid information
	When I enter warrior name
	And I click button after entering name
	And I start the journey
	Then I can see a welcome label