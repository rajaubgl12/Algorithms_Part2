using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Algorithms
{
   public class SubstringAlgos
    {        
        public string LongestPalindromeSubstringDynamic(string str)
        {
            int n = str.Length;   // get length of input string

            // table[i][j] will be false if substring str[i..j]
            // is not palindrome.
            // Else table[i][j] will be true
            bool[,] table = new bool[n, n];

            // All substrings of length 1 are palindromes
            int maxLength = 1;
            for (int i = 0; i < n; ++i)
                table[i, i] = true;

            // check for sub-string of length 2.
            int start = 0;
            for (int i = 0; i < n - 1; ++i)
            {
                if (str[i] == str[i + 1])
                {
                    table[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }

            // Check for lengths greater than 2. k is length
            // of substring
            for (int k = 3; k <= n; ++k)
            {
                int endIn = n - k + 1;
                // Fix the starting index
                for (int i = 0; i < endIn; ++i)
                {
                    // Get the ending index of substring from
                    // starting index i and length k
                    int j = i + k - 1;//end index

                    // checking for sub-string from ith index to
                    // jth index iff str.charAt(i+1) to 
                    // str.charAt(j-1) is a palindrome
                    if (table[i + 1, j - 1] && str[i] ==
                                              str[j])
                    {
                        table[i, j] = true;

                        if (k > maxLength)
                        {
                            start = i;
                            maxLength = k;
                        }
                    }
                }
            }
            Console.WriteLine("Longest palindrome substring is; ");
            //printSubStr(str, start, start + maxLength - 1);
            string strPalin = str.Substring(start, maxLength);
            return strPalin; // return length of LPS
        }

        public string LongestPalindromeNonDynamic(string str)
        {
            int maxLen = 0;
            int startIndex = 0;
            int low = 0;
            int high = 0;
            for(int i=0;i<str.Length;i++)
            {
                //at every instance check if its even length or odd length palindrome.
                //always check if left side of the letter is same as the current index letter value.
                 low = i - 1;
                 high = i;
                while (low >= 0 && high < str.Length && str[low] == str[high])
                {
                    if(maxLen<high-low+1)
                    {
                        maxLen = high - low + 1;
                        startIndex = low;
                    }
                    low--;
                    high++;
                }
                //odd length palindrome;
                low = i - 1;
                high = i + 1;
                while (low >= 0 && high < str.Length && str[low] == str[high])
                {
                    if (maxLen < high - low + 1)
                    {
                        maxLen = high - low + 1;
                        startIndex = low;
                    }
                    low--;
                    high++;
                }                
            }
            return str.Substring(startIndex, maxLen);
        }

        /// <summary>
        /// Expand around centre
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountPalindromeSubstrings(string s)
        {
            int len = s.Length;
            int count = 0;
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            for(int i=0;i<2*len-1;i++)
            {
                int left = i / 2;
                int right = left + i % 2;
                while (left >= 0 && right < len && s[left] == s[right])
                {
                    left--;
                    right++;
                    //distinct palindrome
                    //string palindrome = s.Substring(left, right - left + 1);
                    //if(!keyValuePairs.ContainsKey(palindrome))
                    //{
                    //    count++;
                    //}
                    //else
                    //{
                    //    keyValuePairs.Add(palindrome, count);
                    //}
                    count++;
                }
            }

            return count;
        }
        /// <summary>
        /// https://www.youtube.com/watch?v=Xg0rPVTQf98
        /// https://www.geeksforgeeks.org/find-the-smallest-window-in-a-string-containing-all-characters-of-another-string/
        /// Check this in array string solution,there is a better solution.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pat"></param>
        /// <returns></returns>
        public string MinWindowSubstring(string str, string pat)
        {
            int len1 = str.Length;
            int len2 = pat.Length;

            // check if string's length is less than pattern's 
            // length. If yes then no such window can exist 
            if (len1 < len2)
            {
                Console.WriteLine("No such window exists");
                return "";
            }

            int[] hash_pat = new int[256];
            int[] hash_str = new int[256];

            // store occurrence ofs characters of pattern 
            for (int i = 0; i < len2; i++)
                hash_pat[pat[i]]++;

            int start = 0, start_index = -1, min_len = int.MaxValue;

            // start traversing the string 
            int count = 0; // count of characters 
            for (int j = 0; j < len1; j++)
            {
                // count occurrence of characters of string 
                hash_str[str[j]]++;

                // If string's char matches with pattern's char 
                // then increment count 
                if (hash_pat[str[j]] != 0 &&
                    hash_str[str[j]] <= hash_pat[str[j]])
                    count++;

                // if all the characters are matched 
                if (count == len2)
                {
                    // Try to minimize the window i.e., check if 
                    // any character is occurring more no. of times 
                    // than its occurrence in pattern, if yes 
                    // then remove it from starting and also remove 
                    // the useless characters. 
                    while (hash_str[str[start]] > hash_pat[str[start]]
                        || hash_pat[str[start]] == 0)
                    {

                        if (hash_str[str[start]] > hash_pat[str[start]])
                            hash_str[str[start]]--;
                        start++;
                    }

                    // update window size 
                    int len_window = j - start + 1;
                    if (min_len > len_window)
                    {
                        min_len = len_window;
                        start_index = start;
                    }
                }
            }

            // If no window found 
            if (start_index == -1)
            {
                Console.WriteLine("No such window exists");
                return "";
            }

            // Return substring starting from start_index 
            // and length min_len 
            return str.Substring(start_index, min_len);
        }

        /// <summary>
        /// maximum window substring
        /// https://leetcode.com/problems/longest-substring-without-repeating-characters/solution/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int maxLength = 0;
            int length = 0;
            int indexStart = 0;

            for (int i = 0; i < s.Length; i++)
            {
                // Unique char found
                if (!dict.ContainsKey(s[i]) || dict[s[i]] < indexStart)
                {
                    length++;
                    dict[s[i]] = i;
                }
                // Non-unique char
                // move the start index to the next index of prev occured character index = dict[s[i]]+1;
                //length = i-index+1;
                //update the repeated character index to the current index dict[s[i]] =i;
                // second option use characters 256 https://www.geeksforgeeks.org/length-of-the-longest-substring-without-repeating-characters/
                else
                {
                    indexStart = dict[s[i]] + 1;
                    length = i - indexStart + 1;
                    dict[s[i]] = i;
                }

                ////to get substring 
                ///
                maxLength = Math.Max(maxLength, length);
            }

            return maxLength;
        }

        public string LargestNonRepeatingSubstr(string strLarg)
        {
            int startIndex = 0;
            int endIndex = 0;
            int maxLength = 0;
            int length = 0;

            Dictionary<char, int> visitedChars = new Dictionary<char, int>();
            string subStringNonRepeated = "";
            for (; endIndex < strLarg.Length; endIndex++)
            {
                if (!visitedChars.ContainsKey(strLarg[endIndex]))
                {
                    visitedChars.Add(strLarg[endIndex], endIndex);
                }
                else
                {
                    // startIndex = Math.Max(startIndex, visitedChars[strLarg[endIndex]] + 1);
                    startIndex = visitedChars[strLarg[endIndex]] + 1;
                    visitedChars[strLarg[endIndex]] = endIndex;
                    length = endIndex - startIndex + 1;
                }
                //if (subStringNonRepeated.Length < ((endIndex - startIndex + 1)))
                //{
                //    subStringNonRepeated = strLarg.Substring(startIndex, (endIndex - startIndex + 1));
                //}
                if (length > maxLength)
                {
                    maxLength = length;
                    subStringNonRepeated = strLarg.Substring(startIndex, maxLength);
                }
                //maxLength = Math.Max(length, maxLength);
            }
            return subStringNonRepeated;
        }

        /// <summary>
        /// https://leetcode.com/problems/longest-repeating-substring/solution/
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public int LongestRepeatingSubstring(string S)
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="S"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int NumKLenSubstrNoRepeats(string S, int K)
        {
            
            if (string.IsNullOrWhiteSpace(S) || S.Length < K)
                return 0;
            int leftPtr = 0;
            int rightPtr = 0;
            int count = 0;
            Dictionary<char, int> charPairs = new Dictionary<char, int>();
            for(;rightPtr<S.Length;rightPtr++)
            {
                if(charPairs.ContainsKey(S[rightPtr]))
                {
                    //move the sliding window with left pointer
                    leftPtr = Math.Max(leftPtr, charPairs[S[rightPtr]] + 1);
                    charPairs[S[rightPtr]] = rightPtr;
                }
                else
                {
                    charPairs.Add(S[rightPtr], rightPtr);
                }
                if (K == rightPtr - leftPtr + 1)
                {
                    count++;
                    leftPtr++;
                }
            }
            return count;
        }

        /// <summary>
        /// https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/submissions/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>        
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            if (k == 0) return 0;
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            int leftIndex = 0;
            int rightIndex = 0;
            int maxLen = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            while (rightIndex < s.Length)
            {
                if (!dict.ContainsKey(s[rightIndex]))
                {
                    dict.Add(s[rightIndex], 0);
                }
                dict[s[rightIndex]]++;

                while (leftIndex < rightIndex && dict.Count > k)
                {
                    //remove left most character.
                    dict[s[leftIndex]]--;
                    if (dict[s[leftIndex]] == 0)
                        dict.Remove(s[leftIndex]);
                    leftIndex++;
                }
                maxLen = Math.Max(maxLen, rightIndex - leftIndex + 1);
                rightIndex++;
            }

            return maxLen;
        }
    }
}
