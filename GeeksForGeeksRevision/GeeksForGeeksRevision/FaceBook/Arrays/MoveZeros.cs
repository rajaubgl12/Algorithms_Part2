using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.FaceBook.Arrays
{
    /// <summary>
    /*
        //Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
        //Example:
        //Input: [0,1,0,3,12]
        //Output: [1,3,12,0,0]
        //Note:
        //1.	You must do this in-place without making a copy of the array.
        //2.	Minimize the total number of operations.
        //Logic:
        //a)	Loop through the array
        //b)	If a[i]!=0 copy to an existing array and increment the count from zero
        //c)	And copy the zeros to remaining elements of the array.
    */
    /// </summary>
    public class MoveZerosCls
    {
        public void MoveZeros(int[] nums)
        {
            int nonZeroCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[nonZeroCount++] = nums[i];
                }
            }
            while (nonZeroCount < nums.Length)
            {
                nums[nonZeroCount++] = 0;
            }
        }
    }
}
