using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IK_Algorithms.DynamicProgramming
{
    public class PartitionSubset
    {
        public bool CanPartition(int[] nums)
        {
            if(nums==null || nums.Length==0)
            {
                return false;
            }
            if (nums.Length == 2)
                return nums[0] == nums[1];
           
            int totalSum = nums.Sum();

            if (totalSum % 2 != 0)
                return false;

            int halfSum = totalSum / 2;

            return PartitionHelper(nums, nums.Length, halfSum);            
        }

        private bool PartitionHelper(int[] nums, int length, int halfSum)
        {
            if (halfSum == 0)
                return true;

            if (halfSum < 0 || length == 0)
                return false;

            return (PartitionHelper(nums, length - 1, halfSum - nums[length - 1])
                || PartitionHelper(nums, length - 1, halfSum));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition_DP_TopDwn(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return false;

            if (nums.Length == 1)
                return false;

            if (nums.Length == 2)
                return nums[0].Equals(nums[1]);

            if (nums.Sum() % 2 != 0)
                return false;

            int halfSum = nums.Sum() / 2;
            int[,] memo = new int[nums.Length+1, halfSum + 1];

            return SubsetDP_TpDwn_Helper(nums, nums.Length, halfSum, memo);
        }

        private bool SubsetDP_TpDwn_Helper(int[] nums, int length, int halfSum, int[,] memo)
        {
            if (halfSum == 0)
                return true;
            if (length < 0 || halfSum < 0)
                return false;
            if (memo[length, halfSum] != 0)
                return (memo[length, halfSum] == 1);

            bool result = SubsetDP_TpDwn_Helper(nums, length - 1, halfSum - nums[length-1], memo)
                || SubsetDP_TpDwn_Helper(nums, length - 1, halfSum, memo);

            memo[length, halfSum] = result ? 1 : 2;
            return result;
        }

        public bool CanPartition_DP_BottomUp(int [] nums)
        {
            if (nums == null || nums.Length == 0)
                return false;

            if (nums.Length == 1)
                return false;

            if (nums.Length == 2)
                return nums[0].Equals(nums[1]);

            if (nums.Sum() % 2 != 0)
                return false;

            int halfSum = nums.Sum() / 2;
            bool[,] memo = new bool[nums.Length + 1, halfSum + 1];

            return CanPartition_DP_BottomUpHelper(nums, halfSum, memo);
        }

        public bool CanPartition_DP_BottomUpArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return false;

            if (nums.Length == 1)
                return false;

            if (nums.Length == 2)
                return nums[0].Equals(nums[1]);

            if (nums.Sum() % 2 != 0)
                return false;

            int halfSum = nums.Sum() / 2;
            bool[,] memo = new bool[nums.Length + 1, halfSum + 1];

            List<bool> lst = CanPartition_DP_BottomUp_ReturnElementsArray(nums, halfSum, memo);
            return false;
        }

        private bool CanPartition_DP_BottomUpHelper(int[] nums, int halfSum, bool[,] memo)
        {
            memo[0, 0] = true;            
           
            for(int i=1;i<nums.Length+1;i++)
            {
                for(int j=0;j<halfSum+1;j++)
                {
                    if(nums[i-1]>j)
                    {
                        memo[i, j] = memo[i - 1, j];
                    }
                    else
                    {
                        memo[i, j] = memo[i - 1, j] || memo[i - 1, j - nums[i - 1]];
                        
                    }
                }
            }

            return memo[nums.Length, halfSum];
        }

        private List<bool> CanPartition_DP_BottomUp_ReturnElementsArray(int[] nums, int halfSum, bool[,] memo)
        {
            List<bool> lst = new List<bool>();

            memo[0, 0] = true;

            for (int i = 1; i < nums.Length + 1; i++)
            {
                for (int remSum = 0; remSum < halfSum + 1; remSum++)
                {
                    if (nums[i - 1] > remSum)
                    {
                        memo[i, remSum] = memo[i - 1, remSum];
                    }
                    else
                    {
                        memo[i, remSum] = memo[i - 1, remSum] || memo[i - 1, remSum - nums[i - 1]];
                    }
                }
            }

            if (!memo[nums.Length, halfSum])
            {
                return lst;
            }

            int count = 0;
            int idx = nums.Length-1;
            while (idx >= 0)
            {

                if(idx!=0)
                {
                    if(memo[nums.Length, halfSum] 
                        && memo[nums.Length-1, halfSum])
                    {
                        lst.Add(true);
                        count++;
                        halfSum -= nums[idx];
                        if (halfSum == 0)
                            break;
                    }
                }
                else
                {
                    lst.Add(true);
                }

                idx--;
            }

            return lst; // memo[nums.Length, halfSum];
        }

        /// <summary>
        /// When index of nums 0 means all elements are used. 
        /// when index = array.Length then no element in a set is used.
        /// recurssive starts with 0 index and increments by one 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="halfSum"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        private bool CanPartition_DP_BottomUp(int[] nums, int halfSum)
        {
            // Declare dp type and size
            // row number is number of array indexes and column is half sum 
            // its len+1 and halfsum+1 because 0,0 is initialized value or known value. remaining is unknown value.
            bool[,] dp = new bool[nums.Length + 1, halfSum + 1];

            //initialize the dp
            //0,0 will be true and then zero column means 0 sum, it can be made possible 
            //with empty subset meaning any index value.
            // and sum 1,2,3,4...11 is always false for the no elements in the subset.
            
            //with zero sum, empty subset or more than one subset are always true
            for(int i=0;i<nums.Length+1;i++)
            {
                dp[i,0] = true;
            }

            //with empty subset , any sum value is false
            for (int i = 0; i < halfSum + 1; i++)
            {
                dp[nums.Length, i] = false;
            }

            //main logic , this will follow same as recursion. 
            // Check below element and below element -1. attack from bottom
            for(int i=nums.Length-1;i>=0;i--)
            {
                for(int sum=1;sum<halfSum+1;sum++)
                {
                    bool result = false;
                    //check the bottom values in or condition.
                    //also have if condition to check sum greater than nums[i-1]
                    if(sum>=nums[i])
                    {
                        result = dp[i + 1, sum - nums[i]];
                    }
                    dp[i, sum] = result || dp[i + 1, sum];
                }
            }

            return dp[0, halfSum];
        }
    }
}
