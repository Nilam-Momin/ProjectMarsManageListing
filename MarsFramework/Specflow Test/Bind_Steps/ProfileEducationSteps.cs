using MarsFramework.Base;
using MarsFramework.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsFramework.Specflow_Test.Bind_Steps
{
    [Binding]
    public class AddEducationSteps
    {
        private IWebDriver driver;
        ProfileEducation education;
        public AddEducationSteps(IWebDriver driver)
        {
            this.driver = driver;
        }
       

        [When(@"I add education")]
        public void WhenIAddEducation()
        {
            education = new ProfileEducation(driver);
            //start test
            //  ExtentReport.test = ExtentReport.extent.StartTest("Add Education");
            education.AddEducation();
        }
        
        [When(@"I update education")]
        public void WhenIUpdateEducation()
        {
            education = new ProfileEducation(driver);
            //start test
            //ExtentReport.test = ExtentReport.extent.StartTest("Update Education");
            education.UpdateEducation();
            GlobalDefinitions.wait(50);
        }
        
        [When(@"I delete education")]
        public void WhenIDeleteEducation()
        {
            education = new ProfileEducation(driver);
            //start test
            // ExtentReport.test = ExtentReport.extent.StartTest("Delete Education");
            education.DeleteEduation();
        }
        
        [Then(@"I should be able to find the education")]
        public void ThenIShouldBeAbleToFindTheEducation()
        {
            education.ValidateAddUpd(2);
        }

        [Then(@"I should be able to find the updated education")]
        public void ThenIShouldBeAbleToFindTheUpdatedEducation()
        {
            education.ValidateAddUpd(3);
        }


        [Then(@"It should be able to remove from education")]
        public void ThenItShouldBeAbleToRemoveFromEducation()
        {
            education.DeleteValidation();
        }
    }
}
