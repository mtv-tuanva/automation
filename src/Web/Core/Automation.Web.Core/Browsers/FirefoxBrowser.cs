using Automation.Web.Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Web.Core.Browsers
{
    public class FirefoxBrowser : Browser
    {
        public FirefoxBrowser(string jsonConfigFileName = "browsers.json") 
            : this(BrowserConfig.ReadFromConfig(BrowserType.Firefox, jsonConfigFileName)) { }

        public FirefoxBrowser(BrowserConfig browserConfig) : base(BrowserType.Firefox)
        {
            if (browserConfig == null)
                throw new ArgumentNullException(nameof(browserConfig));

            new DriverManager().SetUpDriver(new FirefoxConfig(), browserConfig.Version, browserConfig.Platform);
            var driverOption = new FirefoxOptions();

            if (browserConfig.IsHeadless)
                browserConfig.Arguments.Add("-headles");

            driverOption.AddArguments(browserConfig.Arguments);
            driverOption.SetLoggingPreference(LogType.Browser, browserConfig.LogLevel);

            WebDriver = new FirefoxDriver(driverOption);
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(browserConfig.DefaultWaitTimeInSecond));
        }

        public override RemoteWebDriver WebDriver { get; protected set; }
        public override WebDriverWait Wait { get; protected set; }
    }
}

