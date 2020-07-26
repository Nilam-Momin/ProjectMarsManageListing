using MarsFramework.Base;
using MarsFramework.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
   internal class SearchSkill
   {
        private IWebDriver driver;
        public SearchSkill(IWebDriver driver)
        {
            this.driver = driver;
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(paths.ExcelPath, "ShareSkill");
            PageFactory.InitElements(driver, this);
        }

        #region IWebElement initialize
        //search skill text box homepage
        [FindsBy(How =How.XPath,Using = ("//input[@placeholder='Search skills'][1]"))]
        private IWebElement txtbxSearchSkill { get; set; }

        //onsite button
        [FindsBy(How =How.XPath, Using = "//button[@class='ui button'][contains(.,'Onsite')]")]
        private IWebElement Onsite { get; set; }
        //Programming link
        [FindsBy(How =How.XPath,Using = "//a[contains(text(), 'Programming & Tech')]")]
        private IWebElement Programming { get; set; }

        [FindsBy(How=How.XPath,Using = "//p[contains(text(), 'Test')]")]
        private IWebElement SearchResult { get; set; }
        #endregion

        internal void FilterSkill()
        {
            Onsite.Click();
        }

        internal void RefineSearch()
        {
            Programming.Click();
        }

        internal void ValidateSearch()
        {
            Assert.IsNotNull(SearchResult);
        }
   }
}
