using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.Recursion
{
    public class NQueen
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            //return the coordinates of the queen.

            IList<IList<string>> result = new List<IList<string>>();
            int[,] board = new int[n, n];
            IList<string> curr = new List<string>();
            int row = 0;
            HelperNQueen(board,result,curr,row);

            return result;
        }

        public int[] SolveNQueensOneDimensionalArray(int n)
        {
            //return the coordinates of the queen.

           // IList<IList<string>> result = new List<IList<string>>();
            int[] board = new int[n];
            //IList<string> curr = new List<string>();
            int row = 0;
            HelperNQueenOneDimensionArray(board, row);

            return board;
        }

        private void HelperNQueen(int[,] board, IList<IList<string>> result, IList<string> curr, int row)
        {
            if (row == board.GetLength(0))
            {
                //Print the solution board. board.
                Console.WriteLine();
                //return;
            }


            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (isSafe(board, row, col))
                {
                    board[row, col] = 1;
                    HelperNQueen(board, result, curr, row + 1);
                    board[row, col] = 0;
                }
            }

        }

        private void HelperNQueenOneDimensionArray(int[] board, int row)
        {
            if (row == board.Length)
            {
                //Print the solution board. board.
                // return;
                PrintChessBoard(board);
            }


            for (int col = 0; col < board.Length; col++)
            {
                if (isSafe(board, row, col))
                {
                    board[row] = col;
                    HelperNQueenOneDimensionArray(board, row + 1);                   
                }
            }

        }

        private void PrintChessBoard(int[] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                Console.WriteLine($"Index is {i} and its value is {board[i]}");
            }            
        }

        bool isSafe(int[,] board, int row, int col)
        {
            int i, j;

            /* Check row on its top */
            for (i = 0; i < row; i++)
                if (board[i, col] == 1)
                    return false;

            /* Check upper diagonal on left side */
            for (i = row, j = col; i >= 0 &&
                 j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            /* Check lower diagonal on left side */
            for (i = row, j = col; i >= 0 &&
                          j < board.GetLength(0); i--, j++)
                if (board[i, j] == 1)
                    return false;

            return true;
        }


        bool isSafe(int[] board, int row, int col)
        {
            int i, j;

            /* Check row on its top */
            for (i = 0; i < row; i++)
                if (board[i] == col)
                    return false;

            /* Check upper diagonal on left side */
            for (i = row, j = col; i >= 0 &&
                 j >= 0; i--, j--)
                if (board[i] == j)
                    return false;

            /* Check lower diagonal on left side */
            for (i = row, j = col; i >= 0 &&
                          j < board.GetLength(0); i--, j++)
                if (board[i] == j)
                    return false;

            return true;
        }

        /// <summary>
        /// IK Problem of NQueen
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>

        /*
         * Complete the function below.
         */
        public static string[][] find_all_arrangements(int n)
        {
            int[] slate = new int[n];
            for (int i = 0; i < n; i++)
            {
                slate[i] = i;
            }

            var result = new List<string[]>();
            nqhelper(slate, 0, result);
            return result.ToArray();
        }

        static void nqhelper(int[] slate, int index, List<string[]> result)
        {
            // base
            if (index == slate.Length)
            {
                result.Add(covertToOutput(slate));
            }

            // recursive
            for (int i = index; i < slate.Length; i++)
            {
                if (isValidCol(slate, slate[i], index))
                {
                    swap(slate, i, index);
                    nqhelper(slate, index + 1, result);
                    swap(slate, i, index);
                }
            }
        }

        static void swap(int[] slate, int i, int j)
        {
            var temp = slate[i];
            slate[i] = slate[j];
            slate[j] = temp;
        }

        static string[] covertToOutput(int[] slate)
        {
            var ret = new string[slate.Length];
            var builder = new System.Text.StringBuilder();
            for (int i = 0; i < slate.Length; i++)
            {
                for (int j = 0; j < slate[i]; j++)
                {
                    builder.Append('-');
                }
                builder.Append('q');
                for (int j = slate[i] + 1; j < slate.Length; j++)
                {
                    builder.Append('-');
                }
                ret[i] = builder.ToString();
                builder.Clear();
            }

            return ret;
        }

        static bool isValidCol(int[] slate, int col, int index)
        {
            var isValid = true;

            for (int j = index - 1; j >= 0; j--)
            {
                int diff = index - j;
                if (slate[j] == col - diff || slate[j] == col + diff)
                {
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}
