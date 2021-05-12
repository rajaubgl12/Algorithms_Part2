using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    public class InsertionSortAlg
    {
        /// <summary>
        /// move the small key ahead index by index 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int [] InsertionSort(int [] a)
        {
            for(int i=1;i<a.Length;i++)
            {
                int key = a[i];
                int j = i - 1;

                while (j >= 0 && key < a[j])
                {
                    //do a right shift
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = key;
            }

            return a;
        }
        public int[] SelectionSortMyCode(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                int key = a[i];

                int j = i - 1;

                while (j >= 0 && a[j] > key)
                {
                    //right shift the value
                    a[j + 1] = a[j];
                    j--;
                }
                //place the element picked from unsorted array to place holder
                a[j + 1] = key;

            }

            return a;
        }
    }
}
