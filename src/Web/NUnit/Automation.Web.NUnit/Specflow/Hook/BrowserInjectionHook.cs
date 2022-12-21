using Automation.Web.Core;
using Automation.Web.Core.Config;
using BoDi;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace Automation.Web.NUnit.Specflow.Hook
{
    [Binding]
    public class BrowserInjectionHook
    {
        private readonly bool _isAutoTakeScreenshot = false;
        private readonly bool _isAutoRecordScreenshot = false;

        public BrowserInjectionHook() { }

        public BrowserInjectionHook(bool isAutoTakeScreenshot, bool isAutoRecordScreenshot)
        {
            _isAutoRecordScreenshot = isAutoRecordScreenshot;
            _isAutoTakeScreenshot = isAutoTakeScreenshot;
        }

        [BeforeScenario]
        public void InitializeWebDriver(ObjectContainer objectContainer, FeatureContext featureContext)
        {
            featureContext.TryGetValue($"browser", out IBrowser browser);
            objectContainer.RegisterInstanceAs(browser);

            if (_isAutoRecordScreenshot)
                browser.StartScreenRecording();
        }

        [BeforeScenario]
        public void InjectIConfiguration(ObjectContainer objectContainer)
        {
            objectContainer.RegisterInstanceAs(BrowserConfigs.ReadConfiguratonFile("appsettings.json"));
        }

        [AfterScenario]
        public void FinishScenario(IBrowser browser, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            if (_isAutoRecordScreenshot)
            {
                var attach = browser.StopScreenRecording();
                specFlowOutputHelper.AddAttachment(UploadRecordedVideo(attach));
            }

            //specFlowOutputHelper.WriteLine("<a src={0}>record video</a>", new Uri(attach));
        }

        [AfterStep]
        public void FinishStep(IBrowser browser, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            var attach = browser.TakeAndSaveScreenshot();

            if (_isAutoTakeScreenshot)
                specFlowOutputHelper.AddAttachment(UploadScreenShot(attach));

            //specFlowOutputHelper.WriteLine("<img style=\"width: 50%\" src={0} />", new Uri(attach));
        }

        /// <summary>
        /// Upload a file to another/external storage, then return new file path
        /// </summary>
        /// <param name="filePath">The original file path</param>
        /// <returns>New uploaded file path</returns>
        public virtual string UploadScreenShot(string filePath)
        {
            return filePath;
        }

        /// <summary>
        /// Upload a file to another/external storage, then return new file path
        /// </summary>
        /// <param name="filePath">The original file path</param>
        /// <returns>New uploaded file path</returns>
        public virtual string UploadRecordedVideo(string filePath)
        {
            return filePath;
        }
    }
}
