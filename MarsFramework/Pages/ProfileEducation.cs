using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using MarsFramework.Pages;
using static NUnit.Core.NUnitFramework;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsFramework.Base;
using Assert = NUnit.Framework.Assert;
using Gherkin.Events.Args.Pickle;
using MarsFramework.Helper;

namespace MarsFramework.Pages
{
    class ProfileEducation
    {
        private IWebDriver driver;

        public ProfileEducation(IWebDriver driver)
        {
            this.driver = driver;
            GlobalDefinitions.ExcelLib.PopulateInCollection(paths.ExcelPath, "Profile");
            PageFactory.InitElements(driver, this);
        }

        #region IWebElements
        [FindsBy(How = How.XPath, Using = "//a[text()='Education']")]
        private IWebElement EducationButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[1]/div[2]/div[1]/table[1]/thead/tr/th[6]/div[1]")]
        private IWebElement AddNewEducation { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='degree']")]
        private IWebElement DegreeText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='text'][@name='instituteName']")]
        private IWebElement InstituteText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[2]//div//div[3]//div//input[@type='button'][@value='Add']")]
        private IWebElement btnAddEducation { get; set; }
        //*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i";

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i")]
        private IWebElement EducationUpdate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]")]
        private IWebElement UpdateButton { get; set; }

        [FindsBy(How =How.XPath, Using = "//input[contains(@value,'Update')]")]
        private IWebElement UpdateButton1 { get; set; }
        #endregion

        // select dropdown for education and certification
        private void selectdropdown(string dropdownname, string value)
        {
            new SelectElement(driver.FindElement(By.XPath("//select[contains(@name,'" + dropdownname + "')]"))).SelectByValue(value);
        }



        //Add Education 
        internal void AddEducation()
        {
           
            GlobalDefinitions.WaitForClickableElement(driver, By.XPath("//a[text()='Education']"),30);

            EducationButton.Click();

            GlobalDefinitions.wait(30);


            AddNewEducation.Click();

            //adding text in institute name
            InstituteText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "University"));

            // select dropdown
            selectdropdown("country", GlobalDefinitions.ExcelLib.ReadData(2, "Country"));
            selectdropdown("title", GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            selectdropdown("yearOfGraduation", GlobalDefinitions.ExcelLib.ReadData(2, "Year"));

            //enter degree 
            DegreeText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Degree"));

            GlobalDefinitions.wait(30);

            // add education
            btnAddEducation.Click();

            GlobalDefinitions.wait(30);

        }

        //Validate add
        internal void ValidateAddUpd(int excelrow)
        {
            GlobalDefinitions.wait(50);
            try
            {
                GlobalDefinitions.WaitForElement(driver, By.XPath("(//table/tbody/tr)[last()]"), 90);
                
                 //Get the table list
                 // GlobalDefinitions.wait(50);
                var lastRow = driver.FindElements(By.XPath("(//table/tbody/tr)[last()]/td"));
                GlobalDefinitions.wait(50);
               
                Assert.Multiple(() =>
                {
                    Assert.That(lastRow[1].Text, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(excelrow, "University")));

                    Assert.That(lastRow[2].Text, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(excelrow, "Title")));

                    Assert.That(lastRow[3].Text, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(excelrow, "Degree")));
                    Assert.That(lastRow[4].Text, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(excelrow, "Year")));
                    Assert.That(lastRow[0].Text, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(excelrow, "Country")));

                });


                //foreach (var Td in TableRow)
                //{   
                //    //var Td = row.FindElements(By.TagName("td"));
                //    Console.WriteLine(Td.Count.ToString());
                //    Console.WriteLine(Td[0].Text);
                //    Console.WriteLine(Td[1].Text);
                //    /*Console.WriteLine(Td[2].ToString());
                //    Console.WriteLine(Td[3].ToString());
                //    Console.WriteLine(Td[4].ToString());*/
                   
                //}
          
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.Fail();
            }
         }

        //update education
        internal void UpdateEducation()
        {

            GlobalDefinitions.WaitForClickableElement(driver, By.XPath("//a[text()='Education']"), 30);

            EducationButton.Click();

            String ExpectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "University");

            //Get the table list
            IList<IWebElement> TRows = driver.FindElements(By.XPath("//table/tbody/tr"));

            //Get the row counts
            var rows = TRows.Count;
            //for (int i = 1; i <= rows; i++)
            //{
            //    GlobalDefinitions.wait(30);

            //    //get xpath
            //    String ActualValue = driver.FindElement(By.XPath("//table/tbody/tr["+i+"]/td[2]")).Text;

            //    //check value

            //    if (ActualValue.Equals(ExpectedValue))
               // {
                    //CliCk on update pen icon
                    driver.FindElement(By.XPath("(//table/tbody/tr)[last()]/td[6]/span[1]/i")).Click();

                    //update uni
                    IWebElement editRowValue = driver.FindElement(By.XPath("(//table/tbody/tr)[last()]/td/div/div[1]/input"));

                    editRowValue.Clear();
                    editRowValue.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "University"));

                    // update Country of College
                    new SelectElement(driver.FindElement(By.XPath("(//table/tbody/tr)[last()]/td/div[1]/div[2]/select"))).SelectByValue(GlobalDefinitions.ExcelLib.ReadData(3, "Country"));


                    // update Title
                    new SelectElement(driver.FindElement(By.XPath("(//table/tbody/tr)[last()]/td/div[2]/div[1]/select"))).SelectByValue(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));

                    //update the Degree
                    IWebElement EditDegree = driver.FindElement(By.XPath("(//table/tbody/tr)[last()]/td/div[2]/div[2]/input"));

                    EditDegree.Clear();
                    EditDegree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Degree"));

                    //update the Year 
                    new SelectElement(driver.FindElement(By.XPath("(//table/tbody/tr)[last()]/td/div[2]/div[3]/select"))).SelectByValue(GlobalDefinitions.ExcelLib.ReadData(3, "Year"));

                    // Click on update button
                    // driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td/div[3]/input[1]")).Click();
                    //driver.FindElement(By.XPath("//input[contains(@value,'Update')]")).Click();
                    UpdateButton1.Click();
                    GlobalDefinitions.wait(500);
                    Thread.Sleep(5000);
                    Console.WriteLine("updated");
               // }
           // }
        }

        //Delete Education
        internal void DeleteEduation()
        {
            GlobalDefinitions.WaitForClickableElement(driver, By.XPath("//a[text()='Education']"), 30);

            EducationButton.Click();


            // Click on the  delete button
            driver.FindElement(By.XPath("(//table/tbody/tr)[last()]/td[6]/span[2]/i")).Click();
         GlobalDefinitions.wait(30);
        }

        internal void DeleteValidation()
        {
            String expectedValue = GlobalDefinitions.ExcelLib.ReadData(3, "Title");

            //Get the list
            IList<IWebElement> Trows = driver.FindElements(By.XPath("//table/tbody/tr"));

            //Get the row 
            var rows = Trows.Count;

            for (int i = 1; i <= rows; i++)
            {
                //Get the xpath of ith row
                String actualValue = driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[3]")).Text;

                //validation
                if (actualValue != expectedValue)
                {
                    Assert.Pass();
                }
            }
            GlobalDefinitions.wait(30);

        }


    }
}





