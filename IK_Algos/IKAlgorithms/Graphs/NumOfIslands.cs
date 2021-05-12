using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.Graphs
{
    /// <summary>
    /// https://leetcode.com/problems/number-of-islands/
    /// </summary>
    public class NumOfIslands
    {
        public int NumIslands(char[,] grid)
        {
            bool[,] isVisited = new bool[grid.Length, grid.Length];

            int numOfIsland = 0;

            for(int i=0;i<grid.GetLength(0);i++)
            {
                for(int j=0;j<grid.GetLength(1);j++)
                {
                    if(grid[i,j]=='1' && !isVisited[i,j])
                    {                        
                        DFSIsland(grid, isVisited, i, j);
                        numOfIsland++;
                    }
                }
            }

            return numOfIsland;
        }

        private void DFSIsland(char[,] grid, bool[,] isVisited, int i, int j)
        {
            if (i >= 0 && j >= 0
                && i < grid.GetLength(0)
                && j < grid.GetLength(1)
                && grid[i,j]=='1'
                && !isVisited[i, j])
            {
                isVisited[i, j] = true;
                DFSIsland(grid, isVisited, i + 1, j);
                DFSIsland(grid, isVisited, i - 1, j);
                DFSIsland(grid, isVisited, i, j + 1);
                DFSIsland(grid, isVisited, i, j - 1);
            }

        }
    }
}
