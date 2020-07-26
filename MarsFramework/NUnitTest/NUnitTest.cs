using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using System;

namespace MarsFramework
{
    public class NUnitTest
    {
        [TestFixture]
        [Category("Sprint1")]
        class User
        {
            [Test]
            public void AddShareSkill()
            {
                //start test
                //ExtentReport.test = ExtentReport.extent.StartTest("Add Listing");
                Profile profileObj = new Profile();
               
                //go to shareskill page from profile page            
                profileObj.GoToShareSkill();
                //fill out share skill form
                ShareSkill shareSkillObj = new ShareSkill();
                shareSkillObj.EnterShareSkill();
                //validate the listing on the manage listing page
                ManageListings manageListingsobj = new ManageListings();
                manageListingsobj.FindListing();
                //shareSkillObj.ReadPopup();
                
                
               

            }

            [Test]
            public void EditShareSkill()
            {
                // ExtentReport.test = ExtentReport.extent.StartTest("Edit Share Skill");
                ExtentReport.test = ExtentReport.extent.StartTest("Edit Listing");
                Profile profileObj = new Profile();
                //go to manage listing              
                profileObj.GoToManageListing();
                ManageListings manageListingsobj = new ManageListings();
                //click edit listing
                manageListingsobj.EditListings();
                ShareSkill shareSkillObj = new ShareSkill();
                //enter share skill
                shareSkillObj.EditShareSkill();
                //validate the listing on the manage listing page and return the row no of the validated row
                manageListingsobj.FindListing();
            }

            [Test]
            public void RemoveAListing()
            {
                //start test report
                ExtentReport.test = ExtentReport.extent.StartTest("Delete a Listing");
                           
                Profile profileObj = new Profile();
                //go to manage listing              
                profileObj.GoToManageListing();
                //manage listing page object
                ManageListings manageListingsobj = new ManageListings();
                       
                //delete listing
                manageListingsobj.DeleteListing();
            }



        }
    }
}