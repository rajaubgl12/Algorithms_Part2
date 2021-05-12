using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.DynamicProgramming
{
    public class Robber
    {
        /// <summary>
        /// Formula nums[i] = nums[i] + Max (nums[i-2], nums[i-3])
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            //initialize
            if (nums.Length == 1)
                return nums[0];

            if (nums.Length == 1)
                return Math.Max(nums[0],nums[1]);


            for (int i=2;i<nums.Length;i++)
            {
                if(i>2)
                nums[i] += Math.Max(nums[i - 2], nums[i - 3]);
                else
                {
                    nums[i] += nums[i - 2];
                }
            }

            return Math.Max(nums[nums.Length - 1], nums[nums.Length - 2]);
        }
    }
}
