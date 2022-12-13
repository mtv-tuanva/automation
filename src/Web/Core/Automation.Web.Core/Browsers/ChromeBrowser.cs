using Automation.Web.Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Web.Core.Browsers
{
    public class ChromeBrowser : Browser
    {
        public ChromeBrowser(string jsonConfigFileName = null) :
            this(BrowserConfig.ReadFromConfig(BrowserType.Chrome, jsonConfigFileName))
        { }

        public ChromeBrowser(string id, string jsonConfigFileName = null) :
            this(BrowserConfig.ReadFromConfig(id, jsonConfigFileName))
        { }

        public ChromeBrowser(BrowserConfig browserConfig) : base(BrowserType.Chrome, browserConfig.Platform)
        {
            if (browserConfig == null)
            {
                browserConfig = new BrowserConfig { Browser = BrowserType.Chrome };
            }

            new DriverManager().SetUpDriver(new ChromeConfig(), browserConfig.Version, browserConfig.OSPlatform);
            var driverOption = new ChromeOptions();

            if (browserConfig.IsHeadless)
                browserConfig.Arguments.Add("--headless");

            if (browserConfig.Arguments.Any())
                driverOption.AddArguments(browserConfig.Arguments);

            driverOption.SetLoggingPreference(LogType.Browser, browserConfig.LogLevel);
            WebDriver = new ChromeDriver(driverOption);
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(browserConfig.DefaultWaitTimeInSecond));
        }

        public override WebDriver WebDriver { get; protected set; }
        public override WebDriverWait Wait { get; protected set; }
    }
}
