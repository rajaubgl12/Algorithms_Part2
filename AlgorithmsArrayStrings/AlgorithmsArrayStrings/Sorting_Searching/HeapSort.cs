using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsArrayStrings.Sorting_Searching
{
    public class HeapSortClass
    {
        public void HeapSort(int [] arr)
        {
            //Build heap 
            int len = arr.Length;
            for (int i = len / 2 -1; i >= 0; i--)
                Heapify(arr,arr.Length, i);

            //one by one extract root node from heap
            for (int i = len - 1; i >= 0; i--)
            {
                //Move current root to end.
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                //call maxheapfy on the reduced heap.
                Heapify(arr, i, 0);
            }

        }

        private void Heapify(int[] arr, int size, int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;
            if (left < size && arr[largest] < arr[left])
            {
                largest = left;
            }
            if (right < size && arr[largest] < arr[right])
            {
                largest = right;
            }
            if (i != largest)
            {
                //swap the nodes
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                //recursively heapify the effected sub tree.
                Heapify(arr, size, largest);
            }
        }
    }

   
}
