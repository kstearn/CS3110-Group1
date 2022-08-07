/***************************************************************
 * MAIN PROGRAM
 * 
 * CS 3110
 * Group 1 - Kari Tyitye, Katelyn Stearn, Joyce Oldham
 **************************************************************/

using System;

namespace BattleshipGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            ConsoleKeyInfo response;
            do
            {
                game.Reset();
                game.Play();

                Console.WriteLine("Do you want to play again (y/n)");
                response = Console.ReadKey();

            } while (response.Key == ConsoleKey.Y);

        }
    }
}
