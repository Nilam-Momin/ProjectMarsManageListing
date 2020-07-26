using MarsFramework.Base;
using MarsFramework.Helper;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace MarsFramework
{
    public sealed class Profile
    {
        private IWebDriver driver;

        public Profile(IWebDriver _driver)
        {
            driver = _driver;
            PageFactory.InitElements(driver, this);
            GlobalDefinitions.ExcelLib.PopulateInCollection(paths.ExcelPath, "Profile");
        }



        #region  Initialize Web Elements 
        //Click on Edit button
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Part Time')]//i[@class='right floated outline small write icon']")]
        private IWebElement AvailabilityTimeEdit { get; set; }

        //Click on Share Skill button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement BtnShareSkill { get; set; }

        //Click on Availability Time dropdown
        [FindsBy(How = How.Name, Using = "availabiltyType")]
        private IWebElement AvailabilityTime { get; set; }

        //Click on Availability Time option
        [FindsBy(How = How.XPath, Using = "//option[@value='0']")]
        private IWebElement AvailabilityTimeOpt { get; set; }

        //Click on Availability Hour dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[1]/div/div[3]/div")]
        private IWebElement AvailabilityHours { get; set; }

        //Click on salary
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[1]/div/div[4]/div")]
        private IWebElement Salary { get; set; }

        //Click on Location
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[2]/div")]
        private IWebElement Location { get; set; }

        //Choose Location
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[2]/div/div[2]")]
        private IWebElement LocationOpt { get; set; }

        //Click on City
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[3]/div")]
        private IWebElement City { get; set; }

        //Choose City
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[3]/div/div[2]")]
        private IWebElement CityOpt { get; set; }

        //Click on Add new to add new Language
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement AddNewLangBtn { get; set; }

        //Enter the Language on text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[1]/input")]
        private IWebElement AddLangText { get; set; }

        //Enter the Language on text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[2]/select")]
        private IWebElement ChooseLang { get; set; }

        //Enter the Language on text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[2]/select/option[3]")]
        private IWebElement ChooseLangOpt { get; set; }

        //Add Language
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[3]/input[1]")]
        private IWebElement AddLang { get; set; }

        //Click on Add new to add new skill
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement AddNewSkillBtn { get; set; }

        //Enter the Skill on text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/div/div[1]/input")]
        private IWebElement AddSkillText { get; set; }

        //Click on skill level dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/div/div[2]/select")]
        private IWebElement ChooseSkill { get; set; }

        //Choose the skill level option
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/div/div[2]/select/option[3]")]
        private IWebElement ChooseSkilllevel { get; set; }

        //Add Skill
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[4]/div/div[2]/div/div/span/input[1]")]
        private IWebElement BtnAddSkill { get; set; }

        //Click on Add new to Educaiton
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/table/thead/tr/th[6]/div")]
        private IWebElement AddNewEducation { get; set; }

        //Enter university in the text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[1]/div[1]/input")]
        private IWebElement EnterUniversity { get; set; }

        //Choose the country
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[1]/div[2]/select")]
        private IWebElement ChooseCountry { get; set; }

        //Choose the skill level option
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[1]/div[2]/select/option[6]")]
        private IWebElement ChooseCountryOpt { get; set; }

        //Click on Title dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[1]/select")]
        private IWebElement ChooseTitle { get; set; }

        //Choose title
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[1]/select/option[5]")]
        private IWebElement ChooseTitleOpt { get; set; }

        //Degree
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[2]/input")]
        private IWebElement Degree { get; set; }

        //Year of graduation
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[3]/select")]
        private IWebElement DegreeYear { get; set; }

        //Choose Year
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[3]/select/option[4]")]
        private IWebElement DegreeYearOpt { get; set; }

        //Click on Add
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[3]/div/input[1]")]
        private IWebElement AddEdu { get; set; }

        //Add new Certificate
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/table/thead/tr/th[4]/div")]
        private IWebElement AddNewCerti { get; set; }

        //Enter Certification Name
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[1]/div/input")]
        private IWebElement EnterCerti { get; set; }

        //Certified from
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[2]/div[1]/input")]
        private IWebElement CertiFrom { get; set; }

        //Year
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[2]/div[2]/select")]
        private IWebElement CertiYear { get; set; }

        //Choose Opt from Year
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[2]/div[2]/select/option[5]")]
        private IWebElement CertiYearOpt { get; set; }

        //Add Ceritification
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[6]/div/div[2]/div/div/div[3]/input[1]")]
        private IWebElement AddCerti { get; set; }

        //Add Desctiption
        [FindsBy(How = How.XPath, Using = "//h3/span/i[@class='outline write icon']")]
        private IWebElement btnUpdateDescription { get; set; }

        //Description textbox
        [FindsBy(How = How.CssSelector, Using = "textarea[name='value']")]
        private IWebElement txtbxDescription { get; set; }

        //Click on Save Button
        [FindsBy(How = How.XPath, Using = "(//button[@class='ui teal button'])[2]")]
        private IWebElement btnSaveDescription { get; set; }

        //click manage listing
        [FindsBy(How = How.CssSelector, Using = "a[href='/Home/ListingManagement']")]
        private IWebElement ManageListing { get; set; }

        //Language tab
        [FindsBy(How = How.XPath, Using = "//a[text()='Languages']")]
        private IWebElement TabLanguage { get; set; }

        //skill tab
        [FindsBy(How = How.XPath, Using = "//a[text()='Skills']")]
        private IWebElement TabSkill { get; set; }

        //education tab
        [FindsBy(How = How.XPath, Using = "//a[text()='Education']")]
        private IWebElement TabEducation { get; set; }

        //certification tab
        [FindsBy(How = How.XPath, Using = "//a[text()='Certifications']")]
        private IWebElement TabCertification { get; set; }

        //popup message
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'ns-box-inner')]")]
        private IWebElement Popup { get; set; }

        //Old password
        [FindsBy(How = How.XPath, Using = "//input[@name='oldPassword']")]
        //*[@id="listing-management-section"]/section[1]/div/a[3]
        private IWebElement oldpassword { get; set; }
        //new password
        [FindsBy(How = How.XPath, Using = "//input[@name='newPassword']")]
        //*[@id="listing-management-section"]/section[1]/div/a[3]
        private IWebElement newpassword { get; set; }
        //Confirm password
        [FindsBy(How = How.XPath, Using = "//input[@name='confirmPassword']")]
        //*[@id="listing-management-section"]/section[1]/div/a[3]
        private IWebElement confirmpassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='button' and text()='Save']")]
        private IWebElement savebutton { get; set; }

        //search skill text box homepage
        [FindsBy(How = How.CssSelector, Using = "input[placeholder='Search skills']")]
        private IWebElement txtbxSearchSkill { get; set; }

        //search button
        [FindsBy(How = How.XPath, Using = "(//i[@class='search link icon'])[1]")]
        private IWebElement btnSearch { get; set; }

        //Hi hello
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
        private IWebElement ddlHi { get; set; }

        //change password
        [FindsBy(How = How.XPath, Using = "//a[text()='Change Password']")]
        private IWebElement btnChangePassword { get; set; }
        #endregion


        internal void GoToShareSkill()
        {
            GlobalDefinitions.wait(30);
            BtnShareSkill.Click();


        }

        internal void GoToManageListing()
        {
            GlobalDefinitions.wait(30);
            ManageListing.Click();
        }

        //add availability type
        public string AddAvailability(string availabilityType)
        {
            Base.GlobalDefinitions.wait(30);
            //click on the pen icon to add availability
            driver.FindElement(By.XPath("(//i[@class='right floated outline small write icon'])[1]")).Click();
            if (availabilityType.ToLower() == "part time")
            {
                //Part Time availability
                new SelectElement(driver.FindElement(By.XPath("//select[contains(@name,'availabiltyType')]"))).SelectByValue("0");
                Console.WriteLine("avail type added");
            }
            else if (availabilityType.ToLower() == "full time")
            {
                //Full Time availability
                new SelectElement(driver.FindElement(By.XPath("//select[contains(@name,'availabiltyType')]"))).SelectByValue("1");
                Console.WriteLine("avail type added");
            }
            return Popup.Text;
        }

        //add availability hour
        public string AddAvailabilityHour(string AvailabilityHour)
        {
            //wait
            Base.GlobalDefinitions.wait(30);
            //click on pen icon to add
            driver.FindElement(By.XPath("(//i[contains(@class,'right floated outline small write icon')])[2]")).Click();

            //check which parameter is passed and select that value from dropdown
            if (AvailabilityHour.ToLower() == "less than 30 hours")
            {
                new SelectElement(driver.FindElement(By.XPath("//select[contains(@name,'availabiltyHour')]"))).SelectByValue("0");
            }

            else if (AvailabilityHour.ToLower() == "more than 30 hours")
            {
                new SelectElement(driver.FindElement(By.XPath("//select[contains(@name,'availabiltyHour')]"))).SelectByValue("1");
            }
            else if (AvailabilityHour.ToLower() == "as needed")
            {
                new SelectElement(driver.FindElement(By.XPath("//select[contains(@name,'availabiltyHour')]"))).SelectByValue("2");
            }

            return Popup.Text;
        }

        //add earn target
        public string AddEarnTarget(string EarnTarget)
        {
            //explicit wait
            Base.GlobalDefinitions.wait(30);
            //click pen icon to add value
            driver.FindElement(By.XPath("(//i[@class='right floated outline small write icon'])[3]")).Click();
            //select dropdown using the parameter passed
            if (EarnTarget.ToLower() == "less than $500")
            {
                new SelectElement(driver.FindElement(By.XPath("//select[contains(@name,'availabiltyTarget')]"))).SelectByValue("0");

            }
            else if (EarnTarget.ToLower() == "between $500 and $1000")
            {
                new SelectElement(driver.FindElement(By.XPath("//select[contains(@name,'availabiltyTarget')]"))).SelectByValue("1");
            }
            else if (EarnTarget.ToLower() == "more than $1000")
            {
                new SelectElement(driver.FindElement(By.XPath("//select[contains(@name,'availabiltyTarget')]"))).SelectByValue("2");
            }
            return Popup.Text;
        }

        public string UpdateDescription()
        {
            GlobalDefinitions.wait(15);
            btnUpdateDescription.Click();
            GlobalDefinitions.wait(15);
            txtbxDescription.Click();
            txtbxDescription.Clear();
            GlobalDefinitions.wait(15);
            txtbxDescription.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            btnSaveDescription.Click();
            Console.WriteLine(Popup.Text);
            return Popup.Text;

        }

        internal void ChangePassword(string changePassword, string currentPassword)
        {

            GlobalDefinitions.wait(15);
            // GlobalDefinitions.ExcelLib.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");
            oldpassword.SendKeys(currentPassword);
            newpassword.SendKeys(changePassword);
            GlobalDefinitions.wait(15);
            confirmpassword.SendKeys(changePassword);
            // click on save button
            savebutton.Click();
            GlobalDefinitions.wait(15);
            GlobalDefinitions.ExcelLib.WriteData(2, "oldPassword", changePassword, currentPassword);


        }
        // Validate password changed successfully
        internal void ValidateChangedPassword()
        {
            string msg = driver.FindElement(By.XPath("//div[contains(@class,'ns-box-inner')]")).Text;
            Console.WriteLine(msg);
            Assert.AreEqual(msg, "Password Changed Successfully");
        }

        //Search skill
        internal void SearchSkill()
        {
            GlobalDefinitions.WaitForElement(driver, By.CssSelector("input[placeholder='Search skills']"), 40);
            txtbxSearchSkill.SendKeys("testing");
            btnSearch.Click();
        }

        internal void GoToChangePassword()
        {
            try
            {
                Thread.Sleep(2000);
                //GlobalDefinitions.WaitForElement(driver, By.CssSelector("span[class='item ui dropdown link active visible']"), 40);
                //driver.FindElement(By.CssSelector("span[class='item ui dropdown link active visible']")).Click();
                driver.FindElement(By.XPath("//span[contains(text(), 'Hi ')]")).Click();
                // driver.FindElement(By.XPath("//span[contains(@tabindex,'0')]")).Click();
                // ddlHi.Click();
                //Thread.Sleep(1000);
                GlobalDefinitions.WaitForClickableElement(driver,By.XPath("//a[text()='Change Password']"),30);
                btnChangePassword.Click();


            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    
    }
}
