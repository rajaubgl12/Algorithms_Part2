using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms.Stacks_Queues
{
    /// <summary>
    /// https://www.youtube.com/watch?v=TzoDDOj60zE
    /// https://leetcode.com/problems/rotting-oranges/discuss/513582/C-faster-than-90-very-similar-approach-as-numbe-of-islands
    /// </summary>
    public class OrangeRotten
    {
        public int OrangesRotting(int[,] grid)
        {
            bool[,] isVisted = new bool[grid.GetLength(0), grid.GetLength(1)];
            return RottenOrrangeHelper(grid, 0, 0, isVisted);
        }

        private int RottenOrrangeHelper(int[,] grid, int x, int y, bool [,] isVisited)
        {
            if (x >= grid.GetLength(0) || y >= grid.GetLength(1)
                || x < 0 || y < 0)
                return 0;
            
            if(grid[x,y]==1)
            {
                grid[x, y] = 2;
                return 1;
            }

            for (int j = 0; j < grid.GetLength(0); j++)
            {
                for(int i=0;i<grid.GetLength(1);i++)
                {                  
                    

                    if (grid[j, i] == 2)
                    {
                        if (isVisited[j, i])
                            continue;

                        isVisited[j, i] = true;
                        return RottenOrrangeHelper(grid, i, j - 1,isVisited)
                             + RottenOrrangeHelper(grid, i, j + 1,isVisited)
                             + RottenOrrangeHelper(grid, i - 1, j,isVisited)
                             + RottenOrrangeHelper(grid, i + 1, j,isVisited) + 1;
                    }
                }
                
            }

            return -1;
        }
    }
}
