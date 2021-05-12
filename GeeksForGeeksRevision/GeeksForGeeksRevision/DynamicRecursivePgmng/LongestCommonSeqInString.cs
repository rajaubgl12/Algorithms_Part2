using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    class LongestCommonSeqInString
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=Qf5R-uYQRPk
        /// https://www.geeksforgeeks.org/longest-common-subsequence-dp-4/
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Lcs(string str1, string str2, int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;
            if (str1[m - 1] == str2[n - 1])
                return 1 + Lcs(str1, str2, m - 1, n - 1);
            else
                return Math.Max(Lcs(str1, str2, m, n - 1), Lcs(str1, str2, m - 1, n));
        }

        public int LcsDynamic(string str1, string str2, int m, int n)
        {
            //for easy calculation of the diagonals
            int[,] MatrixLcs = new int[m + 1, n + 1];

            for(int i=0;i<=m; i++)
            {
                for(int j=0;j<=n;j++)
                {
                    if (i == 0 || j == 0)
                        MatrixLcs[i, j] = 0;
                    else if (str1[i - 1] == str2[j - 1])
                        MatrixLcs[i, j] = MatrixLcs[i - 1, j - 1] + 1;
                    else
                        MatrixLcs[i, j] = Math.Max(MatrixLcs[i, j - 1], MatrixLcs[i - 1, j]);
                }
            }
            return MatrixLcs[m, n];
        }
    }
}
