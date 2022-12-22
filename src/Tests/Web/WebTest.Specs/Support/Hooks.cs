using Automation.Web.NUnit.Specflow.Hook;
using BoDi;
using NUnit.Framework;
using WebTest.Specs.Helpers;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace WebTest.Specs.Support
{
    [Binding]
    public class WebDriverSupport : BrowserInjectionHook
    {
        private VideoStorageService _videoStorageService => _objectContainer.Resolve<VideoStorageService>();
        private ScreenshotStorageService _screenshotStorageService => _objectContainer.Resolve<ScreenshotStorageService>();
        private readonly ObjectContainer _objectContainer;

        public WebDriverSupport(ObjectContainer objectContainer) : base(true, true)
        {
            _objectContainer = objectContainer;
        }

        public override string UploadRecordedVideo(string filePath)
        {
            return _videoStorageService.UploadFile(base.UploadRecordedVideo(filePath));
        }

        public override string UploadScreenShot(string filePath)
        {
            return _screenshotStorageService.UploadFile(base.UploadScreenShot(filePath));
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            //browser?.Dispose();
        }
    }
}
