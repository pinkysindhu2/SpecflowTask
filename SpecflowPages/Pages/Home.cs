using OpenQA.Selenium;
using SpecflowPages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowPages.Pages
{
  public class Home
  {
        public static void NavigateToPortal(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(CommonUrls.ProjectUrl);
        }


        public static void clickOnLogin(IWebDriver driver)
        {
            IWebElement webElement = driver.FindElement(By.XPath("//a[@class=\"item\"]"));
            webElement.Click();
        }
    }
}
