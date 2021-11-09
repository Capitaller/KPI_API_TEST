@Post
@Regression
Feature: Post

Scenario: 1. Validate Pet Post
	Given I have free API with swagger
	When I send pet creation request 
	Then I see created pet in get response