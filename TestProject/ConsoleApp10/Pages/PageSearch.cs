using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp10.Pages
{
    public class PageSearch : IPage
    {
		// Drivers
		private IWebDriver _driver;

		// Page Objects
		private readonly By Table = By.CssSelector("#main > table");
		private readonly By _Rows = By.TagName("tr");
		private readonly By _td = By.TagName("td");

		private readonly By PreviousBtn;
		private readonly By NextBtn;
		private readonly By AddNewBtn;

		public PageSearch(IWebDriver driver)
		{
			_driver = driver;
		}

		// Returns the row number where that computer is (since we are using unique ID's to identify it, there should only be 1 entry)
		public int FindRow(string computerName)
		{
			var table = _driver.FindElement(Table);
			var rows = table.FindElements(_Rows);

			if (rows.Count > 1)
			{
				int row = 1;
				while (row <= rows.Count)
				{
					string selectorPath = "#main > table > tbody > tr:nth-child(" + row + ") > td:nth-child(1)";
					By currentComputerName = By.CssSelector(selectorPath);
					string name = _driver.FindElement(currentComputerName).Text.ToString();

					if (name.Equals(computerName)) return row;

					row++;
				}
			}

			return -1;
		}

		private string GetTDText(int row, int col)
		{
			var table = _driver.FindElement(Table);
			var rows = table.FindElements(_Rows);

			string selectorPath = "#main > table > tbody > tr:nth-child(" + row + ") > td:nth-child(" + col + ")";
			By td = By.CssSelector(selectorPath);
			return _driver.FindElement(td).Text.ToString();
		}

		public string FindIntroduced(int row)
		{
			return GetTDText(row, 2);
		}

		public string FindDiscontinued(int row)
		{
			return GetTDText(row, 3);
		}

		public string FindCompany(int row)
		{
			return GetTDText(row, 4);
		}

		public PageUpdate ClickOnComputer(int row)
		{
			string selectorPath = "#main > table > tbody > tr:nth-child(" + row + ") > td:nth-child(1) > a";
			By td = By.CssSelector(selectorPath);
			_driver.FindElement(td).Click();

			return new PageUpdate(_driver);
		}

	}
}
