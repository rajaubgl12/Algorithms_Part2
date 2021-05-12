using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    class MaxSumIncreasingSubSeq
    {
        public int MaxSumIncSubSeq(int[] a)
        {
            int maxSum = 0;
            int[] maxSumArray = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                maxSumArray[i] = a[i];
            }

            for (int i = 1; i < a.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    
                    if (a[i] > a[j] && maxSumArray[i] < maxSumArray[j] + a[i])
                    {
                        maxSumArray[i] = maxSumArray[j] + a[i];
                    }
                }
            }
            for(int i =0; i<maxSumArray.Length;i++)
            {
                if(maxSum<maxSumArray[i])
                {
                    maxSum = maxSumArray[i];
                }
            }
            return maxSum;
        }
    }
}
