using Automation.Web.Core;
using Automation.Web.Core.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace Automation.Web.NUnit
{

    /// <summary>
    /// Identifies the browser source used to provide test fixture instances for a test class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class BrowserSourceAttribute : TestFixtureSourceAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceType">A descendant of ExecutableBrowserSourceConfig type</param>
        public BrowserSourceAttribute(Type sourceType) : base(sourceType)
        {
        }
    }

    public class WebTestBase : ParallelizableWebTestBase
    {
        public WebTestBase(string browserId) : base(browserId)
        {
        }
    }

    [Parallelizable(ParallelScope.Self)]
    public class ParallelizableWebTestBase : NonParallelizableWebTestBase
    {
        public ParallelizableWebTestBase(string browserId) : base(browserId)
        {
        }
    }

    [BrowserSource(typeof(ExecutableBrowserSourceConfig))]
    public class NonParallelizableWebTestBase
    {
        protected IBrowser Browser;
        protected readonly string BrowserId;
        public virtual ScreenshotCondition ScreenshotCondition { get; set; } = ScreenshotCondition.Failure;

        public NonParallelizableWebTestBase(string browserId)
        {
            BrowserId = browserId;
        }

        [SetUp]
        public virtual void SetUp()
        {
            Browser = BrowserFactory.CreateBrowser(BrowserId);
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

            Browser.Dispose();
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
