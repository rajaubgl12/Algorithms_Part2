using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IK_Algorithms.Recursion
{

    /// <summary>
    /// https://leetcode.com/problems/palindrome-partitioning/solution/
    /// Input: "aab"
    //Output:
    //[
    //    ["aa","b"],
    //    ["a","a","b"]
    //]
    /// </summary>
    public class PalindromeSubsets
    {
        
        public IList<IList<string>> Partition(string s)
        {

            var result = new List<IList<string>>();
            //if (s == null || s.Length == 0) return result;

            //Helper(s, result, new List<string>(), 0);

            var result2 = new List<string>();
            //if (s == null || s.Length == 0) return result;

            HelperTrial(s, result2, string.Empty, 0);
            return result;
        }

        public string[] generate_palindromic_decompositions(string s)
        {
            var result2 = new List<string>();
            HelperTrial(s, result2, string.Empty, 0);

            return result2.ToArray();

        }

        private void HelperTrial(string s, List<string> result, string currPali, int startIndex)
        {
            //var partition = new List<string>(p);
            if (startIndex == s.Length)
            {
                result.Add(currPali);
                return;
            }
            for (var i = startIndex + 1; i < s.Length + 1; i++)
            {
                var sub = s.Substring(startIndex, i - startIndex);
                if (!IsPalindrome(sub)) continue;
                //currPali = string.IsNullOrWhiteSpace(currPali) ? sub : currPali + "|" + sub;
                if(string.IsNullOrWhiteSpace(currPali))
                {
                    HelperTrial(s, result, sub, i);
                }
                else
                {
                    HelperTrial(s, result, currPali + "|" + sub, i);
                }

                
            }
        }

        private void Helper(string s, List<IList<string>> result, List<string> p, int startIndex)
        {
            var partition = new List<string>(p);
            if (startIndex == s.Length)
            {
                result.Add(partition);
                return;
            }

            for (var i = startIndex; i < s.Length; i++)
            {
                var sub = s.Substring(startIndex, i - startIndex + 1);   // java's substring(startIndex, endIndex)      C#'s Substring(startIndex, SubLength)
                if (!IsPalindrome(sub)) continue;
                partition.Add(sub);
                Helper(s, result, partition, i + 1);
                partition.RemoveAt(partition.Count() - 1);       // Better to write as RemoveAt , but not Remove(x.Last()) cuz sometime it may remove the first element
            }

        }


        /// <summary>
        /// append string with , seperated
        /// </summary>
        /// <param name="s"></param>
        /// <param name="result"></param>
        /// <param name="currPali"></param>
        /// <param name="startIndex"></param>
        private void HelperTrial2(string s, List<string> result, string currPali, int startIndex)
        {
            //var partition = new List<string>(p);
            if (startIndex == s.Length)
            {
                result.Add(currPali);
                return;
            }
            for (var i = startIndex; i < s.Length; i++)
            {
                var sub = s.Substring(startIndex, i - startIndex + 1);   
                if (!IsPalindrome(sub)) continue;
                currPali=string.IsNullOrWhiteSpace(currPali)?sub: currPali+"|" + sub;
                HelperTrial(s, result, currPali, i + 1);             
            }
        }


        private bool IsPalindrome(string str)
        {
            for (int i = 0, j = str.Length - 1; i < j;)
            {
                if (str[i++] != str[j--]) return false;
            }
            return true;
        }
    }
}
