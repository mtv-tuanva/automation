using Automation.Web.Core.Forms.Recorder;

namespace Automation.Web.Core
{
    public static class BrowserExtension
    {
        public static void StartScreenRecording(this IBrowser browser)
        {
            if (browser.Platform == PlatformType.Android || browser.Platform == PlatformType.IOS)
            {
                browser.StartScreenRecordingInternal();
            }
            else
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), $"VideoRecords");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var fileName = $"Record_{Guid.NewGuid()}.avi";
                string fullPath = Path.Combine(folderPath, fileName);
                var rec = new ScreenRecorder(fullPath);
                browser.Recorders.Enqueue(rec);
            }
        }

        public static string StopScreenRecording(this IBrowser browser)
        {
            if (browser.Platform == PlatformType.Android || browser.Platform == PlatformType.IOS)
            {
                return browser.StopScreenRecordingInternal();
            }
            else
            {
                var rec = (ScreenRecorder)browser.Recorders.Dequeue();
                var filePath = rec.FileName;
                rec.Dispose();
                return filePath;
            }
        }
    }
}