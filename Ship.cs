using System;
namespace CS3110_Module8_Group1
{
    public class Ship
    {
        public int size;
        public char letter;

        public Ship(int size, char letter)
        {
            this.size = size;
            this.letter = letter;
        }
    }
    
    //For AI integration.
    /*
    class Position
    {
        public int x { get; set; } = -1;
        public int y { get; set; } = -1;
    }*/
}

