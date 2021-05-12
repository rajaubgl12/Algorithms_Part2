using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsArrayStrings.Amazon
{
    public class AllCombinationAlgs
    {
        private Dictionary<char, IList<char>> mapsNum = new Dictionary<char, IList<char>>()
        {
            {'2', new List<char>{ 'a','b','c'} },
            {'3', new List<char>{ 'd','e','f'} },
            {'4', new List<char>{ 'g','h','i'} },
            {'5', new List<char>{ 'j','k','i'} },
            {'6', new List<char>{ 'm','n','o'} },
            {'7', new List<char>{ 'p','q','r','s'} },
            {'8', new List<char>{ 't','u','v'} },
            {'9', new List<char>{ 'w','x','y','z'} },
        };

        /// <summary>
        /// https://www.geeksforgeeks.org/find-possible-words-phone-digits/
        /// https://www.youtube.com/watch?v=h6FmiyYDjmk
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            IList<string> result = new List<string>();
            if (string.IsNullOrWhiteSpace(digits))
                return result;
            HelperMethod(digits, 0, string.Empty, result);
            return result;
        }

        private void HelperMethod(string digits, int index, string temp, IList<string> result)
        {
            if (index == digits.Length)
            {
                result.Add(temp);
                return;
            }
            var charsList = mapsNum[digits[index]];

            for (int i = 0; i < charsList.Count; i++)
            {
                HelperMethod(digits, index + 1, temp + charsList[i], result);
            }
        }
    }
}
