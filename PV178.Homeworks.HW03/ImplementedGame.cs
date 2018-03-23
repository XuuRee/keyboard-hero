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
            reader.ReadKeys();
            reader.Handler += HandleSomethingHappening;
            reader.Dispose();
            Console.WriteLine("End! Your points: {0}", reader.points);
            Console.ReadLine();
        }

        public void HandleSomethingHappening(object sender, EventArgs e)
        {
            Console.WriteLine("Something happened!");
        }
    }
}
