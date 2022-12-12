using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Automation.Web.Core.Config
{
    public class BrowserConfigs
    {
        public const string DefaultConfigurationFileName = "browsers.json";

        public string[] ExecutableBrowsers { get; set; }

        public BrowserConfig[] Browsers { get; set; }

        /// <summary>
        /// Read the BrowserConfigs from a json file
        /// </summary>
        /// <param name="jsonConfigFileName">The json config file of browser.</param>
        /// <returns>BrowserConfigs</returns>
        public static BrowserConfigs ReadFromConfig(string jsonConfigFileName = null)
        {
            if (string.IsNullOrEmpty(jsonConfigFileName))
            {
                if (!File.Exists(Path.Combine(Environment.CurrentDirectory, DefaultConfigurationFileName)))
                {
                    throw new ArgumentNullException(nameof(jsonConfigFileName), $"Can't find the configuration {Path.Combine(Environment.CurrentDirectory, DefaultConfigurationFileName)}");
                }

                jsonConfigFileName = DefaultConfigurationFileName;
            }

            var config = new ConfigurationBuilder()
             .SetBasePath(Environment.CurrentDirectory)
             .AddJsonFile(jsonConfigFileName, optional: false, reloadOnChange: true)
             .AddEnvironmentVariables()
             .Build();

            return config.Get<BrowserConfigs>();
        }
    }
}
