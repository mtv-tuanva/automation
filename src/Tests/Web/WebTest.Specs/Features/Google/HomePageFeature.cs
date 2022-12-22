using Automation.Web.Core.Config;
using Automation.Web.NUnit.Attributes;
using Automation.Web.NUnit.Specflow.Feature;

namespace WebTest.Specs.Features.Google
{
    [BrowserSource(typeof(ExecutableBrowserSourceConfig))]
    public partial class HomePageFeature : BrowserInjectionFeature
    {
        public HomePageFeature(string browserID) : base(browserID)
        { }
    }
}
