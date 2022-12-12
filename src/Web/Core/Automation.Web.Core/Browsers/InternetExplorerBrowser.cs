using Automation.Web.Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Web.Core.Browsers
{
    public class InternetExplorerBrowser : Browser
    {
        public InternetExplorerBrowser(string jsonConfigFileName = null)
            : this(BrowserConfig.ReadFromConfig(BrowserType.InternetExplorer, jsonConfigFileName)) { }

        public InternetExplorerBrowser(string id, string jsonConfigFileName = null) :
            this(BrowserConfig.ReadFromConfig(id, jsonConfigFileName))
        { }

        public InternetExplorerBrowser(BrowserConfig browserConfig) : base(BrowserType.InternetExplorer)
        {
            if (browserConfig == null)
            {
                browserConfig = new BrowserConfig { Browser = BrowserType.InternetExplorer };
            }

            new DriverManager().SetUpDriver(new InternetExplorerConfig(), browserConfig.Version, browserConfig.OSPlatform);
            var driverOption = new InternetExplorerOptions() { IgnoreZoomLevel = true };

            //IE doesn't support the headless mode
            driverOption.SetLoggingPreference(LogType.Browser, browserConfig.LogLevel);
            WebDriver = new InternetExplorerDriver(driverOption);
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(browserConfig.DefaultWaitTimeInSecond));
        }

        public override WebDriver WebDriver { get; protected set; }
        public override WebDriverWait Wait { get; protected set; }
    }
}
