using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using Gherkin.Ast;
using MarsFramework.Config;
using MarsFramework.Helper;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using TechTalk.SpecFlow;
using static MarsFramework.Base.GlobalDefinitions;

namespace MarsFramework.Base
{
   [Binding] 
   public sealed class Hooks
   {
       
        public static IWebDriver driver { get; set; }
        private readonly IObjectContainer objectContainer;
        private static ExtentTest scenario;
        private static ExtentTest featureName;


        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
          
        }

        [BeforeTestRun]
        public static void BeforeTestFixture()
        {
          
            ExtentReport.InitializeReport();
            Console.WriteLine("Before test run");
           
        }

        [BeforeFeature]
        [Obsolete]
        public static void BeforeFeature()
        {

            
            //Create dynamic feature name
            featureName = ExtentReport.extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(FeatureContext.Current.FeatureInfo.Title);
            Console.WriteLine("BeforeFeature");          
        }

            #region setup and tear down
        [BeforeScenario]
        [Obsolete]
        public void Inititalize()
        {
            Console.WriteLine("BeforeScenario");
            scenario = featureName.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            //initialize browser
            driver = new ChromeDriver();
            //InitializeBrowser(paths.Browser);
            objectContainer.RegisterInstanceAs(driver);
            driver.Navigate().GoToUrl(paths.BaseUrl);
           
            //go to sign in or signup
            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn(driver);

                loginobj.LoginSteps();
            }
            else
            {
                SignUp signUpobj = new SignUp(driver);
                signUpobj.register();
            }

        }


        [AfterStep]
        [Obsolete]
        public void InsertReportingSteps()
        {
            ExtentReport.test = scenario;
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
            }
        }


        [AfterScenario]
        public static void TearDown(IWebDriver driver)
        { // End Test Report and Close the driver
          //
           
            ExtentReport.extent.Flush();
           
            ExtentReport.AfterTest(driver);
            driver.Quit();
            Console.WriteLine("After scenario");
        }
        #endregion

       
        [AfterTestRun]
        public static void AfterTestFixture()
        {
           // ExtentReport.AfterTest(driver);
     
            Console.WriteLine("After test run");
        }


    }
}