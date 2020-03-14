using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp10.Pages
{
    public class PageUpdate
    {
		// Drivers
		private IWebDriver _driver;

		// Page Objects
		private readonly By FieldComputerName = By.CssSelector("#name");
		private readonly By FieldIntroducedDate = By.CssSelector("#introduced");
		private readonly By FieldDiscontinuedDate = By.CssSelector("#discontinued");
		private readonly By DropDownListCompany = By.CssSelector("#company");

		private readonly By SaveBtn = By.CssSelector("#main > form:nth-child(2) > div > input");
		private readonly By CancelBtn = By.CssSelector("#main > form:nth-child(2) > div > a");
		private readonly By DeleteBtn = By.CssSelector("#main > form.topRight > input");

		public PageUpdate(IWebDriver driver)
		{
			_driver = driver;
		}

		//@TODO: Refactor Update and Add Common functions to Helper class
		public void SendFieldComputerName(string s)
		{
			_driver.FindElement(FieldComputerName).Clear();
			_driver.FindElement(FieldComputerName).SendKeys(s);
		}

		public void SendFieldIntroducedDate(string s)
		{
			_driver.FindElement(FieldIntroducedDate).Clear();
			_driver.FindElement(FieldIntroducedDate).SendKeys(s);
		}

		public void SendFieldDiscontinuedDate(string s)
		{
			_driver.FindElement(FieldDiscontinuedDate).Clear();
			_driver.FindElement(FieldDiscontinuedDate).SendKeys(s);
		}

		public void SelectDropDownListCompany(string s)
		{
			var element = _driver.FindElement(DropDownListCompany);
			var selectElement = new SelectElement(element);
			selectElement.SelectByText(s);
		}

		public PageIndex ClickSaveBtn()
		{
			_driver.FindElement(SaveBtn).Click();
			return new PageIndex(_driver);
		}

		public PageIndex ClickDeleteBtn()
		{
			_driver.FindElement(DeleteBtn).Click();
			return new PageIndex(_driver);
		}

		// Duplicate code with AddPage - need to refactor
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
