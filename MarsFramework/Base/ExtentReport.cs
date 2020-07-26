using MarsFramework.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RazorEngine.Compilation.ImpromptuInterface;
//using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using static MarsFramework.Base.GlobalDefinitions;
using System.IO;
using AventStack.ExtentReports;
using MarsFramework.Helper;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace MarsFramework.Base
{
    [TestFixture]
    public static class ExtentReport
    {
        // instance of extent reports
        public static ExtentTest test;
        public static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;

        ////paths for the reports
        //public static string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
        //public static string ReportPath = path + "\\" + MarsResource.ReportPath;
        // public static string ReportXmlPath = path + "\\" + MarsResource.ReportXMLPath;

        //OneTimeSetup
        public static void InitializeReport()
        {
            //Boolean value for replacing exisisting report

           // extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            htmlReporter = new ExtentHtmlReporter(paths.ReportPath);

            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);

            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;


            //Add QA system info to html report

            extent.AddSystemInfo("Host Name", "SkillSwap");

            extent.AddSystemInfo("Environment", "YourQAEnvironment");

               extent.AddSystemInfo("Username", "Nilam");

            //Adding config.xml file
            //Get the config.xml file from http://extentreports.com
           // extent.LoadConfig(paths.ReportXmlPath);
        }

        //TearDown
        public static void AfterTest(IWebDriver driver)
        {
            try
            {
                //StackTrace details for failed Testcases

                var status = TestContext.CurrentContext.Result.Outcome.Status;

                var stackTrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;

                if (status == TestStatus.Failed)
                {
                    
                    String img = ExcelLib.SaveScreenShotClass.SaveScreenshot(driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                   
                    test.Log(Status.Fail, status + errorMessage);

                    test.Log(Status.Fail, status + "Image example: " + img);

                }

                else if (status == TestStatus.Passed)
                {

                    String img = ExcelLib.SaveScreenShotClass.SaveScreenshot(driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");

                    test.Log(Status.Pass, "Test Passed" );
                }

                else if (status == TestStatus.Skipped)
                {

                    String img = ExcelLib.SaveScreenShotClass.SaveScreenshot(driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");

                    test.Log(Status.Skip, "Test Skipped");
                }
               

            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        
    }


       

    
}

