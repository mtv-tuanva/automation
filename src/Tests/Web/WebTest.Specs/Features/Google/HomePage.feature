Feature: HomePage

Check the title displays successfully

@WI:2
@id:2
Scenario: User can see the title
	Given I go to "https://google.com"
	When The page has been loaded successfully
	Then I can see the "Google" as the title

#
#Scenario: User can see the title 2
#	Given I go to "https://google.com"
#	When The page has been loaded successfully
#	Then I can see the "Google" as the title
