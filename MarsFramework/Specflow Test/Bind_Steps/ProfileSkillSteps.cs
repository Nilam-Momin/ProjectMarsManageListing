using MarsFramework.Base;
using MarsFramework.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;


namespace MarsFramework.Specflow_Test.Bind_Steps
{
    [Binding]
    public class AddSkillSteps
    {
        private readonly IWebDriver driver;
        public AddSkillSteps(IWebDriver driver)
        {
            this.driver = driver;
        }
        ProfileSkill skill ;

        [When(@"I add Skill")]
        public void WhenIAddSkill()
        {
            skill = new ProfileSkill(driver);
            //start test
            //ExtentReport.test = ExtentReport.extent.StartTest("Add Skill");
            skill.AddSkill();
        }
        
        [When(@"I update Skill")]
        public void WhenIUpdateSkill()
        {
            skill = new ProfileSkill(driver);
            //start test
            // ExtentReport.test = ExtentReport.extent.StartTest("Update Skill");
            skill.UpdateSkill();
        }
        
        [When(@"I delete Skill")]
        public void WhenIDeleteSkill()
        {
            skill = new ProfileSkill(driver);
            //start test
            //ExtentReport.test = ExtentReport.extent.StartTest("Delete Skill");
            skill.DeleteSkill();
        }
        
        [Then(@"I should be able to find the Skill")]
        public void ThenIShouldBeAbleToFindTheSkill()
        {
            skill.ValidateAddUpdSkill(2);
        }

        [Then(@"I should be able to find the updated Skill")]
        public void ThenIShouldBeAbleToFindTheUpdatedSkill()
        {
            skill.ValidateAddUpdSkill(3);
        }


        [Then(@"It should be able to remove from Skill")]
        public void ThenItShouldBeAbleToRemoveFromSkill()
        {
            skill.ValidateDeleteSkill();
        }
    }
}
