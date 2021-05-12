using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.DynamicProgramming
{
    public class UniquePathGrid
    {
        public int UniquePathsRec(int m, int n)
        {
            if (m == 1 || n == 1)
                return 1;

            return UniquePathsRec(m, n - 1) + UniquePathsRec(m - 1, n);
        }

        public int UniquePathsDP(int m, int n)
        {
            int[,] dp = new int[m, n];

            for(int i=0;i<m;i++)
            {
                for(int j=0;j<n;j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 1;
                        continue;
                    }

                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1];
        }

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid == null || obstacleGrid.Length == 0 || obstacleGrid[0][0] == 1)
                return 0;

            int[,] grid = new int[obstacleGrid.Length, obstacleGrid[0].Length];

            grid[0, 0] = 1;

            //fill 1 for the zeroth row
            for (int i = 1; i < obstacleGrid[0].Length; i++)
                if (obstacleGrid[0][i] != 1)
                    grid[0, i] = 1;
                else
                    break;

            //fill 1 for 0th column.
            for (int i = 1; i < obstacleGrid.Length; i++)
                if (obstacleGrid[i][0] != 1)
                    grid[i, 0] = 1;
                else
                    break;

            for (int i = 1; i < obstacleGrid.Length; i++)
                for (int j = 1; j < obstacleGrid[0].Length; j++)
                    if (obstacleGrid[i][j] == 1)
                        grid[i, j] = 0;
                    else
                        grid[i, j] = grid[i - 1, j] + grid[i, j - 1];

            return grid[obstacleGrid.Length - 1, obstacleGrid[0].Length - 1];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxPathSum(int[][] grid)
        {
            int[,] dp = new int[grid.Length, grid[0].Length];

            // Add cost of this point in grid plus min cost to reach point i,j from all possible points. 
            // we can reach this point in 2 possible ways i.e. from i-1,j or i,j-1. (down or right) We take max of both.
            // in case i or j == 0 we handle that case in else parts
            for (int i=0;i<grid.Length;i++)
            {
                for(int j=0;j<grid[i].Length;j++)
                {
                    dp[i, j] += grid[i][j];

                    if (i > 0 && j > 0)
                    {
                        dp[i, j] += Math.Max(dp[i - 1,j], dp[i,j - 1]);
                    }
                    //base case for j=0, meaning 0th column, Copy the prev row + current value;
                    else if (i > 0)
                    {
                        dp[i, j] +=  dp[i-1,j];
                    }
                    //base case for i=0, meaning 0th row, Copy the prev col + current value;
                    else if (j > 0)
                    {
                        dp[i, j] += dp[i,j-1];
                    }
                }
            }

            return dp[grid.Length - 1, grid[0].Length - 1];
        }
    }
}
