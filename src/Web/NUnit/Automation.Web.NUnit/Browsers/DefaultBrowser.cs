using Automation.Web.Core.Browsers;

namespace Automation.Web.NUnit.Browsers
{
    public class DefaultBrowser : ChromeBrowser
    {
        public DefaultBrowser() : base(jsonConfigFileName: null)
        {
        }
    }
}
