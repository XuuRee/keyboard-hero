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
            bool paidVersion = IsPaidVersion();
            while (true)
            {
                Console.WriteLine("Write the name of the song that you want the play:");
                string songName = Console.ReadLine();
                try
                { 
                    reader = new Reader(songName, paidVersion);
                    Points = reader.Text.Length;
                    break;
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            reader.Handler += HandlePoints;
            reader.PlayGame();
            Console.WriteLine("End! You get {0} points! (from {1} points)", Points, reader.Text.Length);
            Console.ReadLine();
        }

        /// <summary>
        /// Ask player if he has paid version of keyboard hero.
        /// </summary>
        private bool IsPaidVersion()
        {
            Console.WriteLine("Do you have paid version? [y/n]");
            string version = Console.ReadLine();
            if (version == "y" || version == "yes")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Handle event and check whether player press right key.
        /// </summary>
        /// <param name="reader">reader</param>
        /// <param name="kpea">key position event args</param>
        public void HandlePoints(Reader sender, KeyPositionEventArgs kpea)
        {
            if (kpea.Key == null)
            {
                if (sender.Text[kpea.Position] != ' ')
                {
                    Points -= 1;
                }
            }
            else
            {
                if (sender.Text[kpea.Position] != kpea.Key)
                {
                    Points -= 1;
                }
            }
        }
    }
}
