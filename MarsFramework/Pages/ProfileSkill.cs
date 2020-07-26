using MarsFramework.Base;
using MarsFramework.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class ProfileSkill
    {
        private IWebDriver driver;

        public ProfileSkill(IWebDriver driver)
        {
            this.driver = driver;
            GlobalDefinitions.ExcelLib.PopulateInCollection(paths.ExcelPath, "Profile");
            PageFactory.InitElements(driver, this);
        }


        #region Initialize IWebElement
        [FindsBy(How = How.XPath, Using = "//a[text()='Skills']")]
            private IWebElement SkillsButton { get; set; }



            [FindsBy(How = How.XPath, Using = "//div[@class='ui teal button']")]
            private IWebElement AddNewSkills { get; set; }


            [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'Add Skill')]")]
            private IWebElement SkillsText { get; set; }



            [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")]
            private IWebElement SkillsUpdate { get; set; }


            [FindsBy(How = How.XPath, Using = "//span[@class='buttons-wrapper']//input[@type='button'][@value='Add']")]
            private IWebElement btnAddSkill { get; set; }


            [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]")]
            private IWebElement UpdateButton { get; set; }
        #endregion

        //Add Skills
        internal void AddSkill()
        {
            //explicit wait
            GlobalDefinitions.WaitForClickableElement(driver, By.XPath("//a[text()='Skills']"), 30);

            //click on skill
            SkillsButton.Click();

                GlobalDefinitions.wait(30);

                //click on add new button
                AddNewSkills.Click();

                GlobalDefinitions.wait(30);

                //GlobalDefinitions.WaitForElement("//input[contains(@placeholder,'Add Skill')]");
                //add value in skill text 
                SkillsText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill"));

                //Skill level
                new SelectElement(driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"))).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SkillLevel")); 

                //click on add button
                btnAddSkill.Click();

                GlobalDefinitions.wait(30);
               
            }


        internal void ValidateAddUpdSkill(int excelrow)
        {
                //Validate the Skill is added sucessfully 
                try
                {
                //skills test
                     GlobalDefinitions.wait(30);
                    string skill = driver.FindElement(By.XPath("(//div[@data-tab='second']//table//tbody//tr[1]//td[1])[1]")).Text;
                    Console.WriteLine(skill);
                    Console.WriteLine(GlobalDefinitions.ExcelLib.ReadData(excelrow, "Skill"));
                    if(GlobalDefinitions.ExcelLib.ReadData(excelrow, "Skill")== skill)
                    {
                    Assert.IsTrue(true);
                    }

                }
                catch (Exception)
                {
                    Assert.Fail();
                }
                GlobalDefinitions.wait(30);

        }


            //Update skill
        internal void UpdateSkill()
        {
            //explicit wait
            GlobalDefinitions.WaitForClickableElement(driver, By.XPath("//a[text()='Skills']"), 30);

            //click on skill
            SkillsButton.Click();
              GlobalDefinitions.wait(30);

                    //get text of skill 
              var skilltext = driver.FindElement(By.XPath("//table/tbody/tr[last()]/td[1]")).Text;

              GlobalDefinitions.wait(30);

                 //click on pen icon update
                driver.FindElement(By.XPath("//table/tbody/tr[last()]/td[3]/span[1]")).Click();

                        //get skill text box 
                IWebElement skilledittext1 = driver.FindElement(By.XPath("//table/tbody/tr[last()]/td/div/div[1]/input"));

                 skilledittext1.Clear();

                        //enter skill
                 skilledittext1.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Skill"));

                        //click on update
                 driver.FindElement(By.XPath("//table/tbody/tr[last()]/td/div/span/input[1]")).Click();

        }


       
            //Delete a given language
        internal void DeleteSkill()
        {
            //explicit wait
            GlobalDefinitions.WaitForClickableElement(driver, By.XPath("//a[text()='Skills']"), 30);

            //click on skill
            SkillsButton.Click();

            String expectedvalue = GlobalDefinitions.ExcelLib.ReadData(2, "Skill");
            String expectedvalue1 = GlobalDefinitions.ExcelLib.ReadData(3, "Skill");
            //table row
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));

                //Get the row count of table
                var rowCount = Tablerows.Count;

                for (int i = 1; i <= rowCount; i++)
                {
                    //Get the xpath of skill name
                    //div/table/tbody[" + i + "]/tr/td[1]
                    String actualValue = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    // String actualValue = driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    //validate
                    if((expectedvalue == actualValue)|| (expectedvalue1 == actualValue))
                    {
                        driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[2]/i"));
                    Console.WriteLine("Deleted");
                    break;
                    }
                                
                }
        }


            //Validate deletion
        internal void ValidateDeleteSkill()
        {
               try
               {
                   String expectedValue = GlobalDefinitions.ExcelLib.ReadData(3, "Skill");

                //get the table list
                IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));

                   
                   string actualvalue = driver.FindElement(By.XPath("//div/table/tbody/tr[last()]/td[1]")).Text;

                        //check if expected value is not  equal to actual value
                   if (expectedValue != actualvalue)
                   {
                            Assert.Pass();
                   }
               }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Assert.Fail();
                 }
                GlobalDefinitions.wait(30);
        }


    }

}





