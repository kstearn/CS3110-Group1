/*********************************************************
 * BATTLESHIP GRID
 * 
 * CS 3110
 * Group 1 - Kari Tyitye, Katelyn Stearn, Joyce Oldham
 *********************************************************/

using System;

namespace BattleshipGame
{
    public class Grid
    {
        public int size = 10;
        private char[,] grid;
        private bool hasShipsLeft;

        public char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private string border = ("--#---#---#---#---#---#---#---#---#---#---#");
        

        //readonly property to return if ships left
        public bool HasShipsLeft
        {
            get
            {
                //assume no ships left
                hasShipsLeft = false;

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (grid[i, j] != '.' &&
                            grid[i, j] != 'H' &&
                            grid[i, j] != 'M')
                        {
                            //set to true if ship found
                            hasShipsLeft = true;
                        }

                    }
                }
                return hasShipsLeft;
            }
        }

        public Grid()
        {
            grid = new char[size, size];
            hasShipsLeft = true;
        }


        public void Reset()
        {
            //set all spaces to empty
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = '.';
                }
            }

            //add ships
            this.PlaceShips();
            hasShipsLeft = true;
        }

        public void PlaceShips()
        {
            //we will create one ship of each size
            //starting with largest size because it is harder to place
            //without overlap
            for (int shipSize = 5; shipSize >= 2; shipSize--)
            {
                //choose letter based on shipSize
                char letter = '.';
                switch (shipSize)
                {
                    case 2:
                        letter = 'P';
                        break;
                    case 3:
                        letter = 'S';
                        break;
                    case 4:
                        letter = 'B';
                        break;
                    case 5:
                        letter = 'A';
                        break;
                }


                //choose random number 1 or 2 for orientation
                Random random = new Random();
                int shipOrientation = random.Next(1, 3);


                //choose random number for starting index
                //the starting index must be <= board size minus ship size
                int startIndex = random.Next(0, (size - shipSize) + 1);


                //if PossiblePlacement is false, choose a new start index
                while (!PossiblePlacement(shipSize, startIndex, shipOrientation))
                {
                    startIndex = random.Next(0, (size - shipSize) + 1);
                }


                //shipOrientation == 1 will be horizontal
                //row will remain the same, iterate through columns
                if (shipOrientation == 1)
                {
                    for (int i = startIndex; i < startIndex + shipSize; i++)
                    {
                        grid[startIndex, i] = letter;
                    }
                }


                //shipOritenation == 2 will be vertical
                //column will remain the same, iterate through rows
                if (shipOrientation == 2)
                {
                    for (int j = startIndex; j < startIndex + shipSize; j++)
                    {
                        grid[j, startIndex] = letter;
                    }
                }
            }
        }


        public bool PossiblePlacement(int shipSize, int startIndex, int direction)
        { 
            //horizontal
            if (direction == 1)
            {
                for (int i = startIndex; i < startIndex + shipSize; i++)
                {
                    //if we encounter a ship, return false for possible placement
                    if (grid[startIndex, i] != '.')
                    {
                        return false;
                    }
                }
                //if ship not encountered, return true
                return true;
            }

            //vertical
            if (direction == 2)
            {
                for (int j = startIndex; j < startIndex + shipSize; j++)
                {
                    //if we encounter a ship, return false for possible placement
                    if (grid[j, startIndex] != '.')
                    {
                        return false;
                    }
                }
                //if ship not encountered, return true
                return true;
            }

            return false;
        }


        public void Draw()
        {
            //numbers for labeling columns
            Console.Write(" "); //space before 1

            if (size > 10)
            {
                for (int i = 1; i < 11; i++)
                {
                    Console.Write(" | " + i);
                }
                for (int i = 11; i <= size; i++)
                {
                    Console.Write("| " + i);
                }
            }
            else
            {
                for (int i = 1; i <= size; i++)
                {
                    Console.Write(" | " + i);
                }
            }
            
            Console.Write("|"); //right border
            Console.WriteLine();

            //top border
            Console.WriteLine(border);
            

            for (int i = 0; i < size; i++)
            {
                //letter label for row
                Console.Write(alphabet[i]);

                for (int j = 0; j < size; j++)
                {

                    switch (grid[i, j])
                    {
                        case 'S':
                            Console.Write(" | "); //border between columns
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write("S");
                            break;
                        case 'P':
                            Console.Write(" | ");
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write("P");
                            break;
                        case 'A':
                            Console.Write(" | ");
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("A");
                            break;
                        case 'B':
                            Console.Write(" | ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("B");
                            break;
                        case 'H': //H for hit
                            Console.Write(" | ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("X");
                            break;
                        case 'M': //M for miss
                            Console.Write(" | ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("X");
                            break;
                        default:
                            Console.Write(" | ");
                            Console.Write(".");
                            break;
                    }

                    Console.ResetColor(); //set color back to default
                }
                Console.WriteLine(" |"); //right border

                //border between rows
                Console.WriteLine(border);

            }
        }

        public void DropBomb(int x, int y)
        {
            //if hit, change letter to H for hit
            if (grid[x, y] != '.')
            {
                grid[x, y] = 'H';
            }
            //if not hit, change to M for miss
            else
            {
                grid[x, y] = 'M';
            }
        }


    }
}

