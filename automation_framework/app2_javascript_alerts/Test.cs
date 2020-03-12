using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace JSAlertsTest
{
    [TestFixture]
    public class Test
    {
		// Drivers
		private IWebDriver _driver;
		
		// Pages
		Index pageIndex;

        [OneTimeSetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			
			pageIndex = new pageIndex(_driver);
			pageIndex.GoToURL("https://the-internet.herokuapp.com/javascript_alerts");
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _driver.Close();
            _driver.Quit();
        }
		
		[Test, Order(1)]
        [Description("Click for JS Alert")]
        public void Test001()
        {
			pageIndex.ClickAlertBtn();
			IAlert alert = _driver.SwitchTo().Alert();
			
			string expectedJSMsg = "I am a JS Alert";
			string actualJSMsg = alert.Text;
			
			Assert.AreEqual(expectedJSMsg, actualJSMsg);
			
			alert.Accept();
			
			string expectedResultMsg = "You successfuly clicked an alert";
			string actualResultMsg = _driver.FindElement(By.CssSelector("#result")).Test.ToString();
			
			Assert.AreEqual(expectedResultMsg, actualResultMsg);
        }
		
		[Test, Order(2)]
        [Description("Click for JS Confirm - OK")]
        public void Test002()
        {
			pageIndex.ClickConfirmBtn();
			IAlert alert = _driver.SwitchTo().Alert();
			
			string expectedJSMsg = "I am a JS Confirm";
			string actualJSMsg = alert.Text;
			
			Assert.AreEqual(expectedJSMsg, actualJSMsg);
			
			alert.Accept();
			
			string expectedResultMsg = "You clicked: Ok";
			string actualResultMsg = _driver.FindElement(By.CssSelector("#result")).Test.ToString();
			
			Assert.AreEqual(expectedResultMsg, actualResultMsg);
        }
		
		[Test, Order(3)]
        [Description("Click for JS Confirm - Cancel")]
        public void Test003()
        {
			pageIndex.ClickConfirmBtn();
			IAlert alert = _driver.SwitchTo().Alert();
			
			string expectedJSMsg = "I am a JS Confirm";
			string actualJSMsg = alert.Text;
			
			Assert.AreEqual(expectedJSMsg, actualJSMsg);
			
			alert.Dismiss();
			
			string expectedResultMsg = "You clicked: Cancel";
			string actualResultMsg = _driver.FindElement(By.CssSelector("#result")).Test.ToString();
			
			Assert.AreEqual(expectedResultMsg, actualResultMsg);
        }
		
		[Test, Order(4)]
        [Description("Click for JS Prompt - Cancel")]
        public void Test004()
        {
			pageIndex.ClickPromptBtn();
			IAlert alert = _driver.SwitchTo().Alert();
			
			string expectedJSMsg = "I am a JS prompt";
			string actualJSMsg = alert.Text;
			
			Assert.AreEqual(expectedJSMsg, actualJSMsg);
			
			alert.Dismiss();
			
			string expectedResultMsg = "You entered: null";
			string actualResultMsg = _driver.FindElement(By.CssSelector("#result")).Test.ToString();
			
			Assert.AreEqual(expectedResultMsg, actualResultMsg);
        }
		
		[Test, Order(5)]
        [Description("Click for JS Prompt - valid string")]
        public void Test005()
        {
			pageIndex.ClickPromptBtn();
			IAlert alert = _driver.SwitchTo().Alert();
			
			string expectedJSMsg = "I am a JS prompt";
			string actualJSMsg = alert.Text;
			
			Assert.AreEqual(expectedJSMsg, actualJSMsg);
			
			alert.SendKeys("asdf");
			alert.Accept();
			
			string expectedResultMsg = "You entered: asdf";
			string actualResultMsg = _driver.FindElement(By.CssSelector("#result")).Test.ToString();
			
			Assert.AreEqual(expectedResultMsg, actualResultMsg);
        }
		
		[Test, Order(6)]
        [Description("Click for JS Prompt - valid string but cancel")]
        public void Test006()
        {
			pageIndex.ClickPromptBtn();
			IAlert alert = _driver.SwitchTo().Alert();
			
			string expectedJSMsg = "I am a JS prompt";
			string actualJSMsg = alert.Text;
			
			Assert.AreEqual(expectedJSMsg, actualJSMsg);
			
			alert.SendKeys("random");
			alert.Dismiss();
			
			string expectedResultMsg = "You entered: null";
			string actualResultMsg = _driver.FindElement(By.CssSelector("#result")).Test.ToString();
			
			Assert.AreEqual(expectedResultMsg, actualResultMsg);
        }
		
		[Test, Order(7)]
        [Description("Click for JS Confirm - Injection Attack")]
        public void Test007()
        {
			pageIndex.ClickPromptBtn();
			IAlert alert = _driver.SwitchTo().Alert();
			
			string expectedJSMsg = "I am a JS prompt";
			string actualJSMsg = alert.Text;
			
			Assert.AreEqual(expectedJSMsg, actualJSMsg);
			
			alert.SendKeys("<h1> Hello </h1>");
			alert.Accept();
			
			string expectedResultMsg = "You entered: <h1> Hello </h1>";
			string actualResultMsg = _driver.FindElement(By.CssSelector("#result")).Test.ToString();
			
			Assert.AreEqual(expectedResultMsg, actualResultMsg);
        }
    }
}
