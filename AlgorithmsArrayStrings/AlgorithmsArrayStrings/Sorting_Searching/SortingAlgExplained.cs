using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsArrayStrings.Sorting_Searching
{
    class SortingAlgExplained
    {
    }
}
/*
 * https://www.geeksforgeeks.org/time-complexities-of-all-sorting-algorithms/
 * https://www.youtube.com/watch?v=HqPJF2L5h9U
 * 
Algorithm Time Complexity
                Best            Average              Worst
Selection Sort  Ω(n^2)           θ(n^2)              O(n^2)

Bubble Sort     Ω(n)             θ(n^2)              O(n^2)

Insertion Sort  Ω(n)             θ(n^2)              O(n^2)

Quick Sort      Ω(n log(n))      θ(n log(n))         O(n^2)

Heap Sort       Ω(n log(n))      θ(n log(n))         O(n log(n))
Merge Sort      Ω(n log(n))      θ(n log(n))         O(n log(n))

Bucket Sort     Ω(n+k)           θ(n+k)              O(n^2)
Radix Sort      Ω(nk)            θ(nk)               O(nk)
*/

/*
 * Selection Sort
 * The selection sort algorithm sorts an array by repeatedly 
 * finding the minimum element (considering ascending order) from unsorted part and putting it at the beginning. 
 * The algorithm maintains two subarrays in a given array.

 1) The subarray which is already sorted.
 2) Remaining subarray which is unsorted.

 In every iteration of selection sort, the minimum element (considering ascending order) from the unsorted subarray 
 is picked and moved to the sorted subarray.
 * arr[] = 64 25 12 22 11

// Find the minimum element in arr[0...4]
// and place it at beginning
11 25 12 22 64

// Find the minimum element in arr[1...4]
// and place it at beginning of arr[1...4]
11 12 25 22 64

// Find the minimum element in arr[2...4]
// and place it at beginning of arr[2...4]
11 12 22 25 64

// Find the minimum element in arr[3...4]
// and place it at beginning of arr[3...4]
11 12 22 25 64 
 * */

/*
 * Bubble Sort
Bubble Sort is the simplest sorting algorithm that works by repeatedly
swapping the adjacent elements if they are in wrong order.

 * /
 * 
 * /*
     * Insertion Sort
    Insertion sort is a simple sorting algorithm that works the way we sort playing cards in our hands.
    Algorithm
    // Sort an arr[] of size n
    insertionSort(arr, n)
    Loop from i = 1 to n-1.
    ……a) Pick element arr[i] and insert it into sorted sequence arr[0…i-1]

 * /
}

    Merge Sort:
    ----------------
    MergeSort(arr[], l,  r)
If r > l
     1. Find the middle point to divide the array into two halves:  
             middle m = (l+r)/2
     2. Call mergeSort for first half:   
             Call mergeSort(arr, l, m)
     3. Call mergeSort for second half:
             Call mergeSort(arr, m+1, r)
     4. Merge the two halves sorted in step 2 and 3:
             Call merge(arr, l, m, r)
}
*/
