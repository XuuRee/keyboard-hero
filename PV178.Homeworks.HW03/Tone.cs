using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW03
{
    /// <summary>
    /// Represents tone with name and frequency.
    /// </summary>
    public struct Tone
    {
        public string Name { get; set; }
        public int Frequency { get; set; }
        
        public Tone(string name, int frequency)
        {
            this.Name = name;
            this.Frequency = frequency;
        }

        public override String ToString()
        {
            return Name + " (" + Frequency + " Hz)";
        }
    }
}
