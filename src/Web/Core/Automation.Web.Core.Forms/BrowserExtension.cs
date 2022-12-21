using Automation.Web.Core.Forms.Recorder;

namespace Automation.Web.Core
{
    public static class BrowserExtension
    {
        public static void WindowsOsStartScreenRecording(this IBrowser browser)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "VideoRecords");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var fileName = $"Record_{Guid.NewGuid():N}.avi";
            string fullPath = Path.Combine(folderPath, fileName);
            var rec = new ScreenRecorder(fullPath);
            browser.Recorders.Enqueue(rec);
        }

        public static string WindowsOsStopScreenRecording(this IBrowser browser)
        {
            var rec = (ScreenRecorder)browser.Recorders.Dequeue();
            var filePath = rec.FileName;
            rec.Dispose();
            return filePath;
        }
    }
}