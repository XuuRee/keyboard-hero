using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW03.Utils
{
    public static class ReaderExtensions
    {
        /// <summary>
        /// Contains ReadKeys and Dispose methods from reader.
        /// </summary>
        /// <param name="reader">reader</param>
        public static void PlayGame(this Reader reader)
        {
            reader.ReadKeys();
            reader.Dispose();
        }
    }
}
