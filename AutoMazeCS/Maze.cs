using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMazeCS
{
    class Maze
    {
        public int HEIGHT;
        public int WIDTH;
        public char[,] maze;

        public int totalTiles;

        public static char[] alphabet = 
            { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        public Maze(int H, int W)
        {
            HEIGHT = H;
            WIDTH = W;

            totalTiles = HEIGHT * WIDTH;

            maze = GenMaz();
        }

        public char[,] GenMaz()
        {
            char[,] gmaze = new char[WIDTH, HEIGHT];
            int wallSpace = ((WIDTH * 2) + (HEIGHT * 2)) - 2;
            Random random = new Random();

            for (int i = 0; i < WIDTH; i++)
            {
                gmaze[i, 0] = '#';
                gmaze[i, HEIGHT - 1] = '#';
            }
            for (int u = 1; u < HEIGHT; u++)
            {
                    gmaze[0, u] = '#';
                    gmaze[WIDTH - 1, u] = '#';
            }

            Program.BotStartX = random.Next(1, WIDTH - 1);
            Program.BotStartY = random.Next(1, HEIGHT - 1);

            int FX = random.Next(1, WIDTH - 1);
            int FY = random.Next(1, HEIGHT - 1);

            gmaze[FX, FY] = '$';

            int alphaCounter = 0;
            for (int i = 0; i < WIDTH; i++)
            {
                for (int u = 0; u < HEIGHT; u++)
                { 
                    
                    if (gmaze[i, u] != '#' && gmaze[i, u] != '@' && gmaze[i, u] != '$')
                    {
                        //gmaze[i, u] = alphabet[random.Next(0,26)];
                        gmaze[i, u] = alphabet[alphaCounter];

                        if (alphaCounter == 25)
                        {
                            alphaCounter = 0;
                        }
                        else
                        {
                            alphaCounter++;
                        }
                    }   
                }
            }

            foreach (var tile in gmaze)
            {
                if (tile != '#' && tile != '@' && tile != '$')
                {

                }
            }

            for (int i = 0; i < WIDTH; i++)
            {
                for (int u = 0; u < HEIGHT; u++)
                {
                    if (gmaze[i, u] != '#' && gmaze[i, u] != '@' && gmaze[i, u] != '$' && gmaze[i, u] != ' ')
                    {
                        gmaze[i, u] = '#';
                    }
                }
            }
                                        
            return gmaze;

        }


        
    }
}
