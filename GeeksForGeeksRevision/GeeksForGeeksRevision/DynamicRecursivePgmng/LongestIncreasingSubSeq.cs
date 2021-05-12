using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    public class LongestIncreasingSubSeqCls
    {
        int max_ref;

        public int LongsetIncrSubSeqLenRecur(int [] a)
        {
            return _lis(a, a.Length);
        }
        /// <summary>
        /// for recursive
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private int _lis(int[] arr, int n)
        {
            // base case 
            if (n == 1)
                return 1;

            // 'max_ending_here' is length of LIS ending with arr[n-1] 
            int res;
            int max_ending_here = 1;

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

        /// <summary>
        /// O(n2)
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int LongsetIncreasingSubSequenceLength(int[] a)
        {
            int[] LIS = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                LIS[i] = 1;
            }
            for (int i = 1; i < a.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (a[i] > a[j] && LIS[i] < LIS[j] + 1)
                    {
                        LIS[i] = 1 + LIS[j];
                    }
                }

            }
            int maxLen = 0;
            for (int i = 0; i < LIS.Length; i++)
            {
                if (maxLen < LIS[i])
                    maxLen = LIS[i];
            }
            return maxLen;
        }

        /// <summary>
        /// https://www.geeksforgeeks.org/longest-increasing-subsequence-dp-3/
        /// </summary>
        /// <param name="A">O(nlogn)</param>
        /// <param name="size"></param>
        /// <returns></returns>
        public int LongestIncreasingSubsequenceLength(
            int[] A, int size)
        {

            // Add boundary case, when array size 
            // is one 

            int[] tailTable = new int[size];
            int len; // always points empty slot 

            tailTable[0] = A[0];
            len = 1;
            for (int i = 1; i < size; i++)
            {
                if (A[i] < tailTable[0])
                    // new smallest value 
                    tailTable[0] = A[i];

                else if (A[i] > tailTable[len - 1])
                {
                    // A[i] wants to extend largest 
                    // subsequence 
                    tailTable[len++] = A[i];

                }
                else
                {

                    // A[i] wants to be current end 
                    // candidate of an existing 
                    // subsequence. It will replace 
                    // ceil value in tailTable 
                    tailTable[CeilIndex(tailTable, -1,
                                        len - 1, A[i])]
                        = A[i];
                }

            }

            return len;
        }

        // Binary search (note boundaries 
        // in the caller) A[] is ceilIndex 
        // in the caller 
        static int CeilIndex(int[] A, int l,
                             int r, int key)
        {
            while (r - l > 1)
            {
                int m = l + (r - l) / 2;

                if (A[m] >= key)
                    r = m;
                else
                    l = m;
            }

            return r;
        }


    }
      
}
