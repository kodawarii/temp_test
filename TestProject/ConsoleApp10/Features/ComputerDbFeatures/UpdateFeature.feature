Feature: UpdateFeature
	In order to update a computer
	As a test automation engineer
	I want to create and search for a computer

Scenario Outline: SC002 Update Computer Successfully
	Given I am on http://computer-database.gatling.io/computers ComputerDbApp
	And I create an arbitary computer
	And I search for the computer
	When I click on the computer
	And I enter the following updated details
	| Field             | Name               |
	#| Computer Name     | <ComputerName>     |
	| Introduced Date   | <IntroducedDate>   |
	| Discontinued Date | <DiscontinuedDate> |
	| Company           | <Company>          |
	And I click save 
	Then I can see the alert message for Update
	Examples:
	| ID   | ComputerName | IntroducedDate | DiscontinuedDate | Company    |
	| TC01 | CustomName   | 1999-10-19     | 2002-09-09       | Apple Inc. |
