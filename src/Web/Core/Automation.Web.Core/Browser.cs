using Automation.Web.Core.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace Automation.Web.Core
{
    public abstract partial class Browser : IBrowser
    {
        protected Browser(BrowserType browserType)
        {
            BrowserType = browserType;
        }

        ~Browser()
        {
            WebDriver.Quit();
        }

        protected const uint DefaultWaitTimeInSecond = 30;

        public BrowserType BrowserType { get; }

        public abstract RemoteWebDriver WebDriver { get; protected set; }

        public abstract WebDriverWait Wait { get; protected set; }

        public INavigation Navigation => WebDriver.Navigate();

        public ICookieJar Cookie => WebDriver.Manage().Cookies;

        public ILogs Logs => WebDriver.Manage().Logs;

        public IWindow Window => WebDriver.Manage().Window;

        public bool HasWebStorage => WebDriver.HasWebStorage;

        public IWebStorage WebStorage => WebDriver.WebStorage;

        public bool HasLocationContext => WebDriver.HasLocationContext;

        public IApplicationCache ApplicationCache => WebDriver.ApplicationCache;

        public string Url { get => WebDriver.Url; set => WebDriver.Url = value; }

        public ILocationContext LocationContext => WebDriver.LocationContext;

        public IFileDetector FileDetector { get => WebDriver.FileDetector; set => WebDriver.FileDetector = value; }

        public SessionId SessionId => WebDriver.SessionId;

        public string Title => WebDriver.Title;

        public void Close() => WebDriver.Close();

        public void Quit() => WebDriver.Quit();

        /// <summary>
        /// Get the full path of the downloaded file.
        /// </summary>        
        /// <param name="fileName">The file name of </param>
        /// <returns></returns>
        /// <remarks>Only support Windows OS so far.</remarks>
        public string GetDownloadFilePath(string fileName)
            => FileHelper.GetDownloadFilePath(fileName);

        protected By GetBy(string selector, SelectorType selectorType = SelectorType.CssSelector)
        {
            switch (selectorType)
            {
                case SelectorType.Id:
                    return By.Id(selector);
                case SelectorType.Name:
                    return By.Name(selector);
                case SelectorType.ClassName:
                    return By.ClassName(selector);
                case SelectorType.LinkText:
                    return By.LinkText(selector);
                case SelectorType.PartialLinkText:
                    return By.PartialLinkText(selector);
                case SelectorType.TagName:
                    return By.TagName(selector);
                case SelectorType.XPath:
                    return By.XPath(selector);
                case SelectorType.CssSelector:
                    return By.CssSelector(selector);
                default:
                    return By.CssSelector(selector);
            }
        }
    }
}
