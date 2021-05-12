using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    /// <summary>
    /// Check this
    /// https://www.geeksforgeeks.org/longest-palindromic-subsequence-dp-12/
    /// </summary>
    public class LongestPalindromeSubstring
    {
        // One by one consider every  
        // character as center point 
        // of even and length palindromes
        public int LongestPalindrome(string s)
        {

            int maxLen = 0;
            int low = 0;
            int high = 0;
            int startIndex = 0;
            string subStrPalindrome = "";
            //even and odd palindrome
            //Idea is to expand left and right from given point 
            while (startIndex < s.Length)
            {
                //initialize the high and low pointers with startindex.
                low = startIndex;
                high = startIndex;
                // move the right pointer if there are consequitive same letters.
                while (s[low] == s[high + 1] && low >= 0 && high + 1 < s.Length)
                {
                    high++;
                }
                startIndex = high + 1;

                while (s[low - 1] == s[high + 1] && low - 1 >= 0 && high + 1 < s.Length)
                {
                    low--;
                    high++;
                }
                if (maxLen < high - low + 1)
                {
                    maxLen = high - low + 1;
                    subStrPalindrome = s.Substring(low, maxLen);
                }
            }

            return maxLen;
        }
    }
}
