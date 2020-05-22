using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Converters;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using WebDriverManager.Helpers;

namespace Automation.Web.Core.Config
{
    public class BrowserConfig
    {
        public const string DefaultConfigurationFileName = "browsers.json";

        public BrowserConfig() { }

        public BrowserConfig(BrowserType browserType)
        {
            Browser = browserType;
        }

        /// <summary>
        /// Browser type, that is specify the browser is chrome or firefox or IE or Safari...
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public BrowserType Browser { get; set; }

        /// <summary>
        /// WebDriver/Browser version. Default value is `Latest`
        /// </summary>
        public string Version { get; set; } = "Latest";

        /// <summary>
        /// X32 or X64 or Auto. Default value is `Auto`
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Architecture Platform { get; set; } = Architecture.Auto;

        /// <summary>
        /// Specify that the browser is going to be run as headless or not. Notice that only Chrome or Firefox supports headless type.
        /// </summary>
        public bool IsHeadless { get; set; }

        /// <summary>
        /// The Arguments that are going to be added to the DriverOptions
        /// </summary>
        public List<string> Arguments { get; set; } = new List<string>();

        /// <summary>
        /// The log level of browser
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        /// <summary>
        ///     The implicit wait timeout in second, which is the amount of time the driver
        ///     should wait when searching for an element if it is not immediately present.
        /// </summary>
        /// <Remarks>
        ///     When searching for a single element, the driver should poll the page until the
        ///     element has been found, or this timeout expires before throwing a OpenQA.Selenium.NoSuchElementException.
        ///     When searching for multiple elements, the driver should poll the page until at
        ///     least one element has been found or this timeout has expired.
        ///     Increasing the implicit wait timeout should be used judiciously as it will have
        ///     an adverse effect on test run time, especially when used with slower location
        ///     strategies like XPath.
        /// </Remarks>

        public uint ImplicitTimeoutInSecond { get; set; } = 30;

        /// <summary>
        /// The timeout value indicating how long to wait for the condition.
        /// </summary>
        public uint DefaultWaitTimeInSecond { get; set; } = 30;

        /// <summary>
        /// Read the BrowserConfig from a json file
        /// </summary>
        /// <param name="browserType">The browser type.</param>
        /// <param name="jsonConfigFileName">The json config file of browser.</param>
        /// <returns></returns>
        public static BrowserConfig ReadFromConfig(BrowserType browserType, string jsonConfigFileName = null)
        {
            if (string.IsNullOrEmpty(jsonConfigFileName))
            {
                if (!File.Exists(Path.Combine(Environment.CurrentDirectory, DefaultConfigurationFileName)))
                {
                    return new BrowserConfig(browserType);
                }

                jsonConfigFileName = DefaultConfigurationFileName;
            }

            var config = new ConfigurationBuilder()
             .SetBasePath(Environment.CurrentDirectory)
             .AddJsonFile(jsonConfigFileName, optional: false, reloadOnChange: true)
             .AddEnvironmentVariables()
             .Build();

            return config.Get<BrowserConfigs>().Browsers?.FirstOrDefault(x => x.Browser == browserType) ?? new BrowserConfig();
        }
    }
}
