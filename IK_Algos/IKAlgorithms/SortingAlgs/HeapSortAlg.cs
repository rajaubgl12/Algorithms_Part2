using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.SortingAlgs
{

    /// <summary>
    /// Heap Sort Algorithm for sorting in increasing order:
    ///1. Build a max heap from the input data.
    ///2. At this point, the largest item is stored at the root of the heap.
    ///Replace it with the last item of the heap followed by reducing the size of heap by 1. 
    ///Finally, heapify the root of the tree.
    ///3. Repeat step 2 while size of heap is greater than 1.
    ///https://www.geeksforgeeks.org/heap-sort/
    ///https://www.youtube.com/watch?v=Q_eia3jC9Ts&t=632s
    ///
    /// </summary>
    public class HeapSortAlg
    {
        public void HeapifySort(int [] arr)
        {
            int n = arr.Length-1;
            //Build max heap from the input data.
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                HeapifyArray(arr, n, i);
            }

            //Delete the root 
            for(int i=n;i>=0;i--)
            {
                //move the root to end.
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                // push bigger element to last and call max heap on the reduced map.
                HeapifyArray(arr, i-1, 0);
            }
        }

        private void HeapifyArray(int[] arr, int n, int i)
        {
            int largest = i;
            int left = i * 2 + 1;
            int right = i * 2 + 2;

            if (left <= n && arr[left] > arr[largest])
            {
                largest = left;
            }
            if (right <= n && arr[right] > arr[largest])
            {
                largest = right;
            }

            if(largest!=i)
            {
                //swap 
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                HeapifyArray(arr, n, largest);
            }
        }
    }
}
