//using Automation.Web.Core;

//namespace WebTest.Specs.Scenarios
//{
//    public class LoginScenario : WebTestBase
//    {
//        private GooglePages pages;

//        public LoginScenario(WebDriver webDriver) : base(browserId)
//        {
//            ScreenshotCondition = ScreenshotCondition.Always;
//        }

//        public override void SetUp()
//        {
//            base.SetUp();
//            pages = new GooglePages(Browser);
//            Browser.StartScreenRecording();
//        }

//        public override void TearDown()
//        {
//            var recordVideoPath = Browser.StopScreenRecording();
//            TestContext.AddTestAttachment(recordVideoPath);
//            base.TearDown();
//        }

//        [Test]
//        public void LoginSuccess()
//        {
//            pages.HomePage.GoHere();
//            //pages.HomePage.GotoLogin();
//            //pages.LoginPage.Login("automation.web.test", "0123456789a@T");

//            Assert.True(pages.HomePage.IsDisplaying());
//        }
//    }
//}
