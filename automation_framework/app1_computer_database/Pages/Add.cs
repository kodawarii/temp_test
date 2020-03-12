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
    class Add : IPage
    {
		// Drivers
		private IWebDriver _driver;
		
		// Page Objects
		private By FieldComputerName = By.CssSelector("#name");
		private By FieldIntroducedDate = By.CssSelector("#introduced");
		private By FieldDiscontinuedDate = By.CssSelector("#discontinued");
		private By DropDownListCompany = By.CssSelector("#company");
		
		private By CreateBtn = By.CssSelector("#main > form > div > input");
		private By CancelBtn = By.CssSelector("#main > form > div > a");
		
		public Add(IWebDriver driver){
			_driver = driver;
		}
		
		// Click Operations
		public void SendFieldComputerName(string s){
			_driver.FindElement(FieldComputerName).SendKeys(s);
		}
		
		public void SendFieldIntroducedDate(string s){
			_driver.FindElement(FieldIntroducedDate).SendKeys(s);
		}
		
		public void SendFieldDiscontinuedDate(string s){
			_driver.FindElement(FieldDiscontinuedDate).SendKeys(s);
		}
		
		public void SelectDropDownListCompany(string s){
			_driver.FindElement(DropDownListCompany).SelectByVisibleText(s);
		}
		
		public Index ClickCreateBtn(){
			_driver.FindElement(CreateBtn).Click();
			
			return new Index(_driver);
		}
		
		public Index ClickCancelBtn(){
			_driver.FindElement(CancelBtn).Click();
			
			return new Index(_driver);
		}
	}	
}