using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsArrayStrings.Amazon
{
    public class ProductOfArrayExceptSelf
    {
        public int [] ProductSelf(int [] nums)
        {
            int[] result = new int[nums.Length];
            int left = 1;
            for(int i =0; i<nums.Length;i++)
            {
                result[i] = left;
                left = left * nums[i];
            }

            int right = 1;
            for(int i =nums.Length-1;i>-1;i--)
            {
                result[i] = result[i] * right;
                right = right * nums[i];
            }

            return result;
        }
    }
}
