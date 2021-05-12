using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    class LongestCommonSubstring
    {
        public int Lcsubstring(string str1, string str2, int m, int n, int count)
        {
            if (m == 0 || n == 0)
                return 0;
            if (str1[m - 1] == str2[n - 1])
                count = 1 + Lcsubstring(str1, str2, m - 1, n - 1, count);
            
                count= Math.Max(count, Math.Max(Lcsubstring(str1, str2, m, n - 1,0), Lcsubstring(str1, str2, m - 1, n,0)));

            return count;
        }

        public int LcsubstrDynamic(string str1, string str2, int m, int n)
        {
            //for easy calculation of the diagonals
            int[,] MatrixLcs = new int[m + 1, n + 1];
            int count = 0;
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    //to fill the zeros on edges of rows and columns.
                    if (i == 0 || j == 0)
                        MatrixLcs[i, j] = 0;

                    else if (str1[i - 1] == str2[j - 1])
                    {
                        MatrixLcs[i, j] = MatrixLcs[i - 1, j - 1] + 1;
                        count = Math.Max(count, MatrixLcs[i, j]);
                    }

                    else
                        MatrixLcs[i, j] = 0;
                }
            }
            return count;
        }
    }
}
