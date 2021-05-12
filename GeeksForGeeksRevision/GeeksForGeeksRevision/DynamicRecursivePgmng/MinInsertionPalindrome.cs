using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    public class MinInsertionPalindrome
    {
        /// <summary>
        /// https://www.geeksforgeeks.org/minimum-insertions-to-form-a-palindrome-dp-28/
        /// Let the input string be str[l……h]. The problem can be broken down into three parts:
        // Find the minimum number of insertions in the substring str[l + 1,…….h].
        //Find the minimum number of insertions in the substring str[l…….h - 1].
        //Find the minimum number of insertions in the substring str[l + 1……h - 1].
        //Recursive Approach: The minimum number of insertions in the string str[l…..h] can be given as:
        //minInsertions(str[l + 1…..h - 1]) if str[l] is equal to str[h]
        //min(minInsertions(str[l…..h - 1]), minInsertions(str[l + 1…..h])) + 1 otherwise
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int FindMinInsertions(string str)
        {
            return FindMinInsertionsRec(str, 0, str.Length - 1);
        }

        private int FindMinInsertionsRec(string str, int l, int r)
        {
            if (l == r)
                return 0;
            if (l > r)
                return int.MaxValue;
            if (l == r - 1)
              return  (str[l] == str[r] )? 0 : 1;

            return str[l] == str[r] ? 0 
                : ((Math.Min(FindMinInsertionsRec(str, l, r - 1), FindMinInsertionsRec(str, l + 1, r)) + 1));
        }

        public int FindMinInsertionsPalindromeDynamic(string str)
        {
            int[,] table = new int[str.Length, str.Length];
            //int gap, l, h;

            for (int gap = 1; gap < str.Length; gap++)
            {
                for (int l = 0, h = gap; h < str.Length; l++, h++)
                {
                    table[l, h] = str[l] == str[h] ? table[l + 1, h - 1] : (Math.Min(table[l + 1, h], table[l, h - 1]) + 1);
                }
            }
            return table[0, str.Length - 1];
        }
    }
}
