using Automation.Web.Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Web.Core.Browsers
{
    //Download the latest Edge from https://www.microsoft.com/en-us/edge
    public class EdgeBrowser : Browser
    {
        public EdgeBrowser(string jsonConfigFileName = "browsers.json") 
            : this(BrowserConfig.ReadFromConfig(BrowserType.Edge, jsonConfigFileName)) { }

        public EdgeBrowser(BrowserConfig browserConfig) : base(BrowserType.Edge)
        {
            if (browserConfig == null)
                throw new ArgumentNullException(nameof(browserConfig));

            new DriverManager().SetUpDriver(new EdgeConfig()
                , version: browserConfig.Version
                , architecture: browserConfig.Platform
                );
            var driverOption = new EdgeOptions();

            //Edge doesn't support headless
            driverOption.SetLoggingPreference(LogType.Browser, browserConfig.LogLevel);

            try
            {
                WebDriver = new EdgeDriver(driverOption);
            }
            catch (Exception ex)
            {
                if (WebDriver != null)
                    WebDriver.Dispose();

                Console.WriteLine(ex);
                TryToSetupmWebDriver(driverOption, ex);
            }

            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(browserConfig.DefaultWaitTimeInSecond));
        }

        public override RemoteWebDriver WebDriver { get; protected set; }
        public override WebDriverWait Wait { get; protected set; }

        private void TryToSetupmWebDriver(EdgeOptions driverOption, Exception thrownException)
        {
            foreach (var exePath in Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "Edge"), "*.exe", SearchOption.AllDirectories))
            {
                try
                {
                    WebDriver = new EdgeDriver(EdgeDriverService.CreateDefaultService(Path.GetDirectoryName(exePath), Path.GetFileName(exePath)),
                                                driverOption);

                    return;
                }
                catch (Exception ex)
                {
                    if (WebDriver != null)
                        WebDriver.Dispose();

                    Console.WriteLine(ex);
                    Console.WriteLine("Keep trying to create EdgDriver...");
                }
            }

            throw thrownException;
        }
    }
}
