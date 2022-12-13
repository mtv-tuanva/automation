using OpenQA.Selenium;
using System;
using System.IO;

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

            fileName = fileName ?? $"Screenshot_{Guid.NewGuid()}.png";
            string fullPath = Path.Combine(folderPath, fileName);
            WebDriver.GetScreenshot().SaveAsFile(fullPath);

            return fullPath;
        }

        public virtual void StartScreenRecordingInternal()
        {
            throw new NotImplementedException("Add nuget package Automation.Web.Core to use this function in Windows");
        }

        public virtual string StopScreenRecordingInternal(string fileName = null)
        {
            throw new NotImplementedException("Add nuget package Automation.Web.Core to use this function in Windows");
        }
    }
}
