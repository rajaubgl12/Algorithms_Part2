using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    public class Pair
    {
        public int a;
        public int b;
        public Pair(int a1, int a2)
        {
            this.a = a1;
            this.b = a2;
        }
    }

   public class MaxLenChainPairs
    {
        public int MaxChainLength(Pair [] pairs)
        {
                       

            int[] LIS = new int[pairs.Length];
            for (int i = 0; i < pairs.Length; i++)
            {
                LIS[i] = 1;
            }
            for (int i=0;i<pairs.Length;i++)
            {
                for(int j=0;j<i;j++)
                {
                    if(pairs[i].a>pairs[j].b&&LIS[i]<LIS[j]+1)
                    {
                        LIS[i] = LIS[j] + 1;
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
