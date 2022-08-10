using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipGame;
//Here is the Class called Enemy Grid to display a second grid
namespace BattleshipGame
{
    internal class EnemyGrid
    {

        public int size = 10;
        private char[,] enemyGrid;
        private Ship[] ships;
        private bool hasEnemyShipsLeft;

        public char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private string border = ("--#---#---#---#---#---#---#---#---#---#---#");


        //readonly property to return if ships left
        public bool HasEnemyShipsLeft
        {
            get
            {
                //assume no ships left
                hasEnemyShipsLeft = false;

                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (enemyGrid[i, j] != '.' &&
                            enemyGrid[i, j] != 'H' &&
                            enemyGrid[i, j] != 'M')
                        {
                            //set to true if ship found
                            hasEnemyShipsLeft = true;
                        }

                    }
                }
                return hasEnemyShipsLeft;
            }
        }
        public EnemyGrid()
        {
            enemyGrid = new char[size, size];
            hasEnemyShipsLeft = true;

            //initialize ships
            ships = new Ship[]
            {
                new Ship(5, 'A'), //aircraft carrier
                new Ship(4, 'B'), //battleship
                new Ship(3, 'C'), //cruiser
                new Ship(3, 'S'), //submarine
                new Ship(2, 'D')  //destroyer
            };
        }

        public void Reset()
        {
            //set all spaces to empty
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    enemyGrid[i, j] = '.';
                }
            }

            //add ships
            this.PlaceShips();
            hasEnemyShipsLeft = true;
        }

        public void PlaceShips()
        {
            //we will create one ship of each size
            //starting with largest size because it is harder to place
            //without overlap

            foreach (Ship ship in ships)
            {
                //choose random number 1 or 2 for orientation
                Random random = new Random();
                int shipOrientation = random.Next(1, 3);


                //choose random number for starting index
                //the starting index must be <= board size minus ship size
                int startIndex = random.Next(0, (size - ship.size) + 1);


                //if PossiblePlacement is false, choose a new start index
                while (!PossiblePlacement(ship.size, startIndex, shipOrientation))
                {
                    startIndex = random.Next(0, (size - ship.size) + 1);
                }


                //shipOrientation == 1 will be horizontal
                //row will remain the same, iterate through columns
                if (shipOrientation == 1)
                {
                    for (int i = startIndex; i < startIndex + ship.size; i++)
                    {
                        enemyGrid[startIndex, i] = ship.letter;
                    }
                }


                //shipOrientation == 2 will be vertical
                //column will remain the same, iterate through rows
                if (shipOrientation == 2)
                {
                    for (int j = startIndex; j < startIndex + ship.size; j++)
                    {
                        enemyGrid[j, startIndex] = ship.letter;
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
                    if (enemyGrid[startIndex, i] != '.')
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
                    if (enemyGrid[j, startIndex] != '.')
                    {
                        return false;
                    }
                }
                //if ship not encountered, return true
                return true;
            }

            return false;
        }

//I'm trying to change the placement of the second grid but still a work in progress
        public void Draw2()
        {
            //numbers for labeling columns
            Console.WriteLine("\n");
            Console.WriteLine("   Enemy Player   ");
            Console.Write(" "); //space before 1

            for (int j = 1; j <= 10; j++)
            {
                Console.Write(" | " + j);
            }


            Console.Write("|"); //right border
            Console.WriteLine();

            //top border
            Console.WriteLine(border);


            for (int j = 0; j < 10; j++)
            {
                //letter label for row
                Console.Write(alphabet[j]);

                for (int i = 0; i < 10; i++)
                {

                    switch (enemyGrid[i, j])
                    {
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
            if (enemyGrid[x, y] != '.')
            {
                enemyGrid[x, y] = 'H';
            }
            //if not hit, change to M for miss
            else
            {
                enemyGrid[x, y] = 'M';
            }
        }

    }
}
    
