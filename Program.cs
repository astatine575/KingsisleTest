using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsisleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            bool quitToDesktop = false;
            while (!quitToDesktop)
            {
                Console.Clear();

                Console.SetCursorPosition((Console.WindowWidth - "Astatine's Card Games".Length) / 2, Console.CursorTop);
                Console.WriteLine("Astatine's Card Games");

                Console.SetCursorPosition((Console.WindowWidth - "As many games as Riot Games!".Length) / 2, Console.CursorTop + 1);
                Console.WriteLine("As many games as Riot Games!");

                String menu = "[H]igh Card\n" +
                                "[Q]uit to desktop\n";

                Console.Write("\n" + menu);


                ConsoleKey keyPressed;
                bool leavemenu = false;
                do
                {
                    keyPressed = Console.ReadKey(true).Key;

                    leavemenu = leavemenu || keyPressed == ConsoleKey.H;
                    leavemenu = leavemenu || keyPressed == ConsoleKey.Q;
                } while (!leavemenu);

                if (keyPressed == ConsoleKey.Q)
                {
                    quitToDesktop = true;
                }

                if (keyPressed == ConsoleKey.H)
                {
                    Game.HighCard();
                }
            }
        }
    }
}
