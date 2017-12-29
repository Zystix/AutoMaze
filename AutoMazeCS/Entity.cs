using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMazeCS
{
    class Entity
    {
       public int PrevX;
       public int PrevY;

        public enum Directions { Left, Right, Up, Down };
        public List<Directions> mDirections = new List<Directions>();

        
        public int X;
        public int Y;
    }
}
