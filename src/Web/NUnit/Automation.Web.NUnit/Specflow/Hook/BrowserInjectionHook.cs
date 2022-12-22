using Automation.Web.Core;
using Automation.Web.Core.Config;
using BoDi;
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
        public void FinishScenario(IBrowser browser, ISpecFlowOutputHelper specFlowOutputHelper, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            if (_isAutoRecordScreenshot)
            {
                string fileName = null;
                var scenarioId = GetScenarioId(scenarioContext);

                if (scenarioId != null)
                {
                    fileName = $"{featureContext.Get<string>("browserId")}\\{scenarioId}\\iterate_{NextIterateIndex(scenarioContext)}";
                }
                var attach = browser.StopScreenRecording(fileName);
                specFlowOutputHelper.AddAttachment(UploadRecordedVideo(attach));
                ResetStepIndex(scenarioContext);
            }

            //specFlowOutputHelper.WriteLine("<a src={0}>record video</a>", new Uri(attach));
        }

        [AfterStep]
        public void FinishStep(IBrowser browser, ISpecFlowOutputHelper specFlowOutputHelper, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            if (_isAutoTakeScreenshot)
            {
                string fileName = null;
                var scenarioId = GetScenarioId(scenarioContext);

                if (scenarioId != null)
                {
                    fileName = $"{featureContext.Get<string>("browserId")}\\{scenarioId}\\iterate_{GetIterateIndex(scenarioContext)}_step{NextStepIndex(scenarioContext)}";
                }

                var attach = browser.TakeAndSaveScreenshot(fileName);
                specFlowOutputHelper.AddAttachment(UploadScreenShot(attach));
            }


            //specFlowOutputHelper.WriteLine("<img style=\"width: 50%\" src={0} />", new Uri(attach));
        }

        private string GetScenarioId(ScenarioContext scenarioContext)
        {
            var scenarioId = scenarioContext.ScenarioInfo.Tags?.Where(x => x.ToLower().StartsWith("id:") || x.ToLower().StartsWith("wi:")).OrderBy(x => x.ToLower()).FirstOrDefault();
            return scenarioId.Replace(":", "_").Replace(" ", "_");
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
