using ConsoleApp10.Contexts;
using ConsoleApp10.Helpers;
using ConsoleApp10.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ConsoleApp10.Steps
{
    [Binding]
    public sealed class JavascriptAlertAppSteps
    {
        // Contexts
        private ScenarioContext scenarioContext;
        private DataContext dataContext;
        private GlobalRunner runner;

        // Helper
        private readonly Functions functions;

        public JavascriptAlertAppSteps(ScenarioContext scenarioContext, DataContext dataContext, GlobalRunner runner)
        {
            this.scenarioContext = scenarioContext;
            this.dataContext = dataContext;
            this.runner = runner;

            functions = new Functions();
        }

        [Given(@"I click on the '(.*)' button")]
        public void GivenIClickOnTheButton(string p0)
        {
            runner.pageJavascriptAlert.ClickBtn(p0);
        }

        [Given(@"I enter the prompt '(.*)'")]
        public void GivenIEnterThePrompt(string p0)
        {
            runner.pageJavascriptAlert.SendKeys(p0);
        }

        [When(@"I click '(.*)'")]
        public void WhenIClick(string p0)
        {
            //string expectedAlertMsg = "I am a JS Confirm";
            //string actualAlertMsg = runner.pageJavascriptAlert.alertMsg;
            //Assert.AreEqual(expectedAlertMsg, actualAlertMsg);

            runner.pageJavascriptAlert.ClickAlertBtn(p0);
        }

        [Then(@"I can see the result message '(.*)'")]
        public void ThenICanSeeTheResultMessage(string expectedResultMsg)
        {
            string actualResultMsg = runner.pageJavascriptAlert.GetResultMessage();

            Assert.AreEqual(expectedResultMsg, actualResultMsg);
        }
    }
}
