using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    class LongestSubstringWithKDistinctChars
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            var n = s.Length;

            var distinctCount = k;

            var startIndex = 0;

            var charAndCount = new int[256];
            var letterCount = 0;

            var result = 0;

            for (var i = 0; i < n; i++)
            {
                var curChar = s[i];

                if (charAndCount[curChar] == 0)
                {
                    letterCount++;
                }
                charAndCount[curChar]++;

                while (letterCount > k)
                {
                    //
                    if (charAndCount[s[startIndex]] > 0)
                    {
                        charAndCount[s[startIndex]]--;

                        if (charAndCount[s[startIndex]] == 0)
                            letterCount--;
                        //change the startIndex
                        startIndex++;
                    }
                }

                result = Math.Max(result, i - startIndex + 1);
            }
            return result;
        }

       
    }
}
