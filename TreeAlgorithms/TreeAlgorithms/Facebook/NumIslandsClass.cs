using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms.Facebook
{
   public class NumIslandsClass
    {


        #region DFS

        int countNumIslands = 0;
        public int NumIslands(int[,] grid)
        {
            bool[,] isVisited = new bool[grid.GetLength(0), grid.GetLength(1)];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 1 && !isVisited[i, j])
                    {
                        countNumIslands++;
                        NumIslandsHelper(grid, i, j, isVisited);
                    }
                }
            }

            return countNumIslands;
        }

        private void NumIslandsHelper(int[,] grid, int x, int y, bool[,] isVisited)
        {
            //base condition
            if (x < 0 || y < 0 
                || x >= grid.GetLength(0) 
                || y >= grid.GetLength(1)
                || grid[x, y] == 0
                || isVisited[x, y])
            {
                return;
            }


            isVisited[x, y] = true;

            NumIslandsHelper(grid, x + 1, y, isVisited);
            NumIslandsHelper(grid, x - 1, y, isVisited);
            NumIslandsHelper(grid, x, y + 1, isVisited);
            NumIslandsHelper(grid, x, y - 1, isVisited);

        }

        #endregion

        #region BFS

        public int NumIslandsBFS(int[,] grid)
        {
            bool[,] isVisited = new bool[grid.GetLength(0), grid.GetLength(1)];
            int countBfs = 0;
            for(int i =0;i<grid.GetLength(0);i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if(grid[i,j]==1 && !isVisited[i,j])
                    {
                        
                        NumIslandsBFSHelper(grid, i, j,isVisited);
                        countBfs++;
                    }
                    
                }
            }

            return countBfs;

        }

        private void NumIslandsBFSHelper(int[,] grid, int i, int j, bool[,] isVisited)
        {
           
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[2] { i, j });
            isVisited[i, j] = true;

            //duplicate instead of isvisited you can also make value of grid to zero
            grid[i, j] = 0;

            while (queue.Count > 0)
            {
                int[] neibours = queue.Dequeue();
                int x = neibours[0];
                int y = neibours[1];

                if (x + 1 < grid.GetLength(0) && !isVisited[x + 1, y] && grid[x + 1, y] == 1)
                {
                    isVisited[x + 1, y] = true;
                    grid[x + 1, y] = 0;
                    queue.Enqueue(new int[] { x + 1, y });
                }

                if (x - 1 > -1 && !isVisited[x - 1, y] && grid[x - 1, y] == 1)
                {
                    isVisited[x - 1, y] = true;
                    grid[x - 1, y] = 0;
                    queue.Enqueue(new int[] { x - 1, y });
                }
                if (y + 1 < grid.GetLength(1) && !isVisited[x, y + 1] && grid[x, y + 1] == 1)
                {
                    isVisited[x, y + 1] = true;
                    grid[x, y + 1] = 0;
                    queue.Enqueue(new int[] { x, y + 1 });
                }

                if (y - 1 > -1 && !isVisited[x, y - 1] && grid[x, y - 1] == 1)
                {
                    isVisited[x, y - 1] = true;
                    grid[x, y - 1] = 0;
                    queue.Enqueue(new int[] { x, y - 1 });
                }

            }
        }

        #endregion

    }
}
