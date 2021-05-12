using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision
{
    class ArraysAlgorithms
    {
        
        // Method for maximum amount of water
        public static int FindWater(int [] arr, int n)
        {
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
                water += Math.Min(left[i], right[i]) - arr[i];

            return water;
        }

        public static void ReverseArrayInGroup(int [] a, int k)
        {
            int left = 0;
            int right = 0;
            for(int i=0;i<a.Length;i=i+k)
            {
                left = i;
                right = Math.Min(i + k - 1, a.Length - 1);
                while(left<=right)
                {
                    int temp = a[left];
                    a[left] = a[right];
                    a[right] = temp;
                    left++;
                    right--;
                }
            }
        }

        //https://www.geeksforgeeks.org/minimum-number-platforms-required-railwaybus-station/
        public static int MaximumPlatformNeeded(int [] a, int [] d)
        {            
            int j = 0;
            int i = 0;            
            int platformCount = 1;
            Array.Sort(a);
            Array.Sort(d);
            while (i<a.Length&&j<d.Length)
            {                 
                if (d[j]>=a[i])
                {
                    platformCount++;
                    i++;                                        
                }
                else
                {
                    platformCount--;
                    j++;
                }
            }
            return platformCount;
        }

        //An element is leader if its greater 
        //than all the elements to its right side.
        public static void LeadersArray(int [] a)
        {
            int maxNum = 0;
            for(int i =a.Length-1;i>=0;i--)
            {
                if(maxNum<a[i])
                {
                    maxNum = a[i];
                    Console.WriteLine(maxNum);
                }
            }
        }

        // maxSumIS() returns the 
        // maximum sum of increasing
        // subsequence in arr[] of size n 
        //

        /* 1. copy the original array to new copy.
         * 2. sum up the value in increasing order
         * 2. skip the bigger number in between
         * 3. store in the copy 
         * 4. Iterate to get the bigger number.
         * */
        public static int MaximumIncreasingSubSeq1(int[] arr)
        {
            //copy the array
            
            int[] findMaxSum = new int[arr.Length];
            Array.Copy(arr, findMaxSum,arr.Length);
            
            for (int i = 1; i < arr.Length; i++)
                for (int j = 0; j < i; j++)
                    if (arr[i] > arr[j] )
                        findMaxSum[i] = arr[i] + findMaxSum[j];

            int maxSum = 0;
            for(int i=0;i<findMaxSum.Length;i++)
            {
                if (maxSum < findMaxSum[i])
                    maxSum = findMaxSum[i];
            }
            return maxSum;
           // //copy array to another array

                        // int n = arr.Length;
                        // int[] msis = new int[n];

                        // /* Initialize msis values
                        //    for all indexes */
                        // Array.Copy(arr, msis, n);

                        // /*Compute maximum sum values
                        //in bottom up manner */
                        // for (int i = 1; i < n; i++)
                        //     for (int j = 0; j < i; j++)
                        //         if (arr[i] > arr[j] &&
                        //             msis[i] < msis[j] + arr[i])
                        //             msis[i] = msis[j] + arr[i];
                        // int maxSum = 0;
                        // for (int i = 0; i < msis.Length; i++)
                        // {
                        //     if (maxSum < msis[i])
                        //     {
                        //         maxSum = msis[i];
                        //     }
                        // }
                        // return maxSum;
        }

        public static int MaximumIncreasingSubSeq(int [] nums)
        {
            if (nums.Length == 0) return 0;
            int[] tails = new int[nums.Length];
            int size = 1;
            tails[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > tails[size - 1])
                    tails[size++] = nums[i]; //case 1, n is bigger than all
                if (nums[i] < tails[0])
                    tails[0] = nums[i];
                tails[BinarySearch(tails, -1, size - 1, nums[i])] = nums[i];
            }
            return size;
        }

        private static int BinarySearch(int[] arr, int l, int r, int key)
        {
            while ((r - l) > 1)
            {
                int m = l + (r - l) / 2;
                if (arr[m] >= key) r = m;
                else l = m;
            }
            return r;

        }

        public static int EquilibriumIndex(int[] a)
        {
            for (int i = 0; i < a.Length / 2; i++)
            {
                int count = i;
                int leftI = 0;

                int leftSum = 0;
                int rightSum = 0;
                while (leftI <= i)
                {
                    leftSum += a[leftI];
                    leftI++;
                }
                int middleIndex = leftI++;
                while (count >= 0)
                {
                    rightSum += a[leftI];
                    leftI++;
                    count--;
                }
                if (leftSum == rightSum)
                    return middleIndex;
            }
            return -1;
        }

        static int equilibrium(int[] arr, int n)
        {
            // initialize sum of whole array
            int sum = 0;

            // initialize leftsum
            int leftsum = 0;

            /* Find sum of the whole array */
            for (int i = 0; i < n; ++i)
                sum += arr[i];

            for (int i = 0; i < n; ++i)
            {

                // sum is now right sum
                // for index i
                sum -= arr[i];

                if (leftsum == sum)
                    return i;

                leftsum += arr[i];
            }

            /* If no equilibrium index found, 
            then return 0 */
            return -1;
        }

        // Sort the input array, the array is assumed to
        // have values in {0, 1, 2}
        public static void sort012(int[] a, int arr_size)
        {
            int lo = 0;
            int hi = arr_size - 1;
            int mid = 0, temp = 0;

            while (mid <= hi)
            {
                switch (a[mid])
                {
                    case 0:
                        {
                            temp = a[lo];
                            a[lo] = a[mid];
                            a[mid] = temp;
                            lo++;
                            mid++;
                            break;
                        }
                    case 1:
                        mid++;
                        break;
                    case 2:
                        {
                            temp = a[mid];
                            a[mid] = a[hi];
                            a[hi] = temp;
                            hi--;
                            break;
                        }
                }
            }
        }
        // Returns true if the 
        // there is a subarray of 
        // arr[] with sum equal to
        // 'sum' otherwise returns false. 
        // Also, prints the result

        public static int subArraySum(int[] arr, 
                                   int sum)
        {
            int n = arr.Length;
            int curr_sum = arr[0],
                     start = 0, i;

            // Pick a starting point
            for (i = 1; i <= n; i++)
            {
                // If curr_sum exceeds  
                // the sum, then remove
                // the starting elements
                while (curr_sum > sum &&
                       start < i - 1)
                {
                    curr_sum = curr_sum -
                               arr[start];
                    start++;
                }

                // If curr_sum becomes equal to
                // sum, then return true
                if (curr_sum == sum)
                {
                    int p = i - 1;
                    Console.WriteLine("Sum found between " +
                                         "indexes " + start +
                                               " and " + p);
                    return 1;
                }

                // Add this element to curr_sum
                if (i < n)
                    curr_sum = curr_sum + arr[i];

            }
            Console.WriteLine("No subarray found");
            return 0;
        }
        public static int LargestSumContiguousArray(int[] a)
        {
            int maxSumSoFar = 0;
            int maxSumEndsHere = 0;
            
            for (int i = 0; i < a.Length; i++)
            {
                maxSumEndsHere += a[i];
                if (maxSumEndsHere < 0)
                    maxSumEndsHere = 0;

                if (maxSumEndsHere > maxSumSoFar)
                {
                    maxSumSoFar = maxSumEndsHere;
                }
            }

            return maxSumSoFar;
        }
    }
}
