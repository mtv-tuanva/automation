using OpenQA.Selenium;

namespace Automation.Web.Core
{
    public interface IBrowserScreenshot
    {
        /// <summary>
        /// Gets a OpenQA.Selenium.Screenshot object representing the image of the page on the screen.
        /// </summary>
        /// <returns>A OpenQA.Selenium.Screenshot object containing the image.</returns>
        Screenshot GetScreenshot();

        /// <summary>
        /// Takes and stores a OpenQA.Selenium.Screenshot object representing the image of the page on the screen.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>The full path of screenshot file.</returns>
        string TakeAndSaveScreenshot(string fileName = null);

        /// <summary>
        /// Start screen recording 
        /// </summary>
        void StartScreenRecording();

        /// <summary>
        /// Stop screen recording and save it to the path
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>The full path of record file.</returns>
        string StopScreenRecording(string fileName = null);
    }
}
