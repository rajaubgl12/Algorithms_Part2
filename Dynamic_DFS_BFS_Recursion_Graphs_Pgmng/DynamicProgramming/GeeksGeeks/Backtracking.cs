using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProramming.GeeksGeeks
{
    /// <summary>
    /// permutations
    /// </summary>
    public class Backtracking
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            if (nums.Length < 1)
                return null;
            IList<IList<int>> res = new List<IList<int>>();
            int index = 0;
            PermuteHelper(nums,  new List<int>(),res, new bool [nums.Length]);
            //PermuteHelper2(nums, index, res);
            return res;
        }

        private void PermuteHelper(int[] nums,  IList<int> currList, IList<IList<int>> res, bool [] visited)
        {
            if(currList.Count==nums.Length)
            {
                res.Add(new List<int>(currList));
                return;
            }
            for(int i=0;i<nums.Length;i++)
            {
                if (visited[i])
                    continue;
                currList.Add(nums[i]);
                visited[i] = true;
                PermuteHelper(nums, currList, res, visited);
                currList.RemoveAt(currList.Count-1);
                visited[i] = false;
            }
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=GuTPwotSdYw
        /// https://www.youtube.com/watch?v=RkXl5iYoQn4
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="index"></param>
        /// <param name="res"></param>
        private void PermuteHelper2(int[] nums, int index, IList<IList<int>> res)
        {
            if (index == nums.Length)
            {
                res.Add(new List<int>(nums));
                return;
            }
            for (int i = index; i < nums.Length; i++)
            {
                //swap
                int temp = nums[i];
                nums[i] = nums[index];
                nums[index] = temp;
               
                PermuteHelper2(nums, index+1, res);

                //unchoose, swap again to keep it original

                int temp2 = nums[i];
                nums[i] = nums[index];
                nums[index] = temp2;
            }
        }

        public int[,] SolveNQueens(int n)
        {
            int[,] board = new int[n, n];
            SolveNQueensBoard( board, 0);
            return board;
        }

        private bool SolveNQueensBoard(int[,] board, int row)
        {
            if (row == board.GetLength(0))
                return true;

            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (IsSafe(row, i, board))
                {
                    board[row, i] = 1;
                    //go to next row
                    if (SolveNQueensBoard(board, row + 1))
                        return true;

                    /* If placing queen in board[i,col] 
                    doesn't lead to a solution then 
                    remove queen from board[i,col]  backtrack */
                    board[row, i] = 0;
                }
            }
            /* If the queen can not be placed in any row in 
                this colum col, then return false */
            return false;
        }

        private bool IsSafe(int row, int col, int [,] board)
        {
            for(int i=0;i<row;i++)
            {
                if (board[i, col] == 1)
                    return false;
            }

            //check top left corner
            for (int i = row, j = col;i>=0&&j>=0;i--,j--)
            {
                if (board[i, j] == 1)
                    return false;
            }

            //check top right corner
            for (int i = row, j = col; i >= 0 && j < board.GetLength(1); i--, j++)
            {
                if (board[i, j] == 1)
                    return false;
            }

            return true;
        }

        public int[,] RatInMaze(int[,] maze)
        {
            int[,] sol = new int[maze.GetLength(0), maze.GetLength(1)];

            RatInMazeHelper(maze, sol, 0,0);
            
            return sol;
        }

        private bool RatInMazeHelper(int[,] maze, int[,] sol, int row, int col)
        {
            if(row==maze.GetLength(0) || col==maze.GetLength(1))
            {
                return true;
            }
            
            if (maze[row,col]==1)
            {
                sol[row, col] = 1;
                RatInMazeHelper(maze, sol, row, col + 1);
                return true;
            }
            else
            {
                RatInMazeHelper(maze, sol, row + 1, col-1);
            }
            return false;
        }
    }
}
