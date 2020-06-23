using Automation.Web.Bdd.Models;

namespace Automation.Web.Bdd.Processors
{
    public interface ITestCaseRunner
    {
        void Run(TestCaseConfig testCaseConfig);
    }
}
