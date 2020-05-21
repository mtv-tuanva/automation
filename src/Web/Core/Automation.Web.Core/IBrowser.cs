using OpenQA.Selenium;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Automation.Web.Core
{
    public interface IBrowser : IBrowserWait, IBrowserScript, IBrowserConsole
    {
        /// <summary>
        /// Indicate the browser is Chrome or Firefox or IE or Safari...
        /// </summary>
        BrowserType BrowserType { get; }

        RemoteWebDriver WebDriver { get; }

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
        /// Gets a value indicating whether web storage is supported for this browser.
        /// </summary>
        bool HasWebStorage { get; }
        
        /// <summary>
        /// Gets an OpenQA.Selenium.Html5.IWebStorage object for managing web storage.
        /// </summary>
        IWebStorage WebStorage { get; }

        /// <summary>
        /// Gets a value indicating whether manipulating geolocation is supported for this browser
        /// </summary>
        bool HasLocationContext { get; }

        /// <summary>
        /// Gets an OpenQA.Selenium.Html5.IApplicationCache object for managing application cache
        /// </summary>
        IApplicationCache ApplicationCache { get; }

        /// <summary>
        /// Gets or sets the URL the browser is currently displaying.
        /// </summary>
        string Url { get; set; }
   
        /// <summary>
        /// Gets an OpenQA.Selenium.Html5.ILocationContext object for managing browser location.
        /// </summary>
        ILocationContext LocationContext { get; }
 
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
    }
}
