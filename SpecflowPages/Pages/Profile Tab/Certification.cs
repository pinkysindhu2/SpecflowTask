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
    public class Certification
    {
        // click on Certification Tab
        public static void clickOnCertificationTab(IWebDriver driver)
        {
            Thread.Sleep(1000);
            IWebElement certi = driver.FindElement(By.XPath("//a[@data-tab=\"fourth\"]"));
            certi.Click();
        }

        // add a new Education
        public static void addNewCertification(IWebDriver driver)
        {
            Thread.Sleep(2000);
            // click on add new button
            IWebElement addCertification = driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]//table/thead/tr/th[4]/div"));
            addCertification.Click();

            // Access the SellerData.xlxs file
            Helpers.ExcelReaderHelper.PopulateInCollection(CommonUrls.excelFilePath, "Certification");

            // Send a Certification deatils to add
            certificationData(driver, 2);

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
            IWebElement addCertification = driver.FindElement(By.XPath("//input[@value=\"Add\"]"));
            addCertification.Click();
            Helpers.CommonTestRsltMethods.SaveScreenshot(Helpers.CommonDriver.driver, "CertificationAdded");
        }

        public static void addCertificationSuccess(IWebDriver driver)
        {
            Thread.Sleep(2000);

            bool status = false;

            IList<IWebElement> tbody = driver.FindElements(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody"));

            for (int i = 1; i <= tbody.Count; i++)
            {
                var certificateName = driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody[" + i + "]/tr/td[1]"));
                var certifiedFrom = driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody[" + i + "]/tr/td[2]"));
                var year = driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody[" + i + "]/tr/td[3]"));

                if (certificateName.Text == Helpers.ExcelReaderHelper.ReadData(2, "Certification/Award Name") &&
                    certifiedFrom.Text == Helpers.ExcelReaderHelper.ReadData(2, "Certified From") &&
                    year.Text == Helpers.ExcelReaderHelper.ReadData(2, "Year"))
                {
                    status = true;
                    Console.WriteLine("Test Success");
                }
            }
            Assert.That(status, Is.EqualTo(true));
        }

        public static void checkIfCertificationAvailable(IWebDriver driver)
        {
            //count how many tbody is present into table
            Thread.Sleep(1000);
            IList<IWebElement> row = driver.FindElements(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody"));
            Assert.That(row.Count, Is.GreaterThan(0));

        }

        //Edit the First row of Certification
        public static void editCertification(IWebDriver driver)
        {
            Thread.Sleep(1500);

            IWebElement editBtn = driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody[1]/tr[1]/td[4]/span[1]"));
            editBtn.Click();

            // Access the SellerData.xlxs file
            Helpers.ExcelReaderHelper.PopulateInCollection(CommonUrls.excelFilePath, "Certification");

            Thread.Sleep(1000);

            // Update Education with new details
            certificationData(driver, 3);

            // Update the language
            IWebElement updateLang = driver.FindElement(By.XPath("//input[@value=\"Update\"]"));
            updateLang.Click();
            Helpers.CommonTestRsltMethods.SaveScreenshot(Helpers.CommonDriver.driver, "CertificationEdited");
        }

        // Edit the First row of Certification is passed or failed
        public static void updateCertificationSuccess(IWebDriver driver)
        {
            Thread.Sleep(2000);
            bool status = false;

            var certificateName = driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody[1]/tr/td[1]"));
            var certifiedFrom = driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody[1]/tr/td[2]"));
            var year = driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody[1]/tr/td[3]"));


            if (certificateName.Text == Helpers.ExcelReaderHelper.ReadData(3, "Certification/Award Name")
                && certifiedFrom.Text == Helpers.ExcelReaderHelper.ReadData(3, "Certified From") &&
                year.Text == Helpers.ExcelReaderHelper.ReadData(3, "Year"))
            {
                status = true;
                Console.WriteLine("Test Success");
            }
            Assert.That(status, Is.EqualTo(true));
        }

        // Delete the first row of Certification
        public static void deleteCertification(IWebDriver driver)
        {
            Thread.Sleep(1500);
            IWebElement deleteBtn = driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody[1]/tr/td[4]/span[2]"));
            deleteBtn.Click();
            Helpers.CommonTestRsltMethods.SaveScreenshot(Helpers.CommonDriver.driver, "CertificationDeleted");
        }

        // Delete the Certification is passed or failed: It should run after edit the Certification
        public static void deleteCertificationSuccess(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(1000);
                bool status = false;

                // Access the SellerData.xlxs file
                Helpers.ExcelReaderHelper.PopulateInCollection(CommonUrls.excelFilePath, "Certification");

                Thread.Sleep(1500);

                IList<IWebElement> tbody = driver.FindElements(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody"));
                int row = tbody.Count;

                if (tbody != null && row >= 1)
                {
                    for (int i = 1; i <= row; i++)
                    {

                        var certificateName = driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody[" + i + "]/tr/td[1]"));
                        var certifiedFrom = driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody[" + i + "]/tr/td[2]"));
                        var year = driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]//table/tbody[" + i + "]/tr/td[3]"));

                        if (certificateName.Text == Helpers.ExcelReaderHelper.ReadData(3, "Certification/Award Name") &&
                            certifiedFrom.Text == Helpers.ExcelReaderHelper.ReadData(3, "Certified From") &&
                            year.Text == Helpers.ExcelReaderHelper.ReadData(3, "Year"))
                        {
                            status = true;
                            Console.WriteLine("Test Success");
                        }
                    }
                }
                if (tbody.Count == 0)
                {
                    status = true;

                    Console.WriteLine("Certification is deleted successfully!");
                }

                Assert.That(status, Is.EqualTo(true));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        private static void certificationData(IWebDriver driver, int rowNumber)
        {
            // send certification name
            IWebElement certificationName = driver.FindElement(By.XPath("//input[@name=\"certificationName\"]"));
            certificationName.Clear();
            certificationName.SendKeys(Helpers.ExcelReaderHelper.ReadData(rowNumber, "Certification/Award Name"));

            // send Certified from
            IWebElement certifiedFrom = driver.FindElement(By.XPath("//input[@name=\"certificationFrom\"]"));
            certifiedFrom.Clear();
            certifiedFrom.SendKeys(Helpers.ExcelReaderHelper.ReadData(rowNumber, "Certified From"));

            // Select yesr from drop down list
            selectionFromDropDwon(driver, Helpers.ExcelReaderHelper.ReadData(rowNumber, "Year"), "//select[@name=\"certificationYear\"]");
        }
    }
}
