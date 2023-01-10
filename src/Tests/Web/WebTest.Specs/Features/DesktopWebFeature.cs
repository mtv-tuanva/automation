using Automation.Web.Core.Config;
using Automation.Web.NUnit.Attributes;
using Automation.Web.NUnit.Specflow.Feature;

namespace WebTest.Specs.Features
{
    [BrowserSource(typeof(ExecutableBrowserSourceConfig))]
    //[Parallelizable(ParallelScope.Self)]
    public partial class CalculatorFeature : BrowserInjectionFeature
    {
        public CalculatorFeature(string browserID) : base(browserID)
        {
        }
    }

    [BrowserSource(typeof(ExecutableBrowserSourceConfig))]
    public partial class CalculatorFeature2 : CalculatorFeature
    {
        public CalculatorFeature2(string browserID) : base(browserID)
        {
        }
    }
}
