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
            if (!string.IsNullOrEmpty(fileName) && !fileName.EndsWith(".png"))
            {
                fileName = $"{fileName}.png";
            }

            fileName = fileName ?? $"images/Screenshot_{Guid.NewGuid():N}.png";
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            //Create folder
            var directory = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            //var bytes = WebDriver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker()));
            //File.WriteAllBytes(fullPath, bytes);

            //((WebElement)FindElementByCssSelector("html")).GetScreenshot().SaveAsFile(fullPath);
            WebDriver.GetScreenshot().SaveAsFile(fullPath);

            return fullPath;
        }

        public virtual void StartScreenRecording()
        {
            GetBrowserExtensionType()?.GetMethod("WindowsOsStartScreenRecording").Invoke(null, new object[] { this });
        }

        public virtual string StopScreenRecording(string fileName = null)
        {
            if (!string.IsNullOrEmpty(fileName) && !fileName.EndsWith(".avi"))
            {
                fileName = $"{fileName}.avi";
            }

            var generatedPath = GetBrowserExtensionType()?.GetMethod("WindowsOsStopScreenRecording").Invoke(null, new object[] { this }) as string;

            if (string.IsNullOrEmpty(fileName))
            {
                return generatedPath;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            //Create folder
            var directory = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!generatedPath.Equals(fullPath, StringComparison.OrdinalIgnoreCase))
            {
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }

                File.Move(generatedPath, fullPath);
            }

            return fullPath;
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
