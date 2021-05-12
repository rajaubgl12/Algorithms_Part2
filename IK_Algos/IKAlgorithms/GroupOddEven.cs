using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    public class GroupOddEven
    {
        public static int[] solve(int[] arr)
        {
            //two pointer system
            int left = 0;
            int right = arr.Length - 1;

            while(left<right)
            {
                while (arr[left] % 2 == 0 && left < right)
                {
                    left++;
                }

                while (arr[right] % 2 != 0 && right > left)
                {
                    right--;
                }

                if(left<right)
                {
                    //swap
                    int odd = arr[left];
                    arr[left] = arr[right];
                    arr[right] = odd;
                    right--;
                    left++;
                }
            }

            return arr;
        }
    }
}
