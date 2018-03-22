using System;
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
    }
}
