using MarsFramework.Config;
using MarsFramework.Base;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using RazorEngine.Compilation.ImpromptuInterface;

namespace MarsFramework.Specflow_Test.Bind_Steps
{
    [Binding]
    public sealed class ProfileSteps
    {
        //create profile page object
        Profile ProfilePage;
        SearchSkill searchSkill;
        string Availabilitymessage;
        string Hourmessage;
        string EarnTargetmessage;
        string DescriptionMessage;
        private readonly IWebDriver driver;

        public ProfileSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I am on profile page")]
        public void GivenIAmOnProfilePage()
        {
            ProfilePage = new Profile(driver);
        }

        
        [When(@"I add availability")]
        public void WhenIAddAvailability()
        {
            //start test
         // ExtentReport.test = ExtentReport.extent.CreateTest("Add Availability");
            Availabilitymessage = ProfilePage.AddAvailability(GlobalDefinitions.ExcelLib.ReadData(2, "Availability"));
        }

        [When(@"I add AvailabilityHour")]
        public void WhenIAddAvailabilityHour()
        {
            //start test
           // ExtentReport.test = ExtentReport.extent.StartTest("Add Availability Hour");

            Hourmessage = ProfilePage.AddAvailabilityHour(GlobalDefinitions.ExcelLib.ReadData(2, "Hour"));

        }

        [When(@"I add EarnTarget")]
        public void WhenIAddEarnTarget()
        {
            //start test
            //ExtentReport.test = ExtentReport.extent.StartTest("Add Earn Target");

            EarnTargetmessage = ProfilePage.AddEarnTarget(GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget"));

        }

        [When(@"I update Description")]
        public void WhenIUpdateDescription()
        {
            //start test
           // ExtentReport.test = ExtentReport.extent.StartTest("Update Description");


            DescriptionMessage = ProfilePage.UpdateDescription();
        }

        [Given(@"I have navigated to the change password")]
        public void GivenIHaveNavigatedToTheChangePassword()
        {
            //start test
            //ExtentReport.test = ExtentReport.extent.StartTest("Chnge Password");
            ProfilePage.GoToChangePassword();
        }

        [When(@"I add new password detail")]
        public void WhenIAddNewPasswordDetail()
        {
            ProfilePage.ChangePassword(GlobalDefinitions.ExcelLib.ReadData(2, "ChangePassword"), GlobalDefinitions.ExcelLib.ReadData(2, "CurrentPassword"));
            //change password back to the old one
           // ProfilePage.GoToChangePassword();
           // ProfilePage.ChangePassword(GlobalDefinitions.ExcelLib.ReadData(2, "NewPassword"), GlobalDefinitions.ExcelLib.ReadData(2, "oldPassword"));
        }

        [Given(@"I searched for a skill")]
        public void GivenISearchedForASkill()
        {
            //start test
           //ExtentReport.test = ExtentReport.extent.();
            ProfilePage.SearchSkill();
        }

        [When(@"I filter the serach result")]
        public void WhenIFilterTheSerachResult()
        {
            searchSkill = new SearchSkill(driver);
            searchSkill.FilterSkill();//filter by onsite
            searchSkill.RefineSearch();//refine by programming
        }

        [Then(@"I should be able to view the skill I want")]
        public void ThenIShouldBeAbleToViewTheSkillIWant()
        {
            searchSkill.ValidateSearch();   
        }


        [Then(@"I should be able to change the password")]
        public void ThenIShouldBeAbleToChangeThePassword()
        {
           ProfilePage.ValidateChangedPassword();
        }



        [Then(@"I should be able to get confirmation message")]
        public void ThenIShouldBeAbleToGetConfirmationMessage()
        {
            if ((Availabilitymessage == "Availability updated") || (Hourmessage == "Availability updated") || (EarnTargetmessage == "Availability updated"))
            {
                Console.WriteLine(Availabilitymessage);
                Assert.IsTrue(true);
            }
        }

        [Then(@"I should be able to get description saved message")]
        public void ThenIShouldBeAbleToGetDescriptionSavedMessage()
        {
            Console.WriteLine(DescriptionMessage);
            Assert.AreEqual("Description has been saved successfully", DescriptionMessage);
        }


    }
}