using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW03
{
    /// <summary>
    /// Represents piano with stored tones.
    /// </summary>
    public class Piano
    {
        public Dictionary<char, Tone> PianoDict { get; set; }

        public Piano()
        {
            this.PianoDict = new Dictionary<char, Tone> {};
            this.PianoDict.AddRange(CreatePianoList());
        }

        /// <summary>
        /// Play tone that corresponds with given key.
        /// </summary>
        /// <param name="key">keyboard key</param>
        public int PlayTone(char key)
        {
            if (PianoDict.ContainsKey(key))
            {
                return PianoDict[key].Frequency;
            }
            return 37;      // Console.Beep = 37 až 32767 Hz
        }

        /// <summary>
        /// Create list with given keys and tones.
        /// </summary>
        private List<KeyValuePair<char, Tone>> CreatePianoList()
        {
            var list = new List<KeyValuePair<char, Tone>>()
            {
                new KeyValuePair<char, Tone>('a', new Tone("C", 261)),
                new KeyValuePair<char, Tone>('s', new Tone("D", 293)),
                new KeyValuePair<char, Tone>('d', new Tone("E", 330)),
                new KeyValuePair<char, Tone>('f', new Tone("F", 349)),
                new KeyValuePair<char, Tone>('g', new Tone("G", 392)),
                new KeyValuePair<char, Tone>('h', new Tone("A", 440)),
                new KeyValuePair<char, Tone>('j', new Tone("H", 494))
            };
            return list;
        }
    }
}
