using System;
using System.Media;
using System.Threading;

namespace PV178.Homeworks.HW03.Utils
{
    /// <summary>
    /// Class for making sound in other thread.
    /// </summary>
    public static class Sounder
    {
        /// <summary>
        /// Makes sound with given frequency and duration.
        /// </summary>
        /// <param name="frequency">frequency</param>
        /// <param name="duration">duration</param>
        public static void MakeSound(int frequency, int duration = 300)
        {
            ThreadPool.QueueUserWorkItem(state =>
                Console.Beep(frequency, duration));
        }

        /// <summary>
        /// Makes sound with given .wav file.
        /// </summary>
        /// <param name="key">key</param>
        public static void MakeCoolSound(char key)
        {
            string path = @"..\..\Sounds\";
            SoundPlayer player = ChoosePianoTone(key, path);
            player.Play();
        }

        /// <summary>
        /// Choose piano tone with given key.
        /// </summary>
        /// <param name="key">key</param>
        /// /// <param name="path">path</param>
        private static SoundPlayer ChoosePianoTone(char key, string path)
        {
            switch (key)
            {
                case 'a':
                    return new SoundPlayer(path + "piano-a.wav");
                case 'd':
                    return new SoundPlayer(path + "piano-d.wav");
                case 'f':
                    return new SoundPlayer(path + "piano-f.wav");
                case 'g':
                    return new SoundPlayer(path + "piano-g.wav");
                case 'h':
                    return new SoundPlayer(path + "piano-h.wav");
                case 'j':
                    return new SoundPlayer(path + "piano-j.wav");
                case 's':
                    return new SoundPlayer(path + "piano-s.wav");
                default:
                    return new SoundPlayer();
            }
        }
    }
}
