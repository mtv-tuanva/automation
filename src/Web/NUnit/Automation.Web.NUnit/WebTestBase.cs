using Automation.Web.Core;
using Automation.Web.Core.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace Automation.Web.NUnit
{
    [TestFixtureSource(typeof(ExecutableBrowserConfig))]
    [Parallelizable(ParallelScope.Self)]
    public class WebTestBase
    {
        protected IBrowser Browser;
        protected readonly BrowserType BrowserType;
        public Func<ResultState, bool> AutoTakeScreenshotCondition =
            (result) =>
            {
                return true;
            };

        public WebTestBase(BrowserType browserType)
        {
            BrowserType = browserType;
        }

        [SetUp]
        public virtual void SetUp()
        {
            Browser = BrowserFactory.CreateBrowser(BrowserType);
        }

        [TearDown]
        public virtual void TearDown()
        {
            if (AutoTakeScreenshotCondition(TestContext.CurrentContext.Result.Outcome))
            {
                TakeScreenshot();
            }
            
            Browser.Quit();
        }

        public string TakeScreenshot(string fileName = null, bool autoAttach = true)
        {
            string filePath = Browser.TakeAndSaveScreenshot(fileName);

            if (autoAttach)
                TestContext.AddTestAttachment(filePath);

            return filePath;
        }
    }
}
