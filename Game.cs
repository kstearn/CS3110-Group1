/*********************************************************
 * GAMEPLAY
 * 
 * CS 3110
 * Group 1 - Kari Tyitye, Katelyn Stearn, Joyce Oldham
 ********************************************************/
//I've updated the Game class to include the Enemy Grid to be played
using System;

namespace CS3110_Module8_Group1
{
    internal class Game
    {
        private Grid grid;
        enemyGrid = new EnemyGrid();// calling new class for enemy grid

        //constructor
        public Game()
        {
            grid = new Grid();
            private EnemyGrid enemyGrid;
        }

        //methods
        internal void Reset()
        {
            Console.Clear();
            grid.Reset();
            enemyGrid.Reset();//once player makes a move, the grid resets. leter it will show what moves the AI made
        }

        internal void Play()
        {
            while (grid.HasShipsLeft)
            {
                grid.Draw();
                enemyGrid.Draw2();//calling the enemy grid method to display

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
                        enemyGrid.Draw2();
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
