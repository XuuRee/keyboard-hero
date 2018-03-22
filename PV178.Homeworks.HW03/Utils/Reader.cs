using System;
using System.IO;
using System.Threading;

namespace PV178.Homeworks.HW03.Utils
{
    /// <summary>
    /// Class responsible for reading songs from textfiles and handling user input.
    /// </summary>
    public class Reader : IDisposable
    {
        public string Text { get; set; }

        private const int Timeout = 300;
        private readonly Displayer displayer = new Displayer();

        private AutoResetEvent trackDone;
        private Thread checkingThread;
        private Thread gettingThread;
        private char? input;
        private bool end;

        public Reader(string songName)
        {
            if (File.Exists(@"..\..\Songs\" + songName + ".txt"))
            {
                Text = File.ReadAllText(@"..\..\Songs\" + songName + ".txt");
                trackDone = new AutoResetEvent(false);
                checkingThread = new Thread(CheckInput) { IsBackground = true };
                gettingThread = new Thread(GetInput) { IsBackground = true };
            }
            else
            {
                throw new ArgumentException("Wrong song path");
            }
        }

        /// <summary>
        /// Starts reading keys and checking whether user pressed some.
        /// </summary>
        public void ReadKeys()
        {
            gettingThread.Start();
            checkingThread.Start();
            trackDone.WaitOne();
        }

        /// <summary>
        /// Performs cleanup.
        /// </summary>
        public void Dispose()
        {
            end = true;
            trackDone.Dispose();
            Console.Clear();
        }

        /// <summary>
        /// Invokes event that says which key was pressed and what is actual reading position.
        /// </summary>
        /// <param name="key">pressed key</param>
        /// <param name="position">actual reading position</param>
        protected virtual void OnKeyPressed(char key, int position)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Invokes event that says no key was pressed and what is actual reading position.
        /// </summary>
        /// <param name="position">actual reading position</param>
        protected virtual void OnKeyNotPressed(int position)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Periodically checks if some key was pressed.
        /// </summary>
        private void CheckInput()
        {
            for (var i = -6; i < Text.Length; i++)
            {
                displayer.ActualDisplay(Text, i + 6);
                Thread.Sleep(Timeout);
                // First chars just skip (because animation)
                if (i < 0)
                {
                    continue;
                }
                if (input != null)
                {
                    OnKeyPressed((char)input, i);
                    input = null;
                }
                else
                {
                    OnKeyNotPressed(i);
                }
            }
            trackDone.Set();
        }

        /// <summary>
        /// Gets input from the user.
        /// </summary>
        private void GetInput()
        {
            while (true)
            {
                input = Console.ReadKey(true).KeyChar;
                if (input != null && !end)
                {
                    Sounder.MakeSound(400);
                }
            }
        }
    }
}
