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
    class Delete : IPage
    {
		private IWebDriver _driver;
		
		public Delete(IWebDriver driver){
			_driver = driver;
		}
	}	
}