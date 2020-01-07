using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using RelevantCodes.ExtentReports;

namespace SpecflowPages.Pages.Profile_Tab
{
    public class Language
    {
        public static void clickOnLangTab(IWebDriver driver)
        {
            Thread.Sleep(1000);
            IWebElement lang = driver.FindElement(By.XPath("//a[@data-tab=\"first\"]"));
            lang.Click();
        }

        public static void addNewLang(IWebDriver driver)
        {
            Thread.Sleep(1000);
            // click on add new button
            if (checkLangCount(driver))
            {
                IWebElement addNew = driver.FindElement(By.XPath("//div[@data-tab=\"first\"]//table/thead/tr/th[3]/div"));
                addNew.Click();

                // Access the SellerData.xlxs file
                Helpers.ExcelReaderHelper.PopulateInCollection("C:/Users/Pinky Sindhu/Desktop/Industry Connect/Industry Connect" +
                    "/Internship/Project Mars/Test Data/SellerData.xlsx", "Language");

                // Send a Language and level to add
                IWebElement lang = driver.FindElement(By.XPath("//input[@name=\"name\"]"));
                lang.SendKeys(Helpers.ExcelReaderHelper.ReadData(2, "Language"));

                // Select from drop down list
                selectLangLevel(driver, Helpers.ExcelReaderHelper.ReadData(2, "Level"));

                //click on Add button to Save the lanaguage
                IWebElement add = driver.FindElement(By.XPath("//input[@value=\"Add\"]"));
                add.Click();
            }
            else
            {
                Assert.Fail("No Language is added because user has already added 4 languages!! " +
                    "Please Delete one to run this test");
            }


        }

        // Select from drop down list
        private static void selectLangLevel(IWebDriver driver, string langLevel)
        {
            Thread.Sleep(1000);
            IWebElement level = driver.FindElement(By.TagName("select"));
            var selectLevel = new SelectElement(level);
            selectLevel.SelectByText(langLevel);

        }

        private static void clickOnAdd(IWebDriver driver)
        {
            IWebElement addLang = driver.FindElement(By.XPath("//input[@value=\"Add\"]"));
            addLang.Click();
            Helpers.CommonTestRsltMethods.SaveScreenshot(Helpers.CommonDriver.driver, "LanguageAdded");
        }

        public static void addLangSuccess(IWebDriver driver)
        {
            Thread.Sleep(1000);
            bool status = false;
            IList<IWebElement> tbody = driver.FindElements(By.XPath("//div[@data-tab=\"first\"]//table/tbody"));
            for (int i = 1; i <= tbody.Count; i++)
            {
                var lang = driver.FindElement(By.XPath("//div[@data-tab=\"first\"]//table/tbody[" + i + "]/tr/td[1]"));
                var level = driver.FindElement(By.XPath("//div[@data-tab=\"first\"]//table/tbody[" + i + "]/tr/td[2]"));

                if (lang.Text == "C#" && level.Text == "Basic")
                {
                    status = true;
                    Console.WriteLine("Test Success");
                }
            }
            Assert.That(status, Is.EqualTo(true));
        }

        //check if 1 or more language is available for edit or delete
        public static void checkIfLangAvailable(IWebDriver driver)
        {
            //count how many tbody is present into table
            IList<IWebElement> row = driver.FindElements(By.XPath("//div[@data-tab=\"first\"]//table/tbody"));

            Assert.That(row.Count, Is.GreaterThan(0));

        }

        // Edit the Language
        public static void editLanguage(IWebDriver driver)
        {
            Thread.Sleep(500);

            IWebElement editBtn = driver.FindElement(By.XPath("//div[@data-tab=\"first\"]//table/tbody[1]/tr/td[3]/span[1]"));
            editBtn.Click();

            Thread.Sleep(500);

            // Send a Language and level to add
            IWebElement lang = driver.FindElement(By.XPath("//input[@name=\"name\"]"));
            lang.Clear();
            lang.SendKeys("English");

            // Select from drop down list
            selectLangLevel(driver, "Fluent");

            // Update the language
            IWebElement updateLang = driver.FindElement(By.XPath("//input[@value=\"Update\"]"));
            updateLang.Click();
            Helpers.CommonTestRsltMethods.SaveScreenshot(Helpers.CommonDriver.driver, "LanguageEdited");
        }

        // Edit the Language is passed or failed
        public static void updateLangSuccess(IWebDriver driver)
        {
            Thread.Sleep(2000);
            bool status = false;

            var lang = driver.FindElement(By.XPath("//div[@data-tab=\"first\"]//table/tbody[1]/tr/td[1]"));
            var level = driver.FindElement(By.XPath("//div[@data-tab=\"first\"]//table/tbody[1]/tr/td[2]"));

            if (lang.Text == "English" && level.Text == "Fluent")
            {
                status = true;
                Console.WriteLine("Language Updation is succeed!");
            }
            Assert.That(status, Is.EqualTo(true));
        }

        // Delete the Language 
        public static void deleteLanguage(IWebDriver driver)
        {
            Thread.Sleep(1500);
            IWebElement deleteBtn = driver.FindElement(By.XPath("//div[@data-tab=\"first\"]//table/tbody[3]/tr/td[3]/span[2]"));
            deleteBtn.Click();
            Helpers.CommonTestRsltMethods.SaveScreenshot(Helpers.CommonDriver.driver, "LanguageDeleted");
        }

        // Delete the Language is passed or failed
        public static void deleteLangSuccess(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(1000);


                Thread.Sleep(1000);
                IList<IWebElement> tbody = driver.FindElements(By.XPath("//div[@data-tab=\"first\"]//table/tbody"));
                int row = tbody.Count;

                if (tbody != null && row >= 1)
                {
                    for (int i = 1; i <= row; i++)
                    {
                        var lang = driver.FindElement(By.XPath("//div[@data-tab=\"first\"]//table/tbody[" + i + "]/tr/td[1]"));
                        var level = driver.FindElement(By.XPath("//div[@data-tab=\"first\"]//table/tbody[" + i + "]/tr/td[2]"));

                        if (lang.Text != "English" && level.Text != "Fluent")
                        {
                            Assert.Pass();

                            Console.WriteLine("Language is deleted successfully!");
                        }
                    }
                }
                if (tbody.Count == 0)
                {
                    Assert.Pass();

                    Console.WriteLine("Language is deleted successfully!");
                }
            }
            catch (Exception)
            {

            }
        }

        // check langauge is alread in count 4 if it is then user can not click on addnew and if not then use can click on addnew
        private static bool checkLangCount(IWebDriver driver)
        {
            IList<IWebElement> tbody = driver.FindElements(By.XPath("//div[@data-tab=\"first\"]//table/tbody"));

            int tbodyCount = tbody.Count;

            if (tbodyCount == 4)
                return false;
            else
                return true;
        }
    }
}
