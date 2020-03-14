Feature: CreateFeature
	In order to search for a computer
	As a test automation engineer
	I want to create a computer

Scenario Outline: SC001 Create Successful Computer
	Given I am on http://computer-database.gatling.io/computers
	When I click on the add new computer button
	And I enter the following details
	| Field             | Name               |
	#| Computer Name     | <ComputerName>     |
	| Introduced Date   | <IntroducedDate>   |
	| Discontinued Date | <DiscontinuedDate> |
	| Company           | <Company>          |
	And I click create
	And I search for the computer
	Then I can see the search result
	Examples:
	| ID   | ComputerName | IntroducedDate | DiscontinuedDate | Company    |
	| TC01 | CustomName   | 2008-10-13     | 2010-06-17       | Apple Inc. |
