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
    public sealed class UpdateFeatureSteps
    {
        // Contexts
        private ScenarioContext scenarioContext;
        private DataContext dataContext;
        private GlobalRunner runner;

        // Helper
        private readonly Functions functions;

        public UpdateFeatureSteps(ScenarioContext scenarioContext, DataContext dataContext, GlobalRunner runner)
        {
            this.scenarioContext = scenarioContext;
            this.dataContext = dataContext;
            this.runner = runner;

            functions = new Functions();
        }

        [Given(@"I click on the computer")]
        [When(@"I click on the computer")]
        public void WhenIClickOnTheComputer()
        {
            int row = runner.pageSearch.FindRow(dataContext.uniqueID1);
            Assert.AreNotEqual(-1, row);

            runner.pageUpdate = runner.pageSearch.ClickOnComputer(row);

            //@TODO: Assert Pre-populated input fields have correct details
        }

        // @TODO: Refactor duplicate code (same code as add computer)
        [When(@"I enter the following updated details")]
        public void WhenIEnterTheFollowingUpdatedDetails(Table table)
        {
            dataContext.uniqueID2 = functions.GenerateGUID();
            Console.WriteLine("> Unique ID2 for this Test: " + dataContext.uniqueID2);

            // Use the uniqueID2 for computer name, if user entered name, then that will overtake uniqueID
            runner.pageUpdate.SendFieldComputerName(dataContext.uniqueID2);

            foreach (var row in table.Rows)
            {
                string field = row[0];
                string value = row[1];

                dataContext.updateComputerDetailsTracker.Add(field, value);
                runner.pageUpdate.EnterDetails(field.ToLower().Replace(" ", string.Empty), value);
            }
        }

        [When(@"I click save")]
        public void WhenIClickSave()
        {
            runner.pageIndex = runner.pageUpdate.ClickSaveBtn();
        }

        [Then(@"I can see the alert message for Update")]
        public void ThenICanSeeTheAlertMessage()
        {
            string expectedMsg = "Done! Computer " + dataContext.uniqueID2 + " has been updated";
            string actualAlertMsg = runner.pageIndex.GetAlertMsg();
            Assert.AreEqual(expectedMsg, actualAlertMsg);
        }

    }
}
