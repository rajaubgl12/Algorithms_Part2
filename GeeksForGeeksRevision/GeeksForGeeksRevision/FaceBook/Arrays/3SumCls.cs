using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.FaceBook.Arrays
{
    /// <summary>
    /// 
    ////*
    ///Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? 
    ///Find all unique triplets in the array which gives the sum of zero.
        /*Note:

        The solution set must not contain duplicate triplets.

        Example:

        Given array nums = [-1, 0, 1, 2, -1, -4],

        A solution set is:
        [
          [-1, 0, 1],
          [-1, -1, 2]
        ]
        Logic:
        1. Sort all element of array
        2. Run loop from i=0 to n-2.
             Initialize two index variables l=i+1 and r=n-1
        4. while (l < r) 
             Check sum of arr[i], arr[l], arr[r] is
             zero or not if sum is zero then print the
             triplet and do l++ and r--.
        5. If sum is less than zero then l++
        6. If sum is greater than zero then r--
        7. If not exist in array then print not found.
        */
    /// */
    /// </summary>
   public class ThreeSumCls
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            IList<IList<int>> lst3Sum = new List<IList<int>>(); 
            for (int i=0;i<n-2;i++)
            {
                //initialize left and right
                int lSecond = i + 1;
                int rThird = n - 1;
                while(lSecond < rThird)
                {
                    int sum = nums[i] + nums[lSecond] + nums[rThird];
                    if(sum==0)
                    {
                        IList<int> lst = new List<int>();
                        lst.Add(nums[i]);
                        lst.Add(nums[lSecond]);
                        lst.Add(nums[rThird]);
                        lst3Sum.Add(lst);
                        lSecond++;
                        rThird--;
                    }
                    //if sum is less than zero then increment left index
                    if(sum<0)
                    lSecond++;
                    //the decrement positive number
                    else                   
                    rThird--;
                }
            }

            return lst3Sum;
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            var n = nums.Length;

            var globalClosest = int.MaxValue;
            var globalSum = 0;
            for (int i = 0; i < n; i++)
            {
                var left = i + 1;
                var right = n - 1;

                while (left < right)
                {
                    var sum = nums[i] + nums[left] + nums[right];
                    var localClosest = Math.Abs(sum - target);
                    if (sum == target)
                    {
                        return target;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }

                    if (globalClosest > localClosest)
                    {
                        globalClosest = localClosest;
                        globalSum = sum;
                    }
                }

            }

            return globalSum;
        }

        public IList<IList<int>> ThreeSum(int[] a, int sum)
        {
            var lst = new List<IList<int>>();
            Array.Sort(a);
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == a[i - 1])
                    continue;

                // int tempSum = sum - a[i];
                HashSet<int> hashValues = new HashSet<int>();
                for (int j = i + 1; j < a.Length; j++)
                {
                    var trplValues = new List<int>();
                    int tempSum = a[i] + a[j];
                    if (hashValues.Contains(sum - tempSum))
                    {
                        trplValues.Add(a[i]);
                        trplValues.Add(a[j]);
                        trplValues.Add(sum - tempSum);
                    }
                    hashValues.Add(a[j]);
                    if (trplValues != null && trplValues.Count > 0)
                        lst.Add(trplValues);
                }
            }
            return lst;
        }

    }
}
