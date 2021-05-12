using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    public class BubbleSortAlg
    {
        public int[] BubbleSort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
              
            }

            return a;
        }
    }
}
