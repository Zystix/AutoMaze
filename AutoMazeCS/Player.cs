﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static AutoMazeCS.Player;

namespace AutoMazeCS
{
    class Player : IDisposable
    {
        // The bot's previous co-ords, used as the spot to spawn child bots when the parent reaches an intersection.
        int PrevX;
        int PrevY;
    
        // the current map
        public static char[,] currentMap = new char[Program.WIDTH, Program.HEIGHT];

        // Directions, used as arguements to decide where to move. Used so a the full code snippet of moving somewhere can be ommited
        public enum Directions { Left, Right, Up, Down };

        // A list of directions that a bot can take at each tick / loop, resets when it moves to a new tile.
        public List<Directions> mDirections = new List<Directions>();

        // The master list of all bots, used to draw all bots at once in DrawMap()
        public static List<Player> mPlayers = new List<Player>();

        // A bots properties: it's icon, X and Y co-ords.
        public char icon;
        public int X;
        public int Y;

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
            Dispose();
            
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
                    Program.map[X, Y - 1] = ',';
                    break;

                case 1:
                    Y--;
                    Program.map[X, Y + 1] = ',';
                    break;

                case 2:
                    X--;
                    Program.map[X + 1, Y] = ',';
                    break;

                case 3:
                    X++;
                    Program.map[X - 1, Y] = ',';
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
            Program.DrawMap();
            mDirections = new List<Directions>();
            Check();
            
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Player() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
