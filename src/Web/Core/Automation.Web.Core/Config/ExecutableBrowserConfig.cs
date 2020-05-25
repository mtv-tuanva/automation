using System.Collections;

namespace Automation.Web.Core.Config
{
    public class ExecutableBrowserConfig : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            return BrowserConfigs.ReadFromConfig()?.ExecutableBrowsers?.GetEnumerator();
        }
    }
}
