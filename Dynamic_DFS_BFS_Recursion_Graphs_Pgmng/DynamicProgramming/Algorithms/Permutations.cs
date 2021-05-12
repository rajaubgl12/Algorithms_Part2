using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Algorithms
{
    class Permutations
    {
        /// <summary>
        /// ABC one method 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public void PermuteString1(string str)
        {
           GetPermutationStrings1("", str);
            
        }

        private void GetPermutationStrings1(string choose, string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine(choose);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    string before = str.Substring(0, i);
                    //remaining string after removing before.       
                    string after = i+1<str.Length? str.Substring(i + 1, str.Length-1-before.Length):"";

                    GetPermutationStrings1(choose+str[i], before + after);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
           /** 
    * permutation function 
    * @param str string to  
       calculate permutation for 
    * @param l starting index 
    * @param r end index 
    * Method 2
    * https://www.youtube.com/watch?v=AfxHGNRtFac
    */
        public void permute(String str,
                                    int l, int r)
        {
            if (l == r) // when there is no more string to permute then print it.
                Console.WriteLine(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    //choose
                    str = swap(str, l, i);
                    //explore
                    permute(str, l + 1, r);
                    //keep it back in original way.
                    str = swap(str, l, i); // back track , keep it in original way.
                }
            }
        }

        /** 
        * Swap Characters at position 
        * @param a string value 
        * @param i position 1 
        * @param j position 2 
        * @return swapped string 
        */
        private String swap(String a,
                                  int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }

    }
}
