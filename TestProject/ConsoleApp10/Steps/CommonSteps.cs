using ConsoleApp10.Contexts;
using ConsoleApp10.Helpers;
using ConsoleApp10.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ConsoleApp10.Steps
{
    [Binding]
    public sealed class CommonSteps
    {
        // Contexts
        private ScenarioContext scenarioContext;
        private DataContext dataContext;
        private GlobalRunner runner;

        // Helper
        private readonly Functions functions;

        public CommonSteps(ScenarioContext scenarioContext, DataContext dataContext, GlobalRunner runner)
        {
            this.scenarioContext = scenarioContext;
            this.dataContext = dataContext;
            this.runner = runner;

            functions = new Functions();
        }

        [Given(@"I am on (.*) (.*)")]
        public void GivenIAmOn(string _URL, string app)
        {
            // @TODO: Make into switch
            if (app.Equals("ComputerDbApp"))
            {
                runner.pageIndex = new PageIndex(runner._driver);
                runner.pageIndex.GoToURL(_URL);
            }
            else if (app.Equals("JsAlertApp"))
            {
                runner.pageJavascriptAlert = new PageIndexJavascriptAlert(runner._driver);
                runner.pageJavascriptAlert.GoToURL(_URL);
            }
            else
            {
                throw new Exception("> That app doesn't exist in this test: " + app);
            }
        }

        [Given(@"I create an arbitary computer")]
        public void GivenICreateAComputer()
        {
            runner.pageAdd = runner.pageIndex.ClickAddBtn();
            dataContext.uniqueID1 = functions.GenerateGUID();
            Console.WriteLine("> Unique ID1 for this Test: " + dataContext.uniqueID1);

            runner.pageAdd.SendFieldComputerName(dataContext.uniqueID1);
            runner.pageAdd.SendFieldDiscontinuedDate("2019-01-01");
            runner.pageAdd.SendFieldIntroducedDate("2005-06-06");
            runner.pageAdd.SelectDropDownListCompany("Apple Inc.");

            runner.pageIndex = runner.pageAdd.ClickCreateBtn();
        }

        [Given(@"I search for the computer")]
        [When(@"I search for the computer")]
        public void WhenISearchForTheComputer()
        {
            runner.pageIndex.SendFieldSearch(dataContext.uniqueID1);
            runner.pageSearch = runner.pageIndex.ClickFilterBtn();
        }
    }
}
