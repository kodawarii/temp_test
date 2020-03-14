using ConsoleApp10.Contexts;
using ConsoleApp10.Helpers;
using ConsoleApp10.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace ConsoleApp10.Steps
{
    [Binding]
    public class CreateFeatureSteps
    {
        // Contexts
        private ScenarioContext scenarioContext;
        private DataContext dataContext;
        private GlobalRunner runner;

        // Helper
        private readonly Functions functions;

        public CreateFeatureSteps(ScenarioContext scenarioContext, DataContext dataContext, GlobalRunner runner)
        {
            this.scenarioContext = scenarioContext;
            this.dataContext = dataContext;
            this.runner = runner;

            functions = new Functions();
        }
        
        [When(@"I click on the add new computer button")]
        public void WhenIClickOnTheAddNewComputerButton()
        {
            runner.pageAdd = runner.pageIndex.ClickAddBtn();
        }
        
        //@TODO: Currently its duplicate code with update computer steps
        [When(@"I enter the following details")]
        public void WhenIEnterTheFollowingDetails(Table table)
        {
            dataContext.uniqueID1 = functions.GenerateGUID();
            Console.WriteLine("> Unique ID1 for this Test: " + dataContext.uniqueID1);

            // Use the uniqueID1 for computer name, if user entered name, then that will overtake uniqueID
            runner.pageAdd.SendFieldComputerName(dataContext.uniqueID1);

            foreach(var row in table.Rows)
            {
                string field = row[0];
                string value = row[1];

                dataContext.addComputerDetailsTracker.Add(field, value);
                runner.pageAdd.EnterDetails(field.ToLower().Replace(" ", string.Empty), value);
            }
        }
        
        [When(@"I click create")]
        public void WhenIClickCreate()
        {
            runner.pageIndex = runner.pageAdd.ClickCreateBtn();

            string expectedMsg = "Done! Computer " + dataContext.uniqueID1 + " has been created";
            string actualMsg = runner.pageIndex.GetAlertMsg();
            Assert.AreEqual(expectedMsg, actualMsg);
            
            //@TODO: Paramertize expected msg
        }
        
        [Then(@"I can see the search result")]
        public void ThenICanSeeTheSearchResult()
        {
            int row = runner.pageSearch.FindRow(dataContext.uniqueID1);
            Assert.AreNotEqual(-1, row);

            string expectedIntroduced = dataContext.addComputerDetailsTracker["Introduced Date"];
            expectedIntroduced = functions.ConvertToOutputDate(expectedIntroduced);
            string expectedDiscontinued = dataContext.addComputerDetailsTracker["Discontinued Date"];
            expectedDiscontinued = functions.ConvertToOutputDate(expectedDiscontinued);
            string expectedCompany = dataContext.addComputerDetailsTracker["Company"];

            string actualIntroduced = runner.pageSearch.FindIntroduced(row);
            string actualDiscontinued = runner.pageSearch.FindDiscontinued(row);
            string actualCompany = runner.pageSearch.FindCompany(row);

            Assert.AreEqual(expectedIntroduced, actualIntroduced);
            Assert.AreEqual(expectedDiscontinued, actualDiscontinued);
            Assert.AreEqual(expectedCompany, actualCompany);
        }
    }
}
