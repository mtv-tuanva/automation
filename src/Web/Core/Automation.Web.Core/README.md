# Introduction 
This is the web automation test library that can help use early to create an automation web test on many browsers and many OS without setup the corresponding webdriver such as ChromeDriver, FirefoxDriver or IEDriver.
This library is still developing, so please keep looking. Thanks!

# Releate notes
1. v1.x.x -> v2.0.x
- Migrate to Selenium.WebDriver 4.7.x
- Integrate with Appium.WebDriver 5.x.x
- Support mobile web browsers testing on Android/iOS
- Support screen (video) recording function:
    + Added the StartScreenRecording() function into IBrowser
    + Added the StopScreenRecording() function into IBrowser

# Getting Started
1. Create your test project.
2. Install any unit test framework that you like. We will use NUnit in this tutorial.
3. Installation the nuget package: `Automation.Web.Core`
4. Create a `browsers.json` file as below in your test project and set it as a `Content` in the `Build action` and `Copy to Output Directory`
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

5. Add your test code
```
    [TestFixtureSource(typeof(ExecutableBrowserSourceConfig))]
    public class BrowserTests
    {
        private IBrowser browser;
        private readonly string browserId;

        public BrowserTests(string browserId)
        {
            this.browserId = browserId;
        }

        [SetUp]
        public void SetUp()
        {
            browser = BrowserFactory.CreateBrowser(browserId);

            //Start screen recording for evidence
            //browser.StartScreenRecording();
        }

        [Test]
        public void Test()
        {
            browser.Navigation.GoToUrl("https://www.google.com");
            Assert.True(browser.Title.Contains("Google"));
        }

        [TearDown]
        public virtual void TearDown()
        {
            //Take screenshot
            string filePath = browser.TakeAndSaveScreenshot();
            TestContext.AddTestAttachment(filePath);

            //Stop video recording            
            //browser.StopScreenRecording();

            //Dispose the browser
            browser.Dispose();
        }
    }
```
*Note: 
    - The `StartScreenRecording` & `StopScreenRecording` functions only work when run web test on mobile device. 
    - To let they work also in Windows OS, please add nuget package `Automation.Web.Core.Forms` https://www.nuget.org/packages/Automation.Web.Core.Forms/

6. Run your test cases and see the magic^^

7. Browser configuration details
7.1 Desktop web testing
- Currently, we support Chrome, Firefox, Safari, Edge, InternetExplorer.

7.2 Mobile web testing
- It's required to have an Appium server to run the Mobile web testing. So, please don't forget to set the `ServerUrl` to the Appium server such as http://127.0.0.1:4723.

# Recommend
There is another nuget package `Automation.Web.NUnit` that applying the `Automation.Web.Core` with the `NUnit` framework. It also supports to integrate with Specflow for BDD.
So, let try with it https://www.nuget.org/packages/Automation.Web.NUnit

# APIs document
1. IBrowser APIs
 * The IBrowser is wrapper almost APIs from IWebDriver
 * Highlight APIs:
 - IBrowser.TakeAndSaveScreenshot(fileName) : take screenshot and save to local disk then return the file path.
 - IBrowser.StartScreenRecording() : start screen recording video. This api supports mobile web, and windows web only.
 - IBrowser.StopScreenRecording() : stop screen recording video and return the file path. This api supports mobile web, and windows web only.

# Contribute
Will update later.