using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProramming.Algorithms
{
    public class SubsequenceAlgos
    {
        /// <summary>
        /// https://leetcode.com/problems/longest-increasing-subsequence/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            int maxSofar = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int maxCurrent = nums[i];
                int maxLIS = 1;
                for (int k = i + 1; k < nums.Length; k++)
                {
                    maxCurrent = nums[i];
                    maxLIS = 1;
                    for (int j = k; j < nums.Length; j++)
                    {
                        if (maxCurrent < nums[j])
                        {
                            maxCurrent = nums[j];
                            maxLIS++;
                        }
                    }
                    if (maxLIS > maxSofar)
                    {
                        maxSofar = maxLIS;
                    }
                }
                if (maxLIS > maxSofar)
                {
                    maxSofar = maxLIS;
                }
            }

            return maxSofar;
        }

        static int max_ref; // stores the LIS 

        /* To make use of recursive calls, this function must return 
        two things: 
        1) Length of LIS ending with element arr[n-1]. We use 
           max_ending_here for this purpose 
        2) Overall maximum as the LIS may end with an element 
           before arr[n-1] max_ref is used this purpose. 
        The value of LIS of full array of size n is stored in 
        *max_ref which is our final result */
        static int _lis(int[] arr, int n)
        {
            // base case 
            if (n == 1)
                return 1;

            // 'max_ending_here' is length of LIS ending with arr[n-1] 
            int res, max_ending_here = 1;

            /* Recursively get all LIS ending with arr[0], arr[1] ... 
               arr[n-2]. If   arr[i-1] is smaller than arr[n-1], and 
               max ending with arr[n-1] needs to be updated, then 
               update it */
            for (int i = 1; i < n; i++)
            {
                res = _lis(arr, i);
                if (arr[i - 1] < arr[n - 1] && res + 1 > max_ending_here)
                    max_ending_here = res + 1;
            }

            // Compare max_ending_here with the overall max. And 
            // update the overall max if needed 
            if (max_ref < max_ending_here)
                max_ref = max_ending_here;

            // Return length of LIS ending with arr[n-1] 
            return max_ending_here;
        }


        /* lis() returns the length of the longest increasing  
   subsequence in arr[] of size n */
        /// <summary>
        /// https://www.geeksforgeeks.org/longest-increasing-subsequence-dp-3/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Lis(int[] arr, int n)
        {
            int[] lis = new int[n];
            int i, j, max = 0;

            /* Initialize LIS values for all indexes */
            for (i = 0; i < n; i++)
                lis[i] = 1;

            /* Compute optimized LIS values in bottom up manner */
            for (i = 1; i < n; i++)
                for (j = 0; j < i; j++)
                    if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                        lis[i] = lis[j] + 1;

            /* Pick maximum of all LIS values */
            for (i = 0; i < n; i++)
                if (max < lis[i])
                    max = lis[i];

            return max;
        }

        public int LengthOfLIS_Dynamic(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int[] dp = new int[nums.Length];
            dp[0] = 1;
            int maxans = 1;
            for (int i = 1; i < dp.Length; i++)
            {
                int maxval = 0;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        maxval = Math.Max(maxval, dp[j]);
                    }
                }
                dp[i] = maxval + 1;
                maxans = Math.Max(maxans, dp[i]);
            }
            return maxans;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> FindIncreasingSubsequences(int[] nums)
        {
            var result = new List<IList<int>>();
            DFS(nums, 0, new List<int>(), result);
            return result;
        }

        private void DFS(int[] nums, int startIndex, IList<int> oneResult, IList<IList<int>> result)
        {
            if (oneResult.Count > 1)
            {
                result.Add(new List<int>(oneResult));
            }

            // not able to sort, so we add isVisited to remove the duplicate 
            var isVisited = new HashSet<int>();

            var n = nums.Length;
            for (int i = startIndex; i < n; i++)
            {
                var cur = nums[i];
                if (isVisited.Contains(cur)) continue;
                if (!oneResult.Any() || oneResult.Last() <= cur)
                {
                    isVisited.Add(cur);
                    oneResult.Add(cur);
                    DFS(nums, i + 1, oneResult, result);
                    oneResult.RemoveAt(oneResult.Count - 1);
                }
            }
        }

        public int LongestCommonSubsequence(string s1, string s2)
        {
            int[,] s1s2 = new int[s1.Length + 1, s2.Length + 1];
            for (int i = 0; i < s1.Length; i++)
            {
                s1s2[i, 0] = 0;
            }
            for (int i = 0; i < s2.Length; i++)
            {
                s1s2[0, i] = 0;
            }
            for (int i = 1; i < s1.Length + 1; i++)
            {
                for (int j = 1; j < s2.Length + 1; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        s1s2[i, j] = 1 + s1s2[i - 1, j - 1];
                    }
                    else
                    {
                        s1s2[i, j] = Math.Max(s1s2[i, j - 1], s1s2[i - 1, j]);
                    }
                }
            }
            return s1s2[s1.Length, s2.Length];
        }

        /// <summary>
        /// Example 1: Input:"bbbab"Output:4
        /// https://www.geeksforgeeks.org/longest-palindromic-subsequence-dp-12/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestPalindromeSubseq(string s)
        {
            int[,] lps = new int[s.Length, s.Length];

            //One letter are palindrome
            for (int i = 0; i < s.Length; i++)
            {
                lps[i, i] = 1;
            }
            //for 2 letter and more 
            //Lower diagnals are not filled because i>j meaning its subsequence 
            //// Build the table. Note that the  
            // lower diagonal values of table 
            // are useless and not filled in 
            // the process. The values are  
            // filled in a manner similar to 
            // Matrix Chain Multiplication DP 
            // solution (See 
            // https://www.geeksforgeeks.org/matrix-chain-multiplication-dp-8/ 
            // cl is length of substring 
            for (int j = 2; j <= s.Length; j++)
            {
                for (int k = 0; k < s.Length - j + 1; k++)
                {
                    int m = j + k - 1;
                    if (s[k] == s[m] && j == 2)
                    {
                        lps[k, m] = 2;
                    }
                    else if (s[k] == s[m])
                    {
                        lps[k, m] = lps[k + 1, m - 1] + 2;
                    }
                    else
                        lps[k, m] = Math.Max(lps[k, m - 1], lps[k + 1, m]);
                }
            }
            return lps[0, s.Length - 1];
        }

        public string MinWindowSubsequnce(string S, string T)
        {
            if (S == null || S.Length == 0)
                return "";

            int i = 0, j = 0, start_idx = -1, min_len = S.Length;
            while (i < S.Length)
            {
                if (S[i++] == T[j])
                {  // i++;
                    j++;
                    if (j == T.Length)
                    {
                        /* find a qualified tail */
                        int tail = i - 1;
                        /* try to find the closest head reversely */
                        int head = tail;
                        int jj = T.Length - 1;
                        while (jj >= 0)
                        {
                            if (S[head--] == T[jj])
                                jj--;
                        }
                        head = head + 1;
                        int cur_len = tail - head + 1;
                        if (cur_len < min_len)
                        {
                            min_len = cur_len;
                            start_idx = head;
                        }
                        j = 0;  /* reset j */
                        i = head + 1; /*next round should start with next idx after head */
                    }
                }
            }

            return start_idx == -1 ? "" : S.Substring(start_idx, min_len);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public String minWindow(String s, String t)
        {
            int maxLen = int.MaxValue;
            int start = 0;
            int end = 0;
            if (s.Equals("") || t.Equals(""))
                return "";
            // dp[i][j] represent the largest index s such that S[s: j] has subsequence T[0: i]
            int[,] dp = new int[t.Length, s.Length];
            for (int i = 0; i < t.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {

                    if (s[j] == t[i])
                    {
                        // If first character of T, note down the starting index in S
                        if (i == 0)
                            dp[i, j] = j + 1;
                        // Else note down the starting index from the subproblem dp[i-1][j-1]		
                        else if (i > 0 && j > 0 && dp[i - 1, j - 1] != 0)
                            dp[i, j] = dp[i - 1, j - 1];
                    }
                    else if (j > 0)
                        dp[i, j] = dp[i, j - 1];


                    // Update the result, we are looking at a string
                    // ending at a index j having start index s such that 
                    // S[s: j] has a subsequence equal to T
                    if (i == t.Length - 1 && dp[i, j] != 0)
                    {
                        if (j - dp[i, j] + 2 < maxLen)
                        {
                            maxLen = j - dp[i, j] + 2;
                            start = dp[i, j] - 1;
                            end = j;
                        }
                    }
                }
            }

            return maxLen == int.MaxValue ? "" : s.Substring(start, end + 1);
        }
    }
}
