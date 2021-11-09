@Delete
@Regression
Feature: Delete Pet by Id

Scenario: Delete Pet by valid id
	Given I have created Pet
	When I send Pet delete request
	Then I see pet response with 0 id
