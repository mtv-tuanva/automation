using Automation.Web.Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Web.Core.Browsers
{
    public class FirefoxBrowser : Browser
    {
        public FirefoxBrowser(string jsonConfigFileName = null)
            : this(BrowserConfig.ReadFromConfig(BrowserType.Firefox, jsonConfigFileName)) { }

        public FirefoxBrowser(string id, string jsonConfigFileName = null) :
            this(BrowserConfig.ReadFromConfig(id, jsonConfigFileName))
        { }

        public FirefoxBrowser(BrowserConfig browserConfig) : base(BrowserType.Firefox)
        {
            if (browserConfig == null)
            {
                browserConfig = new BrowserConfig { Browser = BrowserType.Firefox };
            }

            new DriverManager().SetUpDriver(new FirefoxConfig(), browserConfig.Version, browserConfig.OSPlatform);
            var driverOption = new FirefoxOptions();

            if (browserConfig.IsHeadless)
                browserConfig.Arguments.Add("-headles");

            driverOption.AddArguments(browserConfig.Arguments);
            driverOption.SetLoggingPreference(LogType.Browser, browserConfig.LogLevel);

            WebDriver = new FirefoxDriver(driverOption);
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(browserConfig.DefaultWaitTimeInSecond));
        }

        public override WebDriver WebDriver { get; protected set; }
        public override WebDriverWait Wait { get; protected set; }
    }
}

