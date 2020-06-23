using System.Threading.Tasks;
using Automation.Web.Bdd.Models;

namespace Automation.Web.Bdd.Processors
{
    public class TestCaseRunner : ITestCaseRunner
    {
        public void Run(TestCaseConfig testCaseConfig)
        {
            Parallel.ForEach(testCaseConfig.Browsers, (browser) =>
            {
                new WebTestRunner(browser).Run(testCaseConfig.Steps);
            });
        }
    }
}
