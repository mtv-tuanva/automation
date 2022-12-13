using SharpAvi.Codecs;
using SharpAvi.Output;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Automation.Web.Core.Forms.Recorder
{
    public class ScreenRecorder : IDisposable
    {
        #region Fields
        private readonly AviWriter writer;
        private readonly IAviVideoStream videoStream;
        private readonly Thread screenThread;
        private readonly ManualResetEvent stopThread = new ManualResetEvent(false);
        private readonly int width, height;
        private readonly string fileName;
        #endregion

        public ScreenRecorder(string fileName)
        {
            this.fileName = fileName;
            height = (int)(Screen.PrimaryScreen.Bounds.Height * 1.25);
            width = (int)(Screen.PrimaryScreen.Bounds.Width * 1.25);

            // Create AVI writer and specify FPS
            writer = new AviWriter(fileName)
            {
                FramesPerSecond = 30,
                EmitIndex1 = true,
            };

            // Create video stream
            videoStream = writer.AddUncompressedVideoStream(width, height);

            // Set only name. Other properties were when creating stream, 
            // either explicitly by arguments or implicitly by the encoder used
            videoStream.Name = "Captura";

            screenThread = new Thread(RecordScreen)
            {
                Name = typeof(ScreenRecorder).Name + ".RecordScreen",
                IsBackground = true
            };

            screenThread.Start();
        }

        public string FileName => fileName;

        public void Dispose()
        {
            stopThread.Set();
            screenThread.Join();
            writer.Close();
            stopThread.Dispose();
        }

        void RecordScreen()
        {
            var frameInterval = TimeSpan.FromSeconds(1 / (double)writer.FramesPerSecond);
            var buffer = new byte[width * height * 4];
            Task videoWriteTask = null;
            var timeTillNextFrame = TimeSpan.Zero;

            while (!stopThread.WaitOne(timeTillNextFrame))
            {
                var timestamp = DateTime.Now;

                // Wait for the previous frame is written
                videoWriteTask?.Wait();

                Screenshot(buffer);

                // Start asynchronous (encoding and) writing of the new frame
                videoWriteTask = videoStream.WriteFrameAsync(true, buffer, 0, buffer.Length);

                timeTillNextFrame = timestamp + frameInterval - DateTime.Now;
                if (timeTillNextFrame < TimeSpan.Zero)
                    timeTillNextFrame = TimeSpan.Zero;
            }

            // Wait for the last frame is written
            videoWriteTask?.Wait();
        }

        public void Screenshot(byte[] Buffer)
        {
            using (var BMP = new Bitmap(width, height))
            {
                using (var g = Graphics.FromImage(BMP))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, new Size(width, height), CopyPixelOperation.SourceCopy);

                    g.Flush();

                    var bits = BMP.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
                    Marshal.Copy(bits.Scan0, Buffer, 0, Buffer.Length);
                    BMP.UnlockBits(bits);
                }
            }
        }

        /*THIS CODE BLOCK IS COPIED*/

        public Bitmap ToBitmap(byte[] byteArrayIn)
        {
            var ms = new System.IO.MemoryStream(byteArrayIn);
            var returnImage = System.Drawing.Image.FromStream(ms);
            var bitmap = new System.Drawing.Bitmap(returnImage);

            return bitmap;
        }

        public Bitmap ReduceBitmap(Bitmap original, int reducedWidth, int reducedHeight)
        {
            var reduced = new Bitmap(reducedWidth, reducedHeight);
            using (var dc = Graphics.FromImage(reduced))
            {
                // you might want to change properties like
                dc.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                dc.DrawImage(original, new Rectangle(0, 0, reducedWidth, reducedHeight), new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);
            }

            return reduced;
        }

        /*END OF COPIED CODE BLOCK*/
    }
}