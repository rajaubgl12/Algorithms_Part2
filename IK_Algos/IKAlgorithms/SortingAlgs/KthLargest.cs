using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.SortingAlgs
{
   public class KthLargest
    {

        /// <summary>
        /// 1, 5, 4, 4, 2 ans 4,5
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] topK(int[] arr, int k)
        {
             FindKthLargest(arr, arr.Length);
            int[] newArr = new int[k];
            for(int i=0;i<k;i++)
            {
                newArr[i] = arr[i];
            }
            return newArr;
        }

        public void FindKthLargest(int[] nums, int k)
        {

            //build min Heap O(k)
            for (int j = (k / 2) - 1; j >= 0; j--)
            {
                Minheapify(nums, j, k);
            }

            //(n-k)log(k)
            for (int i = k-1; i >=0; i--)
            {
                //if (nums[0] < nums[i])
                {
                    Swap(nums, 0, i);
                    Minheapify(nums, 0, i);
                }
            }
            
        }

        public void Minheapify(int[] nums, int index, int k)
        {
            var left = (2 * index) + 1;
            if (left >= k)
            {
                return;
            }
            var right = (2 * index) + 2;
            if (right >= k || nums[left] < nums[right])
            {
                if (nums[left] < nums[index])
                {
                    Swap(nums, left, index);
                    Minheapify(nums, left, k);
                }
            }
            else
            {
                if (nums[right] < nums[index])
                {
                    Swap(nums, right, index);
                    Minheapify(nums, right, k);
                }
            }
        }

        private void Swap(int[] nums, int child, int parent)
        {
            var temp = nums[child];
            nums[child] = nums[parent];
            nums[parent] = temp;
        }

    }
}
