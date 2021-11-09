@Put
@Regression
Feature: Put Pet

Scenario: 1. Validate Pet Put
	Given I have free API with swagger
	When I send put request 
	Then I see updated pet in get response