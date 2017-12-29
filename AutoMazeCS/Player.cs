using System;
using System.Collections.Generic;
using System.Threading;

namespace AutoMazeCS
{
    class Player : Entity
    {

        public char icon;

        // the current map
        public static char[,] currentMap;

        // The master list of all bots, used to draw all bots at once in DrawMap()
        public static List<Player> mPlayers = new List<Player>();

        // If a bot reaches the '$', this paues the simulation and prints Solved to the screen.
        public void Win()
        {
            Console.Write("\n");
            Console.WriteLine("SOLVED");
            Console.Read();
        }

        // The bot constructer.
        public Player(int x, int y, char icon = '@')
        {
            X = x;
            Y = y;
            this.icon = icon;
        }

        // Checks where the bot can move, adding all possible directions to mDirections, and dieing if theres no options.
        public void Check()
        {
            Thread.Sleep(Program.wait);
          
            if ((currentMap[X, Y + 1] != '#') && (currentMap[X, Y + 1] != ','))
            {
                if (currentMap[X, Y + 1] == '$')
                {
                    Win();
                }
                
                mDirections.Add(Directions.Up);
              
            }
            if ((currentMap[X, Y - 1] != '#') && (currentMap[X, Y - 1] != ','))
            {
                if (currentMap[X, Y - 1] == '$')
                {
                    Win();
                }

                mDirections.Add(Directions.Down);
                
            }
            if ((currentMap[X - 1, Y] != '#') && (currentMap[X - 1, Y] != ','))
            {
                if (currentMap[X - 1, Y] == '$')
                {
                    Win();
                }

                mDirections.Add(Directions.Left);
                
            }
            if ((currentMap[X + 1, Y] != '#') && (currentMap[X + 1, Y] != ','))
            {
                if (currentMap[X + 1, Y] == '$')
                {
                    Win();
                }

                mDirections.Add(Directions.Right);
                
            }

            if (mDirections.Count == 0)
            {
                Die();
            }

            else
            Act();

        }
     
        // If there is only one direction to go, it moves, or it sets prev co-ords to spawn bots at then moves
        void Act()
        {
            if (mDirections.Count > 1)
            {
                PrevX = X;
                PrevY = Y;
                Move(mDirections[0]);
            }
            else
            {
                Move(mDirections[0]);
            }
        }

        // More or less kills the bots.
        public void Die()
        {
            icon = ',';
            mPlayers.Remove(this);
            
            
        }

        // Actaully moves the bots by altering its X and Y co-ords, and leaving commas where it already has been.
        // When a bot has moved, it spawns a bot if it has to.
        // Then clears the screen, draws the map again and begins the loop again.
        public void Move(Directions dir)
        {
  
            int d = 0;
            if (dir == Directions.Up) { d = 0; }
            else if (dir == Directions.Down) { d = 1; }
            else if (dir == Directions.Left) { d = 2; }
            else if (dir == Directions.Right) { d = 3; }

            switch (d)
            {
                case 0:
                    Y++;
                    Program.map.maze[X, Y - 1] = ',';
                    break;

                case 1:
                    Y--;
                    Program.map.maze[X, Y + 1] = ',';
                    break;

                case 2:
                    X--;
                    Program.map.maze[X + 1, Y] = ',';
                    break;

                case 3:
                    X++;
                    Program.map.maze[X - 1, Y] = ',';
                    break;
            }

            if (mDirections.Count > 1)
            {
                for (int i = 1; i < mDirections.Count; i++)
                {
                    if (mPlayers.Count > 4)
                    {
                        mPlayers.RemoveAt(3);
                    }
                    
                    Player player = new Player(PrevX, PrevY);
                    mPlayers.Add(player);
                    player.Move(mDirections[i]);
                    
                }

            }
            
            Console.Clear();
            Program.DrawMap(Program.map);
            mDirections = new List<Directions>();
            Check();
            
        }

    }
}
