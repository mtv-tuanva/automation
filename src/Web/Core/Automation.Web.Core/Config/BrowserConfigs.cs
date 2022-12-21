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
        /// <param name="jsonConfigFileName">The json config file of browser. It should be in the same folder with the execution file</param>
        /// <returns>BrowserConfigs</returns>
        public static BrowserConfigs ReadFromConfig(string jsonConfigFileName = null)
        {
            var config = ReadConfiguratonFile(jsonConfigFileName);

            return config.Get<BrowserConfigs>();
        }

        /// <summary>
        /// Read the BrowserConfigs from a json file
        /// </summary>
        /// <param name="jsonConfigFileName">The json config file of browser. It should be in the same folder with the execution file</param>
        /// <returns>An IConfiguration value</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IConfiguration ReadConfiguratonFile(string jsonConfigFileName = null)
        {
            if (string.IsNullOrEmpty(jsonConfigFileName))
            {
                if (!File.Exists(Path.Combine(Environment.CurrentDirectory, DefaultConfigurationFileName)))
                {
                    throw new ArgumentNullException(nameof(jsonConfigFileName), $"Can't find the configuration {Path.Combine(Environment.CurrentDirectory, DefaultConfigurationFileName)}");
                }

                jsonConfigFileName = DefaultConfigurationFileName;
            }

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environment.GetEnvironmentVariable("ENVIRONMENT");

            var configBuilder = new ConfigurationBuilder()
             .SetBasePath(Environment.CurrentDirectory)
             .AddJsonFile(jsonConfigFileName, optional: false, reloadOnChange: true);

            if (!string.IsNullOrEmpty(env))
            {
                var fileNameWithoutExtention = jsonConfigFileName.Substring(0, jsonConfigFileName.LastIndexOf('.'));
                var extension = jsonConfigFileName.Substring(jsonConfigFileName.LastIndexOf('.') + 1);
                configBuilder.AddJsonFile($"{fileNameWithoutExtention}.{env}.{extension}", optional: true, reloadOnChange: true);
            }

            return configBuilder.AddEnvironmentVariables().Build();
        }
    }
}
