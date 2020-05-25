using Automation.Web.Core;
using Automation.Web.Core.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Automation.Web.NUnit
{
    [TestFixtureSource(typeof(ExecutableBrowserConfig))]
    [Parallelizable(ParallelScope.Self)]
    public class WebTestBase
    {
        protected IBrowser Browser;
        protected readonly BrowserType BrowserType;
        public virtual ScreenshotCondition ScreenshotCondition { get; set; } = ScreenshotCondition.Failure;

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
            switch (ScreenshotCondition)
            {
                case ScreenshotCondition.Always:
                    TakeScreenshot();
                    break;

                case ScreenshotCondition.Success:
                    if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
                    {
                        TakeScreenshot();
                    }
                    break;

                case ScreenshotCondition.Failure:
                    if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
                    {
                        TakeScreenshot();
                    }
                    break;
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
