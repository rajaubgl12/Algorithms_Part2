using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision
{
    class Lc_FaceBk_BackTracking
    {
       

        /// <summary>
        /// https://www.youtube.com/watch?v=LdtQAYdYLcE
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsArrayInt(int[] nums)
        {
            //var result = new List<IList<int>>();
            //BackTrack(result, new List<int>(), nums, 0);
            //return result;
            var result = new List<IList<int>>();
            BacktrackSets(result, new List<int>(), nums, 0);
            return result;
        }

        private void BacktrackSets(List<IList<int>> subsets, List<int> currlist, int[] nums, int index)
        {
            subsets.Add(new List<int>(currlist));
            for (int i = index; i < nums.Length; i++)
            {
                currlist.Add(nums[i]);
                BacktrackSets(subsets, currlist, nums, i + 1);
                currlist.RemoveAt(currlist.Count - 1);
            }
        }

        #region phoneLetterCombination
        private IDictionary<char, IList<char>> dictChars = new Dictionary<char, IList<char>>()
        {
            { '2', new List<char>() {'a', 'b', 'c'} },
            { '3', new List<char>() {'d', 'e', 'f'} },
            { '4', new List<char>() {'g', 'h', 'i'} },
            { '5', new List<char>() {'j', 'k', 'l'} },
            { '6', new List<char>() {'m', 'n', 'o'} },
            { '7', new List<char>() {'p', 'q', 'r', 's'} },
            { '8', new List<char>() {'t', 'u', 'v'} },
            { '9', new List<char>() {'w', 'x', 'y', 'z'} },
        };

        public IList<string> LetterCombinations(string digits)
        {
            int index = 0;
            List<string> strResult = new List<string>();
            if (string.IsNullOrEmpty(digits))
                return strResult;
            HelperLetterCombination(digits,index,string.Empty,strResult);
            return strResult;
        }

        private void HelperLetterCombination(string digits, int index, string letterComb, List<string> strResult)
        {
            if(digits.Length==index)
            {
                strResult.Add(letterComb);
                return;
            }
            var chars = dictChars[digits[index]];
            for(int i=0;i<chars.Count;i++)
            {
                HelperLetterCombination(digits, index + 1, chars[i] + letterComb, strResult);
            }
        }
        #endregion

        
       
        
    }
}
