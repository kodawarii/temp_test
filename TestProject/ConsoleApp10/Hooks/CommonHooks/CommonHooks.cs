using ConsoleApp10.Contexts;
using ConsoleApp10.Helpers;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ConsoleApp10.Hooks.CommonHooks
{
    [Binding]
    public sealed class CommonHooks
    {
        // Contexts
        private ScenarioContext scenarioContext;
        private DataContext dataContext;
        private GlobalRunner runner;

        public CommonHooks(ScenarioContext scenarioContext, DataContext dataContext, GlobalRunner runner)
        {
            this.scenarioContext = scenarioContext;
            this.dataContext = dataContext;
            this.runner = runner;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            runner._driver = new ChromeDriver();
            runner._driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            runner._driver.Close();
            runner._driver.Quit();
        }
    }
}
