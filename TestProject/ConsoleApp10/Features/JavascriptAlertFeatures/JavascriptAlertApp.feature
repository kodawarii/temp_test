Feature: JavascriptAlertApp
	In order to test the javascript alert web app
	As a test automation engineer
	I want to press the different buttons

Background:
	Given I am on https://the-internet.herokuapp.com/javascript_alerts JsAlertApp

Scenario: SC001 - Click for JS Alert
	Given I click on the 'Alert' button
	When I click 'OK'
	Then I can see the result message 'You successfuly clicked an alert'

Scenario: SC002 - Click for JS Confirm - OK
	Given I click on the 'Confirm' button
	When I click 'OK'
	Then I can see the result message 'You clicked: Ok'

Scenario: SC003 - Click for JS Confirm - Cancel
	Given I click on the 'Confirm' button
	When I click 'Cancel'
	Then I can see the result message 'You clicked: Cancel'

Scenario: SC004 - Click for JS Prompt - Cancel
	Given I click on the 'Prompt' button
	When I click 'Cancel'
	Then I can see the result message 'You entered: null'

Scenario: SC005 - Click for JS Prompt - Valid String
	Given I click on the 'Prompt' button
	And I enter the prompt 'asdf'
	When I click 'OK'
	Then I can see the result message 'You entered: asdf'

Scenario: SC006 - Click for JS Prompt - Valid String And Cancel
	Given I click on the 'Prompt' button
	And I enter the prompt 'asdf'
	When I click 'Cancel'
	Then I can see the result message 'You entered: null'

# Test SC007 currently failing -- injection successful
Scenario: SC007 - Click for JS Prompt - Injection Attack
	Given I click on the 'Prompt' button
	And I enter the prompt '<h1> Hello World </h1>'
	When I click 'OK'
	Then I can see the result message 'You entered: <h1> Hello World </h1>'