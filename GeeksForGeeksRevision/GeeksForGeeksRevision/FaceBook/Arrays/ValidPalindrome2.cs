using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.FaceBook.Arrays
{

    /// <summary>
    /// /*
    /// *Given a non-empty string s, you may delete at most one character. 
    /// Judge whether you can make it a palindrome.
        /*
        Example 1:
        Input: "aba"
        Output: True
        Example 2:
        Input: "abca"
        Output: True
        Explanation: You could delete the character 'c'.
        Note:
        The string will only contain lowercase characters a-z.The maximum length of the string is 50000.
        
        Logic:
             1. Loop from left to right
             2. if two characters are not equal first skip right character and check
             3. all the characters if its not equal then skip left character and check all the characters.
             4.
        */
    /// */
    /// </summary>
   public class ValidPalindrome2
    {
        public bool IsValidPalindrome2(string s)
        {
            int startIndex = 0;
            int endIndex = s.Length - 1;
            while (startIndex < endIndex)
            {
                if (s[startIndex] == s[endIndex])
                {
                    startIndex++;
                    endIndex--;
                    continue;
                }
                else
                {
                    //skip right
                    int tempStartIndex = startIndex;
                    int tempEndIndex = endIndex - 1;
                    while (tempStartIndex < tempEndIndex)
                    {
                        if (s[tempEndIndex] != s[tempStartIndex])
                        {
                            break;
                        }
                        tempStartIndex++;
                        tempEndIndex--;
                        if (tempStartIndex >= tempEndIndex)
                            return true;
                    }

                    //skip left
                    startIndex++;
                    while (startIndex < endIndex)
                    {
                        if (s[startIndex] != s[endIndex])
                            return false;
                        startIndex++;
                        endIndex--;
                    }
                }
            }
            return true;
        }
    }
}
