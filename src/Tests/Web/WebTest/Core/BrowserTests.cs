using Automation.Web.Core;
using NUnit.Framework;

namespace Tests.Web.WebTest.Core
{
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    [TestFixture(BrowserType.Edge)]
    [TestFixture(BrowserType.InternetExplorer)]
    [TestFixture(BrowserType.Opera)]
    //[TestFixture(BrowserType.Safari)]
    public class BrowserTests
    {
        private IBrowser browser;
        private readonly BrowserType browserType;

        public BrowserTests(BrowserType browserType)
        {
            this.browserType = browserType;
        }

        [SetUp]
        public void SetUp()
        {
            browser = BrowserFactory.CreateBrowser(browserType);
        }

        [Test]
        public void Test()
        {
            browser.Navigation.GoToUrl("https://www.google.com");
            Assert.True(browser.Title.Contains("Google"));
        }

        [TearDown]
        public void TearDown()
        {
            browser.Quit();
        }
    }
}