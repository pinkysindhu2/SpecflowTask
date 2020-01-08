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
    public class Education
    {
        // click on  Education Tab
        public static void clickOnEducationTab(IWebDriver driver)
        {
            Thread.Sleep(1000);
            IWebElement edu = driver.FindElement(By.XPath("//a[@data-tab=\"third\"]"));
            edu.Click();
        }

        // add a new Education
        public static void addNewEducation(IWebDriver driver)
        {
            Thread.Sleep(2000);
            // click on add new button
            IWebElement addEducation = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/thead/tr/th[6]/div"));
            addEducation.Click();

            // Access the SellerData.xlxs file
            Helpers.ExcelReaderHelper.PopulateInCollection(CommonUrls.excelFilePath, "Education");

            // Send a Education deatils to add
            educationData(driver, 2);

            //click on Add button to Save the Education
            clickOnAdd(driver);
        }

        // Select from drop down list
        private static void selectionFromDropDwon(IWebDriver driver, string value, string xpath)
        {
            Thread.Sleep(1000);
            IWebElement level = driver.FindElement(By.XPath(xpath));
            var selectLevel = new SelectElement(level);
            selectLevel.SelectByText(value);

        }

        private static void clickOnAdd(IWebDriver driver)
        {
            IWebElement addEdu = driver.FindElement(By.XPath("//input[@value=\"Add\"]"));
            addEdu.Click();
            Helpers.CommonTestRsltMethods.SaveScreenshot(Helpers.CommonDriver.driver, "EducationAdded");
        }

        public static void addEducationSuccess(IWebDriver driver)
        {
            Thread.Sleep(1000);

            bool status = false;

            IList<IWebElement> tbody = driver.FindElements(By.XPath("//div[@data-tab=\"third\"]//table/tbody"));

            for (int i = 1; i <= tbody.Count; i++)
            {
                var country = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[" + i + "]/tr/td[1]"));
                var uni = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[" + i + "]/tr/td[2]"));
                var title = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[" + i + "]/tr/td[3]"));
                var degree = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[" + i + "]/tr/td[4]"));
                var year = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[" + i + "]/tr/td[5]"));

                if (country.Text == Helpers.ExcelReaderHelper.ReadData(2, "Country")
                    && uni.Text == Helpers.ExcelReaderHelper.ReadData(2, "University") &&
                    title.Text == Helpers.ExcelReaderHelper.ReadData(2, "Title") &&
                    degree.Text == Helpers.ExcelReaderHelper.ReadData(2, "Degree") &&
                    year.Text == Helpers.ExcelReaderHelper.ReadData(2, "Graduated"))
                {
                    status = true;
                    Console.WriteLine("Test Success");
                }
            }
            Assert.That(status, Is.EqualTo(true));
        }

        public static void checkIfEducationAvailable(IWebDriver driver)
        {
            //count how many tbody is present into table
            IList<IWebElement> row = driver.FindElements(By.XPath("//div[@data-tab=\"third\"]//table/tbody"));

            Assert.That(row.Count, Is.GreaterThan(0));

        }

        // Edit the Education
        public static void editEducation(IWebDriver driver)
        {
            Thread.Sleep(1000);

            IWebElement editBtn = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[1]/tr[1]/td[6]/span[1]"));
            editBtn.Click();

            // Access the SellerData.xlxs file
            Helpers.ExcelReaderHelper.PopulateInCollection(CommonUrls.excelFilePath, "Education");

            Thread.Sleep(1000);

            // Update Education with new details
            educationData(driver, 3);

            // Update the language
            IWebElement updateLang = driver.FindElement(By.XPath("//input[@value=\"Update\"]"));
            updateLang.Click();
            Helpers.CommonTestRsltMethods.SaveScreenshot(Helpers.CommonDriver.driver, "EducationEdited");
        }

        // Edit the Skill is passed or failed
        public static void updateEducationSuccess(IWebDriver driver)
        {
            Thread.Sleep(2000);
            bool status = false;

            var country = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[1]/tr/td[1]"));
            var uni = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[1]/tr/td[2]"));
            var title = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[1]/tr/td[3]"));
            var degree = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[1]/tr/td[4]"));
            var year = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[1]/tr/td[5]"));

            if (country.Text == Helpers.ExcelReaderHelper.ReadData(3, "Country")
                && uni.Text == Helpers.ExcelReaderHelper.ReadData(3, "University") &&
                title.Text == Helpers.ExcelReaderHelper.ReadData(3, "Title") &&
                degree.Text == Helpers.ExcelReaderHelper.ReadData(3, "Degree") &&
                year.Text == Helpers.ExcelReaderHelper.ReadData(3, "Graduated"))
            {
                status = true;
                Console.WriteLine("Test Success");
            }
            Assert.That(status, Is.EqualTo(true));
        }

        // Delete the Education 
        public static void deleteEducation(IWebDriver driver)
        {
            Thread.Sleep(1500);
            IWebElement deleteBtn = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[1]/tr/td[6]/span[2]"));
            deleteBtn.Click();
            Helpers.CommonTestRsltMethods.SaveScreenshot(Helpers.CommonDriver.driver, "EducationDeleted");
        }

        // Delete the Language is passed or failed: It should run after edit the Education
        public static void deleteEducationSuccess(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(1000);
                bool status = false;

                // Access the SellerData.xlxs file
                Helpers.ExcelReaderHelper.PopulateInCollection(CommonUrls.excelFilePath, "Education");

                Thread.Sleep(1000);

                IList<IWebElement> tbody = driver.FindElements(By.XPath("//div[@data-tab=\"third\"]//table/tbody"));
                int row = tbody.Count;

                if (tbody != null && row >= 1)
                {
                    for (int i = 1; i <= row; i++)
                    {
                        var country = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[1]/tr/td[1]"));
                        var uni = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[1]/tr/td[2]"));
                        var title = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[1]/tr/td[3]"));
                        var degree = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[1]/tr/td[4]"));
                        var year = driver.FindElement(By.XPath("//div[@data-tab=\"third\"]//table/tbody[1]/tr/td[5]"));

                        if (country.Text != Helpers.ExcelReaderHelper.ReadData(3, "Country")
                            && uni.Text != Helpers.ExcelReaderHelper.ReadData(3, "University") &&
                            title.Text != Helpers.ExcelReaderHelper.ReadData(3, "Title") &&
                            degree.Text != Helpers.ExcelReaderHelper.ReadData(3, "Degree") &&
                            year.Text != Helpers.ExcelReaderHelper.ReadData(3, "Graduated"))
                        {
                            status = true;
                            Console.WriteLine("Test Success");
                        }
                    }
                }
                if (tbody.Count == 0)
                {
                    status = true;

                    Console.WriteLine("Education is deleted successfully!");
                }

                Assert.That(status, Is.EqualTo(true));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        private static void educationData(IWebDriver driver, int rowNumber)
        {
            IWebElement instituteName = driver.FindElement(By.XPath("//input[@name=\"instituteName\"]"));
            instituteName.Clear();
            instituteName.SendKeys(Helpers.ExcelReaderHelper.ReadData(rowNumber, "University"));

            // Select Country from drop down list
            selectionFromDropDwon(driver, Helpers.ExcelReaderHelper.ReadData(rowNumber, "Country"), "//select[@name=\"country\"]");

            // Select Title from drop down list
            selectionFromDropDwon(driver, Helpers.ExcelReaderHelper.ReadData(rowNumber, "Title"), "//select[@name=\"title\"]");

            // send Degree
            IWebElement degree = driver.FindElement(By.XPath("//input[@name=\"degree\"]"));
            degree.Clear();
            degree.SendKeys(Helpers.ExcelReaderHelper.ReadData(rowNumber, "Degree"));

            // Select Year of Graduation from drop down list
            selectionFromDropDwon(driver, Helpers.ExcelReaderHelper.ReadData(rowNumber, "Graduated"), "//select[@name=\"yearOfGraduation\"]");
        }
    }
}
