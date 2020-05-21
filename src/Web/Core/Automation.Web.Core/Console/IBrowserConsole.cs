using OpenQA.Selenium;
using System.Collections.Generic;

namespace Automation.Web.Core
{
    public interface IBrowserConsole
    {
        /// <summary>
        /// Clear browser console log
        /// </summary>
        void ClearConsoleLog();

        /// <summary>
        /// Get browser console log
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<LogEntry> GetConsoleLog();
    }
}
