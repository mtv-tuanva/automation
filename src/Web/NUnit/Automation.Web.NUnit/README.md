# Introduction 
This is the web automation test library that can help use early to create an automation web test on many browsers and many OS without setup the corresponding webdriver such as ChromeDriver, FirefoxDriver or IEDriver.
This library is still developing, so please keep looking. Thanks!

# Releate notes
1. v1.x.x -> v2.0.0
- Migrate Automation.Web.Core to v2.0.0
- Added 2 more test class base:
 + NonParallelizableWebTestBase
 + ParallelizableWebTestBase
- Add new attribute `BrowserSourceAttribute`. It is used to configure your browser source which decides all browsers will be used to execute on the target Test Class.
- Support Specflow:
    + Added class `BrowserInjectionFeature` to extend your generated class xxx.feature.cs to inject multiple browser into the same feature. If will help you to execute multiple browsers using the same Feature/scenario
    + Added class `BrowserInjectionHook`. It is used to inject the IBrowser into the scenario context, and setting auto take screenshot per steps, or auto take the video record per scenario.

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
      "Id": "Android",
      "Browser": "Chrome",
      "Platform": "Android",
      "PlatformVersion": "11.0",
      "DeviceName": "Pixel5",
      "AutomationName": "UIAutomator2",
      "ServerUrl": "http://127.0.0.1:4723",
      "IsHeadless": false,
      "LogLevel": "Debug",
      "Arguments": [],
      "ImplicitTimeoutInSecond": 30,
      "DefaultWaitTimeInSecond": 3000
    },
    {
      "Id": "Chrome",
      "Browser": "Chrome",
      "Version": "Latest",
      "IsHeadless": false,
      "LogLevel": "Debug",
      "Arguments": [],
      "ImplicitTimeoutInSecond": 30,
      "DefaultWaitTimeInSecond": 30
    },
    {
      "Id": "Firefox",
      "Browser": "Firefox",
      "Version": "Latest",
      "IsHeadless": false,
      "LogLevel": "Debug",
      "Arguments": [],
      "ImplicitTimeoutInSecond": 30,
      "DefaultWaitTimeInSecond": 30
    },
    {
      "Id": "InternetExplorer",
      "Browser": "InternetExplorer",
      "Platform": "X32",
      "LogLevel": "Debug",
      "Arguments": [],
      "ImplicitTimeoutInSecond": 30,
      "DefaultWaitTimeInSecond": 30
    },
    {
      "Id": "Edge",
      "Browser": "Edge",
      "Version": "Latest",
      "LogLevel": "Debug",
      "Arguments": [],
      "ImplicitTimeoutInSecond": 30,
      "DefaultWaitTimeInSecond": 30
    },
    {
      "Id": "Safari",
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

6. Browser configuration details
6.1 Desktop web testing
- Currently, we support Chrome, Firefox, Safari, Edge, InternetExplorer.

6.2 Mobile web testing
- It's required to have an Appium server to run the Mobile web testing. So, please don't forget to set the `ServerUrl` to the Appium server such as http://127.0.0.1:4723.

6.3 Execute multiple browsers with the same Test case
- You can configure a list of browsers that you wanna run with your test case using the `ExecutableBrowsers` in above browser.json.

7. Specflow support

# Contribute
Will update later.