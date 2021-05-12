using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.Microsoft.Arrays
{
    class General
    {
        public bool CheckZeroSumSubArrayExists(int [] a)
        {
            for(int i=0;i<a.Length;i++)
            {
                int sum = a[i];
                for(int j=i+1;j<a.Length;j++)
                {
                    sum = sum + a[j];
                    if(sum==0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool subArrayExists(int[] arr)
        {
            // Creates an empty hashMap hM 
            Dictionary<int,
                       int> hM = new Dictionary<int,
                                                int>();
            // Initialize sum of elements 
            int sum = 0;

            // Traverse through the given array 
            for (int i = 0; i < arr.Length; i++)
            {
                // Add current element to sum 
                sum += arr[i];

                // Return true in following cases 
                // a) Current element is 0 
                // b) sum of elements from 0 to i is 0 
                // c) sum is already present in hash map 
                if (arr[i] == 0 || sum == 0)
                    return true;
                // if sum is seen before, we have found a sub-array with 0 sum
                if (hM.ContainsKey(sum))
                {
                    return true;
                }

                // insert sum so far into set
                hM.Add(sum,i);
                // Add sum to hash map 
               // hM[i] = sum;
            }

            // We reach here only when there is 
            // no subarray with 0 sum 
            return false;
        }
    }
}
