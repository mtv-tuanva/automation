using Automation.Web.Bdd.Models;

namespace Automation.Web.Bdd.Processors
{
    public interface IWebTestRunner
    {
        void Run(Step[] steps);
    }
}
