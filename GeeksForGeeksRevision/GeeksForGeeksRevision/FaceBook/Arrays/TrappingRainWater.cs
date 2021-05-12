using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.FaceBook.Arrays
{
    /// <summary>
    /// Input: [0,1,0,2,1,0,1,3,2,1,2,1]
    ///Output: 6
    ///
    /*
     *Logic:
     * 1. Find the highest bar on left store in an array and right side store in a second array.
     * 2. Get the difference between min of right and left array - current array element.
     *
    */
    /// </summary>
    public class TrappingRainWater
    {
        // Method for maximum amount of water 
        public int Trap(int[] arr)
        {
            int n = arr.Length;
            // left[i] contains height of tallest bar to the 
            // left of i'th bar including itself 
            int[] left = new int[n];

            // Right [i] contains height of tallest bar to 
            // the right of ith bar including itself 
            int[] right = new int[n];

            // Initialize result 
            int water = 0;

            // Fill left array 
            left[0] = arr[0];
            for (int i = 1; i < n; i++)
                left[i] = Math.Max(left[i - 1], arr[i]);

            // Fill right array 
            right[n - 1] = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
                right[i] = Math.Max(right[i + 1], arr[i]);

            // Calculate the accumulated water element by element 
            // consider the amount of water on i'th bar, the 
            // amount of water accumulated on this particular 
            // bar will be equal to min(left[i], right[i]) - arr[i] . 
            for (int i = 0; i < n; i++)
            {
                water = water+ Math.Min(left[i], right[i]) - arr[i];
            }
                

            return water;
        }

        /// <summary>
        /// Since water trapped at any element = min( max_left, max_right) – arr[i] we will calculate 
        /// water trapped on smaller element out of A[lo] and A[hi] first and move the pointers till lo doesn’t cross hi.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int TrapOptmz(int[] arr)
        {
            int leftMax = 0;
            int rightMax = 0;
            int trapedWaterCount = 0;
            int low = 0;
            int high = arr.Length - 1;

            while(low<high)
            {
                if(arr[low]<arr[high])
                {
                    if(leftMax<arr[low])
                    {
                        leftMax = arr[low];
                    }
                    else
                    {
                        trapedWaterCount = trapedWaterCount + (leftMax - arr[low]);
                    }
                    low++;
                }
                else
                {
                    if(rightMax < arr[high])
                    {
                        rightMax = arr[high];
                    }
                    else
                    {
                        trapedWaterCount = trapedWaterCount + (rightMax-arr[high]);
                    }
                    high--;
                }
            }
            return trapedWaterCount;
        }
    }
}
