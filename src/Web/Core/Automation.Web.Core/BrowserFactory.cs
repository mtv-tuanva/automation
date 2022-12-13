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

                case BrowserType.Safari:
                    return new SafariBrowser(jsonConfigFileName);
            }

            throw new InvalidEnumArgumentException($"The value of {nameof(browserType)} isn't supported.");
        }

        public static IBrowser CreateBrowser(string id, string jsonConfigFileName = "browsers.json")
        {
            var browserConfig = BrowserConfig.ReadFromConfig(id, jsonConfigFileName);

            switch (browserConfig.Platform)
            {

                case PlatformType.Android:
                    return new AndroidBrowser(browserConfig);
                case PlatformType.IOS:
                    return new IOSBrowser(browserConfig);
                case PlatformType.Any:
                case PlatformType.Win32:
                case PlatformType.Win64:
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

                        case BrowserType.Safari:
                            return new SafariBrowser(browserConfig);
                    }

                    throw new InvalidEnumArgumentException($"The value of {nameof(BrowserTypeName)} isn't supported.");
            }

            throw new InvalidEnumArgumentException($"The value of {nameof(BrowserTypeName)} isn't supported.");
        }
    }
}
