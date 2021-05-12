using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsArrayStrings.Amazon
{
    /// <summary>
    /// https://leetcode.com/problems/container-with-most-water/
    /// The intuition behind this approach is that the area formed between the 
    /// lines will always be limited by the height of the shorter line.
    /// Further, the farther the lines, the more will be the area obtained.
    ///We take two pointers, one at the beginning and one at the end of the array constituting
    ///the length of the lines.Futher, we maintain a variable \text{maxarea}
    ///maxarea to store the maximum area obtained till now.At every step, we find out the area 
    ///formed between them, update \text{maxarea}maxarea and move the pointer pointing to the shorter 
    ///line towards the other end by one step.

    ///The algorithm can be better understood by looking at the example below:
    /// </summary>
    public class ContainerWithWater
    {
        public int ContainerWithMostWaterI(int [] a)
        {
            int maxWater = 0;
            int startIndex = 0;
            int endIndex = a.Length - 1;
            while (startIndex < endIndex)
            {
               int minContainerLen = Math.Min(a[startIndex], a[endIndex]);
                maxWater = Math.Max(maxWater, (endIndex - startIndex) * minContainerLen);
                if (a[startIndex] < a[endIndex])
                    startIndex++;
                else
                    endIndex--;
            }
            return maxWater;
        }


        /// <summary>
        /// For each element in the array, we find the maximum level of water it can trap after the rain,
        /// which is equal to the minimum of maximum height of bars on both the sides minus its own height
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int ContainerWithMostWaterII(int[] a)
        {
            int maxWater = 0;
            int[] leftMax = new int[a.Length];
            int[] rightMax = new int[a.Length];
            int leftMaxVal = a[0];
            int rightMaxVal = a[0];
            for (int i=0;i<a.Length;i++)
            {
                leftMaxVal = Math.Max(leftMaxVal, a[i]);
                leftMax[i] = leftMaxVal;
            }

            for (int i = a.Length - 1; i > -1; i--)
            {
                rightMaxVal= Math.Max(rightMaxVal, a[i]);
                rightMax[i] = rightMaxVal;
            }

            for (int i = 0; i < a.Length; i++)
            {
                maxWater +=  Math.Min(rightMax[i], leftMax[i])-a[i];
            }
            return maxWater;
        }
    }
}
