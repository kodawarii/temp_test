using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp10.Pages
{
    public class PageAdd : IPage
    {
		// Drivers
		private IWebDriver _driver;

		// Page Objects
		private readonly By FieldComputerName = By.CssSelector("#name");
		private readonly By FieldIntroducedDate = By.CssSelector("#introduced");
		private readonly By FieldDiscontinuedDate = By.CssSelector("#discontinued");
		private readonly By DropDownListCompany = By.CssSelector("#company");

		private readonly By CreateBtn = By.CssSelector("#main > form > div > input");
		private readonly By CancelBtn = By.CssSelector("#main > form > div > a");

		public PageAdd(IWebDriver driver)
		{
			_driver = driver;
		}

		//@TODO: See Update Class for duplicate code
		public void SendFieldComputerName(string s)
		{
			_driver.FindElement(FieldComputerName).SendKeys(s);
		}

		public void SendFieldIntroducedDate(string s)
		{
			_driver.FindElement(FieldIntroducedDate).SendKeys(s);
		}

		public void SendFieldDiscontinuedDate(string s)
		{
			_driver.FindElement(FieldDiscontinuedDate).SendKeys(s);
		}

		public void SelectDropDownListCompany(string s)
		{
			var element = _driver.FindElement(DropDownListCompany);
			var selectElement = new SelectElement(element);
			selectElement.SelectByText(s);
			//selectElement.SelectByValue(s);
		}

		public PageIndex ClickCreateBtn()
		{
			_driver.FindElement(CreateBtn).Click();
			return new PageIndex(_driver);
		}

		public PageIndex ClickCancelBtn()
		{
			_driver.FindElement(CancelBtn).Click();
			return new PageIndex(_driver);
		}

		public void EnterDetails(string field, string value)
		{
			switch (field)
			{
				case "computername":
					SendFieldComputerName(value);
					break;
				case "introduceddate":
					SendFieldIntroducedDate(value);
					break;
				case "discontinueddate":
					SendFieldDiscontinuedDate(value);
					break;
				case "company":
					SelectDropDownListCompany(value);
					break;
				default:
					throw new Exception("> That field does not exist: " + field);
			}
		}
	}
}
