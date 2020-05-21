using OpenQA.Selenium;
using System.Collections.Generic;

namespace Automation.Web.Core
{
    public partial class Browser : IBrowserConsole
    {
        /// <summary>
        /// Get browser console log
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<LogEntry> GetConsoleLog()
            => Logs.GetLog(LogType.Browser);

        /// <summary>
        /// Clear browser console log
        /// </summary>
        public void ClearConsoleLog()
            => ExecuteScript("console.clear()");
    }
}
