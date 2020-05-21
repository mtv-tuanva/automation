using System;
using System.IO;
using System.Runtime.InteropServices;
using ImageMagick;

namespace Automation.Web.Core.Helpers
{
    /// <summary>
    /// The FileHelper hasn't been tested on other OS except Windows yet. So, please be careful.
    /// </summary>
    public static class FileHelper
    {
        public static void ConvertPdfToImg(string pfdPath, string jpgPath)
        {
            MagickNET.SetGhostscriptDirectory("Libs");
            MagickReadSettings settings = new MagickReadSettings();
            // Settings the density to 300 dpi will create an image with a better quality
            settings.Density = new Density(300);
            using (MagickImageCollection images = new MagickImageCollection())
            {
                // Add all the pages of the pdf file to the collection
                images.Read(pfdPath, settings);
                // Create new image that appends all the pages vertically
                using (IMagickImage vertical = images.AppendVertically())
                {
                    // Save result as a jpg
                    vertical.Write(jpgPath);
                }
            }
        }

        public static string GetDownloadFilePath(string fileName)
        {
            SHGetKnownFolderPath(KnownFolder.Downloads, 0, IntPtr.Zero, out var downloadsPath);
            return Path.Combine(downloadsPath, fileName);
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath);
    }

    public static class KnownFolder
    {
        public static readonly Guid Downloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
    }
}
