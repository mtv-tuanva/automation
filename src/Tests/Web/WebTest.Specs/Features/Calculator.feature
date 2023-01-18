Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](WebTest.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@test1
@WI:1
Scenario Outline: Verify web title
	Given I go to <url>
	When The page has been loaded successfully
	Then I can see the <result> as the title

	Scenarios: 
	| url | result |
	| "https://google.com" | "Google" |
	| "https://mail.google.com" | "Gmail" |