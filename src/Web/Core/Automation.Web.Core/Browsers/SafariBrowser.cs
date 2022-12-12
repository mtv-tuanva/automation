using Automation.Web.Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using System;

namespace Automation.Web.Core.Browsers
{
    class SafariBrowser : Browser
    {
        public SafariBrowser(string jsonConfigFileName = null) :
            this(BrowserConfig.ReadFromConfig(BrowserType.Safari, jsonConfigFileName))
        { }

        public SafariBrowser(string id, string jsonConfigFileName = null) :
            this(BrowserConfig.ReadFromConfig(id, jsonConfigFileName))
        { }

        public SafariBrowser(BrowserConfig browserConfig) : base(BrowserType.Safari)
        {
            //No need to setup safari web driver
            var driverOption = new SafariOptions();
            var waitTimeInSecond = DefaultWaitTimeInSecond;

            if (browserConfig != null)
            {
                //Safari doesn't support the headless mode

                waitTimeInSecond = browserConfig.DefaultWaitTimeInSecond;
                driverOption.SetLoggingPreference(LogType.Browser, browserConfig.LogLevel);
            }

            WebDriver = new SafariDriver(driverOption);
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(waitTimeInSecond));
        }

        public override WebDriver WebDriver { get; protected set; }
        public override WebDriverWait Wait { get; protected set; }
    }
}
