using Automation.Web.Core.Config;

namespace Automation.Web.Bdd.Models
{
    public class TestCaseConfig : BrowserConfigs
    {
        public Step[] Steps { get; set; }

        /// <summary>
        /// Read the TestCaseConfig from a json file
        /// </summary>
        /// <param name="jsonConfigFileName">The json config file of test case.</param>
        /// <returns>TestCaseConfig</returns>
        public static TestCaseConfig ReadTestCasesFromConfig(string jsonConfigFileName)
        {
            return ReadFromConfig<TestCaseConfig>(jsonConfigFileName);
        }
    }
}
