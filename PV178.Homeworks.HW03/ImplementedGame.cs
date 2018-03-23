using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PV178.Homeworks.HW03.Utils;

namespace PV178.Homeworks.HW03
{
    class ImplementedGame : IGame
    {
        private int Points { get; set; }

        public void Start()
        {
            Reader reader;
            Console.WriteLine("Welcome to the game FI Keyboard Hero!");
            while (true)
            {
                Console.WriteLine("Write the name of the song that you want the play: ");
                string songName = Console.ReadLine();
                try
                { 
                    reader = new Reader(songName);
                    break;
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            this.Points = reader.Text.Length;
            reader.Handler += HandlePoints;
            reader.ReadKeys();
            reader.Dispose();
            Console.WriteLine("End! Your points: {0}", this.Points);
            Console.ReadLine();
        }

        public void HandlePoints(Reader sender, KeyPositionEventArgs kpea)
        {
            if (kpea.key == null)
            {
                if (sender.Text[kpea.position] != ' ')
                {
                    Points -= 1;
                }
            }
            else
            {
                if (sender.Text[kpea.position] != kpea.key)
                {
                    Points -= 1;
                }
            }
        }
    }
}
