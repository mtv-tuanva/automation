using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Automation.Web.Core
{
    public interface IBrowser : IBrowserWait, IBrowserScript, IBrowserConsole, IBrowserAction, IBrowserFindElement, IBrowserScreenshot, IBrowserTab
    {
        /// <summary>
        /// Indicate the browser is Chrome or Firefox or IE or Safari...
        /// </summary>
        BrowserType BrowserType { get; }

        /// <summary>
        /// Indicate the OS platform such as Win32, Win64, Android, IOS, Mac
        /// </summary>
        PlatformType Platform { get; }

        WebDriver WebDriver { get; }

        WebDriverWait Wait { get; }

        INavigation Navigation { get; }

        /// <summary>
        /// Gets an object allowing the user to manipulate cookies on the page.
        /// </summary>
        ICookieJar Cookie { get; }

        /// <summary>
        /// Gets an object allowing the user to examing the logs for this driver instance.
        /// </summary>
        ILogs Logs { get; }

        /// <summary>
        /// Gets an object allowing the user to manipulate the currently-focused browser window.
        /// </summary>
        /// <remarks>
        /// "Currently-focused" is defined as the browser window having the window handle 
        /// returned when IWebDriver.CurrentWindowHandle is called.
        /// </remarks>
        IWindow Window { get; }

        /// <summary>
        /// Gets or sets the URL the browser is currently displaying.
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Gets or sets the OpenQA.Selenium.IFileDetector responsible for detecting sequences of keystrokes representing file paths and names.
        /// </summary>
        IFileDetector FileDetector { get; set; }

        /// <summary>
        /// Gets the OpenQA.Selenium.Remote.RemoteWebDriver.SessionId for the current session of this driver.
        /// </summary>
        SessionId SessionId { get; }

        /// <summary>
        /// Closes the Browser
        /// </summary>
        void Close();

        /// <summary>
        /// Close the Browser and Dispose of WebDriver
        /// </summary>
        void Quit();

        /// <summary>
        /// Gets the title of the current browser window.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Get the full path of the downloaded file.
        /// </summary>
        /// <param name="fileName">The file name of </param>
        /// <returns></returns>
        string GetDownloadFilePath(string fileName);

        /// <summary>
        /// Store video record instances
        /// </summary>
        Queue<object> Recorders { get; }
    }
}
