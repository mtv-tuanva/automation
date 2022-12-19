using Automation.Web.Core;
using BoDi;
using TechTalk.SpecFlow;

namespace Automation.Web.NUnit.Specflow.Hook
{
    [Binding]
    public class BrowserInjectionHook
    {
        private readonly IObjectContainer _objectContainer;

        public BrowserInjectionHook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver(FeatureContext featureContext)
        {
            featureContext.TryGetValue($"browser", out IBrowser browser);
            _objectContainer.RegisterInstanceAs(browser);
        }
    }
}
