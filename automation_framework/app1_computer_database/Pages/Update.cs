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
    class Update : IPage
    {
		// Drivers
		private IWebDriver _driver;
		
		// Page Objects
		private By FieldComputerName = By.CssSelector("#name");
		private By FieldIntroducedDate = By.CssSelector("#introduced");
		private By FieldDiscontinuedDate = By.CssSelector("#discontinued");
		private By DropDownListCompany = By.CssSelector("#company");
		
		private By SaveBtn = By.CssSelector("#main > form:nth-child(2) > div > input");
		private By CancelBtn = By.CssSelector("#main > form:nth-child(2) > div > a");
		private By DeleteBtn = By.CssSelector("#main > form.topRight > input");
		
		public Update(IWebDriver driver){
			_driver = driver;
		}
		
		//@TODO: Refactor Update and Add Common functions to Helper class
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
		
		public Index ClickSaveBtn(){
			_driver.FindElement(SaveBtn).Click();
			return new Index(_driver);
		}
		
		public Index ClickDeleteBtn(){
			_driver.FindElement(DeleteBtn).Click();
			return new Index(_driver);
		}
	}	
}