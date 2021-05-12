using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.IK_TimedTests
{
   public class RecursionTest
    {
        public static bool check_if_sum_possible(long[] arr, long k)
        {
            int currSum = 0;
            int startIndex = 0;
           return checksum(arr, k, currSum, startIndex);
        }

        private static bool checksum(long[] arr, long targetSum, long currSum, int startIndex)
        {
            if (currSum > targetSum)
                return false;
            if (currSum == targetSum)
                return true;
            for(int i=startIndex;i<arr.Length;i++)
            {
                checksum(arr, targetSum, currSum + arr[i], startIndex + 1);
            }

            return false;
        }
    }
}
