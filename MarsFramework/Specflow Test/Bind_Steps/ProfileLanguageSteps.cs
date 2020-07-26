using MarsFramework.Base;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsFramework.Specflow_Test.Bind_Steps
{
    [Binding]
    public class AddLanguageSteps
    {
        private readonly IWebDriver driver;
        public AddLanguageSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        ProfileLanguage language;

        [When(@"I add language")]
        public void WhenIAddLanguage()
        {
             language = new ProfileLanguage(driver);
            //start test
            //ExtentReport.test = ExtentReport.extent.StartTest("Add Language");
            language.Addlanguage();
        }
        
        [When(@"I update language")]
        public void WhenIUpdateLanguage()
        {
            language = new ProfileLanguage(driver);
            //start test
            // ExtentReport.test = ExtentReport.extent.StartTest("Update Language");
            language.UpdateLanguage();
        }
        
        [When(@"I delete language")]
        public void WhenIDeleteLanguage()
        {
            language = new ProfileLanguage(driver);
            //start test
            // ExtentReport.test = ExtentReport.extent.StartTest("Delete Language");
            language.DeleteLanguage();
        }
        
        [Then(@"I should be able to find the language")]
        public void ThenIShouldBeAbleToFindTheLanguage()
        {
            language.ValidateAddUpdLanguage(2);
            //string message = GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'ns-box-inner')]")).Text;
         
            //Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "Language") + " has been added to your languages", message);
        }

        [Then(@"I should be able to find the updated language")]
        public void ThenIShouldBeAbleToFindTheUpdatedLanguage()
        {
            language.ValidateAddUpdLanguage(3);
        }


        [Then(@"It should be able to remove from language")]
        public void ThenItShouldBeAbleToRemoveFromLanguage()
        {
            language.ValidateDeleteLanguage();
        }
    }
}
