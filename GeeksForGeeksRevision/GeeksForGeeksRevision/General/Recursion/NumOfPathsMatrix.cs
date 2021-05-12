using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.General.Recursion
{
    class NumOfPathsMatrix
    {
        /// <summary>
        /// https://www.geeksforgeeks.org/count-possible-paths-top-left-bottom-right-nxm-matrix/
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public int NumberOfPathsMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            matrix[0, 0] = 0;
            //initialize the rows to 1 , it takes 1 unique path to reach each cell of the row.
            for (int i = 1; i < rows; i++)
                matrix[i, 0] = 1;
            //initialize the cols to 1 , it takes 1 unique path to reach each cell of the col.
            for (int i = 1; i < cols; i++)
                matrix[0, i] = 1;

            for (int i = 1; i < rows; i++)
                for (int j = 1; j < cols; j++)
                    matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
            return matrix[rows - 1, cols - 1];
        }
    }
}
