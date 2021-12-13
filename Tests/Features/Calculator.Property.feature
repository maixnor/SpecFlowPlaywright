Feature: Calculator Page
	Simple calculator blazor page for adding two numbers

Scenario: Add two numbers
	Given the adder page
	And any first number
	And any second number
	When the sum button is pressed
	Then the pages result should be both numbers added