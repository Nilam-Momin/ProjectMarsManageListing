using MarsFramework.Base;
using MarsFramework.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsFramework.Specflow_Test.Bind_Steps
{
    [Binding]
    public class AddACertificationSteps
    {
        private IWebDriver driver;
        ProfileCertification certification;
        public AddACertificationSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        
                    
        [When(@"I add certification")]
        public void WhenIAddCertification()
        {
            certification = new ProfileCertification(driver);
            certification.AddCertification();
            
        }
        
        [When(@"I update certification")]
        public void WhenIUpdateCertification()
        {
            certification = new ProfileCertification(driver);
            certification.UpdateCertification();
        }
        
        [When(@"I delete certification")]
        public void WhenIDeleteCertification()
        {
            certification = new ProfileCertification(driver);
           certification.DeleteCertification();
        }
        
        [Then(@"I should be able to find the certification")]
        public void ThenIShouldBeAbleToFindTheCertification()
        {
            certification.ValidateAddUpdcertifications(2);
        }

        [Then(@"I should be able to find the updated certification")]
        public void ThenIShouldBeAbleToFindTheUpdatedCertification()
        {
            certification.ValidateAddUpdcertifications(3);
        }


        [Then(@"It should be able to remove from certification")]
        public void ThenItShouldBeAbleToRemoveFromCertification()
        {
            certification.ValidateDeleteCertification();
        }
    }
}
