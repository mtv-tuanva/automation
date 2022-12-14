# Introduction 
This is the web automation test library that can help use early to create an automation web test on many browsers and many OS without setup the corresponding webdriver such as ChromeDriver, FirefoxDriver or IEDriver.
This library is still developing, so please keep looking. Thanks!
# Getting Started
1. Create your test project.
2. Install any unit test framework that you like. We will use NUnit in this tutorial.
3. Installation the nuget package: `Automation.Web.Core`
4. Create a `browsers.json` file as below in your test project and set it as a `Content` in the `Build action` and `Copy to Output Directory`
```
{
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

5. Add your test code
```
[TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    [TestFixture(BrowserType.Edge)]
    [TestFixture(BrowserType.InternetExplorer)]
    [TestFixture(BrowserType.Opera)]
    [TestFixture(BrowserType.Safari)]
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
```
6. Run your test cases and see the magic^^

7. Browser configuration details
7.1 Desktop web testing
- Currently, we support Chrome, Firefox, Safari, Edge, InternetExplorer.

7.2 Mobile web testing
- It's required to have an Appium server to run the Mobile web testing. So, please don't forget to set the `ServerUrl` to the Appium server such as http://127.0.0.1:4723.

# Contribute
Will update later.