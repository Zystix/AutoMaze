using System;
using System.Collections.Generic;

namespace AutoMazeCS
{
    class Program
    {

        // Dimenstions of the maps. Used in DrawMap()
       public const int WIDTH = 20;
       public const int HEIGHT = 20;

        public static char[,] map = new char[HEIGHT, WIDTH]; // Used to set the desired maze to solve
        public static int wait; // Used to specify the wait.

         public static char[,] map1 = new char[8, 8]
        {
            {'#','#','#','#','#','#','#','#'},
            {'#',' ',' ',' ',' ','#','$','#' },
            {'#',' ','#',' ',' ',' ',' ','#' },
            {'#',' ','#','#','#',' ',' ','#' },
            {'#',' ',' ',' ',' ','#',' ','#' },
            {'#',' ','#',' ',' ',' ',' ','#' },
            {'#',' ','#',' ','#',' ','#','#' },
            {'#','#','#','#','#','#','#','#' }

        };

        public static char[,] map2 = new char[20, 20]
        {
            {'#', '#', '#', '#', '#', '#', '#', '#','#', '#', '#', '#','#', '#', '#', '#','#', '#', '#', '#' },
            {'#', '#', ' ', '#', '$', ' ', ' ', ' ',' ', '#', ' ', ' ',' ', ' ', ' ', '#',' ', ' ', ' ', '#' },
            {'#', ' ', ' ', '#', '#', '#', ' ', ' ',' ', '#', ' ', '#','#', '#', ' ', '#',' ', '#', ' ', '#' },
            {'#', ' ', '#', ' ', ' ', ' ', '#', ' ',' ', '#', ' ', ' ',' ', '#', ' ', '#',' ', '#', ' ', '#' },
            {'#', ' ', ' ', ' ', '#', ' ', '#', ' ','#', '#', '#', '#',' ', '#', ' ', '#',' ', '#', ' ', '#' },
            {'#', '#', '#', '#', '#', ' ', '#', ' ',' ', ' ', ' ', ' ',' ', '#', ' ', '#',' ', '#', ' ', '#' },
            {'#', ' ', ' ', ' ', ' ', ' ', '#', '#','#', '#', '#', '#',' ', '#', ' ', '#',' ', '#', ' ', '#' },
            {'#', ' ', '#', ' ', '#', '#', '#', '#',' ', '#', ' ', '#',' ', '#', ' ', '#',' ', '#', ' ', '#' },
            {'#', ' ', '#', ' ', '#', ' ', ' ', ' ',' ', '#', ' ', '#',' ', '#', ' ', '#',' ', '#', ' ', '#' },
            {'#', ' ', '#', ' ', '#', ' ', '#', '#','#', '#', ' ', ' ',' ', '#', ' ', '#',' ', '#', ' ', '#' },
            {'#', ' ', '#', ' ', '#', ' ', ' ', ' ',' ', '#', ' ', ' ',' ', ' ', ' ', ' ',' ', '#', ' ', '#' },
            {'#', ' ', '#', ' ', '#', '#', '#', '#',' ', '#', '#', '#','#', '#', '#', '#','#', '#', ' ', '#' },
            {'#', ' ', '#', ' ', ' ', ' ', ' ', ' ',' ', '#', ' ', ' ',' ', ' ', ' ', ' ',' ', ' ', ' ', '#' },
            {'#', ' ', '#', '#', '#', '#', '#', '#','#', '#', ' ', '#','#', '#', '#', '#','#', '#', '#', '#' },
            {'#', ' ', ' ', ' ', '#', '#', '#', '#','#', '#', ' ', ' ',' ', ' ', ' ', ' ','#', '#', '#', '#' },
            {'#', '#', '#', ' ', '#', ' ', ' ', ' ','#', '#', '#', '#','#', '#', '#', ' ',' ', '#', '#', '#' },
            {'#', '#', ' ', ' ', '#', ' ', '#', ' ','#', '#', '#', '#',' ', ' ', ' ', '#',' ', ' ', ' ', '#' },
            {'#', '#', ' ', '#', '#', ' ', '#', ' ',' ', ' ', ' ', '#',' ', '#', ' ', '#','#', '#', ' ', '#' },
            {'#', '#', ' ', ' ', ' ', ' ', '#', '#','#', '#', ' ', ' ',' ', '#', ' ', ' ',' ', ' ', ' ', '#' },
            {'#', '#', '#', '#', '#', '#', '#', '#','#', '#', '#', '#','#', '#', '#', '#','#', '#', '#', '#' }

        };
       

        public static void DrawMap()
        {
            //sets current map to whichever map is selected in Main()

            for (int i = 0; i < HEIGHT; i++)
            {
                for (int u = 0; u < WIDTH; u++)
                {
                    Player.currentMap[u, i] = map[u, i]; 
                }
            }

            // assigns every bot's icon to the map array at tis location. 
            // Also takes care of bug where if a bot died on a comma it would freak out.

            foreach (var player in Player.mPlayers)
            {
                if (Player.currentMap[player.X, player.Y] == ',')
                {
                    Player.currentMap[player.X, player.Y] = ' ';
                }
                else
                Player.currentMap[player.X, player.Y] = player.icon;
            }

            //Draws the map

            for (int i = 0; i < HEIGHT; i++)
            {
                Console.Write("\n");
                for (int u = 0; u < WIDTH; u++)
                {
                    Console.Write(Player.currentMap[u, i]);
                }
            }

        }

        //Entry point of the program

        static void Main(string[] args)
        {
            map = map2; // Set the map here.
            wait = 100; // Set the wait between ticks/loops in milliseconds

            Player parent = new Player(1, 2); // Set the start coordinates of the parent bot.
            Player.mPlayers.Add(parent); // Adds the parent to the Master list.

            DrawMap(); // Draws the map to the screen for the first time
            parent.Check(); // Starts the parant bots loop.

            Console.ReadLine();
        }
    }
}
