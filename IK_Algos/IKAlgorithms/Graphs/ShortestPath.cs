using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;
using System.Text;

namespace IK_Algorithms.Graphs
{
    /// <summary>
    /// https://leetcode.com/problems/shortest-path-in-binary-matrix/discuss/1057244/Easy-C-solution-(BFS)
    /// </summary>
    public class ShortestPath
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ShortestPathBinaryMatrix(int[][] grid)
        {

            //firstly check first and last gates are open
            if (grid[0][0] == 1)
                return -1;

            if (grid[grid.Length - 1][grid.Length - 1] == 1)
                return -1;


            Queue<(int, int)> queue = new Queue<(int, int)>();

            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            int[,] coordPaths = new int[,] { {1,0}, { -1, 0 } , { 0, 1 } , { 0, -1 } , { 1, 1 } , { -1, -1 }, { -1, 1 }, { 1, -1 } };
            //initialize the level
            int level = 1;

            queue.Enqueue((0, 0));

            visited.Add((0,0)); 

            while (queue.Count>0)
            {

                int queueCount = queue.Count;                

                for (int i=0;i<queueCount;i++)
                {

                    var coord = queue.Dequeue();

                    int x = coord.Item1;
                    int y = coord.Item2;
                    //visited.Add((x, y));

                    if (x == grid.Length - 1 && y == grid.Length - 1)
                        return level;

                    //get the neighbours
                    for (int j = 0; j < coordPaths.GetUpperBound(0); j++)
                    {
                        int x1 = x + coordPaths[j, 0];
                        int y1 = y + coordPaths[j, 1];

                        // have a filter condition.
                        if (x1 >= 0 && y1 >= 0 && x1 < grid.Length && y1 < grid.Length
                            && (grid[x1][y1] == 0) && !visited.Contains((x1, y1)))
                        {
                            visited.Add((x1, y1));
                            queue.Enqueue((x1, y1));
                        }
                    }                   

                }
                // We'll now be processing all nodes at current_distance + 1
                level++;

            }

            return -1;

        }

    }
}
