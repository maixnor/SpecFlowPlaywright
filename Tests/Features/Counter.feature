Feature: Counter
	Simple calculator for adding two numbers

Scenario: Increase once
	Given the counter page
	When the count is increased
	Then the resulting count should be 1
	
Scenario: Increase twice
	Given the counter page
	When the count is increased 10 times
	Then the resulting count should be 10

	
	
	