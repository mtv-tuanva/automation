using Automation.Web.Core;
using Automation.Web.Core.Config;
using Automation.Web.NUnit;
using NUnit.Framework;
using WebTest.Google.Pages;

namespace WebTest.Google.Scenarios
{
    [TestFixtureSource(typeof(ExecutableBrowserSourceConfig))]
    [TestFixture()]
    [Parallelizable(ParallelScope.Fixtures)]
    [Order(1)]
    public class LoginScenario : NonParallelizableWebTestBase
    {
        private GooglePages pages;

        public LoginScenario(string browserId) : base(browserId)
        {
            ScreenshotCondition = ScreenshotCondition.Always;
        }

        public override void SetUp()
        {
            base.SetUp();
            pages = new GooglePages(Browser);
            Browser.StartScreenRecording();
        }

        public override void TearDown()
        {
            var recordVideoPath = Browser.StopScreenRecording();
            TestContext.AddTestAttachment(recordVideoPath);
            base.TearDown();
        }

        [Test]
        public void LoginSuccess()
        {
            pages.HomePage.GoHere();
            //pages.HomePage.GotoLogin();
            //pages.LoginPage.Login("automation.web.test", "0123456789a@T");

            Assert.True(pages.HomePage.IsDisplaying());
        }
    }

    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixtureSource(typeof(ExecutableBrowserSourceConfig))]
    [TestFixture()]
    [Order(1)]
    public class BrowserTests
    {
        private IBrowser browser;
        private readonly string browserId;

        public BrowserTests(string browserId)
        {
            this.browserId = browserId;
        }

        [SetUp]
        public void SetUp()
        {
            browser = BrowserFactory.CreateBrowser(browserId);

            //Start screen recording for evidence
            browser.StartScreenRecording();
        }

        [Test]
        public void Test()
        {
            browser.Navigation.GoToUrl("https://www.google.com");
            Assert.True(browser.Title.Contains("Google"));
        }

        [TearDown]
        public virtual void TearDown()
        {
            //Take screenshot
            string filePath = browser.TakeAndSaveScreenshot();
            TestContext.AddTestAttachment(filePath);

            //Stop video recording            
            browser.StopScreenRecording();

            //Dispose the browser
            browser.Dispose();
        }
    }
}
