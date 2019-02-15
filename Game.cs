using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KingsisleTest
{
    class Game
    {
        public static void HighCard()
        {
            //print the main game menu
            Console.Clear();
            String menu =   "[S]tart new game\n" +
                            "[Q]uit to main menu\n";

            Console.SetCursorPosition((Console.WindowWidth - "HIGH CARD".Length) / 2, Console.CursorTop);
            Console.WriteLine("HIGH CARD");

            Console.SetCursorPosition((Console.WindowWidth - "It's High Noon Somewhere!".Length) / 2, Console.CursorTop + 1);
            Console.WriteLine("It's High Noon Somewhere!");

            Console.Write("\n" + menu);

            
            ConsoleKey keyPressed;
            bool leavemenu = false;
            do
            {
                keyPressed = Console.ReadKey(true).Key;

                leavemenu = leavemenu || keyPressed == ConsoleKey.S;
                leavemenu = leavemenu || keyPressed == ConsoleKey.Q;
            } while (!leavemenu);

            bool startGame = (keyPressed != ConsoleKey.Q);

            while (startGame)
            {
                Deck deck = new Deck(Deck.Decks.STANDARD52);
                deck.ShuffleDeck();
                bool victor = false; // which player is the victor, used for draws

                while (!victor)
                {
                    Console.Clear();
                    Console.Write("\n");
                    Thread.Sleep(1000);
                    Console.Write("Player One Draws");
                    for (int i = 0; i < 3; i++) // pause for dramatic effect
                    {
                        Console.Write(".");
                        Thread.Sleep(333);
                    }
                    Card player1Card = deck.DrawTopCard();
                    Console.Write(" a " + player1Card + "!");
                    Console.Write("\n\n");
                    Thread.Sleep(1000);

                    Console.Write("Player Two Draws");
                    for (int i = 0; i < 3; i++) // pause for dramatic effect
                    {
                        Console.Write(".");
                        Thread.Sleep(333);
                    }
                    Card player2Card = deck.DrawTopCard();
                    Console.Write(" a " + player2Card + "!");
                    Console.Write("\n\n");
                    Thread.Sleep(1000);

                    if (player1Card.GetValue() == player2Card.GetValue())
                    {
                        if (deck.IsEmpty())
                        {
                            Console.WriteLine("In all my years, I never thought I'd see the day. We're out of bullets!\n");
                            Console.WriteLine("Sorry partners, but I guess that means none of y'all's the victor!\n");
                            victor = true;
                        }
                        Console.WriteLine("\nWell I'll be! You shot eachother's bullets out of the air!\n\n");
                        Console.WriteLine("I guess it's time to reload and [T]ake another shot, partners...");

                        while (Console.ReadKey(true).Key != ConsoleKey.T) { } // readKey waits, so this isn't a busywait despite how bad it looks
                    }
                    else if (player1Card.GetValue() > player2Card.GetValue())
                    {
                        Console.WriteLine("\nPlayer One was the faster gun!\n");
                        victor = true;
                    }
                    else if (player1Card.GetValue() < player2Card.GetValue())
                    {
                        Console.WriteLine("\nPlayer Two has shot true!\n");
                        victor = true;
                    }
                }

                Console.Write(  "Well, that was some fine shooting y'all! How 'bout a rematch?\n" +
                                    "\n" +
                                    "[O]f course!\n" +
                                    "[N]ah, I ouhgt to get back to the farm");


                leavemenu = false;
                do
                {
                    keyPressed = Console.ReadKey(true).Key;

                    leavemenu = leavemenu || keyPressed == ConsoleKey.O;
                    leavemenu = leavemenu || keyPressed == ConsoleKey.N;
                } while (!leavemenu);

                startGame = (keyPressed != ConsoleKey.N);
                Console.Clear();
            }

            return;
        }
    }
}
