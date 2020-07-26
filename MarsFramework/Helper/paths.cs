using MarsFramework.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Helper
{
    public static class paths
    {
        //paths for the reports
        public static string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
        public static string ReportPath = path + "\\" + MarsResource.ReportPath;
        public static string ReportXmlPath = path + "\\" + MarsResource.ReportXMLPath;
        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static string ScreenshotPath = path + "\\" + MarsResource.ScreenShotPath;
        public static string ExcelPath = path + "\\" + MarsResource.ExcelPath;
        public static string BaseUrl = "http://localhost:5000";

    }
}
