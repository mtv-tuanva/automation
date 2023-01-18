using Automation.Web.Core.Browsers;

namespace Automation.Web.Specflow.Browsers
{
    public class DefaultBrowser : ChromeBrowser
    {
        public DefaultBrowser() : base(jsonConfigFileName: null)
        {
        }
    }
}
