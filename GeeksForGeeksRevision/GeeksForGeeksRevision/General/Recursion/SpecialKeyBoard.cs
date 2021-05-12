using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.General.Recursion
{
    class SpecialKeyBoard
    {
        /// <summary>
        /// https://www.geeksforgeeks.org/how-to-print-maximum-number-of-a-using-given-four-keys/
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int maxA(int N)
        {
            int[] best = new int[N + 1];
            for (int k = 1; k <= N; ++k)
            {
                best[k] = best[k - 1] + 1;
                for (int x = 0; x < k - 1; ++x)
                    best[k] = Math.Max(best[k], best[x] * (k - x - 1));
            }
            return best[N];
        }
    }
}
