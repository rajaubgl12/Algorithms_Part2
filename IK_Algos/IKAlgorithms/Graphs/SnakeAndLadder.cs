using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.Graphs
{
    /// <summary>
    /// https://leetcode.com/problems/snakes-and-ladders/
    /// </summary>
    public class SnakeAndLadder
    {
        public int SnakesAndLadders(int[][] board)
        {
            int n = board.Length;
            var queue = new Queue<int>();
            queue.Enqueue(1);
            HashSet<int> visited = new HashSet<int>();
            int level = 0;
            Dictionary<int, int> storeParentInfo = new Dictionary<int, int>();

            for (int move = 0; queue.Count > 0; move++)
            {
            
                //execute all the child nodes , level by level.
                for (int size = queue.Count; size > 0; size--)
                {
                    int num = queue.Dequeue();
                    
                    if (visited.Contains(num))
                        continue;

                    visited.Add(num);
                    //if(!storeParentInfo.ContainsKey(num))
                    //{
                    //    storeParentInfo.Add(num, -1);
                    //}

                    if (num == n * n)
                    {
                        List<int> shrtsPath = new List<int>();
                        int key = num;
                        shrtsPath.Add(key);
                        for (int i = 0; i < level; i++)
                        {
                            int val = storeParentInfo[key];
                            shrtsPath.Add(val);
                            key = val;
                        }
                         return level;
                    }
                        

                    //Dice rolling numbers
                    for (int i = 1; i <= 6 && num + i <= n * n; i++)
                    {
                        int next = num + i; // this is the number of location
                        int value = GetBoardValue(board, next); // this is the value on the board
                        
                        if (value > 0) // in this locaiton, value is not -1 then there is ladder or snake 
                            next = value; // next location will be the value 
                        
                        if (!visited.Contains(next))
                        {
                            queue.Enqueue(next);
                            if(!storeParentInfo.ContainsKey(next))
                            storeParentInfo.Add(next,num);
                        }
                            
                    }
                }
                //Shortest path level count.
                level++;
            }
            return -1;
        }

        private int GetBoardValue(int[][] board, int num)
        {
            int n = board.Length;
            int r = (num - 1) / n;
            int x = n - 1 - r;
            int y = r % 2 == 0 ? num - 1 - r * n : n + r * n - num; // calculate the y index 
            return board[x][y];
        }
    }
}
