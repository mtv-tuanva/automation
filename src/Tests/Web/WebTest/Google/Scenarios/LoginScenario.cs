using Automation.Web.NUnit;
using NUnit.Framework;
using WebTest.Google.Pages;

namespace WebTest.Google.Scenarios
{
    public class LoginScenario : WebTestBase
    {
        private GooglePages pages;

        public LoginScenario(string browserId) : base(browserId)
        {
            ScreenshotCondition = Automation.Web.Core.ScreenshotCondition.Always;
        }

        public override void SetUp()
        {
            base.SetUp();
            pages = new GooglePages(Browser);
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
}
