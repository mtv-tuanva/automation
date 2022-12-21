using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;

namespace Automation.Web.Core
{
    public partial class Browser : IBrowserScreenshot
    {
        public Screenshot GetScreenshot()
            => WebDriver.GetScreenshot();

        public string TakeAndSaveScreenshot(string fileName = null)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), $"Screenshots");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            fileName = fileName ?? $"Screenshot_{Guid.NewGuid():N}.png";
            string fullPath = Path.Combine(folderPath, fileName);
            WebDriver.GetScreenshot().SaveAsFile(fullPath);

            return fullPath;
        }

        public virtual void StartScreenRecording()
        {
            GetBrowserExtensionType()?.GetMethod("WindowsOsStartScreenRecording").Invoke(null, new object[] { this });
        }

        public virtual string StopScreenRecording()
        {
            return GetBrowserExtensionType()?.GetMethod("WindowsOsStopScreenRecording").Invoke(null, new object[] { this }) as string;
        }

        protected Type GetBrowserExtensionType()
        {
            const string missAssemblyError = "ERROR: This function only supports on Windows at this time. So, please add nuget package Automation.Web.Core to use this function in Windows";
            const string browserExtensionClassName = "Automation.Web.Core.BrowserExtension";

            if (!File.Exists("Automation.Web.Core.Forms.dll"))
            {
                throw new NotImplementedException(missAssemblyError);
            }

            var assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), "Automation.Web.Core.Forms.dll"));
            return assembly.GetType(browserExtensionClassName, false, true);
        }
    }
}
