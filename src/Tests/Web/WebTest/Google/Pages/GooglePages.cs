using Automation.Web.Core;

namespace WebTest.Google.Pages
{
    public class GooglePages
    {
        public readonly HomePage HomePage;
        public readonly LoginPage LoginPage;

        public GooglePages(IBrowser browser)
        {
            HomePage = new HomePage(browser);
            LoginPage = new LoginPage(browser);
        }
    }
}
