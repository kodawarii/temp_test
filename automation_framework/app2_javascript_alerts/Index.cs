using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace JSAlertsTest
{
    public class Index
    {
		// Drivers
		private IWebDriver _driver;
		
		// Page objects
		private By AlertBtn = By.CssSelector("#content > div > ul > li:nth-child(1) > button");
		private By ConfirmBtn = By.CssSelector("#content > div > ul > li:nth-child(2) > button");
		private By PromptBtn = By.CssSelector("#content > div > ul > li:nth-child(3) > button");
		
		public Index(IWebDriver driver){
			_driver = driver;
		}
		
		public void GoToURL(string url){
			_driver.Navigate().GoToUrl(url);
		}
		
		public void ClickAlertBtn(){
			_driver.FindElement(AlertBtn).Click();
		}
		
		public void ClickConfirmBtn(){
			_driver.FindElement(ConfirmBtn).Click();
		}
		
		public void ClickPromptBtn(){
			_driver.FindElement(PromptBtn).Click();
		}
	}	
}