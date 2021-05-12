using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.FaceBook.Arrays
{
    /// <summary>
    /// /*
    /// Given an array nums and a target value k, find the maximum length of a subarray that sums to k. If there isn't one, return 0 instead.
    /*
        Note:
        The sum of the entire nums array is guaranteed to fit within the 32-bit signed integer range.
        Example 1:
        Input: nums = [1, -1, 5, -2, 3], k = 3
        Output: 4 
        Explanation: The subarray [1, -1, 5, -2] sums to 3 and is the longest.
        Example 2:
        Input: nums = [-2, -1, 2, 1], k = 1
        Output: 2 
        Explanation: The subarray [-1, 2] sums to 1 and is the longest.
        Follow Up:
        Can you do it in O(n) time?

        Logic:
             1. Loop through 0 --> n
             2. Sum = sum + nums[i]
             3. If sum == k get the Math.max()
             4. Have a dictionary which stores the sum till at each index.
             4. else if dictionary has the sum then maxLen is i-diction[sum]
             5. else add the sum and index into the dictionary.
            */
    /// */
    /// </summary>
   public class MaxSubArraySumLen
    {
        public int MaxSubArrayLen(int[] nums, int s)
        {
            int sum = 0;
            int maxLen = 0;            
            Dictionary<int, int> valuePairs = new Dictionary<int, int>();

            for(int i=0;i<nums.Length;i++)
            {
                sum = sum + nums[i];
                if(sum==s)
                {
                    maxLen = Math.Max(maxLen, i + 1);                   
                }
                else if(valuePairs.ContainsKey(sum-s))
                {
                    maxLen = Math.Max(maxLen, i-valuePairs[sum - s]);
                }
                if(!valuePairs.ContainsKey(sum))
                {
                    valuePairs.Add(sum, i);
                }
            }
            return maxLen;
        }

        public int MaxSubArrayLen2(int[] nums, int k)
        {

            var result = 0;
            if (nums == null || nums.Length == 0)
            {
                return result;
            }
            var dic = new Dictionary<int, int>();

            var sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];
                if (sum == k)
                {
                    result = Math.Max(result, i + 1);
                }
                else if (dic.ContainsKey(sum - k))
                {
                    result = Math.Max(result, i - dic[sum - k]);
                }
                if (!dic.ContainsKey(sum))
                {
                    dic.Add(sum, i);
                }
            }
            return result;
        }
    }
}
