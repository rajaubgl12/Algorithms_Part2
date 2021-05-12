using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.FaceBook.BackTracking
{
    /// <summary>
    /// Also check Gayle lakmann solution
    /// </summary>
   public class PermuteString
    {
        /** 
   * permutation function 
   * @param str string to  
      calculate permutation for 
   * @param l starting index 
   * @param r end index 
   * https://www.youtube.com/watch?v=AfxHGNRtFac
   */
        public void Permute(string str)
        {
            int index = 0;
            PermuteSub(str, index,0);
        }
        /// <summary>
        /// https://www.youtube.com/watch?v=AsxVqSKPo40
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        private void PermuteSub(string str, int index, int count)
        {
            
            if (index == str.Length - 1)
                Console.WriteLine(str);

            for (int i = index; i < str.Length; i++)
            {
                count++;
                //swap elements
                str = Swap(str, index, i);

                //explore
                PermuteSub(str, index + 1,count);

                //swap again
                str = Swap(str, index, i);
            }
        }


        /** 
        * Swap Characters at position 
        * @param a string value 
        * @param i position 1 
        * @param j position 2 
        * @return swapped string 
        */
        private string Swap(string str, int index, int i)
        {
            char[] charArray = str.ToCharArray();
            char temp = charArray[i];
            charArray[i] = charArray[index];
            charArray[index] = temp;
            return new string(charArray);
        }


        public IList<IList<int>> Permute(int[] nums)
        {
            List<List<int>> returnValue = new List<List<int>>();
            Permute(nums, 0, returnValue);
            return returnValue.ToArray();
        }

        private void Permute(int[] nums, int start, List<List<int>> returnValue)
        {
            if (start == nums.Length - 1)
            {
                returnValue.Add(new List<int>(nums));
                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                // swap numbers Switch number at start with num
                Swap(nums, start, i);
                Permute(nums, start + 1, returnValue);
                // swap back switch back
                Swap(nums, start, i);
            }

        }

        public List<List<int>> PermuteUnique(int[] nums)
        {
            List<List<int>> lstResult = new List<List<int>>();
            Dictionary<List<int>, int> valuePairs = new Dictionary<List<int>, int>();
            PermuteUniqueSub(nums, lstResult, 0);
            return lstResult;
        }

        private void PermuteUniqueSub(int[] nums, List<List<int>> lstResult, int index)
        {
            if (index == nums.Length - 1)
            {
                lstResult.Add(new List<int>(nums));
            }
            Dictionary<int, int> used = new Dictionary<int, int>();
            for (int i = index; i < nums.Length; i++)
            {
                if (used.ContainsKey(nums[i])) continue;

                //combination
                Swap(nums, index,i);
                PermuteUniqueSub(nums, lstResult, index + 1);
                //Reverse it 
                Swap(nums, index, i);
                used.Add(nums[i], i);
            }

        }

        private int[] Swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
            return a;
        }
    }
}
