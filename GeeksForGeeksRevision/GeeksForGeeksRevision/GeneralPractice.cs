using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision
{
    class GeneralPractice
    {        

        public int RainWaterSet1(int [] a)
        {
            //int res = MaxArea(a);
            int startIndex = 0;
            int endIndex = a.Length - 1;
            int maxWater = int.MinValue;
            

            while (startIndex < endIndex)
            {
                int minValue = Math.Min(a[startIndex], a[endIndex]);
                int diffIndex = endIndex - startIndex;
                maxWater = Math.Max(maxWater, minValue * (diffIndex));


                if(a[startIndex] < a[endIndex])
                {

                    startIndex++;
                }
                else
                {

                    endIndex--;
                }

            }

            return maxWater;
        }

        public int MaxProduct(int[] nums)
        {
            int max = nums[0];

            // iterate from left
            int curr = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                curr *= nums[i];

                if (curr > max) max = curr;

                if (curr == 0) curr = 1;
            }

            // iterate from right
            curr = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                curr *= nums[i];

                if (curr > max) max = curr;

                if (curr == 0) curr = 1;
            }

            return max;
        }

    }
}
