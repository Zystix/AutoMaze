using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static AutoMazeCS.Player;

namespace AutoMazeCS
{
    class Player : IDisposable
    {
        int PrevX;
        int PrevY;
    
        public static char[,] currentMap = new char[Program.WIDTH, Program.HEIGHT];

        public enum Directions { Left, Right, Up, Down };

        public List<Directions> mDirections = new List<Directions>();

        public static List<Player> mPlayers = new List<Player>();

        public char icon;
        public int X;
        public int Y;

        public void Win()
        {
            Console.Write("\n");
            Console.WriteLine("SOLVED");
            Console.Read();
        }

        public Player(int x, int y, char icon = '@')
        {
            X = x;
            Y = y;
            this.icon = icon;
        }

        public void Check()
        {
            Thread.Sleep(1000);
          
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

        public void Die()
        {
            icon = ',';
            mPlayers.Remove(this);
            this.Dispose();
            
        }

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
                    Program.map2[X, Y - 1] = ',';
                    break;

                case 1:
                    Y--;
                    Program.map2[X, Y + 1] = ',';
                    break;

                case 2:
                    X--;
                    Program.map2[X + 1, Y] = ',';
                    break;

                case 3:
                    X++;
                    Program.map2[X - 1, Y] = ',';
                    break;
            }


            

            if (mDirections.Count > 1)
            {
                for (int i = 1; i < mDirections.Count; i++)
                {
                    if (mPlayers.Count > 4)
                    {
                        mPlayers.RemoveAt(0);

                    }
                    else
                    {

                        Player player = new Player(PrevX, PrevY);
                        mPlayers.Add(player);
                        player.Move(mDirections[i]);
                    }
                }

            }
            
            Console.Clear();
            Program.DrawMap(Program.map2);
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
