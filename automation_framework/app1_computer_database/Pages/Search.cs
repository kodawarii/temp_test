using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Pages
{
    class Search : IPage
    {
		// Drivers
		private IWebDriver _driver;
		
		// Page Objects
		private By Table = By.CssSelector("#main > table");
		private By _Rows = By.TagName("tr");
		private By _td = By.TagName("td");
		
		private By PreviousBtn;
		private By NextBtn;
		private By AddNewBtn;
		
		public Search(IWebDriver driver){
			_driver = driver;
		}
		
		// Returns the row number where that computer is (since we are using unique ID's to identify it, there should only be 1 entry)
		public int FindRow(string computerName){
			var table = _driver.FindElement(Table);
			var rows = table.FindElements(_Rows);
			
			if(rows.Count > 1){
				int row = 1;
				while(row <= rows.Count){
					string selectorPath = "#main > table > tbody > tr:nth-child(" + row + ") > td:nth-child(1)";
					By currentComputerName = By.CssSelector(selectorPath);
					string name = _driver.FindElement(currentComputerName).Text.ToString();
					
					if(name.Equals(computerName)) return row;
					
					row++;
				}
			}
			
			return -1;
		}
		
		private string GetTDText(int row, int col){
			var table = _driver.FindElement(Table);
			var rows = table.FindElements(_Rows);
			
			string selectorPath = "#main > table > tbody > tr:nth-child(" + row + ") > td:nth-child(" + col + ")";
			By td = By.CssSelector(selectorPath);
			return _driver.FindElement(td).Text.ToString();
		}
		
		public string FindIntroduced(int row){
			return GetTDText(row, 2);
		}
		
		public string FindDiscontinued(int row){
			return GetTDText(row, 3);
		}
		
		public string FindCompany(int row){
			return GetTDText(row, 4);
		}
		
		public Update ClickOnComputer(int row){
			string selectorPath = "#main > table > tbody > tr:nth-child(" + row + ") > td:nth-child(1) > a";
			By td = By.CssSelector(selectorPath);
			_driver.FindElement(td).Click();
			
			return new Update(_driver);
		}
	}	
}