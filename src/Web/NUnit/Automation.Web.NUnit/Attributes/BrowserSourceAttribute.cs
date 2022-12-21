using NUnit.Framework;
using System;

namespace Automation.Web.NUnit.Attributes
{
    /// <summary>
    /// Identifies the browser source used to provide test fixture instances for a test class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class BrowserSourceAttribute : TestFixtureSourceAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceType">A descendant of ExecutableBrowserSourceConfig type</param>
        public BrowserSourceAttribute(Type sourceType) : base(sourceType)
        {
        }
    }
}
