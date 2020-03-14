using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp10.Pages
{
    public class PageIndex : IPage
    {
		// Drivers
		private IWebDriver _driver;

		// Page objects
		private readonly By AddBtn = By.CssSelector("#add");
		private readonly By SearchBtn = By.CssSelector("#searchsubmit");

		private readonly By FieldSearch = By.CssSelector("#searchbox");

		private readonly By AlertMsg = By.CssSelector("#main > div.alert-message.warning");

		public PageIndex(IWebDriver driver)
		{
			_driver = driver;
		}

		public void GoToURL(string url)
		{
			_driver.Navigate().GoToUrl(url);
		}

		public PageAdd ClickAddBtn()
		{
			_driver.FindElement(AddBtn).Click();
			return new PageAdd(_driver);
		}

		public PageSearch ClickFilterBtn()
		{
			_driver.FindElement(SearchBtn).Click();
			return new PageSearch(_driver);
		}

		public string GetAlertMsg()
		{
			return _driver.FindElement(AlertMsg).Text.ToString();
		}

		public void SendFieldSearch(string s)
		{
			_driver.FindElement(FieldSearch).SendKeys(s);
		}
	}
}
