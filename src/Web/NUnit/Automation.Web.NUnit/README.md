# Introduction 
This is the web automation test library that can help use early to create an automation web test on many browsers and many OS without setup the corresponding webdriver such as ChromeDriver, FirefoxDriver or IEDriver.
This library is still developing, so please keep looking. Thanks!
# Getting Started
1. Create your test project.
2. Installation the nuget package: `Automation.Web.NUnit`
3. Create a `browsers.json` file as below in your test project and set it as a `Content` in the `Build action` and `Copy to Output Directory`.
Notice that 
	`ExecutableBrowsers` is the browsers that will be executed in parallel when you run your test cases.
	`Browsers` is the configuration of each browser that you wanna support.
```
{
  "ExecutableBrowsers": [ "Chrome", "Firefox" ],

  "Browsers": [
    {
      "Browser": "Chrome",
      "Version": "Latest",
      "IsHeadless": false,
      "LogLevel": "Debug",
      "Arguments": [],
      "ImplicitTimeoutInSecond": 30,
      "DefaultWaitTimeInSecond": 30
    },
    {
      "Browser": "Firefox",
      "Version": "Latest",
      "IsHeadless": false,
      "LogLevel": "Debug",
      "Arguments": [],
      "ImplicitTimeoutInSecond": 30,
      "DefaultWaitTimeInSecond": 30
    },
    {
      "Browser": "InternetExplorer",
      "Platform": "X32",
      "LogLevel": "Debug",
      "Arguments": [],
      "ImplicitTimeoutInSecond": 30,
      "DefaultWaitTimeInSecond": 30
    },
    {
      "Browser": "Edge",
      "Version": "83.0.478.37",
      "LogLevel": "Debug",
      "Arguments": [],
      "ImplicitTimeoutInSecond": 30,
      "DefaultWaitTimeInSecond": 30
    },
    {
      "Browser": "Opera",
      "LogLevel": "Debug",
      "Arguments": [],
      "ImplicitTimeoutInSecond": 30,
      "DefaultWaitTimeInSecond": 30
    },
    {
      "Browser": "Safari",
      "LogLevel": "Debug",
      "ImplicitTimeoutInSecond": 30,
      "DefaultWaitTimeInSecond": 30
    }
  ]
}
```
This configuration is based on your browser version & your expection browser behaviours.

4. Add your test code. 
We recommend to use the Page Object Modle (POM) pattern in your UI test project. 
Below example is following the POM pattern.
- Define your page object models:
```
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
```

- Create your scenario tests
```
public class LoginScenario : WebTestBase
    {
        private GooglePages pages;

        public LoginScenario(BrowserType browserType) : base(browserType)
        {
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
            pages.HomePage.GotoLogin();
            pages.LoginPage.Login("**************", "****************");

            Assert.True(pages.HomePage.IsDisplaying());
        }
    }
```

5. Run your test cases and see the magic^^

# Contribute
Will update later.