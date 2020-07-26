using MarsFramework.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using SeleniumExtras.PageObjects;
using RazorEngine.Compilation.ImpromptuInterface;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using MarsFramework.Helper;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        private IWebDriver driver;

        public ManageListings(IWebDriver driver)
        {
            this.driver = driver;
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(paths.ExcelPath, "ShareSkill");
            PageFactory.InitElements(driver, this);
        }

        #region "Web Elements"
        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        [FindsBy(How = How.TagName, Using = "tr")]
        private IList<IWebElement> list {get;set;}

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[8]/div/button[3]/i")]
        private IWebElement delete { get; set; }

        //yes button for delete confirmation
        [FindsBy(How =How.XPath, Using = "//button[contains(@class,'ui icon positive right labeled button')]")]
        private IWebElement BtnYes { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        //popup message
        [FindsBy(How =How.XPath,Using = "//div[contains(@class,'ns-box-inner')]")]
        private IWebElement Popup { get; set; }

        #endregion
        //click edit
        internal void EditListings()
        {
            edit.Click();
          
        }

        //delete listing
        internal string DeleteListing()
        {
            
            delete.Click();// delete.Click();

            BtnYes.Click();//confirm delete
            GlobalDefinitions.wait(300);
            //text of popup
            Console.WriteLine(Popup.Text);
            return Popup.Text;
                     
        }

        //validates listing
        internal void FindListing()
        {
            var table = driver.FindElement(By.XPath("//table/tbody"));//table body
            var rows = table.FindElements(By.TagName("tr")); //all the table rows

            try
            {
                //iterate through all the rows until the validated row is found
                foreach (var row in rows)
                {
                    if (row.Text.Contains(GlobalDefinitions.ExcelLib.ReadData(2, "Category")))
                    {
                        //get the table data of the row
                        var tds = row.FindElements(By.TagName("td"));
                        //validates other table data of the row
                        Assert.Multiple(() =>
                        {
                            Assert.That(tds[2].Text, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Title")));
                            
                            Assert.That(tds[3].Text, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Description")));

                        });

                        break;
                    }

                }
            }
            catch (Exception)
            {
                Assert.Fail("listing not found");
            }
            
        }

    }
}
