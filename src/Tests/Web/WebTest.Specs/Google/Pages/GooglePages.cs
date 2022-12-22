using Automation.Web.Core;

namespace WebTest.Specs.Pages
{
    public class GooglePages
    {
        public readonly HomePage HomePage;
        public readonly LoginPage LoginPage;

        public GooglePages(IBrowser webDriver)
        {
            HomePage = new HomePage(webDriver);
            LoginPage = new LoginPage(webDriver);
        }
    }
}
