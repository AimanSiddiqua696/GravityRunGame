using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace SemiFinalGame.Sound
{
    public static class SoundManager
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        private static string currentMusicAlias = "gameMusic";

        /// <summary>
        /// Plays background music in a loop. Stops any currently playing music.
        /// </summary>
        public static void PlayMusic(Stream resourceStream)
        {
            if (resourceStream == null) return;

            // Stop any currently playing music
            StopMusic();

            try
            {
                // Create a temp file for the music
                string tempFile = Path.Combine(Path.GetTempPath(), $"gravityrun_music_{DateTime.Now.Ticks}.wav");

                // Write the resource stream to the temp file
                using (FileStream fileStream = File.Create(tempFile))
                {
                    resourceStream.CopyTo(fileStream);
                }

                // MCI Command to open and play
                // Using "mpegvideo" is more robust as it handles both MP3 and WAV (if renamed)
                string openCommand = $"open \"{tempFile}\" type mpegvideo alias {currentMusicAlias}";
                string playCommand = $"play {currentMusicAlias} repeat";

                mciSendString(openCommand, null, 0, IntPtr.Zero);
                mciSendString(playCommand, null, 0, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Music Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Stops the background music.
        /// </summary>
        public static void StopMusic()
        {
            string stopCommand = $"stop {currentMusicAlias}";
            string closeCommand = $"close {currentMusicAlias}";

            mciSendString(stopCommand, null, 0, IntPtr.Zero);
            mciSendString(closeCommand, null, 0, IntPtr.Zero);
        }

        /// <summary>
        /// Plays a sound effect once (fire-and-forget).
        /// </summary>
        public static void PlaySoundEffect(Stream resourceStream)
        {
            if (resourceStream == null) return;

            try
            {
                // Unique alias for each SFX to allow concurrent playback
                string sfxAlias = "sfx_" + Guid.NewGuid().ToString("N");
                string tempFile = Path.Combine(Path.GetTempPath(), $"gravityrun_sfx_{Guid.NewGuid()}.wav");

                using (FileStream fileStream = File.Create(tempFile))
                {
                    resourceStream.CopyTo(fileStream);
                }

                // Using mpegvideo here too for consistency
                string openCommand = $"open \"{tempFile}\" type mpegvideo alias {sfxAlias}";
                string playCommand = $"play {sfxAlias}"; // No repeat

                mciSendString(openCommand, null, 0, IntPtr.Zero);
                mciSendString(playCommand, null, 0, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SFX Error: {ex.Message}");
            }
        }
    }
}
