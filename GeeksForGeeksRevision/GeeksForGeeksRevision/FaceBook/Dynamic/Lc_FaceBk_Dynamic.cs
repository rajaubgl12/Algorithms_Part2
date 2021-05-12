using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision
{
    class Lc_FaceBk_Dynamic
    {
        public string MinWindowSubSeq(string S,string T)
        {
            var sLen = S.Length;
            var tLen = T.Length;
            var startIndex = -1;
            var len = sLen;
            var sIndex = 0;
            var tIndex = 0;
            bool isFirstIndex = true;
            int saveStartIndex = 0;
            while (sIndex < sLen)
            {
                if (S[sIndex] == T[tIndex])
                {                    
                    if(isFirstIndex)
                    {                        
                        saveStartIndex = sIndex;
                        isFirstIndex = false;
                    }
                    tIndex++;
                    if (tIndex == tLen)
                    {
                        var end = sIndex + 1;

                        var curLen = end - saveStartIndex;
                        if (curLen < len)
                        {
                            len = curLen;
                            startIndex = saveStartIndex;
                        }
                        //reset values
                        tIndex = 0;
                        isFirstIndex = true;
                    }
                }

                sIndex++;
            }

            return startIndex == -1 ? string.Empty : S.Substring(startIndex, len);
        }

        public int MaxBuySellStocks(int [] a)
        {
            int currMax = 0;
            int currMin = a[0];
            for(int i=0;i<a.Length;i++)
            {
                currMin = Math.Min(a[i], currMin);
                currMax = Math.Max(a[i]- currMin, currMax);
            }
            return currMax;
        }

        public int NumDecodings(string s)
        {
            int n = s.Length;
            if (n == 0) return 0;

            int[] memo = new int[n + 1];
            memo[n] = 1;
            memo[n - 1] = s[n - 1] != '0' ? 1 : 0;

            for (int i = n - 2; i >= 0; i--)
            {
                if (s[i] == '0')
                    continue;
                else
                {
                    int digValue = int.Parse(s.Substring(i, 2));
                    if (digValue <= 26)
                    {
                        memo[i] = memo[i + 1] + memo[i + 2];
                    }
                    else
                    {
                        memo[i] = memo[i + 1];
                    }
                    //memo[i] = (int.Parse(s.Substring(i, 2)) <= 26) ? memo[i + 1] + memo[i + 2] : memo[i + 1];
                }
            }
            return memo[0];
        }

    }
}
