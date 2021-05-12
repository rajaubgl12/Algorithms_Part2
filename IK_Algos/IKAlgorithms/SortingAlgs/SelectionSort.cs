using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    public class SelectionSortAlg
    {
        public int [] SelectionSort(int [] a)
        {
            for(int i=0;i<a.Length;i++)
            {
                int min = i;
                for(int j=i+1;j<a.Length;j++)
                {
                    if(a[min]>a[j])
                    {
                        //get the min element index
                        min = j;
                    }    
                }

                // swap the min element with first ith index element.
                int temp = a[min];
                a[min] = a[i];
                a[i] = temp;
            }

            return a;
        }

      
    }
}
