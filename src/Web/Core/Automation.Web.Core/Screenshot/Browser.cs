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
            fileName = fileName ?? $"ScreenShoot_{Guid.NewGuid()}.png";
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            WebDriver.GetScreenshot().SaveAsFile(fullPath);

            return fullPath;
        }
    }
}
