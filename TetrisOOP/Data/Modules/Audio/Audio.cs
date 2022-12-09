using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisOOP.Data.Modules.Audio
{
    /// <summary>
    /// Stream for looping playback
    /// </summary>
    public class Audio : WaveStream
    {
        WaveStream sourceStream;

        /// <summary>
        /// Creates a new Loop stream
        /// </summary>
        /// <param name="sourceStream">The stream to read from. Note: the Read method of this stream should return 0 when it reaches the end
        /// or else we will not loop to the start again.</param>
        public Audio(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
            this.EnableLooping = true;
        }

        /// <summary>
        /// Use this to turn looping on or off
        /// </summary>
        public bool EnableLooping { get; set; }

        /// <summary>
        /// Return source stream's wave format
        /// </summary>
        public override WaveFormat WaveFormat
        {
            get { return sourceStream.WaveFormat; }
        }

        /// <summary>
        /// LoopStream simply returns
        /// </summary>
        public override long Length
        {
            get { return sourceStream.Length; }
        }

        /// <summary>
        /// LoopStream simply passes on positioning to source stream
        /// </summary>
        public override long Position
        {
            get { return sourceStream.Position; }
            set { sourceStream.Position = value; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    if (sourceStream.Position == 0 || !EnableLooping)
                    {
                        // something wrong with the source stream
                        break;
                    }
                    // loop
                    sourceStream.Position = 0;
                }
                totalBytesRead += bytesRead;
            }
            return totalBytesRead;
        }
    }

    public class Sound
    {
        private byte[] _s;

        public static WaveOut sfx;

        public Sound(byte[] s)
        {
            _s = s;
        }

        public void PlayLoop()
        {
            if (sfx == null)
            {
                Stream file = new MemoryStream(_s);
                Mp3FileReader reader = new Mp3FileReader(file);
                Audio loop = new Audio(reader);
                sfx = new WaveOut();
                sfx.Volume = (float)Properties.Settings.Default.AudioVolume / 100;
                sfx.Init(loop);
                sfx.Play();
            }
            else
            {
                Stop();
            }
        }

        public static void Play(byte[] s)
        {
            Stream file = new MemoryStream(s);
            Mp3FileReader reader = new Mp3FileReader(file);
            WaveOut fx = new WaveOut();
            fx.Volume = 1f;
            fx.Init(reader);
            fx.Play();
        }

        public void Stop()
        {
            sfx.Stop();
            sfx.Dispose();
            sfx = null;
        }
    }
}