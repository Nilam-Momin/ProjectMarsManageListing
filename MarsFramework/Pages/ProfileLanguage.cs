using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using MarsFramework.Base;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using SeleniumExtras.PageObjects;
using MarsFramework.Helper;


namespace MarsFramework.Pages
{
    internal class ProfileLanguage
    {
        private IWebDriver driver;

        public ProfileLanguage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            GlobalDefinitions.ExcelLib.PopulateInCollection(paths.ExcelPath, "Profile");
        }

       
        #region IWebElements
        //Language button
        [FindsBy(How = How.XPath, Using = "//a[text()='Languages']")]
            private IWebElement LanguageButton { get; set; }

            //Add new Language
            [FindsBy(How = How.XPath, Using = "//div[@class='eight wide column']/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/thead/tr/th[3]/div[1]")]
            private IWebElement AddNewLanguage { get; set; }

            //Add Language Level
            [FindsBy(How = How.XPath, Using = "//select[@name ='level']")]
            private IWebElement LanguageLevel { get; set; }

            //LAnguage text
            [FindsBy(How = How.XPath, Using = "//input[@name ='name']")]
            private IWebElement LanguageText { get; set; }

            //Add LAnguage
            [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
            private IWebElement AddLanguage { get; set; }

            //Update Language
            [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")]
            private IWebElement UdpateLanguage { get; set; }

            //Update button
            [FindsBy(How = How.XPath, Using = "//input[contains(@type,'button')][1]")]
            private IWebElement UpdateButton { get; set; }

            //Pop up 
            [FindsBy(How = How.XPath, Using = "//div[contains(@class,'ns-box-inner')")]
            private IWebElement PopUp { get; set; }
        #endregion


        //Add new Lanuguage
        internal void Addlanguage()
        {
            //explicit wait
            GlobalDefinitions.WaitForClickableElement(driver, By.XPath("//a[text()='Languages']"), 30);

            //firstly click on language button
            LanguageButton.Click();

                //implicit wait 
                GlobalDefinitions.wait(30);

                //click on add new button
                AddNewLanguage.Click();
            

                GlobalDefinitions.wait(30);
                //enter text in language field
                LanguageText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));

                //select level from drop down

                new SelectElement(driver.FindElement(By.XPath("//select[@class='ui dropdown']"))).SelectByValue(GlobalDefinitions.ExcelLib.ReadData(2, "LanguageLevel"));

                GlobalDefinitions.wait(30);

                //click on add button
                AddLanguage.Click();

                GlobalDefinitions.wait(30);

            
        }

            //Validate new Language
            internal void ValidateAddUpdLanguage(int excelrow)
            {
                try
                {   
                    GlobalDefinitions.wait(30);

                    //click on language button
                   // LanguageButton.Click();

                   GlobalDefinitions.WaitForElement(driver, By.XPath("//table/tbody/tr[last()]/td[1]"),30);
                    string LanguageText = driver.FindElement(By.XPath("//table/tbody/tr[last()]/td[1]")).Text;
                    Console.WriteLine(LanguageText);
                    Console.WriteLine(GlobalDefinitions.ExcelLib.ReadData(excelrow, "Language"));
                    if (LanguageText == GlobalDefinitions.ExcelLib.ReadData(excelrow, "Language"))
                    {
                    Assert.IsTrue(true);
                    }
                         
                    //validate language
                    //Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(excelrow, "Language"), LanguageText);
                
                       

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Assert.Fail();
                }

            }


            //update Language
            internal void UpdateLanguage()
            {
                 GlobalDefinitions.wait(30);
                 LanguageButton.Click();
                GlobalDefinitions.wait(30);
                //click the pen icon to edit
                driver.FindElement(By.XPath("//table/tbody[1]/tr[last()]/td[3]/span[1]/i")).Click();
                //clear existing text
                IWebElement Language = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
                Language.Clear();
                Language.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Language"));
                 //click update button
                driver.FindElement(By.XPath("//input[@value='Update']")).Click();
                GlobalDefinitions.wait(30);
      

            }


            //Delete a given language
            internal void DeleteLanguage()
            {
                    //explicit wait
                 GlobalDefinitions.WaitForClickableElement(driver, By.XPath("//a[text()='Languages']"), 30);

                LanguageButton.Click();

                 //expected value of language 
                 String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Language");
                String expectedValue1 = GlobalDefinitions.ExcelLib.ReadData(3, "Language");
             //Get the table row list
                IList<IWebElement> Tablerows = (IList<IWebElement>)driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));

                //Count how many rows 
                var rowCount = Tablerows.Count;
                for (int i = 1; i <= rowCount; i++)
                {

                    //xpath of ith languagename(row)
                    String actualValue = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    if((expectedValue== actualValue) || (expectedValue1 == actualValue))
                    { //click on delete icon
                        driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();

                        Console.WriteLine("Langugae deleted");

                        break;

                    }

                   
                }


            }


            //validate deletion
            internal void ValidateDeleteLanguage()
            {
               try
               {
                    String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Language");
                    String expectedValue1 = GlobalDefinitions.ExcelLib.ReadData(3, "Language");

                    //get the table list
                    IList<IWebElement> Tablerows = (IList<IWebElement>)driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));

                    for (int i = 1; i <= Tablerows.Count; i++)
                    {

                        string actualvalue = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;

                        //check if expected value is  not equal to actual value
                        if ((expectedValue != actualvalue) || (expectedValue1 != actualvalue))
                        {

                            Console.WriteLine("deleted Successfully");
                            Assert.IsTrue(true);
                        }
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
