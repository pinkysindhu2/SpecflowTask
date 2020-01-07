using SpecflowPages.Base_Class;
using SpecflowPages.Helpers;
using SpecflowPages.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using RelevantCodes.ExtentReports;


namespace SpecflowTests.Hookups
{
    [Binding]
    public sealed class StartHooks
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            //TODO: Initilaize the driver, login before every scenario
            Browser.InitWebDriver();

            // Naviagte to the home page
            Home.NavigateToPortal(CommonDriver.driver);
            Home.clickOnLogin(CommonDriver.driver);

            // Login into the Project Mars
            Login.enterLoginInfo(CommonDriver.driver);
            Login.clickOnLoginBtn(CommonDriver.driver);
            Login.loginSuccess(CommonDriver.driver);

            scenario = extent.StartTest(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public static void AfterScenario(ScenarioContext scenarioContext)
        {
            //  string img = CommonTestRsltMethods.SaveScreenshot(CommonDriver.driver, "Report");

            //scenario.Log(scenario.GetCurrentStatus(), "Snapshot below: " + scenario.AddScreenCapture(img));

            if (scenarioContext.TestError == null)
            {
                scenario.Log(LogStatus.Pass, scenario.Description);
            }
            else if (scenarioContext.TestError != null)
            {
                scenario.Log(LogStatus.Fail, scenario.Description);
            }
            featureName.AppendChild(scenario);

            extent.EndTest(scenario);

            //TODO: Quit the driver
            Browser.QuitDriver();
        }

        [BeforeTestRun]
        public static void InitilizeReport()
        {
            extent = new ExtentReports(CommonUrls.ReportsPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(CommonUrls.ReportXMLPath);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.EndTest(featureName);
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureName = extent.StartTest(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
        }

    }
}
