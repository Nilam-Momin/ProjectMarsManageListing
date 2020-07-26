using Excel;
using MarsFramework.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Linq;
using System.Security.Policy;
using System.Text;
using SeleniumExtras;
using MarsFramework.Helper;

namespace MarsFramework.Base
{
    class GlobalDefinitions
    {
        //Initialise the browser
        // public static IWebDriver driver { get; set; }


        //public static void InitializeBrowser(int Browser)
        //{
        //    switch (Browser)
        //    {

        //        case 1:
        //            GlobalDefinitions.driver = new FirefoxDriver();
        //            break;
        //        case 2:
        //            GlobalDefinitions.driver = new ChromeDriver();
        //            GlobalDefinitions.driver.Manage().Window.Maximize();

        //            break;

        //    }
        //}




        #region WaitforElement 

        public static void wait(int time)
        {
            Hooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by)));
        }

        public static IWebElement WaitForClickableElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by)));
        }
        #endregion


        #region Excel 
        public class ExcelLib
        {
            static List<Datacollection> dataCol = new List<Datacollection>();

            public class Datacollection
            {
                public int rowNumber { get; set; }
                public string colName { get; set; }
                public string colValue { get; set; }
            }


            public static void ClearData()
            {
                dataCol.Clear();
            }


            private static System.Data.DataTable ExcelToDataTable(string fileName, string SheetName)
            {
                // Open file and return as Stream
                using (System.IO.FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    {
                        excelReader.IsFirstRowAsColumnNames = true;

                        //Return as dataset
                        DataSet result = excelReader.AsDataSet();
                        //Get all the tables
                        DataTableCollection table = result.Tables;

                        // store it in data table
                        System.Data.DataTable resultTable = table[SheetName];

                        //excelReader.Dispose();
                        //excelReader.Close();
                        // return
                        return resultTable;
                    }
                }
            }

            public static string ReadData(int rowNumber, string columnName)
            {
                try
                {
                    //Retriving Data using LINQ to reduce much of iterations

                    rowNumber = rowNumber - 1;
                    string data = (from colData in dataCol
                                   where colData.colName == columnName && colData.rowNumber == rowNumber
                                   select colData.colValue).SingleOrDefault();

                    //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;


                    return data.ToString();
                }

                catch (Exception e)
                {
                    //Added by Kumar
                    Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                    return null;
                }
            }

            public static void PopulateInCollection(string fileName, string SheetName)
            {
                ExcelLib.ClearData();
                System.Data.DataTable table = ExcelToDataTable(fileName, SheetName);

                //Iterate through the rows and columns of the Table
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        Datacollection dtTable = new Datacollection()
                        {
                            rowNumber = row,
                            colName = table.Columns[col].ColumnName,
                            colValue = table.Rows[row - 1][col].ToString()
                        };


                        //Add all the details for each row
                        dataCol.Add(dtTable);

                    }
                }

            }

            public static void WriteData(int rowNumber, string columnName, string changePassword, string currentPassword)
            {

                    try
                    {
                        Application oXL;
                        _Workbook oWB;
                        _Worksheet oSheet;
                        Range oRng;
                        object misvalue = System.Reflection.Missing.Value;

                        //Start Excel and get Application object.
                        oXL = new Application();
                        oXL.Visible = false;

                        //Get a new workbook.
                        oWB = (_Workbook)(oXL.Workbooks.Open(paths.ExcelPath));
                        oSheet = (_Worksheet)oWB.ActiveSheet;

                        //Add table headers going cell by cell.
                        oSheet.Cells[2, 21] = changePassword;
                        oSheet.Cells[2, 20] = currentPassword;


                        oWB.Save();
                        oWB.Close();
                        oXL.Quit();
                    }
                    



                
                catch (Exception e)
                {
                    Console.WriteLine("Exception occurred in ExcelLib Class WriteData Method!" + Environment.NewLine + e.Message.ToString());
                }


            }



           

            #endregion

            #region screenshots
            public class SaveScreenShotClass
            {
                public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
                {
                    var folderLocation = (paths.ScreenshotPath);

                    if (!System.IO.Directory.Exists(folderLocation))
                    {
                        System.IO.Directory.CreateDirectory(folderLocation);
                    }

                    var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                    var fileName = new StringBuilder(folderLocation);

                    fileName.Append(ScreenShotFileName);
                    fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                    //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
                    fileName.Append(".jpeg");
                    screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                    return fileName.ToString();
                }
            }
            #endregion

        }
    }
    
}
