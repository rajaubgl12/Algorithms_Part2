using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.SortingAlgs
{
    public class QuickSortAlg
    {
        public int [] QuickSort(int [] a)
        {
             QuickSortHelper(a, 0, a.Length-1);
            return a;
        }

        private void QuickSortHelper(int[] a, int start, int end)
        {
            if(start<end)
            {
                int pi = QuickSortPivot(a, start, end);

                QuickSortHelper(a, start, pi - 1);

                QuickSortHelper(a, pi+1, end);
            }

            
        }

        /// <summary>
        /// https://www.geeksforgeeks.org/quick-sort/
        /// </summary>
        /// <param name="a"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private int QuickSortPivot(int[] a, int start, int end)
        {
            int pivot = a[end];
            int left = start-1;
            int right = start;

            for (int i = start; i < end; i++)
            {
                if (a[i] <= pivot)
                {
                    left++;
                    //swap elements
                    int temp = a[i];
                    a[i] = a[left];
                    a[left] = temp;
                }
            }

            //swap the pivot element.
            int temp1 = a[left + 1];
            a[left + 1] = pivot;
            a[end] = temp1;
            return left + 1;
        }
    }
}
