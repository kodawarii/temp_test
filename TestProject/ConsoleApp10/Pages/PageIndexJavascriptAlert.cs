using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp10.Pages
{
    public class PageIndexJavascriptAlert : IPage
    {
		// Drivers
		private IWebDriver _driver;

		// Page objects
		private By AlertBtn = By.CssSelector("#content > div > ul > li:nth-child(1) > button");
		private By ConfirmBtn = By.CssSelector("#content > div > ul > li:nth-child(2) > button");
		private By PromptBtn = By.CssSelector("#content > div > ul > li:nth-child(3) > button");

		private By resultMessage = By.CssSelector("#result");

		// Alert Objects
		public IAlert alert;
		public string alertMsg;

		public PageIndexJavascriptAlert(IWebDriver driver)
		{
			_driver = driver;
		}

		public void GoToURL(string url)
		{
			_driver.Navigate().GoToUrl(url);
		}

		public void ClickAlertBtn()
		{
			_driver.FindElement(AlertBtn).Click();
		}

		public void ClickConfirmBtn()
		{
			_driver.FindElement(ConfirmBtn).Click();
		}

		public void ClickPromptBtn()
		{
			_driver.FindElement(PromptBtn).Click();
		}

		public void ClickBtn(string s)
		{
			switch (s)
			{
				case "Alert":
					ClickAlertBtn();
					break;
				case "Confirm":
					ClickConfirmBtn();
					break;
				case "Prompt":
					ClickPromptBtn();
					break;
				default:
					throw new Exception("> That button doesn't exist!: " + s);
			}

			alert = _driver.SwitchTo().Alert();
			alertMsg = alert.Text;
		}

		public void SendKeys(string s)
		{
			try
			{
				alert.SendKeys(s);
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public void ClickAlertBtn(string s )
		{
			switch (s)
			{
				case "OK":
					alert.Accept();
					break;
				case "Cancel":
					alert.Dismiss();
					break;
				default:
					throw new Exception("> That Prompt Btn does not exist!: " + s);
			}
		}

		public string GetResultMessage()
		{
			return _driver.FindElement(resultMessage).Text.ToString();
		}
	}
}
