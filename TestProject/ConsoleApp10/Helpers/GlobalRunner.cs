using ConsoleApp10.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp10.Helpers
{
    public class GlobalRunner
    {
        // Drivers
        public IWebDriver _driver;

        // Pages
        public PageAdd pageAdd;
        public PageDelete pageDelete;
        public PageIndex pageIndex;
        public PageSearch pageSearch;
        public PageUpdate pageUpdate;

        public GlobalRunner()
        {
            
        }
    }
}
