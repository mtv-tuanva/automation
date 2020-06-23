using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Text.Json.Serialization;

namespace Automation.Web.Core.Config
{
    public class BrowserConfigs
    {
        public const string DefaultConfigurationFileName = "browsers.json";

        [JsonConverter(typeof(StringEnumConverter))]
        public BrowserType[] ExecutableBrowsers { get; set; }

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

        /// <summary>
        /// Read the configs from a json file
        /// </summary>
        /// <param name="jsonConfigFileName">The json config file.</param>
        /// <returns>T</returns>
        public static T ReadFromConfig<T>(string jsonConfigFileName)
        {
            if (string.IsNullOrEmpty(jsonConfigFileName))
            {
                throw new ArgumentNullException(nameof(jsonConfigFileName), $"The json config is required.");
            }

            var config = new ConfigurationBuilder()
             .SetBasePath(Environment.CurrentDirectory)
             .AddJsonFile(jsonConfigFileName, optional: false, reloadOnChange: true)
             .AddEnvironmentVariables()
             .Build();

            return config.Get<T>();
        }
    }
}
