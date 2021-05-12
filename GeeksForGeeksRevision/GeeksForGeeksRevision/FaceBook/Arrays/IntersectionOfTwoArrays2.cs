using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.FaceBook.Arrays
{
    /// <summary>
    /// 
    /// Given two arrays, write a function to compute their intersection.
        /*Example 1:
        Input: nums1 = [1,2,2,1], nums2 = [2,2]
        Output: [2,2]
        Example 2:
        Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        Output: [4,9]
        Note:
        •	Each element in the result should appear as many times as it shows in both arrays.
        •	The result can be in any order.
        Follow up:
        •	What if the given array is already sorted? How would you optimize your algorithm?
        •	What if nums1's size is small compared to nums2's size? Which algorithm is better?
        •	What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements into the memory at once?
        ________________________________________

        Logic: 
        a)  Copy the one(smaller) array to Dictionary
        b)	Have a list, run through the other array if values contain in the dictionary add to list.
        c)	Return the list.
        */
    /// </summary>
    public class IntersectionOfTwoArrays2
    {
        public int[] ArrayIntersect(int[] nums1, int[] nums2)
        {
            //find ou the shorter array
            int[] shorter = nums1.Length < nums2.Length ? nums1 : nums2;
            int[] longer = nums1.Length < nums2.Length ? nums2 : nums1;
            //define a dictionary
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in shorter)
            {
                dict[num] = 1;
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict[num] = 1;
            }
            IList<int> intersection = new List<int>();
            foreach (int num in longer)
            {
                if (dict.ContainsKey(num) && dict[num] > 0)
                {
                    intersection.Add(num);
                    dict[num]--;
                }

            }
            //convert hashset type to array type
            return intersection.ToArray();
        }
    }
}
