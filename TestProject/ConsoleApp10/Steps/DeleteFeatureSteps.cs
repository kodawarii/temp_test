using ConsoleApp10.Contexts;
using ConsoleApp10.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ConsoleApp10.Steps
{
    [Binding]
    public sealed class DeleteFeatureSteps
    {
        // Contexts
        private ScenarioContext scenarioContext;
        private DataContext dataContext;
        private GlobalRunner runner;

        // Helper
        private readonly Functions functions;

        public DeleteFeatureSteps(ScenarioContext scenarioContext, DataContext dataContext, GlobalRunner runner)
        {
            this.scenarioContext = scenarioContext;
            this.dataContext = dataContext;
            this.runner = runner;

            functions = new Functions();
        }

        [When(@"I click delete")]
        public void WhenIClickDelete()
        {
            runner.pageIndex = runner.pageUpdate.ClickDeleteBtn();
        }

        [Then(@"I can see the alert message for Delete")]
        public void ThenICanSeeTheAlertMessageForDelete()
        {
            string expectedMsg = "Done! Computer has been deleted";
            string actualAlertMsg = runner.pageIndex.GetAlertMsg();
            Assert.AreEqual(expectedMsg, actualAlertMsg);
        }
    }
}
