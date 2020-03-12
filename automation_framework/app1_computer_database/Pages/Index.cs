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
    class Index : IPage
    {
		// Drivers
		private IWebDriver _driver;
		
		// Page objects
		private By AddBtn = By.CssSelector("#add");
		private By SearchBtn = By.CssSelector("#searchsubmit");
		
		private By FieldSearch = By.CssSelector("#searchbox");
		
		private By AlertMsg = By.CssSelector("#main > div.alert-message.warning");
		
		public Index(IWebDriver driver){
			_driver = driver;
		}
		
		public void GoToURL(string url){
			_driver.Navigate().GoToUrl(url);
		}
		
		public Add ClickAddBtn(){
			_driver.FindElement(AddBtn).Click();
			
			return new Add(_driver);
		}
		
		public Search ClickFilterBtn(){
			_driver.FindElement(SearchBtn).Click();
			
			return new Search(_driver);
		}
		
		public string GetAlertMsg(){
			return _driver.FindElement(AlertMsg).Text.ToString();
		}
		
		public void SendFieldSearch(string s){
			_driver.FindElement(FieldSearch).SendKeys(s);
		}
	}	
}