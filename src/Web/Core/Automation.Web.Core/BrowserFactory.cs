using Automation.Web.Core.Browsers;
using Automation.Web.Core.Config;
using System.ComponentModel;

namespace Automation.Web.Core
{
    public static class BrowserFactory
    {
        public static IBrowser CreateBrowser(BrowserType browserType, string jsonConfigFileName = "browsers.json")
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new ChromeBrowser(jsonConfigFileName);

                case BrowserType.Firefox:
                    return new FirefoxBrowser(jsonConfigFileName);

                case BrowserType.Edge:
                    return new EdgeBrowser(jsonConfigFileName);

                case BrowserType.InternetExplorer:
                    return new InternetExplorerBrowser(jsonConfigFileName);

                case BrowserType.Opera:
                    return new OperaBrowser(jsonConfigFileName);

                case BrowserType.Safari:
                    return new SafariBrowser(jsonConfigFileName);
            }

            throw new InvalidEnumArgumentException($"The value of {nameof(browserType)} isn't supported.");
        }

        public static IBrowser CreateBrowser(BrowserConfig browserConfig)
        {
            switch (browserConfig.Browser)
            {
                case BrowserType.Chrome:
                    return new ChromeBrowser(browserConfig);

                case BrowserType.Firefox:
                    return new FirefoxBrowser(browserConfig);

                case BrowserType.Edge:
                    return new EdgeBrowser(browserConfig);

                case BrowserType.InternetExplorer:
                    return new InternetExplorerBrowser(browserConfig);

                case BrowserType.Opera:
                    return new OperaBrowser(browserConfig);

                case BrowserType.Safari:
                    return new SafariBrowser(browserConfig);
            }

            throw new InvalidEnumArgumentException($"The value of {nameof(browserConfig.Browser)} isn't supported.");
        }
    }
}
