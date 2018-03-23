using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW03
{
    public class Piano
    {
        public Dictionary<char, Tone> dictionary;

        public Piano()
        {
            this.dictionary = new Dictionary<char, Tone> {};
            this.dictionary.AddRange(CreatePianoList());
        }
        
        public int PlayTone(char key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key].Frequency;
            }
            return 0;
        }

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
