using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProramming.GeeksGeeks
{
   public class AlgosGeeks
    {
        public void GenerateAllBinaryStrings(int n)
        {
            int low = 0;
            int high = n;
            int[] A = new int[n];
            GenerateAllBinaryStringsHelper(A, low,high);
        }

        private void GenerateAllBinaryStringsHelper(int[] a, int low, int high)
        {
            if(low==high)
            {
                for(int i=0;i<a.Length;i++)
                {
                    Console.Write(a[i]);
                }
                Console.WriteLine("----------");
            }
            
            else
            {
                a[low] = 0;
                GenerateAllBinaryStringsHelper(a, low + 1, high);

                a[low] = 1;
                GenerateAllBinaryStringsHelper(a, low + 1, high);
            }
        }
    }
}
