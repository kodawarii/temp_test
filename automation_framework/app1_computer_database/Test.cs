using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using Pages;

namespace ComputerDatabaseTest
{
    [TestFixture]
    public class Test
    {
		// Drivers
		private IWebDriver _driver;
		
		// Pages
		private Add pageAdd;
		private Delete pageDelete;
		private Index pageIndex;
		private Search pageSearch;
		private Update pageUpdate;
		
		// Global Data

        [OneTimeSetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			
			pageIndex = new pageIndex(_driver);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _driver.Close();
            _driver.Quit();
        }
		
		[Test, Order(1)]
        [Description("Create Successful Computer")]
        public void Test001()
        {
			// Given I am on the computer database website
			// When I click add new computer button 
			// And I enter the details
			// And I click create 
			// And I search for the computer
			// Then I can see the search result
			
			string uniqueID = Guid.NewGuid().ToString();
			DataContext.uniqueID = uniqueID;
			Console.WriteLine("Unique ID for Test Case 001: " + uniqueID);
			
			pageIndex.GoToURL("http://computer-database.gatling.io/computers");
			pageAdd = pageIndex.ClickAddBtn();
			pageAdd.SendFieldComputerName(uniqueID);
			pageAdd.SendFieldIntroducedDate("2008-10-13");
			pageAdd.SendFieldDiscontinuedDate("2010-06-17");
			pageAdd.SelectDropDownListCompany("Apple Inc.");
			pageIndex = pageAdd.ClickCreateBtn();
			
			string actualAlertMsg = pageIndex.GetAlertMsg();
			Assert.AreEqual("Done! Computer " + uniqueID + " has been created", actualAlertMsg);
			
			pageIndex.SendFieldSearch(uniqueID);
			pageSearch = pageIndex.ClickFilterBtn();
			
			int row = pageSearch.FindRow(uniqueID);
			Assert.AreNotEqual(-1, row);
			
			string actualIntroduced = pageSearch.FindIntroduced(row);
			string actualDiscontinued = pageSearch.FindDiscontinued(row);
			string actualCompany = pageSearch.FindCompany(row);
			Assert.AreEqual("2008-10-13", actualIntroduced);
			Assert.AreEqual("2010-06-17", actualDiscontinued);
			Assert.AreEqual("Apple Inc.", actualCompany);
        }
		
		//@TODO: From both IndexPage, and SearchPage
		[Test, Order(2)]
        [Description("Update Computer")]
        public void Test002()
        {
			// Given I am on the computer database website
			// And I search for the computer created in TC01
			// And I click on the computer
			// And I enter the details
			// And I click Save this computer
			// Then I can see the alert message
			
			pageIndex.GoToURL("http://computer-database.gatling.io/computers");
			pageIndex.SendFieldSearch(uniqueID);
			pageSearch = pageIndex.ClickFilterBtn();
			
			int row = pageSearch.FindRow(uniqueID);
			Assert.AreNotEqual(-1, row);
			
			pageUpdate = pageSearch.ClickOnComputer(DataContext.UniqueID);
        }
		
		[Test, Order(3)]
        [Description("Delete Computer")]
        public void Test003()
        {
			// Given I am on the computer database website
			// And I click on a computer name
			// And I click delete computer button
			// Then I can see the alert message
        }
		
		//@TODO: Computers with duplicate names
    }
}
