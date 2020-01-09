//using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SpecflowPages.Pages
{
    public class Login: Home
    {
        public static void enterLoginInfo(IWebDriver driver)
        {
            // find the email field
            IWebElement email = driver.FindElement(By.Name("email"));
            email.SendKeys("sindhupinky2@gmail.com");

            //find the password field
            IWebElement password = driver.FindElement(By.Name("password"));
            password.SendKeys("abcd123");
        }

        public static void clickOnLoginBtn(IWebDriver driver)
        {
            IWebElement login = driver.FindElement(By.XPath("//button[@class=\"fluid ui teal button\"]"));
            login.Click();
        }

        public static void loginSuccess(IWebDriver driver)
        {
            Thread.Sleep(1500);
            string url = driver.Url;
            Thread.Sleep(3000);
            Assert.AreEqual(url, "http://www.skillswap.pro/Account/Profile");

        }
    }

}

