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

        public static void MakeCoolSound(char key)
        {
            SoundPlayer player;
            string path = @"..\..\Sounds\";
            switch (key)
            {
                case 'a':
                    player = new SoundPlayer(path + "piano-a.wav");
                    break;
                case 'd':
                    player = new SoundPlayer(path + "piano-d.wav");
                    break;
                case 'f':
                    player = new SoundPlayer(path + "piano-f.wav");
                    break;
                case 'g':
                    player = new SoundPlayer(path + "piano-g.wav");
                    break;
                case 'h':
                    player = new SoundPlayer(path + "piano-h.wav");
                    break;
                case 'j':
                    player = new SoundPlayer(path + "piano-j.wav");
                    break;
                case 's':
                    player = new SoundPlayer(path + "piano-s.wav");
                    break;
                default:
                    player = new SoundPlayer();
                    break;
            }
            player.Play();
        }
    }
}
