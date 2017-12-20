using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMazeCS
{
    class Maze
    {
        int HEIGHT;
        int WIDTH;

        int FinishX;
        int FinishY;

        int StartX;
        int StartY;

        public char[,] maze;

        public Maze(int H, int W, int FX, int FY, int SY, int SX)
        {
            HEIGHT = H;
            WIDTH = W;

            FinishX = FX;
            FinishY = FY;

            StartX = SX;
            StartY = SY;

            maze = GenMaz();
        }

        public char[,] GenMaz()
        {
            char[,] gmaze = new char[HEIGHT, WIDTH];
            gmaze[StartX, StartY] = '@';
            gmaze[FinishX, FinishY] = '$';

     
            return gmaze;

        }
        
    }
}
