using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowPages.Helpers
{
    public class CommonUrls
    {
        //Base Url
        public static string ProjectUrl = "http://www.skillswap.pro/";

       static string solutionParentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;

        //SelerData.Excel file path
        public static string excelFilePath = Path.Combine(solutionParentDirectory, @"SpecflowPages\Test Data\SellerData.xlsx");
        //ScreenshotPath
        public static string ScreenshotPath = Path.Combine(solutionParentDirectory,@"SpecflowPages\Test Reports\ScreenShots\");

        //ExtentReportsPath: HTML Report Path
        public static string ReportsPath = Path.Combine(solutionParentDirectory, @"SpecflowPages\Test Reports\HTMLReport\Test.html");

        //ReportXML Path: XML Report Path
        public static string ReportXMLPath = Path.Combine(solutionParentDirectory, @"SpecflowPages\Test Reports\XMLReport\Report.xml");
    
 
    }
}
