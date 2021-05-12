using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.FaceBook.Arrays
{
    /// <summary>
    /// /*
    /// Given an array of n positive integers and a positive integer s, find the minimal 
    /// length of a contiguous subarray of which the sum ≥ s. If there isn't one, return 0 instead.
    /*Example: 
    Input: s = 7, nums = [2,3,1,2,4,3]
    Output: 2
    Explanation: the subarray[4, 3] has the minimal length under the problem constraint.
    Follow up:
    If you have figured out the O(n) solution, try coding another solution of which the time 
    complexity is O(n log n).
    
        Logic:
        1. Run through the loop 0 to n
        2. Have a start index 
        3. check if sum >= k and have a loop inside which runs again till >= k
        4. Have Math.min and diff of iIndex 
        5. Return the diff

    */
    /// */
    /// /
    /// </summary>
    public class MinSizeSubArraySum
    {
        public int MinSubArrayLen(int[] nums, int s)
        {
            int tSum = 0;
            int startIndex = 0;
            int minLen = nums.Length+1;
            for (int i = 0; i < nums.Length; i++)
            {
                tSum = tSum + nums[i];
                // maintain the valid window, ditch the item at start point if it is not needed.
                if (tSum >= s)
                {
                    minLen = Math.Min(minLen, (i - startIndex) + 1);
                    while (tSum > s)
                    {
                        tSum = tSum- nums[startIndex];
                        startIndex++;
                        if (tSum >= s)
                        {
                            minLen = Math.Min(minLen, (i - startIndex) + 1);
                        }                           
                    }
                }
            }

            return minLen==nums.Length+1?0:minLen;
        }

        public int MinSubArrayLen1(int s, int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int returnVal = nums.Length + 1;
            int start, end, sum;
            start = end = sum = 0;

            while (end < nums.Length)
            {
                sum += nums[end];

                // maintain the valid window, ditch the item at start point if it is not needed.
                if (sum >= s)
                {
                    while (sum - s >= nums[start])
                    {
                        sum = sum- nums[start];
                        start++;
                    }

                    // update once we finsihed filtering. 
                    returnVal = Math.Min(returnVal, end - start + 1);
                }
                end++;
            }
            return returnVal == nums.Length + 1 ? 0 : returnVal;
        }
    }
}
