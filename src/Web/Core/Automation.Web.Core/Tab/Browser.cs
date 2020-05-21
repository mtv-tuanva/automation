using System.Linq;
using OpenQA.Selenium;

namespace Automation.Web.Core
{
    public partial class Browser : IBrowserTab
    {
        public void CloseTab(int index) 
            => SwitchToTab(index).Close();

        public void CloseCurrentTab()
            => SwitchToTab(WebDriver.CurrentWindowHandle).Close();

        public IWebDriver NewTab()
        {
            var oldWindows = WebDriver.WindowHandles.ToArray();
            ExecuteScript("window.open('', '_blank')");
            var newWindows = WebDriver.WindowHandles;
            var newWindow = newWindows.Except(oldWindows).First();

            return SwitchToTab(newWindow);
        }

        public IWebDriver SwitchToFirstTab()
            => SwitchToTab(WebDriver.WindowHandles.First());

        public IWebDriver SwitchToLastTab()
            => SwitchToTab(WebDriver.WindowHandles.Last());

        public IWebDriver SwitchToNextTab()
            => SwitchToTab(GetIndexOfCurrentTab() + 1);
        
        public IWebDriver SwitchToPreviousTab()
            => SwitchToTab(GetIndexOfCurrentTab() - 1);

        public IWebDriver SwitchToTab(int index)
            => SwitchToTab(WebDriver.WindowHandles[index]);

        public IWebDriver SwitchToTab(string windowName) 
            => WebDriver.SwitchTo().Window(windowName);

        public int GetIndexOfCurrentTab()
            => WebDriver.WindowHandles.IndexOf(WebDriver.CurrentWindowHandle);
    }
}
