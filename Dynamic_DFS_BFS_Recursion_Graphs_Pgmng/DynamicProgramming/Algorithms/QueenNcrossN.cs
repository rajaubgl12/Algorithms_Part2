using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Algorithms
{
    public class QueenNcrossN
    {
        public int N = 4;

        public void PlaceQueens(int row, int[] cols, ArrayList results, int queenCount)
        {
            if (row == queenCount)
            {
                results.Add(cols.Clone());
                for (int i = 0; i < cols.Length; i++)
                {
                    Console.WriteLine(cols[i]);
                }

            }
            else
            {
                for (int col = 0; col < queenCount; col++)
                {
                    if (CheckValid(cols, row, col))
                    {
                        cols[row] = col;
                        PlaceQueens(row + 1, cols, results, queenCount);
                    }
                }
            }
        }

        private bool CheckValid(int[] cols, int row1, int col1)
        {

            for (int row2 = 0; row2 < row1; row2++)
            {
                int column2 = cols[row2];
                // check if row2, column2 invalidates row1, col1
                if (col1 == column2)
                    return false;


                //Check diagonals if the distance between the columns equals the distance between the rows 
                //then they are in the same diagonal.
                int colDistanceForDiagonalCheck = Math.Abs(col1 - column2);
                //row1>row2 so no need for abs
                int rowDistance = row1 - row2;
                if (colDistanceForDiagonalCheck == rowDistance)
                    return false;
            }

            return true;
        }

        #region geeks
        /* A utility function to check if a queen can 
      be placed on board[row][col]. Note that this 
      function is called when "col" queens are already 
      placeed in columns from 0 to col -1. So we need 
      to check only left side for attacking queens */
        bool isSafe(int[,] board, int row, int col)
        {
            int i, j;

            /* Check this row on left side */
            for (i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;

            /* Check upper diagonal on left side */
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            /* Check lower diagonal on left side */
            for (i = row, j = col; j >= 0 && i < N; i++, j--)
                if (board[i, j] == 1)
                    return false;



            return true;
        }


        /* A recursive utility function to solve N 
           Queen problem */
        bool solveNQUtil(int[,] board, int col)
        {
            /* base case: If all queens are placed 
               then return true */
            if (col >= N)
                return true;

            /* Consider this column and try placing 
               this queen in all rows one by one */
            for (int i = 0; i < N; i++)
            {
                /* Check if the queen can be placed on 
                   board[i][col] */
                if (isSafe(board, i, col))
                {
                    /* Place this queen in board[i][col] */
                    board[i, col] = 1;

                    /* recur to place rest of the queens */
                    if (solveNQUtil(board, col + 1) == true)
                        return true;

                    /* If placing queen in board[i][col] 
                       doesn't lead to a solution then 
                       remove queen from board[i][col] */
                    board[i, col] = 0; // BACKTRACK 
                }
            }

            /* If the queen can not be placed in any row in 
               this colum col, then return false */
            return false;
        }

        

        /* This function solves the N Queen problem using 
           Backtracking.  It mainly uses solveNQUtil () to 
           solve the problem. It returns false if queens 
           cannot be placed, otherwise, return true and 
           prints placement of queens in the form of 1s. 
           Please note that there may be more than one 
           solutions, this function prints one of the 
           feasible solutions.*/
        public bool solveNQ()
        {
            int[,] board = { { 0, 0, 0, 0 },
                          { 0, 0, 0, 0 },
                          { 0, 0, 0, 0 },
                          { 0, 0, 0, 0 } };

            if (solveNQUtil(board, 0) == false)
            {
                Console.WriteLine("Solution does not exist");
                return false;
            }

            printSolution(board);
            return true;
        }
        /* A utility function to print solution */
        void printSolution(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.WriteLine(" " + board[i, j]
                                     + " ");
                Console.WriteLine();
            }
        }
        #endregion
    }

    public class SolutionChessBoard
    {
        int n;
        int[] rows;
        int[] hills;
        int[] dales;
        IList<IList<string>> output = new List<IList<string>>();
        int[] queens;
        public IList<IList<string>> SolveNQueens(int n)
        {
            this.n = n;
            rows = new int[n];
            hills = new int[4 * n - 1];
            dales = new int[2 * n - 1];
            queens = new int[n];
            Backtrack(0);
            return output;
        }
        public void Backtrack(int row)
        {
            for (int col = 0; col < n; col++)
            {
                if (IsNotUnderAttack(row, col))
                {
                    PlaceQueen(row, col);
                    if (row + 1 == n)
                    {
                        AddSolution();
                    }
                    else
                    {
                        Backtrack(row + 1);
                    }
                    RemoveQueen(row, col);
                }
            }
        }
        public bool IsNotUnderAttack(int row, int col)
        {
            int res = rows[col] + hills[row - col + 2 * n] + dales[row + col];
            return res == 0 ? true : false;
        }
        public void PlaceQueen(int row, int col)
        {
            queens[row] = col;
            rows[col] = 1;
            hills[row - col + 2 * n] = 1;
            dales[row + col] = 1;
        }
        public void RemoveQueen(int row, int col)
        {
            queens[row] = 0;
            rows[col] = 0;
            hills[row - col + 2 * n] = 0;
            dales[row + col] = 0;
        }
        public void AddSolution()
        {
            List<string> solution = new List<string>();
            for (int i = 0; i < n; i++)
            {
                int col = queens[i];
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < col; j++)
                {
                    sb.Append(".");
                }
                sb.Append("Q");
                for (int j = 0; j < n - col - 1; j++)
                {
                    sb.Append(".");
                }
                solution.Add(sb.ToString());
            }
            output.Add(solution);
        }
    }
    
}
