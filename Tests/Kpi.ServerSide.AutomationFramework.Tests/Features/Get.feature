@Get
@Regression
Feature: Get Pet by Id

@Smoke
Scenario: 1. Get Pet by valid id
	Given I have Pet API
	When I receive pet by valid posted id
	Then I see returned pet details

Scenario Outline: 2. Get pet by invalid id
	Given I have Pet API
	When I receive pet by invalid <invalid> id
	Then I see <returned> returned invalid pet details

	Examples: 
	| invalid           | returned                                                                                                |
	| 0                 | {"code":1,"type":"error","message":"Pet not found"}                                                     |
	| -9999999999999999 | {"code":1,"type":"error","message":"Pet not found"}                                                     |
	| 99999999999999999 | {"code":1,"type":"error","message":"Pet not found"}                                                     |
	| string            | {"code":404,"type":"unknown","message":"java.lang.NumberFormatException: For input string: \"string\""} |
	| 1.0               | {"code":404,"type":"unknown","message":"java.lang.NumberFormatException: For input string: \"1.0\""}    |