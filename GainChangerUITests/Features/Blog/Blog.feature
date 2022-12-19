Feature: Login and Export
	 Login and Export Functionality

@smoke
Scenario: Login and Export
	Given User navigate to login page
	When User enter "gainchanger" as username
	And User enter "justdoit" as password
	And User click on the Login button
	Then User should be able to see the home page
	When User click on the "Resources" menu link
	Then User should be able to see the blog page
    When User open the first blog
	Then User should be able to see the blog details and save in json file