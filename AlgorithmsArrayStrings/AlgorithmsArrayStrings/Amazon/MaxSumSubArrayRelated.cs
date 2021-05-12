using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsArrayStrings.Amazon
{
   public class MaxSumSubArrayRelated
    {
        /// <summary>
        /// Given an integer array nums, find the contiguous subarray (containing at least one number) 
        /// which has the largest sum and return its sum.
        /// Input: [-2,1,-3,4,-1,2,1,-5,4],
        ///Output: 6
        ///Explanation: [4,-1,2,1] has the largest sum = 6
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            int maxSum = 0;
            int sum = 0;
            for(int i=0;i<nums.Length;i++)
            {
                sum = sum + nums[i];
                if (sum < 0)
                    sum = 0;
                if (sum > maxSum)
                    maxSum = sum;
            }

            return maxSum;
        }

        public int DegreeOfAnArray(int [] a)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            Dictionary<int, int> index = new Dictionary<int, int>();
            int maxCount = 0;
            int minLen = int.MaxValue;

            for (int i=0;i<a.Length;i++)
            {
                if(!count.ContainsKey(a[i]))
                {
                    count.Add(a[i], 1);
                    index.Add(a[i], i);
                }
                else
                {
                    count[a[i]]++;
                    if(maxCount<count[a[i]])
                    {
                        maxCount = count[a[i]];
                        minLen = i - index[a[i]] + 1;
                    }
                    if(maxCount==count[a[i]])
                    {
                        if (minLen > (i - index[a[i]]))
                            minLen = i - index[a[i]] + 1;
                    }
                }                
            }

            return minLen;
        }
    }
}
