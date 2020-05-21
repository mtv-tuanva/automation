using OpenQA.Selenium;

namespace Automation.Web.Core
{
    public interface IBrowserTab
    {
        /// <summary>
        /// Create new tab
        /// </summary>
        /// <returns>IWebDriver</returns>
        IWebDriver NewTab();

        /// <summary>
        /// Close tab by index
        /// </summary>
        /// <param name="index"></param>
        void CloseTab(int index);

        /// <summary>
        /// Close current tab
        /// </summary>
        void CloseCurrentTab();

        /// <summary>
        /// Switch to first tab
        /// </summary>
        /// <returns>IWebDriver</returns>
        IWebDriver SwitchToFirstTab();

        /// <summary>
        /// Switch to last tab
        /// </summary>
        /// <returns>IWebDriver</returns>
        IWebDriver SwitchToLastTab();

        /// <summary>
        /// Switch to other tab by index 
        /// </summary>
        /// <param name="index"></param>
        /// <returns>IWebDriver</returns>
        IWebDriver SwitchToTab(int index);

        /// <summary>
        /// Switch to next tab
        /// </summary>
        /// <returns>IWebDriver</returns>
        IWebDriver SwitchToNextTab();

        /// <summary>
        /// Switch to previous tab
        /// </summary>
        /// <returns>IWebDriver</returns>
        IWebDriver SwitchToPreviousTab();

        /// <summary>
        /// Switch to tab with handler
        /// </summary>
        /// <param name="handle"></param>
        /// <returns>IWebDriver</returns>
        IWebDriver SwitchToTab(string windowName);

        /// <summary>
        /// Get index of the current tab
        /// </summary>
        /// <returns>IWebDriver</returns>
        int GetIndexOfCurrentTab();
    }
}
