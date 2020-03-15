Feature: DeleteFeature
	In order to delete a computer
	As a test automation engineer
	I want to create and search for a computer

Scenario Outline: SC003 Delete Computer Successfully
	Given I am on http://computer-database.gatling.io/computers ComputerDbApp
	And I create an arbitary computer
	And I search for the computer
	And I click on the computer
	When I click delete 
	Then I can see the alert message for Delete
