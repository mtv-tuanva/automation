using System;
using System.Linq;
using Automation.Web.Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Web.Core.Browsers
{
    public class OperaBrowser : Browser
    {
        public OperaBrowser(string jsonConfigFileName = null) : 
            this(BrowserConfig.ReadFromConfig(BrowserType.Opera, jsonConfigFileName)) { }

        public OperaBrowser(BrowserConfig browserConfig) : base(BrowserType.Opera)
        {
            if (browserConfig == null)
                throw new ArgumentNullException(nameof(browserConfig));

            new DriverManager().SetUpDriver(new OperaConfig(), browserConfig.Version, browserConfig.Platform);
            var driverOption = new OperaOptions();

            //Opera doesn't support the headless mode
            if (browserConfig.Arguments.Any())
                driverOption.AddArguments(browserConfig.Arguments);

            driverOption.SetLoggingPreference(LogType.Browser, browserConfig.LogLevel);

            WebDriver = new OperaDriver(driverOption);
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(browserConfig.DefaultWaitTimeInSecond));
        }

        public override RemoteWebDriver WebDriver { get; protected set; }
        public override WebDriverWait Wait { get; protected set; }
    }
}
