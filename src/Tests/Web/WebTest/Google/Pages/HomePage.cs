using Automation.Web.Core;
using Automation.Web.Core.PageObjectModels;
using OpenQA.Selenium;

namespace WebTest.Google.Pages
{
    public class HomePage : PageBase
    {
        private readonly string url = @"https://www.google.com/";

        public HomePage(IBrowser browser) : base(browser)
        {
        }

        public void GoHere()
        {
            Browser.Navigation.GoToUrl(url);
            Browser.WaitUntilTitleIs("Google");
        }

        public void GotoLogin()
        {
            LinkLogin.Click();
        }

        public void GotoGmail()
        {
            LinkGmail.Click();
        }

        public void Search(string text)
        {
            SearchInput.SendKeys(text);
            //SearchInput.SendKeys(Keys.Enter);
            SearchBtn.Click();
        }

        public bool IsDisplaying()
        {
            return Browser.WaitUntilTitleIs("Google");
        }

        public IWebElement SearchInput => Browser.FindElementByName("q");

        public IWebElement SearchBtn => Browser.FindElementByName("btnK");

        public IWebElement LinkGmail => Browser.FindElementByLinkText("Gmail");

        public IWebElement LinkLogin => Browser.FindElementById("gb_70");
    }
}
