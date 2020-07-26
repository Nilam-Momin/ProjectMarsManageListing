using MarsFramework.Base;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsFramework.Specflow_Test.Bind_Steps
{
    [Binding]
    public class ShareSkillSteps
    {
        string DeleteMessage;
        private readonly IWebDriver driver;
        public ShareSkillSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I have navigated to Share skill page")]
        public void GivenIHaveNavigatedToShareSkillPage()
        {
           // ExtentReport.test = ExtentReport.extent.StartTest("Add Listing");
            Profile profileObj = new Profile(driver);
            //go to shareskill page from profile page            
            profileObj.GoToShareSkill();
        }
        
        [Given(@"I have navigated to Manage Listing page")]
        public void GivenIHaveNavigatedToManageListingPage()
        {
            Profile profileObj = new Profile(driver);
            //go to manage listing              
            profileObj.GoToManageListing();
        }
        
        [When(@"I add my share skill details")]
        public void WhenIAddMyShareSkillDetails()
        {
            //fill out share skill form
            ShareSkill shareSkillObj = new ShareSkill(driver);
            shareSkillObj.EnterShareSkill();
        }
        
        [When(@"I edit my share skill details")]
        public void WhenIEditMyShareSkillDetails()
        {
            // ExtentReport.test = ExtentReport.extent.StartTest("Edit Share Skill");
            //ExtentReport.test = ExtentReport.extent.StartTest("Edit Listing");
            ManageListings manageListingsobj = new ManageListings(driver);
            //click edit listing
            manageListingsobj.EditListings();
            ShareSkill shareSkillObj = new ShareSkill(driver);
            //enter share skill
            shareSkillObj.EditShareSkill();
        }

        [When(@"I remove my share skill details")]
        public void WhenIRemoveMyShareSkillDetails()
        {
            //start test report
           // ExtentReport.test = ExtentReport.extent.StartTest("Delete a Listing");

            Profile profileObj = new Profile(driver);
            //go to manage listing              
            profileObj.GoToManageListing();
            //manage listing page object
            ManageListings manageListingsobj = new ManageListings(driver);

            //delete listing
            DeleteMessage = manageListingsobj.DeleteListing();
        }


        [Then(@"I should be able to see the listing")]
        public void ThenIShouldBeAbleToSeeTheListing()
        {
            //validate the listing on the manage listing page
            ManageListings manageListingsobj = new ManageListings(driver);
            manageListingsobj.FindListing();
        }
        
        [Then(@"I should be able to see the confirmation")]
        public void ThenIShouldBeAbleToSeeTheConfirmation()
        {
            //validates the delete listing

            Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "Title")+" has been deleted", DeleteMessage);
        }
    }
}
