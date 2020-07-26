using MarsFramework.Base;
using MarsFramework.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
   public class SignIn
   {
       
        public SignIn(IWebDriver driver)
        {

            this.driver = driver;
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(paths.ExcelPath, "Profile");
            username = GlobalDefinitions.ExcelLib.ReadData(2, "Username");
            password = GlobalDefinitions.ExcelLib.ReadData(2, "CurrentPassword");

            PageFactory.InitElements(driver, this);
        }

       
        private string username;
        private string password;
        private readonly IWebDriver driver;

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
         
            //Click signin
            SignIntab.Click();
            //enter email
            Email.SendKeys(username);
            //enter password
            Password.SendKeys(password);
            //click login button
            LoginBtn.Click();

        }
    }
}