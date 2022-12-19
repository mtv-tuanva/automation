using Microsoft.Extensions.Configuration;
using System.Collections;

namespace Automation.Web.Core.Config
{
    public class ExecutableBrowserSourceConfig : IEnumerable
    {
        /// <summary>
        /// Override section key of ExecutableBrowsers from browsers.json
        /// </summary>
        protected virtual string ExecutableBrowserKey => "ExecutableBrowsers";

        public IEnumerator GetEnumerator()
        {
            return BrowserConfigs.ReadConfiguratonFile()?.GetSection(ExecutableBrowserKey)?.Get<string[]>()?.GetEnumerator();
        }
    }
}
