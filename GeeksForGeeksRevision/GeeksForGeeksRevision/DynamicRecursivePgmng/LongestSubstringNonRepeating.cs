using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    class LongestSubstringNonRepeatingCls
    {
        public int LongestSubstringNonRepeating(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int maxLength = 0;
            int length = 0;
            int indexStart = 0;

            for (int i = 0; i < s.Length; i++)
            {
                // Unique char found
                if (!dict.ContainsKey(s[i]) || dict[s[i]] < indexStart)
                {
                    length++;
                    dict[s[i]] = i;
                }
                // Non-unique char
                // move the start index to the next index of prev occured character index = dict[s[i]]+1;
                //length = i-index+1;
                //update the repeated character index to the current index dict[s[i]] =i;
                // second option use characters 256 https://www.geeksforgeeks.org/length-of-the-longest-substring-without-repeating-characters/
                else
                {
                    indexStart = dict[s[i]] + 1;
                    length = i - indexStart + 1;
                    dict[s[i]] = i;
                }

                ////to get substring 
                ///
                maxLength = Math.Max(maxLength, length);
            }
           
            return maxLength;
        }

       

        public string LargestNonRepeatingSubstr(string strLarg)
        {
            int startIndex = 0;
            int endIndex = 0;
            int maxLength = 0;
            int length = 0;

            Dictionary<char, int> visitedChars = new Dictionary<char, int>();
            string subStringNonRepeated = "";
            for (; endIndex < strLarg.Length; endIndex++)
            {
                if (!visitedChars.ContainsKey(strLarg[endIndex]))
                {
                    visitedChars.Add(strLarg[endIndex], endIndex);
                }
                else
                {
                    // startIndex = Math.Max(startIndex, visitedChars[strLarg[endIndex]] + 1);
                    startIndex = visitedChars[strLarg[endIndex]] + 1;
                    visitedChars[strLarg[endIndex]] = endIndex;
                    length = endIndex - startIndex + 1;                    
                }
                //if (subStringNonRepeated.Length < ((endIndex - startIndex + 1)))
                //{
                //    subStringNonRepeated = strLarg.Substring(startIndex, (endIndex - startIndex + 1));
                //}
                if(length>maxLength)
                {
                    maxLength = length;
                    subStringNonRepeated = strLarg.Substring(startIndex, maxLength);
                }
                //maxLength = Math.Max(length, maxLength);
            }
            return subStringNonRepeated;
        }

    }
}
