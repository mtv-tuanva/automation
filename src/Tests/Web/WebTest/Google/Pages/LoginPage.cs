using Automation.Web.Core;
using Automation.Web.Core.PageObjectModels;
using OpenQA.Selenium;

namespace WebTest.Google.Pages
{
    public class LoginPage : PageBase
    {
        public LoginPage(IBrowser browser) : base(browser)
        {
        }

        public void WaitUntilReady()
        {
            Browser.WaitUntilElementExists("identifierId", SelectorType.Id);
        }

        public void Login(string username, string password)
        {
            UsernameInput.SendKeys(username);
            NextBtn.Click();
            PasswordInput.SendKeys(password);
            PasswordNextBtn.Click();
        }

        public IWebElement UsernameInput => Browser.FindElementById("identifierId");                
        public IWebElement PasswordInput => Browser.FindElementByName("password");
        public IWebElement NextBtn => Browser.FindElementById("identifierNext");
        public IWebElement PasswordNextBtn => Browser.FindElementById("passwordNext");
    }
}
