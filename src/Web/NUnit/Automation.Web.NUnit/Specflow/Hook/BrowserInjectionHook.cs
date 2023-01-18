using Automation.Web.Core;
using Automation.Web.Core.Config;
using Automation.Web.NUnit.Browsers;
using BoDi;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace Automation.Web.NUnit.Specflow.Hook
{
    /// <summary>
    /// Using BrowserInjectionHook to inject IBrowser into the scenario context, and setting auto take screenshot per steps, or auto take the video record per scenario.
    /// </summary>
    [Binding]
    public class BrowserInjectionHook
    {
        private readonly bool _isAutoTakeScreenshot = false;
        private readonly bool _isAutoRecordVideo = false;

        public BrowserInjectionHook() { }

        public BrowserInjectionHook(bool isAutoTakeScreenshot, bool isAutoRecordVideo)
        {
            _isAutoRecordVideo = isAutoRecordVideo;
            _isAutoTakeScreenshot = isAutoTakeScreenshot;
        }

        protected virtual bool IsAutoTakeScreenShot => _isAutoTakeScreenshot;
        protected virtual bool IsAutoRecordVideo => _isAutoRecordVideo;

        [BeforeScenario]
        public void InitializeWebDriver(ObjectContainer objectContainer, FeatureContext featureContext)
        {
            InjectIConfiguration(objectContainer);

            featureContext.TryGetValue($"browser", out IBrowser browser);
            if (browser == null)
            {
                objectContainer.BaseContainer.RegisterTypeAs<DefaultBrowser, IBrowser>();
                browser = objectContainer.BaseContainer.Resolve<IBrowser>();
                objectContainer.BaseContainer.RegisterInstanceAs<IWebDriver>(browser.WebDriver);
                featureContext.Add("browserId", "Chrome");
                featureContext.Add("browser", browser);
            }
            else
            {
                objectContainer.RegisterInstanceAs(browser);
                objectContainer.RegisterInstanceAs<IWebDriver>(browser.WebDriver);
            }

            if (IsAutoRecordVideo)
                browser.StartScreenRecording();
        }

        /// <summary>
        /// Inject configuration
        /// </summary>
        /// <param name="objectContainer"></param>
        private void InjectIConfiguration(ObjectContainer objectContainer)
        {
            objectContainer.RegisterInstanceAs(BrowserConfigs.ReadConfiguratonFile("appsettings.json"));
        }

        [AfterScenario]
        public void FinishScenario(IBrowser browser, ISpecFlowOutputHelper specFlowOutputHelper, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            var iterateIndex = NextIterateIndex(scenarioContext);
            if (IsAutoRecordVideo)
            {
                string fileName = null;
                var scenarioId = GetScenarioId(scenarioContext);

                if (scenarioId != null)
                {
                    fileName = $"{featureContext.Get<string>("browserId")}\\{scenarioId}\\iterate_{NextIterateIndex(scenarioContext)}";
                }
                var attach = browser.StopScreenRecording(fileName);
                specFlowOutputHelper.AddAttachment(UploadRecordedVideo(attach));
            }

            ResetStepIndex(scenarioContext);
            //specFlowOutputHelper.WriteLine("<a src={0}>record video</a>", new Uri(attach));
        }

        [AfterStep]
        public void FinishStep(IBrowser browser, ISpecFlowOutputHelper specFlowOutputHelper, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            var stepIndex = NextStepIndex(scenarioContext);
            if (IsAutoTakeScreenShot)
            {
                string fileName = null;
                var scenarioId = GetScenarioId(scenarioContext);

                if (scenarioId != null)
                {
                    fileName = $"{featureContext.Get<string>("browserId")}\\{scenarioId}\\iterate_{GetIterateIndex(scenarioContext)}_step{stepIndex}";
                }

                var attach = browser.TakeAndSaveScreenshot(fileName);
                specFlowOutputHelper.AddAttachment(UploadScreenShot(attach));
            }

            //specFlowOutputHelper.WriteLine("<img style=\"width: 50%\" src={0} />", new Uri(attach));
        }

        private string GetScenarioId(ScenarioContext scenarioContext)
        {
            var scenarioId = scenarioContext.ScenarioInfo.Tags?.Where(x => x.ToLower().StartsWith("id:") || x.ToLower().StartsWith("wi:")).OrderBy(x => x.ToLower()).FirstOrDefault();
            return scenarioId?.Replace(":", "_").Replace(" ", "_");
        }

        const string iterate = "iterateIndex";

        /// <summary>
        /// Get iterate index of the scenario
        /// </summary>
        /// <param name="scenarioContext"></param>
        /// <returns></returns>
        private int GetIterateIndex(ScenarioContext scenarioContext)
        {
            int indx;
            scenarioContext.TryGetValue(iterate, out indx);
            return indx + 1;
        }

        private int NextIterateIndex(ScenarioContext scenarioContext)
        {
            int indx;
            scenarioContext.TryGetValue(iterate, out indx);

            if (indx > 0)
            {
                scenarioContext.Remove(iterate);
            }

            scenarioContext.Add(iterate, ++indx);
            return indx;
        }

        const string _stepIndex = "stepIndex";

        private void ResetStepIndex(ScenarioContext scenarioContext)
        {

            int indx;
            scenarioContext.TryGetValue(_stepIndex, out indx);

            if (indx > 0)
            {
                scenarioContext.Remove(_stepIndex);
            }
        }

        private int NextStepIndex(ScenarioContext scenarioContext)
        {
            int indx;
            scenarioContext.TryGetValue(_stepIndex, out indx);

            if (indx > 0)
            {
                scenarioContext.Remove(_stepIndex);
            }

            scenarioContext.Add(_stepIndex, ++indx);
            return indx;
        }

        private int GetStepIndex(ScenarioContext scenarioContext)
        {
            int indx;
            scenarioContext.TryGetValue(_stepIndex, out indx);
            return indx + 1;
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
