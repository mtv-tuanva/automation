# Introduction 
This is the web automation test library that can help use early to create an automation web test on many browsers and many OS without setup the corresponding webdriver such as ChromeDriver, FirefoxDriver or IEDriver.
This library is still developing, so please keep looking. Thanks!
# Getting Started
1. Create your test project.
2. Install any unit test framework that you like. We will use NUnit in this tutorial.
3. Installation the nuget package: `Automation.Web.Core`
4. Create a `browsers.json` file as below in your test project and set it as a `Content or Embedded resource` in the `Build action` and `Copy to Output Directory`
```
	{
	  "Browsers": [
		{
		  "Browser": "Chrome",
		  "Version": "81.0.4044.138",
		  "IsHeadless": false,
		  "LogLevel": "Debug",
		  "Arguments": [],
		  "ImplicitTimeoutInSecond": 10,
		  "DefaultWaitTimeInSecond": 10
		},
		{
		  "Browser": "Firefox",
		  "Version": "Latest",
		  "IsHeadless": false,
		  "LogLevel": "Debug",
		  "Arguments": [],
		  "ImplicitTimeoutInSecond": 10,
		  "DefaultWaitTimeInSecond": 10
		},
		{
		  "Browser": "InternetExplorer",
		  "Platform":  "X32",
		  "LogLevel": "Debug",
		  "Arguments": [],
		  "ImplicitTimeoutInSecond": 10,
		  "DefaultWaitTimeInSecond": 10
		},
		{
		  "Browser": "Edge",
		  "Version": "81.0.416.72",
		  "LogLevel": "Debug",
		  "Arguments": [],
		  "ImplicitTimeoutInSecond": 10,
		  "DefaultWaitTimeInSecond": 10
		},
		{
		  "Browser": "Opera",
		  "LogLevel": "Debug",
		  "Arguments": [],
		  "ImplicitTimeoutInSecond": 10,
		  "DefaultWaitTimeInSecond": 10
		},
		{
		  "Browser": "Safari",
		  "LogLevel": "Debug",
		  "ImplicitTimeoutInSecond": 10,
		  "DefaultWaitTimeInSecond": 10
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

# Contribute
Will update later.