using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecflowPages.Helpers;

namespace SpecflowPages.Base_Class
{
   public class Browser
   {
        // Get the driver for Chrome Browser
        private static IWebDriver GetChromeWebDriver()
        {
            IWebDriver driver = new ChromeDriver();
            return driver;
        }

        public static void InitWebDriver()
        {
            CommonDriver.driver = GetChromeWebDriver();
        }

        //Quit the Driver   
        public static void QuitDriver()
        {
            CommonDriver.driver.Quit();
        }

        // close the driver
        public static void CloseDriver()
        {
            CommonDriver.driver.Close();
        }

    }
}
