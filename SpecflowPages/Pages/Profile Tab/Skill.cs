using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowPages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpecflowPages.Pages.Profile_Tab
{
    public class Skill
    {
        // click on Skill Tab
        public static void clickOnSkillTab(IWebDriver driver)
        {
            Thread.Sleep(1000);
            IWebElement skill = driver.FindElement(By.XPath("//a[@data-tab=\"second\"]"));
            skill.Click();
        }

        // add a new skill
        public static void addNewSkill(IWebDriver driver)
        {
            Thread.Sleep(2000);
            // click on add new button
            IWebElement addSkill = driver.FindElement(By.XPath("//div[@data-tab=\"second\"]//table/thead/tr/th[3]/div"));
            addSkill.Click();

            // Access the SellerData.xlxs file
            Helpers.ExcelReaderHelper.PopulateInCollection(CommonUrls.excelFilePath, "Skill");

            // Send a Skill and level to add
            IWebElement skill = driver.FindElement(By.XPath("//input[@name=\"name\"]"));
            skill.SendKeys(Helpers.ExcelReaderHelper.ReadData(2, "Skill"));

            // Select from drop down list
            selectSkillLevel(driver, Helpers.ExcelReaderHelper.ReadData(2, "Level"));

            //click on Add button to Save the Skill
            IWebElement add = driver.FindElement(By.XPath("//input[@value=\"Add\"]"));
            add.Click();
        }

        // Select from drop down list
        private static void selectSkillLevel(IWebDriver driver, string langLevel)
        {
            Thread.Sleep(1000);
            IWebElement level = driver.FindElement(By.TagName("select"));
            var selectLevel = new SelectElement(level);
            selectLevel.SelectByText(langLevel);

        }

        private static void clickOnAdd(IWebDriver driver)
        {
            IWebElement addSkill = driver.FindElement(By.XPath("//input[@value=\"Add\"]"));
            addSkill.Click();
            Helpers.CommonTestRsltMethods.SaveScreenshot(Helpers.CommonDriver.driver, "SkillAdded");
        }

        public static void addSkillSuccess(IWebDriver driver)
        {
            Thread.Sleep(2000);
            bool status = false;

            IList<IWebElement> tbody = driver.FindElements(By.XPath("//div[@data-tab=\"second\"]//table/tbody"));

            for (int i = 1; i <= tbody.Count; i++)
            {
                var skill = driver.FindElement(By.XPath("//div[@data-tab=\"second\"]//table/tbody[" + i + "]/tr/td[1]"));
                var level = driver.FindElement(By.XPath("//div[@data-tab=\"second\"]//table/tbody[" + i + "]/tr/td[2]"));

                if (skill.Text == "C#" && level.Text == "Beginner")
                {
                    status = true;
                    Console.WriteLine("Test Success");
                }
            }
            Assert.That(status, Is.EqualTo(true));
        }

        public static void checkIfSkillAvailable(IWebDriver driver)
        {
            Thread.Sleep(1000);
            //count how many tbody is present into table
            IList<IWebElement> row = driver.FindElements(By.XPath("//div[@data-tab=\"second\"]//table/tbody"));

            Assert.That(row.Count, Is.GreaterThan(0));

        }

        // Edit the Language
        public static void editSkill(IWebDriver driver)
        {
            Thread.Sleep(1000);

            IWebElement editBtn = driver.FindElement(By.XPath("//div[@data-tab=\"second\"]//table/tbody[1]/tr/td[3]/span[1]"));
            editBtn.Click();

            Thread.Sleep(800);

            // Send a Language and level to add
            IWebElement lang = driver.FindElement(By.XPath("//input[@name=\"name\"]"));
            lang.Clear();
            lang.SendKeys(".Net");

            // Select from drop down list
            selectSkillLevel(driver, "Expert");

            // Update the language
            IWebElement updateLang = driver.FindElement(By.XPath("//input[@value=\"Update\"]"));
            updateLang.Click();
            Helpers.CommonTestRsltMethods.SaveScreenshot(Helpers.CommonDriver.driver, "SkillEdited");
        }

        // Edit the Skill is passed or failed
        public static void updateSkillSuccess(IWebDriver driver)
        {
            Thread.Sleep(2000);
            bool status = false;

            var skill = driver.FindElement(By.XPath("//div[@data-tab=\"second\"]//table/tbody[1]/tr/td[1]"));
            var level = driver.FindElement(By.XPath("//div[@data-tab=\"second\"]//table/tbody[1]/tr/td[2]"));

            if (skill.Text == ".Net" && level.Text == "Expert")
            {
                status = true;
                Console.WriteLine("Skill Updation is succeed!");
            }
            Assert.That(status, Is.EqualTo(true));
        }

        // Delete the SKill 
        public static void deleteSkill(IWebDriver driver)
        {
            Thread.Sleep(1500);
            IWebElement deleteBtn = driver.FindElement(By.XPath("//div[@data-tab=\"second\"]//table/tbody[1]/tr/td[3]/span[2]"));
            deleteBtn.Click();
            Helpers.CommonTestRsltMethods.SaveScreenshot(Helpers.CommonDriver.driver, "SkillDeleted");
        }

        // Delete the Language is passed or failed
        public static void deleteSkillSuccess(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(1500);
                bool status = false;

                IList<IWebElement> tbody = driver.FindElements(By.XPath("//div[@data-tab=\"second\"]//table/tbody"));
                int row = tbody.Count;

                if (tbody != null && row >= 1)
                {
                    for (int i = 1; i <= row; i++)
                    {
                        var skill = driver.FindElement(By.XPath("//div[@data-tab=\"second\"]//table/tbody[" + i + "]/tr/td[1]"));
                        var level = driver.FindElement(By.XPath("//div[@data-tab=\"second\"]//table/tbody[" + i + "]/tr/td[2]"));

                        if (skill.Text != ".Net" && level.Text != "Expert")
                        {
                            status = true;
                            Console.WriteLine("Skill is deleted successfully!");
                        }
                    }
                }
                if (tbody.Count == 0)
                {
                    status = true;

                    Console.WriteLine("Skill is deleted successfully!");
                }

                Assert.That(status, Is.EqualTo(true));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

    }
}
