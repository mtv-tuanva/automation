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

        public virtual void StartScreenRecording()
        {
            throw new NotImplementedException();
        }

        public virtual string StopScreenRecording(string fileName = null)
        {
            throw new NotImplementedException();
        }

    }
}
