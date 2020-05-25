using Automation.Web.Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
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
            this(BrowserConfig.ReadFromConfig(BrowserType.Chrome, jsonConfigFileName)) { }

        public ChromeBrowser(BrowserConfig browserConfig) : base(BrowserType.Chrome)
        {
            if (browserConfig == null)
                throw new ArgumentNullException(nameof(browserConfig));

            new DriverManager().SetUpDriver(new ChromeConfig(), browserConfig.Version, browserConfig.Platform);
            var driverOption = new ChromeOptions();

            if (browserConfig.IsHeadless)
                browserConfig.Arguments.Add("--headless");

            if (browserConfig.Arguments.Any())
                driverOption.AddArguments(browserConfig.Arguments);
            
            driverOption.SetLoggingPreference(LogType.Browser, browserConfig.LogLevel);
            WebDriver = new ChromeDriver(driverOption);
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(browserConfig.DefaultWaitTimeInSecond));
        }

        public override RemoteWebDriver WebDriver { get; protected set; }
        public override WebDriverWait Wait { get; protected set; }
    }
}
