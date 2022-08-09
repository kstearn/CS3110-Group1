/*********************************************************
 * GAMEPLAY
 * 
 * CS 3110
 * Group 1 - Kari Tyitye, Katelyn Stearn, Joyce Oldham
 ********************************************************/

using System;

namespace CS3110_Module8_Group1
{
    internal class Game
    {
        private Grid grid;

        //constructor
        public Game()
        {
            grid = new Grid();
        }

        //methods
        internal void Reset()
        {
            Console.Clear();
            grid.Reset();
        }

        internal void Play()
        {
            while (grid.HasShipsLeft)
            {
                grid.Draw();

                string guess = "";
                String letterString, numberString;
                char letter = 'z';
                int number = 0;


                while (guess != "QUIT" && grid.HasShipsLeft)
                {   //get valid guess
                    bool isValid = false;

                    while (!isValid)
                    {
                        Console.WriteLine("\nEnter your guess: (Enter QUIT to quit.) ");
                        
                        guess = Console.ReadLine();

                        if (guess == "QUIT")
                        {
                            break;
                        }

                        letterString = guess.Substring(0, 1);
                        letter = char.Parse(letterString.ToUpper());

                        numberString = guess.Substring(1);

                        if (int.TryParse(numberString, out number))
                        {
                            number = int.Parse(numberString);
                        }

                        //check that guess is within bounds
                        if (Array.IndexOf(grid.alphabet, letter) < grid.size)
                        {
                            if (number > 0 && number < grid.size + 1)
                            {
                                isValid = true;
                                guess = letter + number.ToString();
                            }
                            else
                            {
                                Console.WriteLine("Number not in range. Try again");

                            }
                        }
                        else
                        {
                            Console.WriteLine("Letter not in range. Try again.");
                        }
                    }

                    if (guess != "QUIT")
                    {
                        int rowIndex = Array.IndexOf(grid.alphabet, letter);
                        int columnIndex = number - 1;


                        grid.DropBomb(rowIndex, columnIndex);

                        Console.Clear();

                        grid.Draw();
                    }
                    else
                    {
                        break;
                    }
                }
                if (guess == "QUIT") break;
            }
        }
    }
}
