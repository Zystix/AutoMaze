using System;
using System.Collections.Generic;

namespace AutoMazeCS
{
    class Program
    {

        // Determined in the Maze method GenMaze(), randomly generated.
        public static int BotStartX;
        public static int BotStartY;

        public static Maze map; // Used to set the desired maze to solve
        public static int wait; // Used to specify the wait.
            
        // Two pre defined mazes for testing before random generation was implemented.
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
       
        // Draws the map to the screen.
        public static void DrawMap(Maze map)
        {
    
            Player.currentMap= map.maze; 

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

            for (int i = 0; i < map.WIDTH; i++)
            {
                Console.Write("\n");
                for (int u = 0; u < map.HEIGHT; u++)
                {
                    Console.Write(Player.currentMap[u, i]);
                }
            }

        }

        //Entry point of the program

        static void Main(string[] args)
        {
            map = new Maze(20, 20); // Set the map here. the two numbers are used to specify dimensions, WIDTH by HEIGHT.
            wait = 100; // Set the wait between ticks/loops in milliseconds
            
            Player parent = new Player(BotStartX, BotStartY); // Set the start coordinates of the parent bot.
            Player.mPlayers.Add(parent); // Adds the parent to the Master list.

            DrawMap(map); // Draws the map to the screen for the first time
                         //parent.Check(); // Starts the parent bots loop.

            Console.Read();
        }
    }
}
