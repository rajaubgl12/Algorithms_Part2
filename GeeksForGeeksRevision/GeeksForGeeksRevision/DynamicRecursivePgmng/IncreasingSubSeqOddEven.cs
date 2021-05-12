using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    class IncreasingSubSeqOddEvenCls
    {
        public int IncreasingSubSeqOddEven(int [] a)
        {
            
            int[] LIS = new int[a.Length];
            for(int i=0;i<a.Length;i++)
            {
                LIS[i] = 1;
            }

            for(int i =1;i<a.Length;i++)
            {
                for(int j=0;j<i;j++)
                {
                        //odd+even = always a odd number.
                        if (a[i] > a[j] && LIS[i] < LIS[j] + 1 && (a[i]+a[j])%2!=0)
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
    }
}
