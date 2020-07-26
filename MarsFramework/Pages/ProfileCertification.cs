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
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class ProfileCertification
    {
        private IWebDriver driver;

        public ProfileCertification(IWebDriver driver)
        {
            this.driver = driver;
            GlobalDefinitions.ExcelLib.PopulateInCollection(paths.ExcelPath, "Profile");
            PageFactory.InitElements(driver, this);
        }

      

        #region Initialize IWebElements
        [FindsBy(How = How.XPath, Using = "//a[text()='Certifications']")]
        private IWebElement CertificationsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[1]/div[2]/div[1]/table[1]/thead/tr/th[4]/div[1]")]
        private IWebElement AddNewCertification { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'Certificate or Award')]")]
        private IWebElement CertificationText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='certificationFrom']")]
        private IWebElement CertifiedFromText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='ui fluid container']//div//div//div[3]//form//div[5]//div//div[2]/div//div[1]//div[3]//input[@type='button'][@value='Add']")]
        private IWebElement btnAddCertification { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]/i")]
        private IWebElement CerficationUpdate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]")]
        private IWebElement UpdateButton { get; set; }

        #endregion


        //select dropdown for education and certification
        internal void selectdropdown(string dropdownname, string value)
        {
            new SelectElement(driver.FindElement(By.XPath("//select[contains(@name,'" + dropdownname + "')]"))).SelectByValue(value);
        }

        //Add Certification
        internal void AddCertification()
        {
            //explicit wait
            GlobalDefinitions.WaitForClickableElement(driver, By.XPath("//a[text()='Certifications']"),30);
           
            //click on certification tab
            CertificationsButton.Click();

            GlobalDefinitions.wait(30);

            //add new certification
            AddNewCertification.Click();

            GlobalDefinitions.wait(30);
            //add value in certificate field and certification from
            CertificationText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate"));

            CertifiedFromText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedFrom"));

            //select certificate year 
            selectdropdown("certificationYear", GlobalDefinitions.ExcelLib.ReadData(2, "CertificationYear"));

            btnAddCertification.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        //update operation performs on Certification field
        internal void UpdateCertification()
        {
            //explicit wait
            GlobalDefinitions.WaitForClickableElement(driver, By.XPath("//a[text()='Certifications']"), 30);

            //click on certification tab
            CertificationsButton.Click();

            GlobalDefinitions.wait(30);
            //click the pen icon to edit 
            CerficationUpdate.Click();

            GlobalDefinitions.wait(30);
            // clear text and enter value
            CertificationText.Clear();
            CertificationText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Certificate"));

            CertifiedFromText.Clear();
            CertifiedFromText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "CertifiedFrom"));

            selectdropdown("certificationYear", GlobalDefinitions.ExcelLib.ReadData(3, "CertificationYear"));

            //click on update button
            UpdateButton.Click();

            GlobalDefinitions.wait(30);

            //Console.WriteLine(driver.FindElement(By.XPath("//div[contains(@class,'ns-box-inner')]")).Text);

            //driver.FindElement(By.XPath("//a[contains(@class,'ns-close')]"));

            Console.WriteLine("*******************************");
        }


        internal void ValidateAddUpdcertifications(int excelrow)
        {
            try
            {
                Thread.Sleep(5000);
                GlobalDefinitions.WaitForElement(driver, By.XPath("(//table/tbody/tr)[last()]"), 90);

                //Get the table list
                var lastRow = driver.FindElements(By.XPath("(//table/tbody/tr)[last()]/td"));
                GlobalDefinitions.wait(40);
               
                Assert.Multiple(() =>
                    {
                        Assert.That(lastRow[1].Text, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(excelrow, "CertifiedFrom")));

                        Assert.That(lastRow[2].Text, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(excelrow, "CertificationYear")));

                        Assert.That(lastRow[0].Text, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(excelrow, "Certificate")));
      
                    });
              

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.Fail();
            }
           
            GlobalDefinitions.wait(30);

        }




        //Delete a given language
        internal void DeleteCertification()
        {
            //explicit wait
            GlobalDefinitions.WaitForClickableElement(driver, By.XPath("//a[text()='Certifications']"), 30);

            //click on certification tab
            CertificationsButton.Click();

            String expectedValue1 = GlobalDefinitions.ExcelLib.ReadData(2, "Certificate");
            
            //Get the row list
            IList<IWebElement> Trows = driver.FindElements(By.XPath("//form/div[5]/div/div[2]/div/table/tbody/tr"));

            //Get the row count of table
            var rows = Trows.Count;
            for (int i = 1; i <= rows; i++)
            {
                //Get the xpath of ith row Name
                String actualValue = driver.FindElement(By.XPath("//form/div[5]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;


                if (actualValue == expectedValue1)
                {
                    // Click on delete button
                    driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[4]/span[2]/i")).Click();
                    break;
                }
            }


        }


        //Validate Deletion
        internal void ValidateDeleteCertification()
        { 
            try
            {
                String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "Certificate");

                //get the table list
                IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[5]/div/div[2]/div/table/tbody/tr"));

                for (int i = 1; i <= Tablerows.Count; i++)
                {

                    string actualvalue = driver.FindElement(By.XPath("//form/div[5]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    //check if expected value is equal to actual value
                    if (expectedValue != actualvalue)
                    {

                        Assert.Pass();
                        Console.WriteLine("Certification deleted");
                        break;
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
