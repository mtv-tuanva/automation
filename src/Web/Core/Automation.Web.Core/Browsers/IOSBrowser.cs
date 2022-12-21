using Automation.Web.Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace Automation.Web.Core.Browsers
{
    public class IOSBrowser : Browser
    {
        public IOSBrowser(string id, string jsonConfigFileName = null) :
            this(BrowserConfig.ReadFromConfig(id, jsonConfigFileName))
        { }

        public IOSBrowser(BrowserConfig browserConfig) : base(browserConfig.Browser, browserConfig.Platform)
        {
            browserConfig.AutomationName = browserConfig.AutomationName ?? "XCUITest";
            browserConfig.DefaultWaitTimeInSecond = browserConfig.DefaultWaitTimeInSecond > 0 ? DefaultWaitTimeInSecond : browserConfig.DefaultWaitTimeInSecond;
            browserConfig.RemoteServer = browserConfig.RemoteServer ?? "http://127.0.0.1:4723";
            var appiumOptions = new AppiumOptions();
            appiumOptions.PlatformName = "iOS";
            appiumOptions.PlatformVersion = browserConfig.PlatformVersion;
            appiumOptions.DeviceName = browserConfig.DeviceName;
            appiumOptions.AutomationName = browserConfig.AutomationName;
            appiumOptions.BrowserName = browserConfig.Browser.ToString();
            appiumOptions.AddAdditionalAppiumOption("newCommandTimeout", browserConfig.DefaultWaitTimeInSecond);
            var url = new Uri($"{browserConfig.RemoteServer}/wd/hub");

            WebDriver = new IOSDriver(url, appiumOptions);
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(browserConfig.DefaultWaitTimeInSecond));
        }

        public override void StartScreenRecording()
        {
            ((IOSDriver)WebDriver).StartRecordingScreen(
                AndroidStartScreenRecordingOptions.GetAndroidStartScreenRecordingOptions()
                    .WithTimeLimit(TimeSpan.FromSeconds(1800))
                    .WithBitRate(500000)
                    .WithVideoSize("720x1280"));
        }

        public override string StopScreenRecording()
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), $"VideoRecords");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var fileName = $"Record_{Guid.NewGuid():N}.mp4";
            string fullPath = Path.Combine(folderPath, fileName);
            var videoBase64 = ((IOSDriver)WebDriver).StopRecordingScreen();
            byte[] videoDecode = Convert.FromBase64String(videoBase64);
            File.WriteAllBytes(fullPath, videoDecode);
            return fullPath;
        }

        public override WebDriver WebDriver { get; protected set; }
        public override WebDriverWait Wait { get; protected set; }
    }
}
